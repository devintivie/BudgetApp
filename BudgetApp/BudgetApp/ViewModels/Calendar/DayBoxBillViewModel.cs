using BudgetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.ViewModels
{
    public class DayBoxBillViewModel : LocalBaseViewModel
    {
        public Bill Bill { get; private set; }

        private string companyName;
        public string CompanyName
        {
            get { return companyName; }
            set
            {
                if (companyName != value)
                {
                    companyName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public BillStatus Status
        {
            get { return Bill.BillStatus; }
            set
            {
                if (Bill.BillStatus != value)
                {
                    Bill.BillStatus = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public double AmountDue
        {
            get { return Bill.AmountDue; }
            set
            {
                if (Bill.AmountDue != value)
                {
                    Bill.AmountDue = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public string AccountID
        {
            get { return Bill.AccountID; }
            set
            {
                if (Bill.AccountID != value)
                {
                    Bill.AccountID = value;
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




        public DayBoxBillViewModel(string name)
        {
            CompanyName = name;
            Bill = new Bill();
            BVM = new BillViewModel(Bill);

        }

        public DayBoxBillViewModel(string name, Bill iBill)
        {
            CompanyName = name;
            Bill = iBill;
            BVM = new BillViewModel(Bill);
        }


    }
}
