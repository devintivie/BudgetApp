using BudgetApp.Models;
using IvieBaseClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.ViewModels
{
    public class NextBillDueDataViewModel : LocalBaseViewModel
    {
        public ObservableCollection<Bill> Bills { get; set; }
        public BillTracker BillTracker { get; private set; }

        public string CompanyName
        {
            get { return BillTracker.CompanyName; }
            set
            {
                if (BillTracker.CompanyName != value)
                {
                    BillTracker.CompanyName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private double nextAmountDue;
        public double NextAmountDue
        {
            get { return nextAmountDue; }
            set
            {
                if (nextAmountDue != value)
                {
                    nextAmountDue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string NextDueDateString
        {
            get
            {
                if (NextDueDate.CompareTo(DateTime.Today) < 0)
                {
                    return "None Due";
                }
                else
                {
                    return NextDueDate.ToShortDateString();
                }
            }
        }
            
        private DateTime nextDueDate;
        public DateTime NextDueDate
        {
            get { return nextDueDate; }
            set
            {
                if (nextDueDate != value)
                {
                    nextDueDate = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged(nameof(NextDueDateString));
                }
            }
        }

        public NextBillDueDataViewModel()
        {
            Bills = new ObservableCollection<Bill>();
            BillTracker = new BillTracker();
            UpdateBills();
            UpdateNextBill();
        }

        public NextBillDueDataViewModel(BillTracker bt)
        {
            Bills = new ObservableCollection<Bill>();
            BillTracker = bt;
            UpdateBills();
            UpdateNextBill();
        }

        public void UpdateBills()
        {
            BillTracker.Bills.Sort();
            Bills.Clear();
            foreach (var b in BillTracker.Bills)
            {
                Bills.Add(b);
            }
        }

        public void UpdateNextBill()
        {
            bool found = false;
            foreach (var d in Bills)
            {
                if (d.DueDate.CompareTo(DateTime.Today) >= 0)
                {
                    NextAmountDue = d.AmountDue;
                    NextDueDate = d.DueDate;
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                NextAmountDue = 0;
                NextDueDate = default(DateTime);
                
            }
        }

        //public bool BillDueDateUsed(DateTime iDueDate)
        //{
        //    foreach (var b in Bills)
        //    {
        //        if (b.DueDate.Equals(iDueDate))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
