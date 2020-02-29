using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.ViewModels
{
    class MultiplePaycheckDesignModel : MultiplePaycheckViewModel
    {
        #region Singleton
        private static MultiplePaycheckDesignModel instance;
        public static MultiplePaycheckDesignModel Instance => instance ?? (instance = new MultiplePaycheckDesignModel());
        #endregion

        #region Constructor
        public MultiplePaycheckDesignModel()
        {
            CompanyName = "New Company";
            PrevAmountDue = 120;
            CurrAmountDue = 120;
            NextAmountDue = 120;
            PrevPaydate = new DateTime(2019, 1, 1);
            CurrPaydate = new DateTime(2019, 1, 15);
            NextPaydate = new DateTime(2019, 1, 29);
            NextDueDate = new DateTime(2018, 11, 18);
        }
        #endregion
    }
}
