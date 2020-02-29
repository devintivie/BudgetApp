using BudgetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.ViewModels
{
    public class CurrentDebtBalanceViewModel : LocalBaseViewModel
    {
        #region Properties
        public DebtTracker DebtTracker { get; private set; }

        public string CompanyName
        {
            get { return DebtTracker.CompanyName; }
            set
            {
                if (DebtTracker.CompanyName != value)
                {
                    DebtTracker.CompanyName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private double currentBalance;
        public double CurrentBalance
        {
            get { return currentBalance; }
            set
            {
                if (currentBalance != value)
                {
                    currentBalance = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        #region Constructors
        public CurrentDebtBalanceViewModel(DebtTracker nDT)
        {
            DebtTracker = nDT;
            UpdateCurrentBalance();
        }

        public CurrentDebtBalanceViewModel() : this(new DebtTracker()) { }
        
        #endregion

        #region Methods
        private void UpdateCurrentBalance()
        {
            var dt = DebtTrackerManager.TrackersByCompany[CompanyName].Debts;
            if(dt.Count == 0)
            {
                CurrentBalance = 0;
            }
            else
            {
                CurrentBalance = dt.Last().Balance;
            }
            
        }
        #endregion


    }
}
