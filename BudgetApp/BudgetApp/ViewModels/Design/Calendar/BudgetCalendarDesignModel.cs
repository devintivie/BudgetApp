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
            DayList = new ObservableCollection<DayBoxViewModel>
            {
                new DayBoxViewModel
                {
                    Date = DateTime.Today,
                },
                new DayBoxViewModel
                {
                    Date = DateTime.Today.AddDays(1),
                },
                new DayBoxViewModel
                {
                    Date = DateTime.Today.AddDays(2),
                },
                new DayBoxViewModel
                {
                    Date = DateTime.Today.AddDays(3),
                },
                new DayBoxViewModel
                {
                    Date = DateTime.Today.AddDays(4),
                },
                new DayBoxViewModel
                {
                    Date = DateTime.Today.AddDays(5),
                },
                new DayBoxViewModel
                {
                    Date = DateTime.Today.AddDays(6),
                }
            };

            
        }
        #endregion
    }
}
