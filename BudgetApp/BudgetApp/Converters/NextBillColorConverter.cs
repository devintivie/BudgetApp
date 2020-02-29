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
                case BillStatus.AutoPay:
                    return Brushes.DarkBlue;
                default:
                    return Brushes.White;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
