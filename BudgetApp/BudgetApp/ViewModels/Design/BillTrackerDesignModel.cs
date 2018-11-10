using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.ViewModels
{
    class BillTrackerDesignModel : BillTrackerViewModel
    {
        #region Singleton
        private static BillTrackerDesignModel instance;
        public static BillTrackerDesignModel Instance => instance ?? (instance = new BillTrackerDesignModel());
        #endregion

        #region Constructor
        public BillTrackerDesignModel()
        {
            Bills = new ObservableCollection<BillViewModel>
            {
                new BillViewModel
                {
                    AmountDue = 50,
                    //Confirmation = "ABC123",
                    DueDate = new DateTime(2018,5,20),
                    //IsPaid = true
                },
                new BillViewModel
                {
                    AmountDue = 75,
                    //Confirmation = "ABC123",
                    DueDate = new DateTime(2018,6,20),
                    //IsPaid = true
                },
                new BillViewModel
                {
                    AmountDue = 80,
                    //Confirmation = "ABC123",
                    DueDate = new DateTime(2018,7,20),
                    //IsPaid = true
                },
                new BillViewModel
                {
                    AmountDue = 50,
                    //Confirmation = "ABC123",
                    DueDate = new DateTime(2018,8,20),
                    //IsPaid = false
                }
            };

            IsContentAvailable = true;
        }
        #endregion
    }
}
