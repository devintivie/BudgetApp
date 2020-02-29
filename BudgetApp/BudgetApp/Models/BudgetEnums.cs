using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp
{
    public enum DueDateFrequencies
    {
        Single,
        OneWeek,
        TwoWeek,
        FourWeek,
        Monthly,
        Quarterly,

    }

    public enum CalendarOptions
    {
        OneWeek,
        TwoWeek,
        FourWeek,
        FiveWeek,
        EightWeek,
    }

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum PayDateFrequencies
    {
        Weekly,
        Biweekly,
        FirstAndMid,
    }

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum Navigation
    {
        Calendar,
        [Description("Bills List")]
        BillList,
        [Description("Banking Overview")]
        BankOverview,
        [Description("Debt Overview")]
        DebtOverview
    }

}
