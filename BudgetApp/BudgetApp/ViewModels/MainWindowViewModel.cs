using BudgetApp.Models;
using IvieBaseClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BudgetApp.ViewModels
{
    public class MainWindowViewModel : LocalBaseViewModel
    {
        public ObservableCollection<BillViewModel> BillList { get; set; } = new ObservableCollection<BillViewModel>();
        public ObservableCollection<NextBillDueDataViewModel> BTList { get; set; }
        public ObservableCollection<Bill> Bills { get; set; }
        public ObservableCollection<NextBillDueDataViewModel> DataList { get; set; }

        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

        private readonly DateTime firstPaydate = DateTime.Today;

        private readonly string filename = "xml_test.xml";

        private BillViewModel bvm;
        public BillViewModel BVM
        {
            get { return bvm; }
            set
            {
                if (bvm != value)
                {
                    bvm = value;
                    Console.WriteLine("hello");
                    NotifyPropertyChanged();
                }
            }
        }

        private BillTrackerViewModel btvm;
        public BillTrackerViewModel BTVM
        {
            get { return btvm; }
            set
            {
                if (btvm != value)
                {
                    btvm = value;
                    NotifyPropertyChanged();
                }
            }
        }


        private Bill currentBill;
        public Bill CurrentBill
        {
            get { return currentBill; }
            set
            {
                if (currentBill != value)
                {
                    currentBill = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private BillViewModel currentBVM;
        public BillViewModel CurrentBVM
        {
            get { return currentBVM; }
            set
            {
                if (currentBVM != value)
                {
                    currentBVM = value;
                    NotifyPropertyChanged();
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


                    //Bills.Clear();
                    //if(CurrentBT != null)
                    //{
                    //    foreach (var b in CurrentBT.Bills)
                    //    {
                    //        Bills.Add(b);
                    //    }
                    //}

                    Console.WriteLine("current bill tracker changed");

                    NotifyPropertyChanged();
                    
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
                    currentSelection = value;
                    NotifyPropertyChanged();
                    UpdateCurrentBTVM();
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

        private double appWindowHeight = 400;
        public double AppWindowHeight
        {
            get { return appWindowHeight; }
            set
            {
                if (appWindowHeight != value)
                {
                    appWindowHeight = value;
                    NotifyPropertyChanged();
                }
            }
        }



        public DelegateCommand AddCompanyCommand { get; set; }
        public DelegateCommand RemoveCompanyCommand { get; set; }
        public DelegateCommand AddBillCommand { get; set; }
        public DelegateCommand EditBillCommand { get; set; }
        public DelegateCommand RemoveBillCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand LoadCommand { get; set; }
        public DelegateCommand BillChangedCommand { get; set; }

        public DelegateCommand ClosingCommand { get; set; }

        public MainWindowViewModel()
        {
            BTList = new ObservableCollection<NextBillDueDataViewModel>();
            Bills = new ObservableCollection<Bill>();
            BTVM = new BillTrackerViewModel();

            DataList = new ObservableCollection<NextBillDueDataViewModel>();

            var newBill = new Bill(150, 7, 12);
            var newBT = new BillTracker
            {
                CompanyName = "Some other company"
            };
            newBT.Bills.Add(newBill);
            var somedata = new NextBillDueDataViewModel(newBT);
            DataList.Add(somedata);

            AddCompanyCommand = new DelegateCommand(OnAddCompany, CanAddCompany);
            RemoveCompanyCommand = new DelegateCommand(OnRemoveCompany, CanRemoveCompany);
            //AddBillCommand = new DelegateCommand(OnAddBill, CanAddBill);
            EditBillCommand = new DelegateCommand(OnEditBill, CanEditBill);
            BillChangedCommand = new DelegateCommand(OnBillChanged, CanBillChanged);
            //RemoveBillCommand = new DelegateCommand(OnRemoveBill, CanRemoveBill);
            SaveCommand = new DelegateCommand(OnSave, CanSave);
            LoadCommand = new DelegateCommand(OnLoad, CanLoad);
            ClosingCommand = new DelegateCommand(ExecuteClosing, CanExecuteClosing);

            //firstPaydate = new DateTime(2018, 6, 15);
            

            BVM = new BillViewModel(new Bill());
            bvm.DueDate = DateTime.Today;

            //var bill1 = new Bill(5, 10);
            //var bill2 = new Bill(7, 15);
            //var mylist = new List<Bill>();

            //mylist.Add(bill1);
            //mylist.Add(bill2);
            //var bt = new BillTracker("USAA", mylist);
            //var bt2 = new BillTracker("Cox", mylist);

            //CurrentBT = new BillTrackerDataViewModel(bt);

            //BillTrackerManager.AddTracker(bt);
            //BillTrackerManager.AddTracker(bt2);
            UpdateBTList();
            OnLoad();
            UpdateCurrentBTVM();

        }

        private void UpdateCurrentBTVM()
        {
            if(CurrentSelection == null)
            {
                CurrentBT = new BillTrackerViewModel(BillTrackerManager.AllTrackers[0]);
            }
            else
            {
                CurrentBT = new BillTrackerViewModel(BillTrackerManager.TrackersByCompany[CurrentSelection.CompanyName]);
            }

                
            

            
        }



        private void OnEditBill()
        {
            BVM.DueDate = CurrentBill.DueDate;
            BVM.Confirmation = CurrentBill.Confirmation;
            BVM.IsPaid = CurrentBill.IsPaid;
            BVM.AmountDue = CurrentBill.AmountDue;

        }

        private bool CanEditBill()
        {
            return CurrentBill != null;
        }

        private void OnBillChanged()
        {
            CurrentBill.DueDate = BVM.DueDate;
            CurrentBill.Confirmation = BVM.Confirmation;
            CurrentBill.IsPaid = BVM.IsPaid;
            CurrentBill.AmountDue = BVM.AmountDue;
            //UpdateBills();
        }

        private bool CanBillChanged()
        {
            return CurrentBill != null;
        }

        //private void OnRemoveBill()
        //{
        //    var found = false;
        //    foreach (var b in CurrentBT.Bills)
        //    {
        //        if (b.DueDate.Equals(CurrentBill.DueDate))
        //        {
        //            found = true;
        //        }
        //    }
        //    if (found)
        //    {
        //        CurrentBT.Bills.Remove(CurrentBVM);//     .Bills.Remove(CurrentBill);
        //        Console.WriteLine(CurrentBT.Bills.Count);
        //    }

        //    CurrentBT.UpdateBills();
        //    UpdateBills();
        //    //CurrentBT.UpdateNextBill();
        //}

        private bool CanRemoveBill()
        {
            return CurrentBill != null;
        }

        //private void OnAddBill()
        //{
        //    var bill = new Bill
        //    {
        //        DueDate = BVM.DueDate,
        //        AmountDue = BVM.AmountDue
        //    };
        //    var found = false;
        //    foreach(var b in CurrentBT.Bills)
        //    {
        //        if (b.DueDate.Equals(bill.DueDate))
        //        {
        //            found = true;
        //        }
        //    }
        //    if (!found)
        //    {
        //        CurrentBT.Bills.Add(bill);
        //    }
            
        //    CurrentBT.UpdateBills();
        //    UpdateBills();
        //    //CurrentBT.UpdateNextBill();
        //}

        private bool CanAddBill()
        {
            if(BVM != null && CurrentBill != null)
            {
                //return CurrentBT != null;// 
                return true;// CurrentBT.BillDueDateUsed(BVM.DueDate);
            }
            else
            {
                return false;
            }
            
        }

        private void OnRemoveCompany()
        {
            //BillTrackerManager.TrackersByCompany.Remove(CurrentBT.CompanyName);
            //BillTrackerManager.AllTrackers.Remove(CurrentBT.BillTracker);
            //UpdateBTList();
        }

        private bool CanRemoveCompany()
        {
            return CurrentBT != null;
        }

        private void OnAddCompany()
        {

            var found = false;
            if(NewCompany != null)
            {
                foreach (var b in BTList)
                {
                    if (b.CompanyName.Equals(NewCompany))
                    {
                        found = true;
                    }
                }
                if (!found && NewCompany.Length>0)
                {
                    var bt = new BillTracker
                    {
                        CompanyName = NewCompany
                    };
                    BillTrackerManager.TrackersByCompany.Add(bt.CompanyName, bt);
                    BillTrackerManager.AllTrackers.Add(bt);
                    UpdateBTList();
                }
            }
            
            NewCompany = "";
            
            
        }

        private bool CanAddCompany()
        {
            return true;
        }

        private void OnSave()
        {
            var bm = new BudgetModel();
            foreach (BillTracker bt in BillTrackerManager.AllTrackers)
            {
                bm.AddBillTracker(bt);
            }
            bm.Serialize(filename);
        }

        private bool CanSave()
        {
            return true;
        }

        private void OnLoad()
        {
            BillTrackerManager.Reset();
            var bm = BudgetModel.Deserialize(filename);
            foreach (BillTracker bt in bm.BudgetData)
            {
                BillTrackerManager.TrackersByCompany.Add(bt.CompanyName, bt);
                BillTrackerManager.AllTrackers.Add(bt);
                Console.WriteLine(bt.CompanyName);
            }

            UpdateBTList();

        }

        private bool CanLoad()
        {
            return true;
        }


        private void UpdateBTList()
        {
            BTList.Clear();
            var tempList = new List<BillTracker>();
            foreach (var b in BillTrackerManager.AllTrackers)
            {
                tempList.Add(b);
                tempList.Sort();
            }
            foreach (var b in tempList)
            {
                BTList.Add(new NextBillDueDataViewModel(b));
            }
            
        }

        //private void UpdateBills()
        //{
        //    Bills.Clear();
        //    foreach (var b in CurrentBT.Bills)
        //    {
        //        Bills.Add(b);
        //    }
        //}

        private void ExecuteClosing()
        {
            MessageBox.Show("CLosing");
        }

        private bool CanExecuteClosing()
        {
            return MessageBox.Show("OK to close?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes;

        }


    }
}
