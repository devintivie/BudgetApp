using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.ViewModels
{
    class DebtTrackerDesignModel : DebtTrackerViewModel
    {
        private static DebtTrackerDesignModel instance;
        public static DebtTrackerDesignModel Instance => instance ?? (instance = new DebtTrackerDesignModel());

        public DebtTrackerDesignModel()
        {
            CompanyName = "Student Loan";
            Debts = new ObservableCollection<DebtViewModel>
            {
                new DebtViewModel
                {
                    Date = DateTime.Today.AddMonths(-3),
                    Total = 1000
                },
                new DebtViewModel
                {
                    Date = DateTime.Today.AddMonths(-2),
                    Total = 950
                },
                new DebtViewModel
                {
                    Date = DateTime.Today.AddMonths(-1),
                    Total = 875
                },
                new DebtViewModel
                {
                    Date = DateTime.Today,
                    Total = 775
                },
            };
            AddDebtAmount = 650;
            AddDebtDate = DateTime.Today.AddMonths(1);
            IsContentAvailable = true;
            
        }
    }
}
