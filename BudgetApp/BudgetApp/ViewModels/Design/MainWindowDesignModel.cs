using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.ViewModels
{
    class MainWindowDesignModel : MainWindowViewModel
    {
        #region Singleton
        private static MainWindowDesignModel instance;
        public static MainWindowDesignModel Instance => instance ?? (instance = new MainWindowDesignModel());
        #endregion

        #region Constructor
        public MainWindowDesignModel()
        {
            
            //PageDisplay = Navigation.BankOverview;
            BTList = new ObservableCollection<NextBillDueDataViewModel>
            {
                new NextBillDueDataViewModel
                {
                    CompanyName = "hello",
                    NextDueDate = DateTime.Today,
                    NextAmountDue = 100

                },
                new NextBillDueDataViewModel
                {
                    CompanyName = "hello",
                    NextDueDate = DateTime.Today,
                    NextAmountDue = 100

                },
                new NextBillDueDataViewModel
                {
                    CompanyName = "hello",
                    NextDueDate = DateTime.Today,
                    NextAmountDue = 100

                },
                new NextBillDueDataViewModel
                {
                    CompanyName = "hello",
                    NextDueDate = DateTime.Today,
                    NextAmountDue = 100

                },
                new NextBillDueDataViewModel
                {
                    CompanyName = "hello",
                    NextDueDate = DateTime.Today,
                    NextAmountDue = 100

                },
                new NextBillDueDataViewModel
                {
                    CompanyName = "hello",
                    NextDueDate = DateTime.Today,
                    NextAmountDue = 100

                },
                new NextBillDueDataViewModel
                {
                    CompanyName = "hello",
                    NextDueDate = DateTime.Today,
                    NextAmountDue = 100

                },
                new NextBillDueDataViewModel
                {
                    CompanyName = "hello",
                    NextDueDate = DateTime.Today,
                    NextAmountDue = 100

                },
                new NextBillDueDataViewModel
                {
                    CompanyName = "hello",
                    NextDueDate = DateTime.Today,
                    NextAmountDue = 100

                },
                new NextBillDueDataViewModel
                {
                    CompanyName = "hello",
                    NextDueDate = DateTime.Today,
                    NextAmountDue = 100

                },
                new NextBillDueDataViewModel
                {
                    CompanyName = "hello",
                    NextDueDate = DateTime.Today,
                    NextAmountDue = 100

                },
                new NextBillDueDataViewModel
                {
                    CompanyName = "hello",
                    NextDueDate = DateTime.Today,
                    NextAmountDue = 100

                },
                new NextBillDueDataViewModel
                {
                    CompanyName = "hello",
                    NextDueDate = DateTime.Today,
                    NextAmountDue = 100

                },
                new NextBillDueDataViewModel
                {
                    CompanyName = "hello",
                    NextDueDate = DateTime.Today,
                    NextAmountDue = 100

                },
                new NextBillDueDataViewModel
                {
                    CompanyName = "hello",
                    NextDueDate = DateTime.Today,
                    NextAmountDue = 100

                },
                new NextBillDueDataViewModel
                {
                    CompanyName = "hello",
                    NextDueDate = DateTime.Today,
                    NextAmountDue = 100

                },
                new NextBillDueDataViewModel
                {
                    CompanyName = "hello",
                    NextDueDate = DateTime.Today,
                    NextAmountDue = 100

                },
                new NextBillDueDataViewModel
                {
                    CompanyName = "hello",
                    NextDueDate = DateTime.Today,
                    NextAmountDue = 100

                },
                new NextBillDueDataViewModel
                {
                    CompanyName = "hello",
                    NextDueDate = DateTime.Today,
                    NextAmountDue = 100

                },
                new NextBillDueDataViewModel
                {
                    CompanyName = "hello",
                    NextDueDate = DateTime.Today,
                    NextAmountDue = 100

                },
                new NextBillDueDataViewModel
                {
                    CompanyName = "hello",
                    NextDueDate = DateTime.Today,
                    NextAmountDue = 100

                },
            };
            BAList = new ObservableCollection<Models.BankAccount>
            {
                new Models.BankAccount()
            };

            OpenFile(@"C:\Users\devin\OneDrive\Documents\VisualStudioFiles\devin_budget.xml");

        }
        #endregion
    }
}
