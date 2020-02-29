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
    public class DebtOverviewViewModel : LocalBaseViewModel, INavigationViewModel
    {
        #region Properties
        private ObservableCollection<string> dtList = new ObservableCollection<string>();
        public ObservableCollection<string> DTList
        {
            get { return dtList; }
            set
            {
                if (dtList != value)
                {
                    dtList = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string currentSelection;
        public string CurrentSelection
        {
            get { return currentSelection; }
            set
            {
                if (currentSelection != value)
                {
                    currentSelection = value;
                    NotifyPropertyChanged();
                    UpdateCurrentDTVM();
                }
            }
        }

        private DebtTrackerViewModel currentDT;
        public DebtTrackerViewModel CurrentDT
        {
            get { return currentDT; }
            set
            {
                if (currentDT != value)
                {
                    currentDT = value;
                    NotifyPropertyChanged();
                }
            }
        }


        private bool isPopupOpen;
        public bool IsPopupOpen
        {
            get { return isPopupOpen; }
            set
            {
                if (isPopupOpen != value)
                {
                    isPopupOpen = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string companyName;
        public string CompanyName
        {
            get { return companyName; }
            set
            {
                if (companyName != value)
                {
                    companyName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private double initialBalance;
        public double InitialBalance
        {
            get { return initialBalance; }
            set
            {
                if (initialBalance != value)
                {
                    initialBalance = value;
                    NotifyPropertyChanged();
                }
            }
        }


        #endregion

        #region Commands
        public ICommand AddAccountCommand { get; set; }
        public ICommand RemoveAccountCommand { get; set; }
        public ICommand OpenPopupCommand { get; set; }
        #endregion

        #region Constructors
        public DebtOverviewViewModel()
        {
            AddAccountCommand = new DelegateCommand(OnAddAccount, CanAddAccount);
            RemoveAccountCommand = new DelegateCommand(OnRemoveAccount, CanRemoveAccount);
            OpenPopupCommand = new DelegateCommand(OnOpenPopup, CanOpenPopup);
            UpdateDTList();
        }

        #endregion

        #region Methods
        public void UpdateDTList()
        {
            DTList.Clear();
            var tempList = new List<string>();

            foreach(var item in DebtTrackerManager.AllTrackers)
            {
                tempList.Add(item.CompanyName);
            }

            tempList.Sort();
            DTList = new ObservableCollection<string>(tempList);
        }

        public void UpdateView()
        {
            UpdateDTList();
        }

        private void OnAddAccount()
        {
            Console.WriteLine(CompanyName);
            Console.WriteLine(InitialBalance);

            var found = false;
            if (CompanyName != null && CompanyName.Length > 2)
            {
                foreach(var d in DTList)
                {
                    if (d.Equals(CompanyName))
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    var dt = new DebtTracker
                    {
                        CompanyName = CompanyName
                    };
                    DebtTrackerManager.AddTracker(dt);
                    Console.WriteLine($"debt tracker manager count {DebtTrackerManager.AllTrackers.Count}");
                    UpdateDTList();
                }

                CompanyName = "";
                InitialBalance = 0;
            }
        }

        public void UpdateCurrentDTVM()
        {
            Console.WriteLine(DebtTrackerManager.TrackerCount);

            if(CurrentSelection == null)
            {
                if(DebtTrackerManager.TrackerCount == 0)
                {
                    CurrentDT = new DebtTrackerViewModel();
                }
                else
                {
                    CurrentDT = new DebtTrackerViewModel(DebtTrackerManager.AllTrackers[0]);
                }
            }
            else
            {
                CurrentDT = new DebtTrackerViewModel(DebtTrackerManager.TrackersByCompany[CurrentSelection]);
            }
        }

        private bool CanAddAccount()
        {
            return true;
        }

        private void OnRemoveAccount()
        {
            throw new NotImplementedException();
        }

        private bool CanRemoveAccount()
        {
            return true;
        }

        private void OnOpenPopup()
        {
            if (!IsPopupOpen)
            {
                IsPopupOpen = true;
            }
        }

        private bool CanOpenPopup()
        {
            return true;
        }

        #endregion

    }
}
