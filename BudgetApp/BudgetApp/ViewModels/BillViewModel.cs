using BudgetApp.Models;
using IvieBaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.ViewModels
{
    public class BillViewModel : LocalBaseViewModel
    {
        private Bill Bill { get; set; }

        public DateTime DueDate
        {
            get { return Bill.DueDate; }
            set
            {
                if (Bill.DueDate != value)
                {
                    Bill.DueDate = value;
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
                    Console.WriteLine(Bill.AmountDue.ToString("C"));
                }
            }
        }

        public string Confirmation
        {
            get { return Bill.Confirmation; }
            set
            {
                if (Bill.Confirmation != value)
                {
                    Bill.Confirmation = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool IsPaid
        {
            get { return Bill.IsPaid; }
            set
            {
                if (Bill.IsPaid != value)
                {
                    Bill.IsPaid = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public BillViewModel(Bill iBill)
        {
            Bill = iBill;
        }

        public BillViewModel()
        {
            Bill = new Bill();
        }


    }
}
