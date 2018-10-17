using IvieBaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace BudgetApp.Models
{
    public class BillTrackerModel { }

    [Serializable]
    public class BillTracker : BaseINPC, IComparable<BillTracker>
    {
        public List<Bill> Bills { get; set; }

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

        public BillTracker()
        {
            CompanyName = "";
            Bills = new List<Bill>();
        }

        public BillTracker(string name, List<Bill> list)
        {
            Bills = new List<Bill>();
            CompanyName = name;
            Bills.Clear();
            foreach (var b in list)
            {
                Bills.Add(b);
            }
        }

        public int CompareTo(BillTracker other)
        {
            if (other == null) return 1;
            else
                return this.CompanyName.CompareTo(other.CompanyName);
        }
    }
}
