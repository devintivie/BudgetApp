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
        public ObservableCollection<NextBillDueDataViewModel> BTList { get; set; } = new ObservableCollection<NextBillDueDataViewModel>();
        public ObservableCollection<MultiplePaycheckViewModel> BudgetDisplay { get; set; } = new ObservableCollection<MultiplePaycheckViewModel>();
        public ObservableCollection<BankAccount> BAList { get; set; } = new ObservableCollection<BankAccount>();

        
        //public ObservableCollection<NextBillDueDataViewModel> DataList { get; set; }

        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;
        private readonly DateTime firstPaydate = DateTime.Today;
        private static string DEFAULT_FILENAME = @"C:\Users\devin\OneDrive\Documents\VisualStudioFiles\new_budget.xml";



        //private BillViewModel bvm;
        //public BillViewModel BVM
        //{
        //    get { return bvm; }
        //    set
        //    {
        //        if (bvm != value)
        //        {
        //            bvm = value;
        //            //Console.WriteLine("hello");
        //            NotifyPropertyChanged();
        //        }
        //    }
        //}



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

        public bool ShowCurrentBT
        {
            get
            {
                if( (BillTrackerManager.TrackerCount == 0) || CurrentSelection == null)
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

        private BudgetCalendarViewModel budgetCalendar = new BudgetCalendarViewModel();
        public BudgetCalendarViewModel BudgetCalendar
        {
            get { return budgetCalendar; }
            set
            {
                if (budgetCalendar != value)
                {
                    budgetCalendar = value;
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
                    //Console.WriteLine("Current Selection Changed");
                    //UpdateBTList();
                }
            }
        }

        private MultiplePaycheckViewModel mpvm;
        public MultiplePaycheckViewModel MPVM
        {
            get { return mpvm; }
            set
            {
                if (mpvm != value)
                {
                    mpvm = value;
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

        private string newAccount = "help";
        public string NewAccount
        {
            get { return newAccount; }
            set
            {
                if (newAccount != value)
                {
                    newAccount = value;
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

        private DateTime currPaydate = DateTime.Now;
        public DateTime CurrPaydate
        {
            get { return currPaydate; }
            set
            {
                if (currPaydate != value)
                {
                    currPaydate = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private DateTime prevPaydate = DateTime.Now.AddDays(-14);
        public DateTime PrevPaydate
        {
            get { return prevPaydate; }
            set
            {
                if (prevPaydate != value)
                {
                    prevPaydate = value;
                    NotifyPropertyChanged();
                }
            }
        }


        


        private DateTime nextPaydate = DateTime.Now.AddDays(14);
        public DateTime NextPaydate
        {
            get { return nextPaydate; }
            set
            {
                if (nextPaydate != value)
                {
                    nextPaydate = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool IsEmptyBudget
        {
            get { return BillTrackerManager.AllTrackers.Count == 0; }
        }

        public ICommand AddCompanyCommand { get; set; }
        public ICommand RemoveCompanyCommand { get; set; }
        public ICommand AddAccountCommand { get; set; }
        public ICommand RemoveAccountCommand { get; set; }
        public ICommand AddBillCommand { get; set; }
        public ICommand EditBillCommand { get; set; }
        public ICommand RemoveBillCommand { get; set; }
        public ICommand NewCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand SaveAsCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        public ICommand BillChangedCommand { get; set; }
        public ICommand UpdateBTListCommand { get; set; }
        public ICommand OpenPopupCommand { get; set; }
        public ICommand OpenAccountPopupCommand { get; set; }

        public ICommand TestAsyncCommand { get; set; }

        public DelegateCommand ClosingCommand { get; set; }

        public MainWindowViewModel()
        {
            

            AddCompanyCommand = new DelegateCommand(OnAddCompany, CanAddCompany);
            RemoveCompanyCommand = new DelegateCommand(OnRemoveCompany, CanRemoveCompany);
            OpenPopupCommand = new DelegateCommand(OnOpenPopup, CanOpenPopup);
            AddAccountCommand = new DelegateCommand(OnAddAccount, CanAddAccount);
            RemoveAccountCommand = new DelegateCommand(OnRemoveAccount, CanRemoveAccount);
            OpenAccountPopupCommand = new DelegateCommand(OnOpenAccountPopup, CanOpenAccountPopup);

            //EditBillCommand = new DelegateCommand(OnEditBill, CanEditBill);
            //BillChangedCommand = new DelegateCommand(OnBillChanged, CanBillChanged);
            NewCommand = new DelegateCommand(OnNew, CanNew);
            SaveCommand = new DelegateCommand(OnSave, CanSave);
            SaveAsCommand = new DelegateCommand(OnSaveAs, CanSaveAs);
            OpenCommand = new DelegateCommand(OnOpen, CanOpen);
            ClosingCommand = new DelegateCommand(ExecuteClosing, CanExecuteClosing);
            UpdateBTListCommand = new DelegateCommand(OnUpdateBTList, CanUpdateBTList);

            //Use this for processes that may take time
            //TestAsyncCommand = new DelegateCommand(async() => await OnTest(), CanTest);

            MPVM = new MultiplePaycheckViewModel();



            OnNew();

        }

        private async Task OnTest()
        {
            await Task.Delay(5000);
            Console.WriteLine("printing test");
            
                
        }

        private bool CanTest()
        {
            return true;
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

            NotifyPropertyChanged(nameof(ShowCurrentBT));






        }

        private void Startup()
        {
            //Console.WriteLine("Startup methods ran");
            BillTrackerManager.Reset();

            BTList.Clear();
            
            UpdateBTList();
            UpdateCurrentBTVM();
        }

        private void OnUpdateBTList()
        {

            //BTList.Clear();
            UpdateBTList();
            //Console.WriteLine("List Updated");
        }

        private bool CanUpdateBTList()
        {
            return true;

        }

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
            if(NewCompany != null)
            {
                Console.WriteLine($"onaddcompany btlist count = {BTList.Count}");
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

                    BillTrackerManager.AddTracker(bt);
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                //Console.WriteLine(openFileDialog.FileName);
                Filename = openFileDialog.FileName;
            }

            //Filename = @"C:\Users\devin\OneDrive\Documents\VisualStudioFiles\xml_test.xml";

            BillTrackerManager.Reset();
            var bm = BudgetModel.Deserialize(Filename);
            foreach (BillTracker bt in bm.BudgetData)
            {
                BillTrackerManager.AddTracker(bt);
            }

            foreach (var acct in bm.BankAccounts)
            {
                BankAccountManager.AddAccount(acct);
            }

            UpdateBTList();
            CurrentSelection = null;
            IsNewBudget = false;
            BudgetCalendar = new BudgetCalendarViewModel();

        }

        private bool CanOpen()
        {
            return true;
        }

        private void UpdateBTList()
        {
            BTList.Clear();
            BudgetDisplay.Clear();
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
                BudgetDisplay.Add(new MultiplePaycheckViewModel(b, PrevPaydate, CurrPaydate, NextPaydate));
            }

            NotifyPropertyChanged(nameof(IsEmptyBudget));
        }

        

        private void UpdateBAList()
        {
            BAList.Clear();
            var tempList = new List<BankAccount>();
            Console.WriteLine($"UpdateBTList tracker count = {BankAccountManager.AllAccounts.Count}");

            foreach (var b in BankAccountManager.AllAccounts)
            {
                tempList.Add(b);
                tempList.Sort();
            }
            foreach (var b in tempList)
            {
                BAList.Add(b);
            }

        }

        private void OnRemoveAccount()
        {
            Console.WriteLine("Remove Account");
            //BankAccountManager.RemoveAccount(CurrentAccount.BankAccount)
            //BillTrackerManager.RemoveTracker(CurrentSelection.BillTracker);
            //UpdateBTList();
        }

        private bool CanRemoveAccount()
        {
            return false; // CurrentSelection != null;
        }

        private void OnAddAccount()
        {
            var found = false;
            if (NewAccount != null)
            {
                Console.WriteLine($"onaddaccount {NewAccount}");
                foreach (var b in BAList)
                {
                    Console.WriteLine($"foreach b info {b.Nickname}");
                    if (b.Nickname.Equals(NewAccount, StringComparison.CurrentCultureIgnoreCase))
                    {
                        Console.WriteLine("bank account found");
                        found = true;
                    }
                }
                if (!found && NewAccount.Length > 0)
                {
                    Console.WriteLine("not found, now lets add a new account");
                    var ba = new BankAccount
                    {
                        Nickname = NewAccount
                    };

                    BankAccountManager.AddAccount(ba);
                    UpdateBAList();
                }
            }
            else
            {
                Console.WriteLine("new account == null");
            }

            Console.WriteLine("reset new account field");
            NewAccount = "";


        }

        private bool CanAddAccount()
        {
            return true;
        }

        private void OnOpenAccountPopup()
        {
            if (!IsPopupOpen)
            {
                IsPopupOpen = true;
            }
        }

        private bool CanOpenAccountPopup()
        {
            return true;
        }






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
