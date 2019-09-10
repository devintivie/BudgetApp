using BudgetApp.Models;
using IvieBaseClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BudgetApp.ViewModels
{
    public class DebtTrackerViewModel : LocalBaseViewModel
    {
        #region Fields
        private DebtTracker DebtTracker { get; set; }
        #endregion

        #region Properties
        public ObservableCollection<DebtViewModel> Debts { get; set; } = new ObservableCollection<DebtViewModel>();

        public ICommand AddCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand OpenAddDebtCommand { get; set; }

        private bool isContentAvailable;
        public bool IsContentAvailable
        {
            get { return isContentAvailable; }
            set
            {
                if (isContentAvailable != value)
                {
                    isContentAvailable = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string CompanyName
        {
            get { return DebtTracker.CompanyName; }
            set
            {
                if (DebtTracker.CompanyName != value)
                {
                    DebtTracker.CompanyName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private DebtViewModel currentDVM;
        public DebtViewModel CurrentDVM
        {
            get { return currentDVM; }
            set
            {
                if (currentDVM != value)
                {
                    currentDVM = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private bool isAddDebtOpen;
        public bool IsAddDebtOpen
        {
            get { return isAddDebtOpen; }
            set
            {
                if (isAddDebtOpen != value)
                {
                    isAddDebtOpen = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private DateTime addDebtDate = DateTime.Today;
        public DateTime AddDebtDate
        {
            get { return addDebtDate; }
            set
            {
                if (addDebtDate != value)
                {
                    addDebtDate = value;
                    NotifyPropertyChanged();
                }
            }
        }


        private double addDebtAmount = 0.0;
        public double AddDebtAmount
        {
            get { return addDebtAmount; }
            set
            {
                if (addDebtAmount != value)
                {
                    addDebtAmount = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        #region Constructors
        public DebtTrackerViewModel(DebtTracker iDebtTracker)
        {
            DebtTracker = iDebtTracker;
            UpdateDebts();

            AddCommand = new DelegateCommand(OnAdd, CanAdd);
            RemoveCommand = new DelegateCommand(OnRemove, CanRemove);
            OpenAddDebtCommand = new DelegateCommand(OnOpenAddDebt, CanOpenAddDebt);
        }

        public DebtTrackerViewModel() : this(new DebtTracker()) { }
        #endregion

        #region Methods
        private void UpdateContentAvailable()
        {
            if(Debts.Count > 0)
            {
                IsContentAvailable = true;
            }
            else
            {
                IsContentAvailable = false;
            }
        }

        private void OnRemove()
        {
            var found = false;
            foreach (var d in DebtTracker.Debts)
            {
                if (d.Date.Equals(CurrentDVM.Date))
                {
                    found = true;
                    break;
                }
            }
            if (found)
            {
                DebtTracker.Debts.Remove(CurrentDVM.Debt);
            }

            UpdateDebts();
        }

        private bool CanRemove()
        {
            return CurrentDVM != null;
        }

        private void OnAdd()
        {
            
        }

        private bool CanAdd()
        {
            return true;
        }

        private void OnOpenAddDebt()
        {
            if (!IsAddDebtOpen)
            {
                IsAddDebtOpen = true;
            }
        }

        private bool CanOpenAddDebt()
        {
            return true;
        }

        public void UpdateDebts()
        {
            Debts.Clear();
            foreach (var debt in DebtTracker.Debts)
            {
                Debts.Add(new DebtViewModel(debt));
            }
            UpdateContentAvailable();
        }

        #endregion

    }
}


