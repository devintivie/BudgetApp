using BudgetApp.Managers;
using IvieBaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BudgetApp.ViewModels
{
    public class LocalBaseViewModel : BaseViewModel
    {
        public BillTrackerManager BillTrackerManager => BillTrackerManager.Instance;
        public DebtTrackerManager DebtTrackerManager => DebtTrackerManager.Instance;
        public BankAccountManager BankAccountManager => BankAccountManager.Instance;
        
        public void ResetManagers()
        {
            BillTrackerManager.Reset();
            BankAccountManager.Reset();
            DebtTrackerManager.Reset();

            ShowBudgetCalendar = new DelegateCommand(ToBudgetCalendarVM);
            ShowBillList = new DelegateCommand(ToBillListVM);
            ShowBankOverview = new DelegateCommand(ToBankOverviewVM);
            ShowDebtOverview = new DelegateCommand(ToDebtOverviewVM);
        }

        //public virtual void UpdateView() { }


        #region Commands
        public ICommand ShowBudgetCalendar { get; set; }
        public ICommand ShowBillList { get; set; }
        public ICommand ShowBankOverview { get; set; }
        public ICommand ShowDebtOverview { get; set; }

        #endregion
        #region Methods
        public void ToBudgetCalendarVM()
        {
            Messenger.Send(new NavigationMessage(new BudgetCalendarViewModel()));
        }

        public void ToBillListVM()
        {
            Messenger.Send(new NavigationMessage(new BillListViewModel()));
        }

        public void ToBankOverviewVM()
        {
            Messenger.Send(new NavigationMessage(new BankOverviewViewModel()));
        }

        public void ToDebtOverviewVM()
        {
            Messenger.Send(new NavigationMessage(new DebtOverviewViewModel()));
        }
        #endregion

    }

}
