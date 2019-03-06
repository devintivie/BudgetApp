using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.ViewModels
{
    class BankAccountDesignModel : BankAccountViewModel
    {
        #region Singleton
        private static BankAccountDesignModel instance;
        public static BankAccountDesignModel Instance => instance ?? (instance = new BankAccountDesignModel());
        #endregion

        #region Constructor
        public BankAccountDesignModel()
        {
            AccountNumber = "100025478";
            Balance = 1500;
            BankName = "Chase";
            Nickname = "Main Account";
            
            
        }
        #endregion
    }
}
