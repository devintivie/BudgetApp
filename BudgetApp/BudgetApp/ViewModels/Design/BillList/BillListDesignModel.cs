using BudgetApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.ViewModels
{
    class BillListDesignModel : BillListViewModel
    {
        #region Singleton
        private static BillListDesignModel instance;
        public static BillListDesignModel Instance => instance ?? (instance = new BillListDesignModel());
        #endregion

        #region Constructor
        public BillListDesignModel()
        {

            BTList = new ObservableCollection<NextBillDueDataViewModel>();

            BTList.Add(new NextBillDueDataViewModel(new BillTracker("test", new Bill())));
            BTList.Add(new NextBillDueDataViewModel(new BillTracker("test", new Bill())));
            BTList.Add(new NextBillDueDataViewModel(new BillTracker("test", new Bill())));
            BTList.Add(new NextBillDueDataViewModel(new BillTracker("test", new Bill())));

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
