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

        private bool showAmountDue = true;
        public bool ShowAmountDue
        {
            get { return showAmountDue; }
            set
            {
                if (showAmountDue != value)
                {
                    showAmountDue = value;
                    NotifyPropertyChanged();
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

        private BillStatus nextBillStatus;
        public BillStatus NextBillStatus
        {
            get { return nextBillStatus; }
            set
            {
                if (nextBillStatus != value)
                {
                    nextBillStatus = value;
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
            BillStatus bs = BillStatus.Paid;
            foreach (var d in Bills)
            {
                if(d.BillStatus == BillStatus.PastDue) { bs = BillStatus.PastDue; }
                if (d.DueDate.CompareTo(DateTime.Today) >= 0)
                {
                    ShowAmountDue = true;
                    NextAmountDue = d.AmountDue;
                    NextDueDate = d.DueDate;
                    if(bs == BillStatus.PastDue)
                    {
                        NextBillStatus = bs;
                    }
                    else
                    {
                        NextBillStatus = d.BillStatus;
                    }
                    
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                ShowAmountDue = false;
                NextBillStatus = BillStatus.DueInOverOneMonth;
                
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
