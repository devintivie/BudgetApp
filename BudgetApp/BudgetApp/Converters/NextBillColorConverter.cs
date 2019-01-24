using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BudgetApp
{
    class NextBillColorConverter : IvieConverters.BaseValueConverter<NextBillColorConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((BillStatus)value)
            {
                case BillStatus.Paid:
                    return Brushes.LightGreen;
                case BillStatus.PastDue:
                    return Brushes.Red;
                case BillStatus.DueToday:
                    return Brushes.Red;
                case BillStatus.DueTomorrow:
                    return Brushes.Red;
                case BillStatus.DueWithinTwoWeeks:
                    return Brushes.Orange;
                case BillStatus.DueWithinOneMonth:
                    return Brushes.Yellow;
                case BillStatus.DueInOverOneMonth:
                    return Brushes.Transparent;
                case BillStatus.NoneDue:
                    return Brushes.LightGreen;
                default:
                    return Brushes.Transparent;
            }
             //if( ((DateTime)value).CompareTo(DateTime.Today) < 0)
             //{
            
            //}
            //else
            //{
            //    return Brushes.Blue;
            //}
            //return Brushes.Orange;

            //if (parameter == null)
            //{
            //    return (bool)value ? Visibility.Visible : Visibility.Hidden;
            //}
            //else if ((string)parameter == "Invert")
            //{
            //    return (bool)value ? Visibility.Hidden : Visibility.Visible;
            //    //return (bool)value ? Visibility.Visible : Visibility.Hidden;
            //}
            //else if ((string)parameter == "Collapse")
            //{
            //    return (bool)value ? Visibility.Visible : Visibility.Collapsed;
            //    //return (bool)value ? Visibility.Visible : Visibility.Hidden;
            //}
            //else
            //{
            //    return (bool)value ? Visibility.Visible : Visibility.Collapsed;
            //    //return (bool)value ? Visibility.Visible : Visibility.Hidden;
            //}
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
