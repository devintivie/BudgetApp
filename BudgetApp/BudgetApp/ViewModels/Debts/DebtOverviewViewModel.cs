using BudgetApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BudgetApp.ViewModels
{
    public class DebtOverviewViewModel : LocalBaseViewModel
    {
        #region Properties
        private ObservableCollection<string> dtList;
        public ObservableCollection<string> DTList
        {
            get { return dtList; }
            set
            {
                if (dtList != value)
                {
                    dtList = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string currentSelection;
        public string CurrentSelection
        {
            get { return currentSelection; }
            set
            {
                if (currentSelection != value)
                {
                    currentSelection = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion


        #region Commands
        public ICommand AddAccountCommand { get; set; }
        public ICommand RemoveAccountCommand { get; set; }
        public ICommand OpenPopupCommand { get; set; }
        #endregion

        #region Constructors
        public DebtOverviewViewModel()
        {
            DTList = new ObservableCollection<string>();
            UpdateDTList();
        }
        #endregion
        

        public void UpdateDTList()
        {
            DTList.Clear();
            var tempList = new List<string>();

            foreach(var item in DebtTrackerManager.AllTrackers)
            {
                tempList.Add(item.CompanyName);
            }

            tempList.Sort();
            DTList = new ObservableCollection<string>(tempList);
        }

    }
}
