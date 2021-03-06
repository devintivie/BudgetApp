﻿using BudgetApp.Models;
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
    class BillListViewModel : LocalBaseViewModel, INavigationViewModel
    {
        #region Properties
        public ObservableCollection<NextBillDueDataViewModel> BTList { get; set; } = new ObservableCollection<NextBillDueDataViewModel>();

        public bool IsEmptyBudget
        {
            get { return BillTrackerManager.AllTrackers.Count == 0; }
        }

        public bool ShowCurrentBT
        {
            get
            {
                if ((BillTrackerManager.TrackerCount == 0) || CurrentSelection == null)
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

        private NextBillDueDataViewModel currentSelection;
        public NextBillDueDataViewModel CurrentSelection
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
                    UpdateCurrentBTVM();
                }
            }
        }

        private BillTrackerViewModel currentBT;
        public BillTrackerViewModel CurrentBT
        {
            get { return currentBT; }
            set
            {
                if (currentBT != value)
                {
                    currentBT = value;
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


        //void OnMessage(Message message)
        //{
        //    if (message.MessageType == MessageType.BillViewModel)
        //    {
        //        //UpdateBTList();
        //        if(CurrentSelection != null)
        //            CurrentSelection.UpdateNextBill();
        //        Console.WriteLine("UpdateBTList from BillViewModel");
        //    }
        //}

        void OnVMUpdate()
        {
            if(CurrentSelection != null)
            {
                CurrentSelection.UpdateNextBill();
                Console.WriteLine("UpdateBTList from BillViewModel");
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
        public BillListViewModel()
        {
            AddCompanyCommand = new DelegateCommand(OnAddCompany, CanAddCompany);
            EditCompanyCommand = new DelegateCommand(OnEditCompany, CanEditCompany);
            RemoveCompanyCommand = new DelegateCommand(OnRemoveCompany, CanRemoveCompany);
            OpenPopupCommand = new DelegateCommand(OnOpenPopup, CanOpenPopup);
            OpenEditPopupCommand = new DelegateCommand(OnEditOpenPopup, CanEditOpenPopup);
            //Messenger.Default.Register<Message>(this, OnMessage);
            Messenger.Register<VMtoVM>(this, x=> OnVMUpdate());

            UpdateBTList();
        }
        #endregion


        #region Methods
        private void UpdateBTList()
        {
            BTList.Clear();
            var tempList = new List<BillTracker>();
            Console.WriteLine($"UpdateBTList tracker count = {BillTrackerManager.AllTrackers.Count}");

            foreach (var b in BillTrackerManager.AllTrackers)
            {
                tempList.Add(b);
                tempList.Sort();
            }
            foreach (var b in tempList)
            {
                BTList.Add(new NextBillDueDataViewModel(b));
            }

            NotifyPropertyChanged(nameof(IsEmptyBudget));
            Console.WriteLine(IsEmptyBudget);
        }

        public void UpdateView()//was an override before
        {
            UpdateBTList();
        }

        private void UpdateCurrentBTVM()
        {
            Console.WriteLine(BillTrackerManager.TrackerCount);
            if (CurrentSelection == null)
            {

                if (BillTrackerManager.TrackerCount == 0)
                {
                    CurrentBT = new BillTrackerViewModel();
                }
                else
                {
                    CurrentBT = new BillTrackerViewModel(BillTrackerManager.AllTrackers[0]);
                }

            }
            else
            {
                //if(BillTrackerManager.TrackersByCompany.ContainsKey(CurrentSelection.CompanyName))
                //{
                CurrentBT = new BillTrackerViewModel(BillTrackerManager.TrackersByCompany[CurrentSelection.CompanyName]);
                //    showCurrentBT = true;
                //}
                //else
                //{
                //    CurrentBT = new BillTrackerViewModel();
                //    showCurrentBT = true;
                //}

            }

            NotifyPropertyChanged(nameof(ShowCurrentBT));

        }


        #endregion

        #region CommandMethods
        private void OnRemoveCompany()
        {
            BillTrackerManager.RemoveTracker(CurrentSelection.BillTracker);
            UpdateBTList();
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
                Console.WriteLine($"onaddcompany btlist count = {BTList.Count}");
                foreach (var b in BTList)
                {
                    if (b.CompanyName.Equals(NewCompany, StringComparison.CurrentCultureIgnoreCase))
                    {
                        found = true;
                    }
                }
                if (!found && NewCompany.Length > 0)
                {
                    var bt = new BillTracker
                    {
                        CompanyName = NewCompany
                    };

                    BillTrackerManager.AddTracker(bt);
                    Console.WriteLine($"bill tracker manager count {BillTrackerManager.AllTrackers.Count}");
                    UpdateBTList();
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
                var tempBT = CurrentSelection.BillTracker;
                BillTrackerManager.RemoveTracker(tempBT);
                tempBT.CompanyName = NewCompany;
                BillTrackerManager.AddTracker(tempBT);
                //BillTrackerManager.TrackersByCompany[CurrentSelection.CompanyName].CompanyName = NewCompany;
                UpdateBTList();

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
