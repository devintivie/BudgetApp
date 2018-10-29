using BudgetApp.Managers;
using IvieBaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.ViewModels
{
    public class LocalBaseViewModel : BaseViewModel
    {
        public BillTrackerManager BillTrackerManager => BillTrackerManager.Instance;
    }

}
