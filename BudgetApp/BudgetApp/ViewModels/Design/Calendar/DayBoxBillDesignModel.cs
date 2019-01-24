using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.ViewModels
{
    class DayBoxBillDesignModel : DayBoxBillViewModel
    {
        #region Singleton
        private static DayBoxBillDesignModel instance;
        public static DayBoxBillDesignModel Instance => instance ?? (instance = new DayBoxBillDesignModel());
        #endregion

        #region Constructor
        public DayBoxBillDesignModel() : base("TheLongestNameAround")
        {

        }
        #endregion
    }
}
