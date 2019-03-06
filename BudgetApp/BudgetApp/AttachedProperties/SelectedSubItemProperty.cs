using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Controls;
using System.Collections;
using System.Collections.ObjectModel;

namespace BudgetApp
{
    public class ListBoxHelper
    {
        #region SelectedItems  

        ///  
        /// SelectedItems Attached Dependency Property  
        ///  
        public static readonly DependencyProperty SelectedItemsProperty =
           DependencyProperty.RegisterAttached("SelectedItems", typeof(IList),
                              typeof(ListBoxHelper),
                              new FrameworkPropertyMetadata((IList)null,
                                           new PropertyChangedCallback(OnSelectedItemsChanged)));

        /// <summary>  
        /// Gets the SelectedItems property.  
        /// </summary>  
        /// <param name="d"></param>  
        /// <returns></returns>  
        public static IList GetSelectedItems(DependencyObject d)
        {
            return (IList)d.GetValue(SelectedItemsProperty);
        }

        /// <summary>  
        /// Sets the SelectedItems property.  
        /// </summary>  
        /// <param name="d"></param>  
        /// <param name="value"></param>  
        public static void SetSelectedItems(DependencyObject d, IList value)
        {
            d.SetValue(SelectedItemsProperty, value);
        }

        /// <summary>  
        /// Called when SelectedItems is set  
        /// </summary>  
        /// <param name="d"></param>  
        /// <param name="e"></param>  
        private static void OnSelectedItemsChanged(DependencyObject d,
                                                 DependencyPropertyChangedEventArgs e)
        {
            var listBox = (ListBox)d;
            SetInternalSelectedItemsToPublic(listBox);
            IList selectedItems = GetSelectedItems(listBox);

            if (selectedItems is ObservableCollection<object>)
            {
                // if the list is a observable collection binde to the changed event 
                // to update the internal collection
                (selectedItems as ObservableCollection<object>).CollectionChanged += delegate
                {
                    SetSelectedDataItemsToInternal(listBox);
                };
            }

            listBox.SelectionChanged += delegate
            {
                SetInternalSelectedItemsToPublic(listBox);
            };
        }


        #region Implementation  

        static bool _isChanging;

        private static void SetSelectedDataItemsToInternal(ListBox listBox)
        {
            if (_isChanging)
                return;

            _isChanging = true;

            var selectedDataItems = GetSelectedItems(listBox);

            if (listBox.SelectedItems != null)
            {
                listBox.SelectedItems.Clear();

                if (selectedDataItems == null)
                {
                    _isChanging = false;
                    return;
                }

                foreach (var item in selectedDataItems)
                    listBox.SelectedItems.Add(item);
            }

            _isChanging = false;
        }

        private static void SetInternalSelectedItemsToPublic(ListBox listBox)
        {
            if (_isChanging)
                return;

            _isChanging = true;

            var selectedDataItems = GetSelectedItems(listBox);

            if (selectedDataItems == null)
            {
                // the bound data type is not of typ IList / IList<object> / 
                // IEnumerable / Ienumerable<object>  
                // in this case the bound property has to be initialized first by the caller  
                _isChanging = false;
                return;
            }

            selectedDataItems.Clear();

            if (listBox.SelectedItems != null)
            {
                foreach (var item in listBox.SelectedItems)
                    selectedDataItems.Add(item);
            }

            _isChanging = false;
        }

        #endregion

        #endregion
    }

    /*
    public class SelectedSubItemProperty
    {
        public static readonly DependencyProperty SelectedSubItem = DependencyProperty.RegisterAttached(
           "SelectedSubItem",
           typeof(IList),
           typeof(SelectedSubItemProperty),
           new FrameworkPropertyMetadata((IList)null, new PropertyChangedCallback(OnSelectedItemsChanged))
           );

        private static void OnSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var listBox = (ListBox)d;
            SetInternalSelectedItemsToPublic(listBox);
            IList selectedItems = GetSelectedItems(listBox);

            if(selectedItems is ObservableCollection<object>)
            {
                (selectedItems as ObservableCollection<object>).CollectionChanged += delegate { SetSelectedDataItemsToInternal(listBox); };
            }
            listBox.SelectionChanged += delegate { SetInternalSelectedItemsToPublic(listBox); };
        }

        static bool _isChanging;

        private static void SetSelectedDataItemsToInternal(ListBox listBox)
        {
            if (_isChanging)
                return;

            _isChanging = true;

            var selectedDataItems = GetSelectedItems(listBox);

            if (listBox.SelectedItems != null)
            {
                listBox.SelectedItems.Clear();

                if (selectedDataItems == null)
                {
                    _isChanging = false;
                    return;
                }

                foreach (var item in selectedDataItems)
                    listBox.SelectedItems.Add(item);
            }

            _isChanging = false;
        }

        private static IList GetSelectedItems(ListBox listBox)
        {
            throw new NotImplementedException();
        }

        private static void SetInternalSelectedItemsToPublic(ListBox listBox)
        {
            if (_isChanging)
                return;

            _isChanging = true;

            var selectedDataItems = GetSelectedItems(listBox);

            if (selectedDataItems == null)
            {
                // the bound data type is not of typ IList / IList<object> / 
                // IEnumerable / Ienumerable<object>  
                // in this case the bound property has to be initialized first by the caller  
                _isChanging = false;
                return;
            }

            selectedDataItems.Clear();

            if (listBox.SelectedItems != null)
            {
                foreach (var item in listBox.SelectedItems)
                    selectedDataItems.Add(item);
            }

            _isChanging = false;
        }

        /// <summary>  
        /// Gets the SelectedItems property.  
        /// </summary>  
        /// <param name="d"></param>  
        /// <returns></returns>  
        public static IList GetSelectedItems(DependencyObject d)
        {
            return (IList)d.GetValue(SelectedSubItem);
        }

        /// <summary>  
        /// Sets the SelectedItems property.  
        /// </summary>  
        /// <param name="d"></param>  
        /// <param name="value"></param>  
        public static void SetSelectedItems(DependencyObject d, IList value)
        {
            d.SetValue(SelectedSubItem, value);
        }













    }
    */
}
