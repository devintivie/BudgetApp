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
    public class BaseViewModel : BaseINPC
    {
        public BillTrackerManager BillTrackerManager { get { return BillTrackerManager.Instance; } }
    }

    //Requires PropertyChanged.Fody from Nuget
    //[ImplementPropertyChanged]
    //public class BaseViewModel : INotifyPropertyChanged
    //{
    //    /// <summary>
    //    ///  
    //    /// </summary>
    //    public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    //}


}
