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
    public class BillTrackerViewModel : LocalBaseViewModel
    {
        #region Fields
        private BillTracker BillTracker { get; set; }
        #endregion

        #region Properties
        public ObservableCollection<BillViewModel> Bills { get; set; } = new ObservableCollection<BillViewModel>();

        public ICommand AddCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand OpenAddBillCommand { get; set; }

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

        private bool isAddBillOpen;
        public bool IsAddBillOpen
        {
            get { return isAddBillOpen; }
            set
            {
                if (isAddBillOpen != value)
                {
                    isAddBillOpen = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool ShowStopDate
        {
            get
            {
                if(SelectedOption == DueDateFrequencies.Single)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                //switch (SelectedOption)
                //{
                //    case DueDateFrequencies.Single:
                //        return false;
                //    case DueDateFrequencies.OneWeek:

                //    case DueDateFrequencies.TwoWeek:

                //    case DueDateFrequencies.FourWeek:

                //    case DueDateFrequencies.Monthly:

                //    case DueDateFrequencies.Quarterly:
                //        return true;
                //    default:
                //        return false;
                        
                //}
            }
        }


        private DateTime addBillStartDate = DateTime.Today;
        public DateTime AddBillStartDate
        {
            get { return addBillStartDate; }
            set
            {
                if (addBillStartDate != value)
                {
                    addBillStartDate = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private DateTime addBillStopDate = DateTime.Today.AddMonths(1);
        public DateTime AddBillStopDate
        {
            get { return addBillStopDate; }
            set
            {
                if (addBillStopDate != value)
                {
                    addBillStopDate = value;
                    NotifyPropertyChanged();
                }
            }
        }


        private double addBillAmount = 0.0;
        public double AddBillAmount
        {
            get { return addBillAmount; }
            set
            {
                if (addBillAmount != value)
                {
                    addBillAmount = value;
                    NotifyPropertyChanged();
                }
            }
        }



        private DueDateFrequencies selectedOption = DueDateFrequencies.Single;
        public DueDateFrequencies SelectedOption
        {
            get { return selectedOption; }
            set
            {
                if (selectedOption != value)
                {
                    selectedOption = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged(nameof(ShowStopDate));
                }
            }
        }


        #endregion

        #region Constructors
        public BillTrackerViewModel(BillTracker iBillTracker)
        {
            BillTracker = iBillTracker;
            UpdateBills();
            AddCommand = new DelegateCommand(OnAdd, CanAdd);
            RemoveCommand = new DelegateCommand(OnRemove, CanRemove);
            OpenAddBillCommand = new DelegateCommand(OnOpenAddBill, CanOpenAddBill);
        }

        public BillTrackerViewModel() : this(new BillTracker()) { }
        #endregion

        #region Methods
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

        private void OnRemove()
        {
            var found = false;
            foreach (var b in BillTracker.Bills)
            {
                if (b.DueDate.Equals(CurrentBVM.DueDate))
                {
                    found = true;
                    break;
                }
            }
            if (found)
            {
                BillTracker.Bills.Remove(CurrentBVM.Bill);
                //Console.WriteLine(BillTracker.Bills.Count);
            }

            UpdateBills();
        }

        private bool CanRemove()
        {
            return CurrentBVM != null;
        }

        private void OnAdd()
        {
            var newBills = new List<Bill>();
            var numDays = (AddBillStopDate - AddBillStartDate).TotalDays;
            var numWeeks = 0;
            var numMonths = 0;
            double dayCount = 0;

            switch (SelectedOption)
            {
                case DueDateFrequencies.Single:
                    var newBill = new Bill()
                    {
                        DueDate = AddBillStartDate,
                        AmountDue = AddBillAmount
                    };
                    newBills.Add(newBill);

                    break;

                case DueDateFrequencies.OneWeek:
                    while (dayCount < numDays)
                    {
                        dayCount = (AddBillStartDate.AddDays(7*(numWeeks+1)) - AddBillStartDate).TotalDays;
                        numWeeks++;
                    }
                    //Console.WriteLine($"weeks of bills = {numWeeks}");

                    for (int i = 0; i < numWeeks; i++)
                    {
                        newBills.Add(new Bill(AddBillAmount, AddBillStartDate.AddDays(7*i)));
                    }

                    break;

                case DueDateFrequencies.TwoWeek:
                    while (dayCount < numDays)
                    {
                        dayCount = (AddBillStartDate.AddDays(14 * (numWeeks + 1)) - AddBillStartDate).TotalDays;
                        numWeeks++;
                    }
                    //Console.WriteLine($"weeks of bills = {numWeeks}");

                    for (int i = 0; i < numWeeks; i++)
                    {
                        newBills.Add(new Bill(AddBillAmount, AddBillStartDate.AddDays(14 * i)));
                    }

                    break;

                case DueDateFrequencies.FourWeek:
                    while (dayCount < numDays)
                    {
                        dayCount = (AddBillStartDate.AddDays(28 * (numWeeks + 1)) - AddBillStartDate).TotalDays;
                        numWeeks++;
                    }
                    //Console.WriteLine($"weeks of bills = {numWeeks}");

                    for (int i = 0; i < numWeeks; i++)
                    {
                        newBills.Add(new Bill(AddBillAmount, AddBillStartDate.AddDays(28 * i)));
                    }

                    break;

                case DueDateFrequencies.Monthly:
                    while(dayCount < numDays)
                    {
                        dayCount = (AddBillStartDate.AddMonths(numMonths + 1) - AddBillStartDate).TotalDays;
                        numMonths++;
                    }
                    //Console.WriteLine($"Months of bills = {numMonths}");

                    for(int i = 0; i < numMonths; i++)
                    {
                        newBills.Add(new Bill(AddBillAmount, AddBillStartDate.AddMonths(i)));
                    }
                    
                    break;

                case DueDateFrequencies.Quarterly:
                    while (dayCount < numDays)
                    {
                        dayCount = (AddBillStartDate.AddMonths(3*(numMonths + 1)) - AddBillStartDate).TotalDays;
                        numMonths++;
                    }
                    //Console.WriteLine($"Months of bills = {numMonths}");

                    for (int i = 0; i < numMonths; i++)
                    {
                        newBills.Add(new Bill(AddBillAmount, AddBillStartDate.AddMonths(3*i)));
                    }

                    break;
                default:
                    break;
            }


            foreach(var bill in newBills)
            {
                var found = false;
                foreach (var b in BillTracker.Bills)
                {
                    if (b.DueDate.Equals(bill.DueDate))
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    BillTracker.Bills.Add(bill);

                }


            }
            //var bill = new Bill()
            //{
            //    DueDate = AddBillStartDate,
            //    AmountDue = AddBillAmount
            //};
            //var found = false;
            //foreach (var b in BillTracker.Bills)
            //{
            //    if (b.DueDate.Equals(bill.DueDate))
            //    {
            //        found = true;
            //        break;
            //    }
            //}
            //if (!found)
            //{
            //    BillTracker.Bills.Add(bill);

            //}

            BillTracker.Bills.Sort();
            //CurrentBT.UpdateBills();
            UpdateBills();
            //CurrentBT.UpdateNextBill();
            IsAddBillOpen = false;
        }

        private bool CanAdd()
        {
            return true;
        }

        private void OnOpenAddBill()
        {
            if (!IsAddBillOpen)
            {
                IsAddBillOpen = true;
            }
        }

        private bool CanOpenAddBill()
        {
            return true;
        }

        public void UpdateBills()
        {
            Bills.Clear();
            foreach (var bill in BillTracker.Bills)
            {
                Bills.Add(new BillViewModel(bill));
            }
            UpdateContentAvailable();
        }

        #endregion
        
    }
}


