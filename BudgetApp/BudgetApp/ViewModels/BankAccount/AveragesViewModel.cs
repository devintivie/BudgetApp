using BudgetApp.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.ViewModels
{
    public class AveragesViewModel : LocalBaseViewModel
    {
        private ObservableCollection<int> years = new ObservableCollection<int>();
        public ObservableCollection<int> Years
        {
            get { return years; }
            set
            {
                if (years != value)
                {
                    years = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int selectedYear;
        public int SelectedYear
        {
            get { return selectedYear; }
            set
            {
                if (selectedYear != value)
                {
                    selectedYear = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private double monthlyAverage;
        public double MonthlyAverage
        {
            get { return monthlyAverage; }
            set
            {
                if (monthlyAverage != value)
                {
                    monthlyAverage = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private double paycheckAverage;
        public double PaycheckAverage
        {
            get { return paycheckAverage; }
            set
            {
                if (paycheckAverage != value)
                {
                    paycheckAverage = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private DateTime firstPayday;
        public DateTime FirstPayday
        {
            get { return firstPayday; }
            set
            {
                if (firstPayday != value)
                {
                    firstPayday = value;
                    NotifyPropertyChanged();
                }
            }
        }



        private string test = "yep";
        public string Test
        {
            get { return test; }
            set
            {
                if (test != value)
                {
                    test = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public AveragesViewModel()
        {
            UpdateAvailableYears();
            UpdateMonthlyAverage();
            UpdatePaycheckAverage();
        }

        public void UpdateAvailableYears()
        {
            Years = new ObservableCollection<int>(MoneyMathHelper.SelectableYears());
            var prefYear = DateTime.Now.Year;
            if(Years.Count > 0)
            {
                if (Years.Contains(prefYear))
                {
                    SelectedYear = prefYear;
                }
                else
                {
                    SelectedYear = years.Last();
                }
            }
        }

        public void UpdateMonthlyAverage()
        {
            var monthlyTotals = Enumerable.Repeat(0.0, 12).ToArray();
            foreach(var item in BillTrackerManager.AllTrackers)
            {
                foreach(var bill in item.Bills)
                {
                    if(bill.DueDate.Year == SelectedYear)
                    {
                        monthlyTotals[bill.DueDate.Month-1] = monthlyTotals[bill.DueDate.Month-1] + bill.AmountDue;
                    }
                }
            }

            MonthlyAverage = monthlyTotals.Average();
        }

        public void UpdatePaycheckAverage()
        {

        }




    }
}
