using BudgetApp.Models;
using IvieBaseClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BudgetApp.ViewModels
{
    public class BillTrackerDataViewModel : LocalBaseViewModel
    {

        public ObservableCollection<Bill> Bills { get; set; }
        private readonly DateTime firstPaydate;

        private string companyName;
        public string CompanyName
        {
            get { return companyName; }
            set
            {
                if (companyName != value)
                {
                    companyName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int billsDue;
        public int BillsDue
        {
            get { return billsDue; }
            set
            {
                if (billsDue != value)
                {
                    billsDue = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged(nameof(BillsDueText));
                }
            }
        }

        public string BillsDueText
        {
            get { return $"{BillsDue} bills due this paycheck"; }
        }

        //public System.Windows.Media.Brush Background
        //{
        //    get
        //    {
        //        if()
        //    }
        //}



        private string nextBill;
        public string NextBill
        {
            get { return nextBill; }
            set
            {
                if (nextBill != value)
                {
                    nextBill = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ICommand TestCommand { get; set; }

        public BillTracker BillTracker { get; private set; }

        public BillTrackerDataViewModel(BillTracker bt, DateTime firstPaycheck)
        {
            Bills = new ObservableCollection<Bill>();
            BillTracker = bt;
            firstPaydate = firstPaycheck;
            UpdateBills();
            UpdateNextBill();
            CompanyName = bt.CompanyName;
            //TestCommand = new DelegateCommand(OnTest, CanTest);
        }

        public void UpdateBills()
        {
            BillTracker.Bills.Sort();
            Bills.Clear();
            var upcoming = 0;
            foreach (var b in BillTracker.Bills)
            {
                Bills.Add(b);
                var npd = BudgetCalculators.FindNextPaycheck(firstPaydate);
                if( (b.DueDate.CompareTo(DateTime.Now) > 0) && (b.DueDate.CompareTo(npd) < 0)  )
                {
                    upcoming++;
                }
            }
            BillsDue = upcoming;
        }

        public void UpdateNextBill()
        {
            var tempString = "None Due";
            foreach (var d in Bills)
            {
                if (d.DueDate.CompareTo(DateTime.Today) > 0)
                {
                    tempString = d.ToString();
                    break;
                }
            }

            NextBill = tempString;

        }

        public bool BillDueDateUsed(DateTime iDueDate)
        {
            foreach (var b in Bills)
            {
                if (b.DueDate.Equals(iDueDate))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
