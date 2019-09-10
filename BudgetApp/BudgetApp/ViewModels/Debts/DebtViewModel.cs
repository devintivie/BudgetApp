using BudgetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.ViewModels
{
    public class DebtViewModel : LocalBaseViewModel
    {
        #region Properties
        public Debt Debt { get; set; }

        public DateTime Date
        {
            get { return Debt.Date; }
            set
            {
                if (Debt.Date != value)
                {
                    Debt.Date = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public double Total
        {
            get { return Debt.Total; }
            set
            {
                if (Debt.Total != value)
                {
                    Debt.Total = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private double delta;
        public double Delta
        {
            get { return delta; }
            set
            {
                if (delta != value)
                {
                    delta = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        #region Constructors
        public DebtViewModel(Debt debt)
        {
            Debt = debt;
            Console.WriteLine("debt view model constructor");

        }

        public DebtViewModel() : this(new Debt()) { }
        #endregion

        #region Methods

        #endregion






    }
}
