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
    class DebtListViewModel : LocalBaseViewModel
    {
        #region Properties
        public ObservableCollection<CurrentDebtBalanceViewModel> DTList { get; set; } = new ObservableCollection<CurrentDebtBalanceViewModel>();

        public bool IsDebtFree
        {
            get { return DebtTrackerManager.AllTrackers.Count == 0; }
        }
        
        public bool ShowCurrentDT
        {
            get
            {
                if ((DebtTrackerManager.TrackerCount == 0) || CurrentSelection == null)
                {
                    //Console.WriteLine("show current bt is false");
                    return false;

                }
                else
                {
                    //Console.WriteLine("show current bt is true");
                    return true;
                }
            }
        }

        private CurrentDebtBalanceViewModel currentSelection;
        public CurrentDebtBalanceViewModel CurrentSelection
        {
            get { return currentSelection; }
            set
            {
                if (currentSelection != value)
                {
                    //if(CurrentSelection == null)
                    //{
                    //    Console.WriteLine("current selection = null");
                    //}
                    //else
                    //{
                    //    Console.WriteLine(CurrentSelection.CompanyName);
                    //}
                    
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

        private string newCompany;
        public string NewCompany
        {
            get { return newCompany; }
            set
            {
                if (newCompany != value)
                {
                    newCompany = value;
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
        private bool isEditPopupOpen;
        public bool IsEditPopupOpen
        {
            get { return isEditPopupOpen; }
            set
            {
                if (isEditPopupOpen != value)
                {
                    isEditPopupOpen = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        #region Commands
        public ICommand AddCompanyCommand { get; set; }
        public ICommand RemoveCompanyCommand { get; set; }
        public ICommand EditCompanyCommand { get; set; }
        public ICommand OpenPopupCommand { get; set; }
        public ICommand OpenEditPopupCommand { get; set; }
        #endregion

        #region Constructors
        public DebtListViewModel()
        {
            AddCompanyCommand = new DelegateCommand(OnAddCompany, CanAddCompany);
            EditCompanyCommand = new DelegateCommand(OnEditCompany, CanEditCompany);
            RemoveCompanyCommand = new DelegateCommand(OnRemoveCompany, CanRemoveCompany);
            OpenPopupCommand = new DelegateCommand(OnOpenPopup, CanOpenPopup);
            OpenEditPopupCommand = new DelegateCommand(OnEditOpenPopup, CanEditOpenPopup);

            UpdateDTList();
        }

        #endregion

        #region Methods
        private void UpdateDTList()
        {
            DTList.Clear();

            var tempList = new List<DebtTracker>();
            Console.WriteLine($"UpdateDTList tracker count = {DebtTrackerManager.AllTrackers.Count}");

            foreach (var dt in DebtTrackerManager.AllTrackers)
            {
                tempList.Add(dt);
                tempList.Sort();
            }
            foreach (var dt in tempList)
            {
                DTList.Add(new CurrentDebtBalanceViewModel(dt));
            }

            NotifyPropertyChanged(nameof(IsDebtFree));
            Console.WriteLine(IsDebtFree);
        }

        public void UpdateView()
        {
            UpdateDTList();
        }

        private void UpdateCurrentDTVM()
        {
            Console.WriteLine(DebtTrackerManager.TrackerCount);
            if (CurrentSelection == null)
            {

                if (DebtTrackerManager.TrackerCount == 0)
                {
                    CurrentDT = new DebtTrackerViewModel();
                }
                else
                {
                    CurrentDT = new DebtTrackerViewModel(DebtTrackerManager.AllTrackers.FirstOrDefault());
                }

            }
            else
            {
                //if(BillTrackerManager.TrackersByCompany.ContainsKey(CurrentSelection.CompanyName))
                //{
                CurrentDT = new DebtTrackerViewModel(DebtTrackerManager.TrackersByCompany[CurrentSelection.CompanyName]);
                //    showCurrentBT = true;
                //}
                //else
                //{
                //    CurrentBT = new BillTrackerViewModel();
                //    showCurrentBT = true;
                //}

            }

            NotifyPropertyChanged(nameof(ShowCurrentDT));

        }


        #endregion

        #region CommandMethods
        private void OnRemoveCompany()
        {
            DebtTrackerManager.RemoveTracker(CurrentSelection.DebtTracker);
            UpdateDTList();
        }

        private bool CanRemoveCompany()
        {
            return CurrentSelection != null;
        }

        private void OnAddCompany()
        {
            var found = false;
            if (NewCompany != null)
            {
                Console.WriteLine($"onaddcompany dtlist count = {DTList.Count}");
                foreach (var b in DTList)
                {
                    if (b.CompanyName.Equals(NewCompany, StringComparison.CurrentCultureIgnoreCase))
                    {
                        found = true;
                    }
                }
                if (!found && NewCompany.Length > 0)
                {
                    var dt = new DebtTracker
                    {
                        CompanyName = NewCompany
                    };

                    DebtTrackerManager.AddTracker(dt);
                    Console.WriteLine($"bill tracker manager count {BillTrackerManager.AllTrackers.Count}");
                    UpdateDTList();
                }
            }

            NewCompany = "";


        }

        private bool CanAddCompany()
        {
            return true;
        }

        private void OnEditCompany()
        {
            var found = false;
            if (NewCompany != null)
            {
                //CurrentSelection.CompanyName = NewCompany;
                var tempDT = CurrentSelection.DebtTracker;
                DebtTrackerManager.RemoveTracker(tempDT);
                tempDT.CompanyName = NewCompany;
                DebtTrackerManager.AddTracker(tempDT);
                //BillTrackerManager.TrackersByCompany[CurrentSelection.CompanyName].CompanyName = NewCompany;
                UpdateDTList();

                //Console.WriteLine($"onaddcompany btlist count = {BTList.Count}");
                //foreach (var b in BTList)
                //{
                //    if (b.CompanyName.Equals(NewCompany, StringComparison.CurrentCultureIgnoreCase))
                //    {
                //        found = true;
                //    }
                //}
                //if (!found && NewCompany.Length > 0)
                //{
                //    var bt = new BillTracker
                //    {
                //        CompanyName = NewCompany
                //    };

                //    BillTrackerManager.AddTracker(bt);
                //    Console.WriteLine($"bill tracker manager count {BillTrackerManager.AllTrackers.Count}");
                //    UpdateBTList();
                //}
            }

            NewCompany = "";


        }

        private bool CanEditCompany()
        {
            return CurrentSelection != null;
        }

        private void OnOpenPopup()
        {
            if (!IsPopupOpen)
            {
                IsPopupOpen = true;
            }
        }

        private void OnEditOpenPopup()
        {
            if (!IsEditPopupOpen)
            {
                IsEditPopupOpen = true;
                NewCompany = CurrentSelection.CompanyName;
            }
        }

        private bool CanOpenPopup()
        {
            return true;
        }

        private bool CanEditOpenPopup()
        {
            return CurrentSelection != null;
        }

        #endregion

    }
}
