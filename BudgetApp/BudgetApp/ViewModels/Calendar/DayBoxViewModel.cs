﻿using IvieBaseClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BudgetApp.ViewModels
{
    public class DayBoxViewModel : LocalBaseViewModel
    {
        public ObservableCollection<DayBoxBillViewModel> Bills { get; set; } = new ObservableCollection<DayBoxBillViewModel>();

        public ICommand TestCommand { get; set; }
        public ICommand RightClickCommand { get; set; }

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

        private bool hitTestVisible = true;
        public bool HitTestVisible
        {
            get { return hitTestVisible; }
            set
            {
                if (hitTestVisible != value)
                {
                    hitTestVisible = value;
                    NotifyPropertyChanged();
                }
            }
        }



        public string Day => Date.Day.ToString();

        public DayBoxViewModel()
        {
            TestCommand = new DelegateCommand(OnTest, CanTest);
            RightClickCommand = new DelegateCommand(OnRightClick, CanRightClick);

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

        private void OnTest()
        {
            Console.WriteLine("Test Command");
        }

        private bool CanTest()
        {
            return true;
        }

        private void OnRightClick()
        {
            Console.WriteLine("RightClickCommand");
        }

        private bool CanRightClick()
        {
            return true;
        }




        public DayBoxViewModel(DateTime date)
        {
            Date = date;
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
