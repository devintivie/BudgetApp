using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.ViewModels
{
    class BudgetCalendarDesignModel : BudgetCalendarViewModel
    {
        #region Singleton
        private static BudgetCalendarDesignModel instance;
        public static BudgetCalendarDesignModel Instance => instance ?? (instance = new BudgetCalendarDesignModel());
        #endregion

        #region Constructor
        public BudgetCalendarDesignModel()
        {
            DayList = new ObservableCollection<DayBoxViewModel>();

            var today = DateTime.Today;

            for(int i = 0; i<21; i++)
            {
                DayList.Add(new DayBoxViewModel(today.AddDays(i)));
            }

            Accounts = new ObservableCollection<BankAccountBalanceViewModel>();
            Accounts.Add(new BankAccountBalanceViewModel(new Models.BankAccount(1200, "1234567", "chase", "main account", "0000")));


        }
        #endregion
    }
}
