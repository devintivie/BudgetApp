using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.ViewModels
{
    class DayBoxDesignModel : DayBoxViewModel
    {
        #region Singleton
        private static DayBoxDesignModel instance;
        public static DayBoxDesignModel Instance => instance ?? (instance = new DayBoxDesignModel());
        #endregion

        #region Constructor
        public DayBoxDesignModel()
        {
            Date = default(DateTime);
        }
        #endregion
    }
}
