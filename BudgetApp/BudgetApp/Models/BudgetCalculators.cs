using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Models
{
    public class BudgetCalculators
    {
        public static DateTime FindNextPaycheck(DateTime firstPayDate)
        {
            var today = DateTime.Now;
            var delta = (today - firstPayDate).TotalDays;
            var paydayJump = delta - (delta % 14) + 14;
            var nextpaydate = firstPayDate.AddDays(paydayJump);
            return nextpaydate;
        }

        
    }
}
