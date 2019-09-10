using System;
using BudgetApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using IvieBaseClasses;

namespace BudgetApp.ViewModels
{
    public class BankAccountBalanceViewModel : LocalBaseViewModel
    {
        public BankAccount BankAccount;

        public ICommand MoveLeftCommand { get; set; }
        public ICommand MoveRightCommand { get; set; }

        #region Properties
        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public double Balance
        {
            get { return BankAccount.Balance; }
            set
            {
                if (BankAccount.Balance != value)
                {
                    BankAccount.Balance = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged(nameof(Remaining));
                }
            }
        }


        public string AccountNumber
        {
            get { return BankAccount.AccountNumber; }
            set
            {
                if (BankAccount.AccountNumber != value)
                {
                    BankAccount.AccountNumber = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public string BankName
        {
            get { return BankAccount.BankName; }
            set
            {
                if (BankAccount.BankName != value)
                {
                    BankAccount.BankName = value;
                    NotifyPropertyChanged();
                }
            }
        }



        public string Nickname
        {
            get { return BankAccount.Nickname; }
            set
            {
                if (BankAccount.Nickname != value)
                {
                    BankAccount.Nickname = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public string UniqueID
        {
            get { return BankAccount.UniqueID; }
            set
            {
                if (BankAccount.UniqueID != value)
                {
                    BankAccount.UniqueID = value;
                    NotifyPropertyChanged();
                }
            }
        }


        private double deductions = 0.0;
        public double Deductions
        {
            get { return deductions; }
            set
            {
                if (deductions != value)
                {
                    deductions = value;
                    Console.WriteLine($"Deductions change to {Deductions} for {Nickname}");
                    NotifyPropertyChanged();
                    NotifyPropertyChanged(nameof(Remaining));
                }
            }
        }

        public double Remaining { get { return Balance - Deductions; } }

        #endregion

        #region Constructors
        public BankAccountBalanceViewModel() : this(new BankAccount()) { }

        public BankAccountBalanceViewModel(BankAccount account)
        {
            MoveLeftCommand = new DelegateCommand(OnMoveLeft, CanMoveLeft);
            MoveRightCommand = new DelegateCommand(OnMoveRight, CanMoveRight);

            BankAccount = account;

            
        }
        #endregion
        

        #region Methods
        private void OnMoveRight()
        {
            var index = BankAccountManager.AllAccounts.IndexOf(BankAccount);
            BankAccountManager.RemoveSelected(BankAccount);
            BankAccountManager.AllAccounts.Insert(index + 1, BankAccount);
            Messenger.Default.Send(new Message(1, MessageType.BankAccountBalanceViewModel));
        }

        private bool CanMoveRight()
        {
            if (IsSelected)
            {
                if(BankAccountManager.AllAccounts.IndexOf(BankAccount) == BankAccountManager.AllAccounts.Count - 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private void OnMoveLeft()
        {
            var index = BankAccountManager.AllAccounts.IndexOf(BankAccount);
            BankAccountManager.RemoveSelected(BankAccount);
            BankAccountManager.AllAccounts.Insert(index - 1, BankAccount);
            Messenger.Default.Send(new Message(1, MessageType.BankAccountBalanceViewModel));
        }

        private bool CanMoveLeft()
        {
            if (IsSelected)
            {
                if (BankAccountManager.AllAccounts.IndexOf(BankAccount) == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        

        #endregion




    }
}
