using System;
using BudgetApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.ViewModels
{
    public class BankAccountViewModel : LocalBaseViewModel
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



        public BankAccountViewModel()
        {
            BankAccount = new BankAccount();

        }

        public BankAccountViewModel(BankAccount account)
        {
            BankAccount = account;
        }

       



    }
}
