using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.ViewModels
{
    class BankAccountBalanceDesignModel : BankAccountBalanceViewModel
    {
        #region Singleton
        private static BankAccountBalanceDesignModel instance;
        public static BankAccountBalanceDesignModel Instance => instance ?? (instance = new BankAccountBalanceDesignModel());
        #endregion

        #region Constructor
        public BankAccountBalanceDesignModel()
        {
            AccountNumber = "100025478";
            Balance = 1500000;
            BankName = "Chase";
            Nickname = "Main Account";
            Deductions = 900;
            
            
        }
        #endregion
    }
}
