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
    public class BillViewModel : LocalBaseViewModel
    {
        public Bill Bill { get; set; }
        public ObservableCollection<string> AccountOptions { get; set; } = new ObservableCollection<string>();

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
                    Messenger.Default.Send(new Message(0, MessageType.BillViewModel));
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
                    Messenger.Default.Send(new Message(0, MessageType.BillViewModel));
                }
            }
        }

        private string selectedAccount;
        public string SelectedAccount
        {
            get { return selectedAccount; }
            set
            {
                if (selectedAccount != value)
                {
                    selectedAccount = value;
                    Bill.AccountID = BankAccountManager.AccountsByNumber[SelectedAccount].UniqueID;
                    NotifyPropertyChanged();
                    
                }
            }
        }


        //public string Account
        //{
        //    get { return BankAccountManager.AccountsByID; }
        //}


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
                    Messenger.Default.Send(new Message(0, MessageType.BillViewModel));

                }
            }
        }

        public BillViewModel(Bill iBill)
        {
            Bill = iBill;
            OpenPopupCommand = new DelegateCommand(OnOpenPopup, CanOpenPopup);

            foreach( var acct in BankAccountManager.AllAccounts)
            {
                AccountOptions.Add(acct.Nickname);
            }
            try
            {
                SelectedAccount = BankAccountManager.AccountsByID[Bill.AccountID].Nickname;
            }
            catch
            {
                try
                {
                    SelectedAccount = BankAccountManager.AllAccounts[0].Nickname;
                }
                catch
                {

                }
                
            }
            


        }

        public BillViewModel() : this(new Bill()) { }

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
            else
            {
                IsCalendarOpen = false;
            }
        }


    }
}
