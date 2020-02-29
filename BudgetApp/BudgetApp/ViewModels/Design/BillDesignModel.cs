using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.ViewModels
{
    class BillDesignModel : BillViewModel
    {
        #region Singleton
        private static BillDesignModel instance;
        public static BillDesignModel Instance => instance ?? (instance = new BillDesignModel());
        #endregion

        #region Constructor
        public BillDesignModel()
        {
            AmountDue = 100;
            //Confirmation = "Test Conf";
            DueDate = new DateTime(2018, 1, 1);
            IsPaid = true;
            //AccountID = "1234";

        }
        #endregion
    }
}
