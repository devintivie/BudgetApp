using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp
{
    public enum BillStatus
    {
        Paid,
        PastDue,
        DueToday,
        DueTomorrow,
        DueWithinTwoWeeks,
        DueWithinOneMonth,
        DueInOverOneMonth,
        NoneDue,
    }
}
