using BudgetApp.Models;
using IvieBaseClasses;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BudgetApp.ViewModels
{
    public class BudgetOverviewViewModel : LocalBaseViewModel
    {
        public ObservableCollection<NextBillDueDataViewModel> BTList { get; set; }

        private NextBillDueDataViewModel currentSelection;
        public NextBillDueDataViewModel CurrentSelection
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

        private double appWindowHeight;
        public double AppWindowHeight
        {
            get { return appWindowHeight; }
            set
            {
                if (appWindowHeight != value)
                {
                    appWindowHeight = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public DelegateCommand AddCompanyCommand { get; set; }
        public DelegateCommand RemoveCompanyCommand { get; set; }


        public BudgetOverviewViewModel()
        {
            BTList = new ObservableCollection<NextBillDueDataViewModel>();
            UpdateBTList();

        }
        

        private void OnRemoveCompany()
        {
            //BillTrackerManager.TrackersByCompany.Remove(CurrentBT.CompanyName);
            //BillTrackerManager.AllTrackers.Remove(CurrentBT.BillTracker);
            //UpdateBTList();
        }

        private bool CanRemoveCompany()
        {
            return CurrentSelection != null;
        }

        private void OnAddCompany()
        {

            //var found = false;
            //if(NewCompany != null)
            //{
            //    foreach (var b in BTList)
            //    {
            //        if (b.CompanyName.Equals(NewCompany))
            //        {
            //            found = true;
            //        }
            //    }
            //    if (!found && NewCompany.Length>0)
            //    {
            //        var bt = new BillTracker
            //        {
            //            CompanyName = NewCompany
            //        };
            //        BillTrackerManager.TrackersByCompany.Add(bt.CompanyName, bt);
            //        BillTrackerManager.AllTrackers.Add(bt);
            //        UpdateBTList();
            //    }
            //}
            
            //NewCompany = "";
            
            
        }

        private bool CanAddCompany()
        {
            return true;
        }

        public void UpdateBTList()
        {
            BTList.Clear();
            var tempList = new List<BillTracker>();


                foreach (var b in BillTrackerManager.AllTrackers)
                {
                    tempList.Add(b);
                    tempList.Sort();
                }
                foreach (var b in tempList)
                {
                    BTList.Add(new NextBillDueDataViewModel(b));
                }
            }
            
            
        


    }
}
