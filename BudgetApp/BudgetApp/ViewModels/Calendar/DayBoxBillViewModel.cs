using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.ViewModels
{
    public class DayBoxBillViewModel : LocalBaseViewModel
    {
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

        private BillStatus status;
        public BillStatus Status
        {
            get { return status; }
            set
            {
                if (status != value)
                {
                    status = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public DayBoxBillViewModel(string name)
        {
            CompanyName = name;
        }

        public DayBoxBillViewModel(string name, BillStatus iStatus)
        {
            CompanyName = name;
            Status = iStatus;
        }


    }
}
