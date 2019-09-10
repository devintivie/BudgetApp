using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.ViewModels
{
    class DebtDesignModel : DebtViewModel
    {
        #region Singleton
        private static DebtDesignModel instance;
        public static DebtDesignModel Instance => instance ?? (instance = new DebtDesignModel());
        #endregion

        #region Constructors
        public DebtDesignModel()
        {
            Total = 1000;
            Date = new DateTime(2018, 1, 1);
            Delta = 150;
        }
        #endregion
    }
}
