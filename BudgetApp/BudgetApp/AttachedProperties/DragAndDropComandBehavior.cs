using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media;
using BudgetApp.ViewModels;

namespace BudgetApp
{
    public class DragAndDropComandBehavior
    {
        #region Fields
        private static Point startPoint = new Point();
        //private ObservableCollection<WorkItem> Items = new ObservableCollection<WorkItem>();
        //private static int startIndex = -1;
        #endregion


        #region CanHandleDrag
        public static readonly DependencyProperty HandleDragProperty = DependencyProperty.RegisterAttached(
            "HandleDragClick",
            typeof(bool),
            typeof(DragAndDropComandBehavior),
            new FrameworkPropertyMetadata(false, new PropertyChangedCallback(OnHandleDragChanged)));

        public static bool GetHandleDrag(DependencyObject d)
        {
            return (bool)d.GetValue(HandleDragProperty);
        }

        public static void SetHandleDrag(DependencyObject d, bool value)
        {
            d.SetValue(HandleDragProperty, value);
        }

        private static void OnHandleDragChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Selector selector = d as Selector;

            selector.AllowDrop = true;
            selector.MouseDown += Selector_MouseDown;
            selector.DragEnter += Selector_DragEnter;
            selector.MouseMove += Selector_MouseMove;
        }

        private static void Selector_MouseMove(object sender, MouseEventArgs e)
        {
            Console.WriteLine("mouse move");

            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                       Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                //Console.WriteLine("Dragging");
                //ListViewItem listViewItem = FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);

                //var item = (LocalBaseViewModel)listvi
                //DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Copy | DragDropEffects.Move);

                // Get the dragged ListViewItem
                ListView listView = sender as ListView;
                ListViewItem listViewItem = FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);
                if (listViewItem == null) return;           // Abort
                                                            // Find the data behind the ListViewItem
                var item = (LocalBaseViewModel)listView.ItemContainerGenerator.ItemFromContainer(listViewItem);
                if (item == null) return;                   // Abort
                                                            // Initialize the drag & drop operation
                //startIndex = lstView.SelectedIndex;
                //DataObject dragData = new DataObject("WorkItem", item);
                //DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Copy | DragDropEffects.Move);

            }

            


        }

        private static void Selector_DragEnter(object sender, DragEventArgs e)
        {
            Console.WriteLine("drag enter");
        }

        private static void Selector_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ItemsControl listview = sender as ItemsControl;
            Console.WriteLine("mouse down drag and drop");
            //    ItemsControl listView = sender as ItemsControl;
            //    DependencyObject originalSender = e.OriginalSource as DependencyObject;
            //    if (listView == null || originalSender == null)
            //        return;

            //    DependencyObject container = ItemsControl.ContainerFromElement(sender as ItemsControl, e.OriginalSource as DependencyObject);

            //    if (container == null || container == DependencyProperty.UnsetValue)
            //        return;

            //    object activatedItem = listView.ItemContainerGenerator.ItemFromContainer(container);

            //    if(activatedItem != null)
            //    {
            //        ICommand command = (ICommand)(sender as DependencyObject).GetValue(DoubleClickCommand);
            //        if(command != null)
            //        {
            //            if (command.CanExecute(null))
            //                command.Execute(null);
            //        }
            //    }

            //    e.Handled = false;
        }
        #endregion

        // Helper to search up the VisualTree
        private static T FindAncestor<T>(DependencyObject current)
            where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }


        //public static readonly DependencyProperty HandleDoubleClickProperty = DependencyProperty.RegisterAttached(
        //    "HandleDoubleClick",
        //    typeof(bool),
        //    typeof(SelectorDoubleClickCommandBehavior),
        //    new FrameworkPropertyMetadata(false, new PropertyChangedCallback(OnHandleDoubleClickedChanged)));

        //public static bool GetHandleDoubleClick(DependencyObject d)
        //{
        //    return (bool)d.GetValue(HandleDoubleClickProperty);
        //}

        //public static void SetHandleDoubleClick(DependencyObject d, bool value)
        //{
        //    d.SetValue(HandleDoubleClickProperty, value);
        //}

        //private static void OnHandleDoubleClickedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    Selector selector = d as Selector;

        //    if(selector != null)
        //    {
        //        if ((bool)e.NewValue)
        //        {
        //            selector.MouseDoubleClick -= OnMouseDoubleClick;

        //            selector.MouseDoubleClick += OnMouseDoubleClick;
        //        }
        //    }
        //}

        //public static readonly DependencyProperty DoubleClickCommand = DependencyProperty.RegisterAttached(
        //    "DoubleClickCommand",
        //    typeof(ICommand),
        //    typeof(SelectorDoubleClickCommandBehavior),
        //    new FrameworkPropertyMetadata((ICommand)null)
        //    );

        //public static ICommand GetDoubleClickCommand(DependencyObject d)
        //{
        //    return (ICommand)d.GetValue(DoubleClickCommand);
        //}

        //public static void SetDoubleClickCommand(DependencyObject d, ICommand value)
        //{
        //    d.SetValue(DoubleClickCommand, value);
        //}

        //private static void OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    ItemsControl listView = sender as ItemsControl;
        //    DependencyObject originalSender = e.OriginalSource as DependencyObject;
        //    if (listView == null || originalSender == null)
        //        return;

        //    DependencyObject container = ItemsControl.ContainerFromElement(sender as ItemsControl, e.OriginalSource as DependencyObject);

        //    if (container == null || container == DependencyProperty.UnsetValue)
        //        return;

        //    object activatedItem = listView.ItemContainerGenerator.ItemFromContainer(container);

        //    if(activatedItem != null)
        //    {
        //        ICommand command = (ICommand)(sender as DependencyObject).GetValue(DoubleClickCommand);
        //        if(command != null)
        //        {
        //            if (command.CanExecute(null))
        //                command.Execute(null);
        //        }
        //    }

        //    e.Handled = false;

        //}
    }
}
