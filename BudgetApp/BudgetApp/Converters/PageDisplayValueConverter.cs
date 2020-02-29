using BudgetApp.Models;
using BudgetApp.Pages;
using IvieConverters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp
{
    public class PageDisplayValueConverter : BaseValueConverter<PageDisplayValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((Navigation)value)
            {
                case Navigation.Calendar:
                    return new BudgetCalendarControl();
                    //break;
                case Navigation.BillList:
                    return new BillListControl();
                    //break;
                default:
                    return new BudgetCalendarControl();
                    //break;
            }

        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
