using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Controls;

namespace BudgetApp
{
    public class SelectorRightClickCommandBehavior
    {
        public static readonly DependencyProperty HandleRightClickProperty = 
            DependencyProperty.RegisterAttached(
                "HandleRightClick",
                typeof(bool),
                typeof(SelectorRightClickCommandBehavior),
                new FrameworkPropertyMetadata(false, new PropertyChangedCallback(OnHandleRightClickedChanged)));

        public static bool GetHandleRightClick(DependencyObject d)
        {
            return (bool)d.GetValue(HandleRightClickProperty);
        }

        public static void SetHandleRightClick(DependencyObject d, bool value)
        {
            d.SetValue(HandleRightClickProperty, value);
        }

        private static void OnHandleRightClickedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Selector selector = d as Selector;

            if(selector != null)
            {
                if ((bool)e.NewValue)
                {

                    selector.MouseRightButtonDown -= OnMouseRightClick;

                    selector.MouseRightButtonDown += OnMouseRightClick;
                }
            }
        }

        public static readonly DependencyProperty RightClickCommand = DependencyProperty.RegisterAttached(
            "RightClickCommand",
            typeof(ICommand),
            typeof(SelectorRightClickCommandBehavior),
            new FrameworkPropertyMetadata((ICommand)null)
            );

        public static ICommand GetRightClickCommand(DependencyObject d)
        {
            return (ICommand)d.GetValue(RightClickCommand);
        }

        public static void SetRightClickCommand(DependencyObject d, ICommand value)
        {
            d.SetValue(RightClickCommand, value);
        }
        
        private static void OnMouseRightClick(object sender, MouseButtonEventArgs e)
        {
            ItemsControl listView = sender as ItemsControl;

            DependencyObject originalSender = e.OriginalSource as DependencyObject;
            if (listView == null || originalSender == null)
                return;

            DependencyObject container = ItemsControl.ContainerFromElement(sender as ItemsControl, e.OriginalSource as DependencyObject);

            if (container == null || container == DependencyProperty.UnsetValue)
                return;

            object activatedItem = listView.ItemContainerGenerator.ItemFromContainer(container);

            if(activatedItem != null)
            {
                ICommand command = (ICommand)(sender as DependencyObject).GetValue(RightClickCommand);
                if(command != null)
                {
                    if (command.CanExecute(null))
                        command.Execute(null);
                }
            }

            e.Handled = false;

        }
    }
}
