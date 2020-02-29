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
    public class MultiplePaycheckViewModel : NextBillDueDataViewModel
    {
        private double prevAmountDue;
        public double PrevAmountDue
        {
            get { return prevAmountDue; }
            set
            {
                if (prevAmountDue != value)
                {
                    prevAmountDue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private double currAmountDue;
        public double CurrAmountDue
        {
            get { return currAmountDue; }
            set
            {
                if (currAmountDue != value)
                {
                    currAmountDue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private DateTime prevPaydate;
        public DateTime PrevPaydate
        {
            get { return prevPaydate; }
            set
            {
                if (prevPaydate != value)
                {
                    prevPaydate = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private DateTime currPaydate;
        public DateTime CurrPaydate
        {
            get { return currPaydate; }
            set
            {
                if (currPaydate != value)
                {
                    currPaydate = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private DateTime nextPaydate;
        public DateTime NextPaydate
        {
            get { return nextPaydate; }
            set
            {
                if (nextPaydate != value)
                {
                    nextPaydate = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private BillStatus prevBillStatus;
        public BillStatus PrevBillStatus
        {
            get { return prevBillStatus; }
            set
            {
                if (prevBillStatus != value)
                {
                    prevBillStatus = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private BillStatus currBillStatus;
        public BillStatus CurrBillStatus
        {
            get { return currBillStatus; }
            set
            {
                if (currBillStatus != value)
                {
                    currBillStatus = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public MultiplePaycheckViewModel() : base()
        {
        }

        public MultiplePaycheckViewModel(BillTracker bt) : base(bt)
        {
            UpdateBillDisplay();
        }

        public MultiplePaycheckViewModel(BillTracker bt, DateTime prev, DateTime current, DateTime next) : base(bt)
        {
            CurrPaydate = current;
            PrevPaydate = prev;
            NextPaydate = next;
            UpdateBillDisplay();
        }


        public void UpdateBillDisplay()
        {
            BillTracker.Bills.Sort();
            PrevAmountDue = 0;
            CurrAmountDue = 0;
            NextAmountDue = 0;

            PrevBillStatus = BillStatus.NoneDue;
            CurrBillStatus = BillStatus.NoneDue;
            NextBillStatus = BillStatus.NoneDue;

            var endcompare = NextPaydate.Add(new TimeSpan(14,0,0,0));

            foreach(var b in BillTracker.Bills)
            {
                if( (b.DueDate.CompareTo(PrevPaydate) >= 0) && (b.DueDate.CompareTo(CurrPaydate) < 0) )
                {
                    PrevAmountDue += b.AmountDue;
                    PrevBillStatus = b.BillStatus;
                    
                }
                else if ((b.DueDate.CompareTo(CurrPaydate) >= 0) && (b.DueDate.CompareTo(NextPaydate) < 0) )
                {
                    CurrAmountDue += b.AmountDue;
                    CurrBillStatus = b.BillStatus;
                }
                else if ((b.DueDate.CompareTo(NextPaydate) >= 0) && (b.DueDate.CompareTo(endcompare) < 0) )
                {
                    NextAmountDue += b.AmountDue;
                    NextBillStatus = b.BillStatus;
                }
            }


        }



    }
}
