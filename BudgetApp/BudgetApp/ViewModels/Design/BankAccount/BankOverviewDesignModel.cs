using BudgetApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.ViewModels
{
    class BankOverviewDesignModel : BankOverviewViewModel
    {
        #region Singleton
        private static BankOverviewDesignModel instance;
        public static BankOverviewDesignModel Instance => instance ?? (instance = new BankOverviewDesignModel());
        #endregion

        #region Constructor
        public BankOverviewDesignModel()
        {

            BAList = new ObservableCollection<BankAccountViewModel>();

            BAList.Add(new BankAccountViewModel(new BankAccount(2000, "10002547", "USAA Bank", "Main Account", "0001")));
            BAList.Add(new BankAccountViewModel(new BankAccount(2500, "10002548", "USAA Bank", "My Account", "0002")));
            BAList.Add(new BankAccountViewModel(new BankAccount(120, "10002550", "USAA Bank", "Her Account", "0003")));
            BAList.Add(new BankAccountViewModel(new BankAccount(600, "10002560", "USAA Bank", "His Account", "0004")));


            //CurrentSelection = new NextBillDueDataViewModel(new BillTracker("test", new Bill()));
            //DayList = new ObservableCollection<DayBoxViewModel>();

            //var today = DateTime.Today;

            //for (int i = 0; i < 21; i++)
            //{
            //    DayList.Add(new DayBoxViewModel(today.AddDays(i)));
            //}



        }
        #endregion
    }
}
