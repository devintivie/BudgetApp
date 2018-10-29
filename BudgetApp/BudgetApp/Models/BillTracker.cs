using IvieBaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace BudgetApp.Models
{
    [Serializable]
    public class BillTracker : BaseINPC, IComparable<BillTracker>
    {
        public List<Bill> Bills { get; set; } = new List<Bill>();

        public string CompanyName { get; set; }

        public BillTracker()
        {
            CompanyName = "No Name";
        }

        public BillTracker(string name, Bill firstBill)
        {
            CompanyName = name;
            Bills.Add(firstBill);
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
