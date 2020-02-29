using BudgetApp.Models;
using IvieBaseClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BudgetApp.ViewModels
{
    public class WeekViewModel : LocalBaseViewModel
    {
        public ObservableCollection<DayBoxViewModel> DayList { get; set; } = new ObservableCollection<DayBoxViewModel>();

    }
}
