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

        private AveragesViewModel avm = new AveragesViewModel();
        public AveragesViewModel AVM
        {
            get { return avm; }
            set
            {
                if (avm != value)
                {
                    avm = value;
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



        #endregion


        #region Fields
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

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
            AVM.UpdateAvailableYears();
        }

        private void OnAddAccount()
        {
            var found = false;
            var random = new Random();
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
                    var uid = new string(Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray());
                    //var uid = new char[4];
                    //for (int i = 0; i < uid.Length, i++)
                    //{
                    //    uid[i] = chars
                    //}
                    Console.WriteLine(uid);
                    while (BankAccountManager.AccountsByID.ContainsKey(uid))
                    {
                        uid = new string(Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray());
                    }
                    var ba = new BankAccount
                    {
                        Nickname = NewNickname,
                        Balance = NewAccountBalance,
                        AccountNumber = "-",
                        BankName = "-",
                        UniqueID = uid
                        
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
        #endregion


    }
}
