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
    public class BudgetCalendarViewModel : LocalBaseViewModel
    {
        public ObservableCollection<DayBoxViewModel> DayList { get; set; } = new ObservableCollection<DayBoxViewModel>();
        
        public ICommand PrevTimeCommand { get; set; }
        public ICommand NextTimeCommand { get; set; }

        private DayBoxViewModel selectedDBVM;
        public DayBoxViewModel SelectedDBVM
        {
            get { return selectedDBVM; }
            set
            {
                if (selectedDBVM != value)
                {
                    selectedDBVM = value;
                    NotifyPropertyChanged();
                    if(SelectedDBVM != null)
                        MonthYear = SelectedDBVM.Date;
                    //NotifyPropertyChanged(nameof(SelectedDate));

                }
            }
        }
        
        private DateTime monthYear;
        public DateTime MonthYear
        {
            get { return monthYear; }
            set
            {
                if (monthYear != value)
                {
                    monthYear = value;
                    
                    NotifyPropertyChanged();
                }
            }
        }


        public BudgetCalendarViewModel()
        {
            MonthYear = DateTime.Today;
            PrevTimeCommand = new DelegateCommand(OnPrevTime, CanPrevTime);
            NextTimeCommand = new DelegateCommand(OnNextTime, CanNextTime);

            UpdateCalendar();



        }

        private void UpdateCalendar()
        {
            var startDay = 0;
            DayList.Clear();
            switch (MonthYear.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    Console.WriteLine("today is sunday");
                    startDay = 0;
                    break;
                case DayOfWeek.Monday:
                    Console.WriteLine("today is Monday");
                    startDay = -1;
                    break;
                case DayOfWeek.Tuesday:
                    Console.WriteLine("today is Tuesday");
                    startDay = -2;
                    break;
                case DayOfWeek.Wednesday:
                    Console.WriteLine("today is Wednesday");
                    startDay = -3;
                    break;
                case DayOfWeek.Thursday:
                    Console.WriteLine("today is Thursday");
                    startDay = -4;
                    break;
                case DayOfWeek.Friday:
                    Console.WriteLine("today is Friday");
                    startDay = -5;
                    break;
                case DayOfWeek.Saturday:
                    Console.WriteLine("today is Saturday");
                    startDay = -6;
                    break;
            }

            for (int i = 0; i < 28; i++)
            {
                var date = MonthYear.AddDays(startDay + i);
                DayList.Add(new DayBoxViewModel(date));

            }
        }

        private bool CanNextTime()
        {
            return true;
        }

        private void OnNextTime()
        {
            MonthYear = MonthYear.AddDays(7);
            UpdateCalendar();
        }

        private bool CanPrevTime()
        {
            return true;
        }

        private void OnPrevTime()
        {
            MonthYear = MonthYear.AddDays(-7);
            UpdateCalendar();
        }
    }
}
