using BudgetApp.Models;
using IvieBaseClasses;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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
        private static string DEFAULT_FILENAME = @"C:\Users\devin\OneDrive\Documents\VisualStudioFiles\new_budget.xml";

        

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
                    NotifyPropertyChanged();
                }
            }
        }

        //private bool showCurrentBT = true;
        //public bool ShowCurrentBT
        //{
        //    get { return showCurrentBT; }
        //    set
        //    {
        //        if (showCurrentBT != value)
        //        {
        //            showCurrentBT = value;
        //            NotifyPropertyChanged();
        //        }
        //    }
        //}



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
                    Console.WriteLine("Current Selection Changed");
                    //UpdateBTList();
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

        private string filename = DEFAULT_FILENAME;
        public string Filename
        {
            get { return filename; }
            set
            {
                if (filename != value)
                {
                    filename = value;
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

        private bool isNewBudget = true;
        public bool IsNewBudget
        {
            get { return isNewBudget; }
            set
            {
                if (isNewBudget != value)
                {
                    isNewBudget = value;
                    NotifyPropertyChanged();
                }
            }
        }



        public bool IsEmptyBudget
        {
            get { return BillTrackerManager.AllTrackers.Count == 0; }
        }





        public DelegateCommand AddCompanyCommand { get; set; }
        public DelegateCommand RemoveCompanyCommand { get; set; }
        public DelegateCommand AddBillCommand { get; set; }
        public DelegateCommand EditBillCommand { get; set; }
        public DelegateCommand RemoveBillCommand { get; set; }
        public DelegateCommand NewCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand SaveAsCommand { get; set; }
        public DelegateCommand OpenCommand { get; set; }
        public DelegateCommand BillChangedCommand { get; set; }
        public ICommand UpdateBTListCommand { get; set; }
        public ICommand OpenPopupCommand { get; set; }

        public DelegateCommand ClosingCommand { get; set; }

        public MainWindowViewModel()
        {
            

            AddCompanyCommand = new DelegateCommand(OnAddCompany, CanAddCompany);
            RemoveCompanyCommand = new DelegateCommand(OnRemoveCompany, CanRemoveCompany);
            OpenPopupCommand = new DelegateCommand(OnOpenPopup, CanOpenPopup);
            
            //EditBillCommand = new DelegateCommand(OnEditBill, CanEditBill);
            //BillChangedCommand = new DelegateCommand(OnBillChanged, CanBillChanged);
            NewCommand = new DelegateCommand(OnNew, CanNew);
            SaveCommand = new DelegateCommand(OnSave, CanSave);
            SaveAsCommand = new DelegateCommand(OnSaveAs, CanSaveAs);
            OpenCommand = new DelegateCommand(OnOpen, CanOpen);
            ClosingCommand = new DelegateCommand(ExecuteClosing, CanExecuteClosing);
            UpdateBTListCommand = new DelegateCommand(OnUpdateBTList, CanUpdateBTList);

            OnNew();

        }

        private void UpdateCurrentBTVM()
        {
            Console.WriteLine(BillTrackerManager.TrackerCount);
            if(CurrentSelection == null)
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

                
            

            
        }

        private void Startup()
        {
            Console.WriteLine("Startup methods ran");
            BTList = new ObservableCollection<NextBillDueDataViewModel>();
            Bills = new ObservableCollection<Bill>();
            BTVM = new BillTrackerViewModel();
            DataList = new ObservableCollection<NextBillDueDataViewModel>();
            
            //UpdateBTList();
            UpdateCurrentBTVM();
        }
        private void OnUpdateBTList()
        {

            //BTList.Clear();
            UpdateBTList();
            Console.WriteLine("List Updated");
        }

        private bool CanUpdateBTList()
        {
            return true;

        }

        //private void OnBillChanged()
        //{
        //    CurrentBill.DueDate = BVM.DueDate;
        //    CurrentBill.Confirmation = BVM.Confirmation;
        //    CurrentBill.IsPaid = BVM.IsPaid;
        //    CurrentBill.AmountDue = BVM.AmountDue;
        //    //UpdateBills();
        //}

        //private bool CanBillChanged()
        //{
        //    return CurrentBill != null;
        //}

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
            BillTrackerManager.TrackersByCompany.Remove(CurrentSelection.CompanyName);
            BillTrackerManager.AllTrackers.Remove(CurrentSelection.BillTracker);
            UpdateBTList();
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
                    if (b.CompanyName.Equals(NewCompany, StringComparison.CurrentCultureIgnoreCase))
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

        private void OnNew()
        {
            Startup();
            IsNewBudget = true;
            Filename = DEFAULT_FILENAME;
        }

        private bool CanNew()
        {
            return true;
        }

        private void SaveFile()
        {
            var bm = new BudgetModel();

            foreach (BillTracker bt in BillTrackerManager.AllTrackers)
            {
                bm.AddBillTracker(bt);
            }

            bm.Serialize(Filename);
            IsNewBudget = false;

        }

        private void OnSave()
        {
            if (IsNewBudget)
            {
                OnSaveAs();
                
            }
            else
            {
                SaveFile();

            }


        }

        private bool CanSave()
        {
            return true;
        }

        private void OnSaveAs()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "xml files (*.xml)|*.xml",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if ( (bool)saveFileDialog.ShowDialog())
            {
                Filename = saveFileDialog.FileName;
                SaveFile();
            }

            //SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            //saveFileDialog1.FilterIndex = 2;
            //saveFileDialog1.RestoreDirectory = true;

            //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    if ((myStream = saveFileDialog1.OpenFile()) != null)
            //    {
            //        // Code to write the stream goes here.
            //        myStream.Close();
            //    }
            //}
            



        }

        private bool CanSaveAs()
        {
            return true;
        }

        private void OnOpen()
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //if (openFileDialog.ShowDialog() == true)
            //{
            //    Console.WriteLine(openFileDialog.FileName);
            //}

            Filename = @"C:\Users\devin\OneDrive\Documents\VisualStudioFiles\xml_test.xml";

            BillTrackerManager.Reset();
            var bm = BudgetModel.Deserialize(Filename);
            foreach (BillTracker bt in bm.BudgetData)
            {
                BillTrackerManager.TrackersByCompany.Add(bt.CompanyName, bt);
                BillTrackerManager.AllTrackers.Add(bt);
                Console.WriteLine(bt.CompanyName);
            }

            UpdateBTList();
            IsNewBudget = false;

        }

        private bool CanOpen()
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

            NotifyPropertyChanged(nameof(IsEmptyBudget));



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
