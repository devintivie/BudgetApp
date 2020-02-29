using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace BudgetApp
{
    [ContentProperty("Actions")]
    public class ConditionalEventTrigger : FrameworkContentElement
    {
        static readonly RoutedEvent DummyEvent = EventManager.RegisterRoutedEvent(
            "", RoutingStrategy.Direct, typeof(EventHandler), typeof(ConditionalEventTrigger));

        public static readonly DependencyProperty TriggersProperty = DependencyProperty.RegisterAttached(
            "Triggers", typeof(ConditionalEventTriggers), typeof(ConditionalEventTrigger),
            new FrameworkPropertyMetadata(RefreshTriggers));

        public static readonly DependencyProperty ConditionProperty = DependencyProperty.Register(
            "Condition", typeof(bool), typeof(ConditionalEventTrigger)); // the Condition is evaluated whenever an event fires

        public ConditionalEventTrigger()
        {
            Actions = new List<TriggerAction>();
        }

        public static ConditionalEventTriggers GetTriggers(DependencyObject obj)
        { return (ConditionalEventTriggers)obj.GetValue(TriggersProperty); }

        public static void SetTriggers(DependencyObject obj, ConditionalEventTriggers value)
        { obj.SetValue(TriggersProperty, value); }

        public bool Condition
        {
            get { return (bool)GetValue(ConditionProperty); }
            set { SetValue(ConditionProperty, value); }
        }

        public RoutedEvent RoutedEvent { get; set; }
        public List<TriggerAction> Actions { get; set; }

        // --- impl ----

        // we can't actually fire triggers because WPF won't let us (stupid sealed internal methods)
        // so, for each trigger, make a dummy trigger (on a dummy event) with the same actions as the real trigger,
        // then attach handlers for the dummy event
        public static void RefreshTriggers(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var targetObj = (FrameworkElement)obj;
            // start by clearing away the old triggers
            foreach (var t in targetObj.Triggers.OfType<DummyEventTrigger>().ToArray())
                targetObj.Triggers.Remove(t);

            // create and add dummy triggers
            foreach (var t in ConditionalEventTrigger.GetTriggers(targetObj))
            {
                t.DataContext = targetObj.DataContext; // set and Track DataContext so binding works
                                                       // targetObj.GetDataContextChanged().WeakSubscribe(dc => t.DataContext = targetObj.DataContext);

                var dummyTrigger = new DummyEventTrigger { RoutedEvent = DummyEvent };
                foreach (var action in t.Actions)
                    dummyTrigger.Actions.Add(action);

                targetObj.Triggers.Add(dummyTrigger);
                targetObj.AddHandler(t.RoutedEvent, new RoutedEventHandler((o, args) => {
                    if (t.Condition) // evaluate condition when the event gets fired
                        targetObj.RaiseEvent(new RoutedEventArgs(DummyEvent));
                }));
            }
        }

        class DummyEventTrigger : EventTrigger { }
    }

    public class ConditionalEventTriggers : List<ConditionalEventTrigger> { }
}
