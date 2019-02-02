﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Controls;

namespace BudgetApp
{
    public class SelectorDoubleClickCommandBehavior
    {
        public static readonly DependencyProperty HandleDoubleClickProperty = DependencyProperty.RegisterAttached(
            "HandleDoubleClick",
            typeof(bool),
            typeof(SelectorDoubleClickCommandBehavior),
            new FrameworkPropertyMetadata(false, new PropertyChangedCallback(OnHandleDoubleClickedChanged)));

        public static bool GetHandleDoubleClick(DependencyObject d)
        {
            return (bool)d.GetValue(HandleDoubleClickProperty);
        }

        public static void SetHandleDoubleClick(DependencyObject d, bool value)
        {
            d.SetValue(HandleDoubleClickProperty, value);
        }



        private static void OnHandleDoubleClickedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Selector selector = d as Selector;

            if(selector != null)
            {
                if ((bool)e.NewValue)
                {
                    selector.MouseDoubleClick -= OnMouseDoubleClick;

                    selector.MouseDoubleClick += OnMouseDoubleClick;
                }
            }
        }

        public static readonly DependencyProperty TheCommandToRunProperty = DependencyProperty.RegisterAttached(
            "TheCommandToRun",
            typeof(ICommand),
            typeof(SelectorDoubleClickCommandBehavior),
            new FrameworkPropertyMetadata((ICommand)null)
            );

        public static ICommand GetTheCommandToRun(DependencyObject d)
        {
            return (ICommand)d.GetValue(TheCommandToRunProperty);
        }

        public static void SetTheCommandToRun(DependencyObject d, ICommand value)
        {
            d.SetValue(TheCommandToRunProperty, value);
        }
        
        private static void OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
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
                ICommand command = (ICommand)(sender as DependencyObject).GetValue(TheCommandToRunProperty);
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
