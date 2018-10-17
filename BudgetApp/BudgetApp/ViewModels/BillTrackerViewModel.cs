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
    public class BillTrackerViewModel : BaseViewModel
    {
        public ObservableCollection<BillViewModel> BillList { get; set; } = new ObservableCollection<BillViewModel>();
        //public ObservableCollection<BillTrackerDataViewModel> BTList { get; set; }
        //public ObservableCollection<Bill> Bills { get; set; }
        //private DateTime firstPaydate;

        private BillViewModel bvm;
        public BillViewModel BVM
        {
            get { return bvm; }
            set
            {
                if (bvm != value)
                {
                    bvm = value;
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

        //private BillTrackerViewModel btvm;
        //public BillTrackerViewModel BTVM
        //{
        //    get { return btvm; }
        //    set
        //    {
        //        if (btvm != value)
        //        {
        //            btvm = value;
        //            NotifyPropertyChanged();
        //        }
        //    }
        //}

        private BillTrackerDataViewModel currentBT;
        public BillTrackerDataViewModel CurrentBT
        {
            get { return currentBT; }
            set
            {
                if (currentBT != value)
                {
                    currentBT = value;
                    Console.WriteLine(CurrentBT.CompanyName);
                    Bills.Clear();
                    foreach (var b in CurrentBT.Bills)
                    {
                        Bills.Add(b);
                    }
                    NotifyPropertyChanged();
                }
            }
        }

        public DelegateCommand UpdateCommand { get; set; }
        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand RemoveCommand { get; set; }

        public BillTrackerViewModel(DateTime firstPaycheck)
        {
            //BTList = new ObservableCollection<BillTrackerDataViewModel>();
            //Bills = new ObservableCollection<Bill>();

            ////UpdateCommand = new DelegateCommand(OnUpdate, CanUpdate);
            //AddCommand = new DelegateCommand(OnAdd, CanAdd);
            //RemoveCommand = new DelegateCommand(OnRemove, CanRemove);

            BVM = new BillViewModel(new Bill());
            firstPaydate = firstPaycheck;
            BTVM = new BillTrackerViewModel(firstPaydate);
            //bvm.DueDate = DateTime.Today;

            //var bill1 = new Bill(5,10);
            //var bill2 = new Bill(7,15);
            //var mylist = new List<Bill>();

            //mylist.Add(bill1);
            //mylist.Add(bill2);
            //var bt = new BillTracker("USAA", mylist);
            //var bt2 = new BillTracker("Cox", mylist);

            //CurrentBT = new BillTrackerDataViewModel(bt);

            //BillTrackerManager.AddTracker(bt);
            //BillTrackerManager.AddTracker(bt2);
            //UpdateBTList();

        }

        private void OnRemove()
        {
            var found = false;
            foreach (var b in CurrentBT.BillTracker.Bills)
            {
                if (b.DueDate.Equals(CurrentBill.DueDate))
                {
                    found = true;
                }
            }
            if (found)
            {
                CurrentBT.BillTracker.Bills.Remove(CurrentBill);
                Console.WriteLine(CurrentBT.BillTracker.Bills.Count);
            }

            CurrentBT.UpdateBills();
            UpdateBills();
            CurrentBT.UpdateNextBill();
        }

        private bool CanRemove()
        {
            return CurrentBill != null;
        }

        private void OnAdd()
        {
            var bill = new Bill();
            bill.DueDate = BVM.DueDate;
            bill.AmountDue = BVM.AmountDue;
            var found = false;
            foreach (var b in CurrentBT.BillTracker.Bills)
            {
                if (b.DueDate.Equals(bill.DueDate))
                {
                    found = true;
                }
            }
            if (!found)
            {
                CurrentBT.BillTracker.Bills.Add(bill);
            }

            CurrentBT.UpdateBills();
            UpdateBills();
            CurrentBT.UpdateNextBill();
        }

        private bool CanAdd()
        {
            return true;
        }

        private void OnUpdate()
        {
            var bill = new Bill();
            bill.DueDate = BVM.DueDate;
            bill.AmountDue = BVM.AmountDue;
            CurrentBT.BillTracker.Bills.Add(bill);
            CurrentBT.UpdateBills();
            UpdateBills();
            CurrentBT.UpdateNextBill();
        }

        private bool CanUpdate()
        {
            return true;
        }


        private void UpdateBTList()
        {
            BTList.Clear();
            foreach (var b in BillTrackerManager.AllTrackers)
            {
                BTList.Add(new BillTrackerDataViewModel(b, firstPaydate));
            }
        }

        private void UpdateBills()
        {
            Bills.Clear();
            foreach (var b in CurrentBT.Bills)
            {
                Bills.Add(b);
            }
        }

    }
}
