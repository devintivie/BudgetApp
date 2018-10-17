using BudgetApp.Models;
using IvieBaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.ViewModels
{
    public class BillViewModel : BaseViewModel
    {
        private DateTime dueDate;
        public DateTime DueDate
        {
            get { return dueDate; }
            set
            {
                if (dueDate != value)
                {
                    dueDate = value;
                    NotifyPropertyChanged();
                    Console.WriteLine("bye");
                }
            }
        }

        private Double amountDue;
        public Double AmountDue
        {
            get { return amountDue; }
            set
            {
                if (amountDue != value)
                {
                    amountDue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string confirmation;
        public string Confirmation
        {
            get { return confirmation; }
            set
            {
                if (confirmation != value)
                {
                    confirmation = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private bool isPaid;
        public bool IsPaid
        {
            get { return isPaid; }
            set
            {
                if (isPaid != value)
                {
                    isPaid = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private Bill Bill { get; set; }

        public BillViewModel(Bill iBill)
        {
            Bill = iBill;
            DueDate = iBill.DueDate;
            AmountDue = iBill.AmountDue;
            Confirmation = iBill.Confirmation;
            IsPaid = iBill.IsPaid;
        }


    }
}
