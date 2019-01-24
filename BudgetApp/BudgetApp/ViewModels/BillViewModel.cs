using BudgetApp.Models;
using IvieBaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BudgetApp.ViewModels
{
    public class BillViewModel : LocalBaseViewModel
    {
        public Bill Bill { get; set; }

        public DateTime DueDate
        {
            get { return Bill.DueDate; }
            set
            {
                if (Bill.DueDate != value)
                {
                    Bill.DueDate = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged(nameof(BillStatus));
                }
            }
        }

        public BillStatus BillStatus
        {
            get { return Bill.BillStatus; }
            set
            {
                if(Bill.BillStatus != value)
                {
                    Bill.BillStatus = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public double AmountDue
        {
            get { return Bill.AmountDue; }
            set
            {
                if (Bill.AmountDue != value)
                {
                    Bill.AmountDue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private bool isCalendarOpen = false;
        public bool IsCalendarOpen
        {
            get { return isCalendarOpen; }
            set
            {
                if (isCalendarOpen != value)
                {
                    isCalendarOpen = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ICommand OpenPopupCommand { get; set; }

        //public string Confirmation
        //{
        //    get { return Bill.Confirmation; }
        //    set
        //    {
        //        if (Bill.Confirmation != value)
        //        {
        //            Bill.Confirmation = value;
        //            NotifyPropertyChanged();
        //        }
        //    }
        //}

        public bool IsPaid
        {
            get { return Bill.IsPaid; }
            set
            {
                if (Bill.IsPaid != value)
                {
                    Bill.IsPaid = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged(nameof(BillStatus));
                }
            }
        }

        public BillViewModel(Bill iBill)
        {
            Bill = iBill;
            OpenPopupCommand = new DelegateCommand(OnOpenPopup, CanOpenPopup);
        }

        public BillViewModel()
        {
            Bill = new Bill();
            OpenPopupCommand = new DelegateCommand(OnOpenPopup, CanOpenPopup);
        }

        private bool CanOpenPopup()
        {
            return true;
        }

        private void OnOpenPopup()
        {
            if (!IsCalendarOpen)
            {
                IsCalendarOpen = true;
            }
        }


    }
}
