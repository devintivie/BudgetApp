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
    public class DebtTracker : BaseINPC, IComparable<DebtTracker>
    {
        public List<Debt> Debts { get; set; } = new List<Debt>();

        public string CompanyName { get; set; }

        public DebtTracker()
        {
            CompanyName = "No Name";
        }

        public DebtTracker(string name, Debt firstDebt)
        {
            CompanyName = name;
            Debts.Add(firstDebt);
        }

        public DebtTracker(string name, List<Debt> list)
        {
            Debts = new List<Debt>();
            CompanyName = name;
            Debts.Clear();
            foreach (var b in list)
            {
                Debts.Add(b);
            }
        }


        public int CompareTo(DebtTracker other)
        {
            if (other == null) return 1;
            else
                return CompanyName.CompareTo(other.CompanyName);
        }
    }
}
