using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.ViewModels
{
    class NextBillDueDataDesignModel : NextBillDueDataViewModel
    {
        #region Singleton
        private static NextBillDueDataDesignModel instance;
        public static NextBillDueDataDesignModel Instance => instance ?? (instance = new NextBillDueDataDesignModel());
        #endregion

        #region Constructor
        public NextBillDueDataDesignModel()
        {
            CompanyName = "New Company";
            NextAmountDue = 140;
            NextDueDate = new DateTime(2018, 11, 18);
            ShowAmountDue = true;
        }
        #endregion
    }
}
