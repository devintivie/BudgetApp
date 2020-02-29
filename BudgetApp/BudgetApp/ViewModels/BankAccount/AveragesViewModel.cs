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

        private int selectedYear = DateTime.Now.Year;
        public int SelectedYear
        {
            get { return selectedYear; }
            set
            {
                if (selectedYear != value)
                {
                    selectedYear = value;
                    UpdateAverages();
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
            UpdateAverages();
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

        private void UpdateAverages()
        {
            UpdateMonthlyAverage();
            UpdatePaycheckAverage();
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

            var tempSum = 0.0;
            var tempCount = 0;
            foreach(var amount in monthlyTotals)
            {
                if(amount > 0)
                {
                    tempCount++;
                    tempSum += amount;
                }
            }

            MonthlyAverage = tempSum / tempCount;// monthlyTotals.Average();
        }

        public void UpdatePaycheckAverage()
        {
            var paycheckTotals = Enumerable.Repeat(0.0, 26).ToArray();
            var payDates = new DateTime[26];
            Console.WriteLine(selectedYear);
            var firstPaydate = new DateTime(SelectedYear, 1, 1);

            for(int i = 0; i < 26; i++)
            {
                if(i == 0)
                {
                    payDates[i] = firstPaydate;
                }
                else
                {
                    payDates[i] = payDates[i - 1].AddDays(14);
                }
            }
            foreach( var item in BillTrackerManager.AllTrackers)
            {
                foreach(var bill in item.Bills)
                {
                    if (bill.DueDate.Year == SelectedYear)
                    {
                        var daysSinceFirst = (int)(bill.DueDate - firstPaydate).TotalDays;
                        var insertIndex = daysSinceFirst / 14;
                        if (insertIndex < 26)
                        {
                            paycheckTotals[insertIndex] = paycheckTotals[insertIndex] + bill.AmountDue;
                        }
                    }
                   
                }
            }

            var tempSum = 0.0;
            var tempCount = 0;
            foreach (var amount in paycheckTotals)
            {
                if (amount > 0)
                {
                    tempCount++;
                    tempSum += amount;
                }
            }

            PaycheckAverage = tempSum / tempCount;// monthlyTotals.Average();



        }




    }
}
