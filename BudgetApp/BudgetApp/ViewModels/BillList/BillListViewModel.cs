using BudgetApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.ViewModels
{
    class BillListViewModel : LocalBaseViewModel
    {

        public ObservableCollection<NextBillDueDataViewModel> BTList { get; set; } = new ObservableCollection<NextBillDueDataViewModel>();

        public bool IsEmptyBudget
        {
            get { return BillTrackerManager.AllTrackers.Count == 0; }
        }

        public BillListViewModel()
        {
            UpdateBTList();
        }

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
        }

        public override void UpdateView()
        {
            UpdateBTList();
        }

        
    }
}
