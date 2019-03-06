using System;
using BudgetApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.ViewModels
{
    public class BankAccountBalanceViewModel : LocalBaseViewModel
    {
        public BankAccount BankAccount;

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

        public BankAccountBalanceViewModel()
        {
            BankAccount = new BankAccount();

        }

        public BankAccountBalanceViewModel(BankAccount account)
        {
            BankAccount = account;
        }

       



    }
}
