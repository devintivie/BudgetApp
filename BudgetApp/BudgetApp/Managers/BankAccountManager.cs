using BudgetApp.Models;
using IvieBaseClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BudgetApp.Managers
{
    public class BankAccountManager : BaseINPC
    {
        #region Singleton
        private static BankAccountManager instance;
        public static BankAccountManager Instance => instance ?? (instance = new BankAccountManager());
        
        private BankAccountManager() { }

        #endregion Singleton

        public Dictionary<string, BankAccount> AccountsByNumber { get; set; } = new Dictionary<string, BankAccount>();
        public List<BankAccount> AllAccounts { get; set; } = new List<BankAccount>();

        private BankAccount selectedAccount;
        public BankAccount SelectedAccount
        {
            get { return selectedAccount; }
            set
            {
                if (selectedAccount != value)
                {
                    selectedAccount = value;
                    NotifyPropertyChanged();
                }
            }
        }


        private int accountCount;
        public int AccountCount
        {
            get { return accountCount; }
            set
            {
                if (accountCount != value)
                {
                    accountCount = value;
                    NotifyPropertyChanged();
                    Console.WriteLine($"bank accountnotify count = {AccountCount}");
                }
            }
        }

        private void UpdateAccountCount()
        {
            AccountCount = AllAccounts.Count;
        }

        public void AddAccount(BankAccount ba)
        {
            
            if (!AllAccounts.Contains(ba))
            {
                Console.WriteLine("bank account added");
                AccountsByNumber.Add(ba.Nickname, ba);
                AllAccounts.Add(ba);
                Console.WriteLine($"all accounts add count {AllAccounts.Count}");
            }
            UpdateAccountCount();
        }

        public void AddAccount(string name, string nickname, string acctNumber = "-", string bankName = "-")
        {
            Console.WriteLine("bank account added");
            if (!AccountsByNumber.ContainsKey(name))
            {
                Console.WriteLine("bank account added");
                var acct = new BankAccount(0, acctNumber, bankName, nickname);
            }
            UpdateAccountCount();
        }

        public void RemoveAccount(BankAccount ba)
        {
            AllAccounts.Remove(ba);
            AccountsByNumber.Remove(ba.AccountNumber);
            UpdateAccountCount();
        }

        public void RemoveAccount(string name)
        {
            if(AccountsByNumber.TryGetValue(name, out var acct))
            {
                RemoveAccount(acct);
            }
            UpdateAccountCount();
        }

        public void Reset()
        {
            AccountsByNumber.Clear();
            AllAccounts.Clear();
            SelectedAccount = null;
            UpdateAccountCount();
        }
    }
}
 