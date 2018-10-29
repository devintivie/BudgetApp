using BudgetApp.Models;
using IvieBaseClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.ViewModels
{
    public class BillTrackerViewModel : LocalBaseViewModel
    {
        private BillTracker BillTracker { get; set; }

        public ObservableCollection<BillViewModel> Bills { get; set; } = new ObservableCollection<BillViewModel>();

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
            get { return BillTracker.CompanyName; }
            set
            {
                if (BillTracker.CompanyName != value)
                {
                    BillTracker.CompanyName = value;
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



        public BillTrackerViewModel()
        {
            BillTracker = new BillTracker();
            UpdateContentAvailable();
        }

        public BillTrackerViewModel(BillTracker iBillTracker)
        {
            BillTracker = iBillTracker;
            Bills.Clear();
            foreach(var bill in iBillTracker.Bills)
            {
                Bills.Add(new BillViewModel(bill));
            }
            UpdateContentAvailable();
        }

        private void UpdateContentAvailable()
        {
            if(Bills.Count > 0)
            {
                IsContentAvailable = true;
            }
            else
            {
                IsContentAvailable = false;
            }
        }


    }
}







/* FOR REFERENCE */
//public ObservableCollection<BillViewModel> BillList { get; set; } = new ObservableCollection<BillViewModel>();

//private BillViewModel currentBVM;
//public BillViewModel CurrentBVM
//{
//    get { return currentBVM; }
//    set
//    {
//        if (currentBVM != value)
//        {
//            currentBVM = value;
//            Console.WriteLine($"current bill view model changed now {CurrentBVM.AmountDue}");
//            NotifyPropertyChanged();
//        }
//    }
//}

//private Bill currentBill;
//public Bill CurrentBill
//{
//    get { return currentBill; }
//    set
//    {
//        if (currentBill != value)
//        {
//            currentBill = value;
//            NotifyPropertyChanged();
//        }
//    }
//}

//private string companyName;
//public string CompanyName
//{
//    get { return companyName; }
//    set
//    {
//        if (companyName != value)
//        {
//            companyName = value;
//            NotifyPropertyChanged();
//        }
//    }
//}


//public DelegateCommand EditCommand { get; set; }
//public DelegateCommand AddCommand { get; set; }
//public DelegateCommand RemoveCommand { get; set; }

//public BillTrackerViewModel(DateTime firstPaycheck)
//{
//    //BTList = new ObservableCollection<BillTrackerDataViewModel>();
//    //Bills = new ObservableCollection<Bill>();

//    ////UpdateCommand = new DelegateCommand(OnEdit, CanEdit);
//    //AddCommand = new DelegateCommand(OnAdd, CanAdd);
//    //RemoveCommand = new DelegateCommand(OnRemove, CanRemove);

//    //BVM = new BillViewModel(new Bill());
//    //BTVM = new BillTrackerViewModel(firstPaydate);
//    //bvm.DueDate = DateTime.Today;

//    //var bill1 = new Bill(5,10);
//    //var bill2 = new Bill(7,15);
//    //var mylist = new List<Bill>();

//    //mylist.Add(bill1);
//    //mylist.Add(bill2);
//    //var bt = new BillTracker("USAA", mylist);
//    //var bt2 = new BillTracker("Cox", mylist);

//    //CurrentBT = new BillTrackerDataViewModel(bt);

//    //BillTrackerManager.AddTracker(bt);
//    //BillTrackerManager.AddTracker(bt2);
//    //UpdateBTList();

//}

//public BillTrackerViewModel()
//{
//    companyName = "this fucking shit";
//    BillList.Add(new BillViewModel(new Bill(60, 5, 6)));
//    BillList.Add(new BillViewModel(new Bill(80, 6, 6)));
//    BillList.Add(new BillViewModel(new Bill(100, 7, 6)));
//}

///*private void OnRemove()
//{
//    var found = false;
//    foreach (var b in CurrentBT.BillTracker.Bills)
//    {
//        if (b.DueDate.Equals(CurrentBill.DueDate))
//        {
//            found = true;
//        }
//    }
//    if (found)
//    {
//        CurrentBT.BillTracker.Bills.Remove(CurrentBill);
//        Console.WriteLine(CurrentBT.BillTracker.Bills.Count);
//    }

//    CurrentBT.UpdateBills();
//    UpdateBills();
//    CurrentBT.UpdateNextBill();
//}

//private bool CanRemove()
//{
//    return CurrentBill != null;
//}

//private void OnAdd()
//{
//    var bill = new Bill
//    {
//        DueDate = BVM.DueDate,
//        AmountDue = BVM.AmountDue
//    };
//    var found = false;
//    foreach (var b in CurrentBT.BillTracker.Bills)
//    {
//        if (b.DueDate.Equals(bill.DueDate))
//        {
//            found = true;
//        }
//    }
//    if (!found)
//    {
//        CurrentBT.BillTracker.Bills.Add(bill);
//    }

//    CurrentBT.UpdateBills();
//    UpdateBills();
//    CurrentBT.UpdateNextBill();
//}

//private bool CanAdd()
//{
//    return true;
//}

//private void OnEdit()
//{
//    var bill = new Bill
//    {
//        DueDate = BVM.DueDate,
//        AmountDue = BVM.AmountDue
//    };
//    CurrentBT.BillTracker.Bills.Add(bill);
//    CurrentBT.UpdateBills();
//    UpdateBills();
//    CurrentBT.UpdateNextBill();
//}

//private bool CanEdit()
//{
//    return true;
//}*/


////public void UpdateBTList()
////{
////    BTList.Clear();
////    foreach (var b in BillTrackerManager.AllTrackers)
////    {
////        BTList.Add(new BillTrackerDataViewModel(b, firstPaydate));
////    }
////}

////public void UpdateBills()
////{
////    Bills.Clear();
////    foreach (var b in CurrentBT.Bills)
////    {
////        Bills.Add(b);
////    }
////}