﻿using BudgetApp.Models;
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
    public class BankOverviewViewModel : LocalBaseViewModel
    {
        #region Properties
        public ObservableCollection<BankAccountViewModel> BAList { get; set; } = new ObservableCollection<BankAccountViewModel>();

        private bool isPopupOpen;
        public bool IsPopupOpen
        {
            get { return isPopupOpen; }
            set
            {
                if (isPopupOpen != value)
                {
                    isPopupOpen = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string newNickname;
        public string NewNickname
        {
            get { return newNickname; }
            set
            {
                if (newNickname != value)
                {
                    newNickname = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private double newAccountBalance;
        public double NewAccountBalance
        {
            get { return newAccountBalance; }
            set
            {
                if (newAccountBalance != value)
                {
                    newAccountBalance = value;
                    NotifyPropertyChanged();
                }
            }
        }


        private BankAccountViewModel currentAccount;
        public BankAccountViewModel CurrentAccount
        {
            get { return currentAccount; }
            set
            {
                if (currentAccount != value)
                {
                    currentAccount = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        #region Commands
        public ICommand AddAccountCommand { get; set; }
        public ICommand RemoveAccountCommand { get; set; }
        public ICommand OpenPopupCommand { get; set; }
        #endregion

        #region Constructors

        public BankOverviewViewModel()
        {
            AddAccountCommand = new DelegateCommand(OnAddAccount, CanAddAccount);
            RemoveAccountCommand = new DelegateCommand(OnRemoveAccount, CanRemoveAccount);
            OpenPopupCommand = new DelegateCommand(OnOpenPopup, CanOpenPopup);

            UpdateAccountList();
        }

        private void OnAddAccount()
        {
            var found = false;
            if (NewNickname != null)
            {
                foreach (var b in BAList)
                {
                    if (b.Nickname.Equals(NewNickname, StringComparison.CurrentCultureIgnoreCase))
                    {
                        found = true;
                    }
                }
                if (!found && NewNickname.Length > 0)
                {
                    var ba = new BankAccount
                    {
                        Nickname = NewNickname,
                        Balance = NewAccountBalance,
                        AccountNumber = "-",
                        BankName = "-"
                    };

                    BankAccountManager.AddAccount(ba);
                    Console.WriteLine($"Add account and check count {BankAccountManager.AllAccounts.Count}");

                    UpdateAccountList();
                }
            }

            NewNickname = "";
            NewAccountBalance = 0;
        }

        private bool CanAddAccount()
        {
            return true;
        }

        private void OnRemoveAccount()
        {
            BankAccountManager.RemoveAccount(CurrentAccount.BankAccount);
            UpdateAccountList();
        }

        private bool CanRemoveAccount()
        {
            return CurrentAccount != null;
        }

        private void OnOpenPopup()
        {
            if (!IsPopupOpen)
            {
                IsPopupOpen = true;
            }
        }

        private bool CanOpenPopup()
        {
            return true;
        }





        //private void OnRemoveCompany()
        //{
        //    BillTrackerManager.RemoveTracker(CurrentSelection.BillTracker);
        //    UpdateBTList();
        //}

        //private bool CanRemoveCompany()
        //{
        //    return CurrentSelection != null;
        //}



        #endregion


        #region Methods

        private void UpdateAccountList()
        {
            BAList.Clear();
            var tempList = new List<BankAccount>();
            Console.WriteLine($"Update bank account tracker count = {BankAccountManager.AllAccounts.Count}");

            foreach (var b in BankAccountManager.AllAccounts)
            {
                tempList.Add(b);
            }
            foreach (var b in tempList)
            {
                BAList.Add(new BankAccountViewModel(b));
            }

        }

        public override void UpdateView()
        {
            UpdateAccountList();
        }
        #endregion


    }
}