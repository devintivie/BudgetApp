using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.ViewModels
{
    public class DayBoxViewModel : LocalBaseViewModel
    {
        public ObservableCollection<DayBoxBillViewModel> Bills { get; set; } = new ObservableCollection<DayBoxBillViewModel>();

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                if (date != value)
                {
                    date = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged(nameof(Day));
                }
            }
        }

        private bool selectStatus = false;
        public bool SelectStatus
        {
            get { return selectStatus; }
            set
            {
                if (selectStatus != value)
                {
                    selectStatus = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public string Day => Date.Day.ToString();

        public DayBoxViewModel()
        {
            Console.WriteLine("DayBoxViewModel called");
            foreach (var bt in BillTrackerManager.AllTrackers)
            {
                foreach (var bill in bt.Bills)
                {
                    if (Date.Equals(bill.DueDate))
                    {
                        Console.WriteLine("bill added to calendar");
                        Bills.Add(new DayBoxBillViewModel(bt.CompanyName));
                    }
                }
            }
            
        }

        public DayBoxViewModel(DateTime date)
        {
            Date = date;
            Console.WriteLine("DayBoxViewModel called");
            foreach (var bt in BillTrackerManager.AllTrackers)
            {
                foreach (var bill in bt.Bills)
                {
                    if (Date.Equals(bill.DueDate))
                    {
                        Console.WriteLine("bill added to calendar");
                        Bills.Add(new DayBoxBillViewModel(bt.CompanyName, bill));
                    }
                }
            }
        }



    }
}
