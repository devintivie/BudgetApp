﻿using BudgetApp.Models;
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
    public class BudgetCalendarViewModel : LocalBaseViewModel, INavigationViewModel
    {
        public ObservableCollection<DayBoxViewModel> DayList { get; set; } = new ObservableCollection<DayBoxViewModel>();
        public ObservableCollection<string> TestItems { get; set; } = new ObservableCollection<string>();
        public List<string> DayOfWeekString { get; set; } = new List<string>();
        public ObservableCollection<BankAccountBalanceViewModel> Accounts { get; set; } = new ObservableCollection<BankAccountBalanceViewModel>();
        public ObservableCollection<DayBoxBillViewModel> Bills { get; set; } = new ObservableCollection<DayBoxBillViewModel>();

        public ICommand PrevTimeCommand { get; set; }
        public ICommand NextTimeCommand { get; set; }
        public ICommand DoubleClickCommand { get; set; }
        public ICommand RightClickCommand { get; set; }
        public ICommand ConnectCommand { get; set; }

        private DayBoxViewModel selectedDBVM;
        public DayBoxViewModel SelectedDBVM
        {
            get { return selectedDBVM; }
            set
            {
                if (selectedDBVM != value)
                {
                    selectedDBVM = value;
                    if(SelectedDBVM != null)
                    {
                        Console.WriteLine(SelectedDBVM.Date);
                    }
                    
                    NotifyPropertyChanged();
                    //if(SelectedDBVM != null)
                    //    MonthYear = SelectedDBVM.Date;
                    //NotifyPropertyChanged(nameof(SelectedDate));

                }
            }
        }

        private bool testConnected = false;
        public bool TestConnected
        {
            get { return testConnected; }
            set
            {
                if (testConnected != value)
                {
                    testConnected = value;
                    NotifyPropertyChanged();
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
                    Console.WriteLine(MonthYear);
                    NotifyPropertyChanged();
                }
            }
        }
        private DateTime currPaydate = DateTime.Today;
        public DateTime CurrPaydate
        {
            get { return currPaydate; }
            set
            {
                if (currPaydate != value)
                {
                    currPaydate = value;
                    //UpdateCalendar();
                    CalculatePaycheckTotal();
                    NotifyPropertyChanged();
                }
            }
        }

        private DateTime nextPaydate;
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



        private double totalDue;
        public double TotalDue
        {
            get { return totalDue; }
            set
            {
                if (totalDue != value)
                {
                    totalDue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private double bankBalance;
        public double BankBalance
        {
            get { return bankBalance; }
            set
            {
                if (bankBalance != value)
                {
                    bankBalance = value;
                    CalculateBalance();
                    NotifyPropertyChanged();
                }
            }
        }

        private double remainingBalance;
        public double RemainingBalance
        {
            get { return remainingBalance; }
            set
            {
                if (remainingBalance != value)
                {
                    remainingBalance = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private CalendarOptions selectedOption = CalendarOptions.FiveWeek;
        public CalendarOptions SelectedOption
        {
            get { return selectedOption; }
            set
            {
                if (selectedOption != value)
                {
                    selectedOption = value;
                    UpdateCalendar();
                    NotifyPropertyChanged();
                }
            }
        }

        private PayDateFrequencies payDateFrequency = PayDateFrequencies.Biweekly;
        public PayDateFrequencies PayDateFrequency
        {
            get { return payDateFrequency; }
            set
            {
                if (payDateFrequency != value)
                {
                    payDateFrequency = value;
                    UpdateCalendar();
                    NotifyPropertyChanged();
                }
            }
        }

        private bool isTextBoxFocused;
        public bool IsTextBoxFocused
        {
            get { return isTextBoxFocused; }
            set
            {
                if (isTextBoxFocused != value)
                {
                    isTextBoxFocused = value;
                    Console.WriteLine(IsTextBoxFocused);
                    NotifyPropertyChanged();
                }
            }
        }

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




        public BudgetCalendarViewModel()
        {
            MonthYear = DateTime.Today;
            PrevTimeCommand = new DelegateCommand(OnPrevTime, CanPrevTime);
            NextTimeCommand = new DelegateCommand(OnNextTime, CanNextTime);
            DoubleClickCommand = new DelegateCommand(OnDoubleClick, CanDoubleClick);
            ConnectCommand = new DelegateCommand(OnConnect);

            Messenger.Register<StringMessage>(this, x => UpdateAccountList());

            //Messenger.Default.Register<Message>(this, OnMessage);

            TestItems.Add("hello");
            TestItems.Add("it me");
            TestItems.Add("Adele");

            BVM = new BillViewModel();
            UpdateView();
        }

        //private void OnMessage(Message message)
        //{
        //    if (message.MessageType == MessageType.BankAccountBalanceViewModel)
        //    {
        //        UpdateAccountList();
        //    }
        //}

        private void OnConnect()
        {
            TestConnected = true;
        }

        public void UpdateView()//was an override before
        {

            UpdateAccountList();
            UpdateCalendar();
            
        }

        public void UpdateCalendar()
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

            

            var weeks = 0;
            switch (SelectedOption)
            {
                case CalendarOptions.OneWeek:
                    weeks = 1;
                    break;

                case CalendarOptions.TwoWeek:
                    weeks = 3;
                    break;

                case CalendarOptions.FourWeek:
                    weeks = 4;
                    break;

                case CalendarOptions.FiveWeek:
                    weeks = 5;
                    break;

                case CalendarOptions.EightWeek:
                    weeks = 8;
                    break;
            }

            for (int i = 0; i < weeks*7; i++)
            {
                var date = MonthYear.AddDays(startDay + i);
                DayList.Add(new DayBoxViewModel(date));

            }

            MonthYear = MonthYear.AddDays(startDay);
            CalculatePaycheckTotal();
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

        private void OnDoubleClick()
        {
            Console.WriteLine("Double Click attached property");
            //CurrPaydate
            //Console.WriteLine(SelectedDBVM.Date);
            if(selectedDBVM != null)
            {
                CurrPaydate = SelectedDBVM.Date;
            }
            
        }

        private bool CanDoubleClick()
        {
            return true;
        }

        private void OnRightClick()
        {
            Console.WriteLine("Right Click attached property");
            //CurrPaydate
            //Console.WriteLine(SelectedDBVM.Date);
            //CurrPaydate = SelectedDBVM.Date;
        }

        private bool CanRightClick()
        {
            return true;
        }

        private void OnPrevTime()
        {
            MonthYear = MonthYear.AddDays(-7);
            UpdateCalendar();
        }

        private void CalculatePaycheckTotal()
        {
            double subtotal = 0;
            foreach (var acct in Accounts)
            {
                acct.Deductions = 0;
            }
            foreach (var daybox in DayList)
            {
                daybox.SelectStatus = false;
                var startDate = CurrPaydate;
                var endDate = (PayDateFrequency == PayDateFrequencies.Biweekly) ? startDate.AddDays(14) : startDate.AddDays(7);

                if( (daybox.Date.CompareTo(startDate) >= 0) && (daybox.Date.CompareTo(endDate) < 0))
                {
                    daybox.SelectStatus = true;
                    foreach(var bill in daybox.Bills)
                    {
                        subtotal += bill.AmountDue;
                        foreach( var acct in Accounts)
                        {
                            if (acct.UniqueID.Equals(bill.AccountID))
                            {
                                acct.Deductions += bill.AmountDue;
                            }
                        }
                    }
                }
            }

            TotalDue = subtotal;
            CalculateBalance();
        }

        private void CalculateBalance()
        {
            RemainingBalance = BankBalance - TotalDue;
        }

        private void UpdateAccountList()
        {
            Accounts.Clear();
            var tempList = new List<BankAccount>();
            Console.WriteLine($"Update bank account tracker count = {BankAccountManager.AllAccounts.Count}");

            foreach (var b in BankAccountManager.AllAccounts)
            {
                tempList.Add(b);
            }
            foreach (var b in tempList)
            {
                Accounts.Add(new BankAccountBalanceViewModel(b));
            }

        }
    }
}
