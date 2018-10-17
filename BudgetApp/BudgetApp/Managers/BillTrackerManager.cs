using BudgetApp.Models;
using IvieBaseClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BudgetApp.Managers
{
    public class BillTrackerManager : BaseINPC
    {
        #region Singleton
        private static BillTrackerManager instance;

        public static BillTrackerManager Instance
        {
            get { return instance ?? (instance = new BillTrackerManager()); }
        }

        private BillTrackerManager() { }
        #endregion Singleton

        public Dictionary<string, BillTracker> TrackersByCompany { get; set; } = new Dictionary<string, BillTracker>();
        public ObservableCollection<BillTracker> AllTrackers { get; set; } = new ObservableCollection<BillTracker>();

        private BillTracker selectedTracker;
        public BillTracker SelectedTracker
        {
            get { return selectedTracker; }
            set
            {
                if (selectedTracker != value)
                {
                    selectedTracker = value;
                    NotifyPropertyChanged();
                }
            }
        }


        private int trackerCount;
        public int TrackerCount
        {
            get { return trackerCount; }
            set
            {
                if (trackerCount != value)
                {
                    trackerCount = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private void UpdateTrackerCount()
        {
            TrackerCount = AllTrackers.Count;
        }

        public void AddTracker(BillTracker bt)
        {
            if (!AllTrackers.Contains(bt))
            {
                TrackersByCompany.Add(bt.CompanyName, bt);
                AllTrackers.Add(bt);
            }
        }

        public void AddTracker(string name, List<Bill> bills)
        {
            if (!TrackersByCompany.ContainsKey(name))
            {
                var tracker = new BillTracker(name, bills);
            }
        }

        public void RemoveTracker(BillTracker bt)
        {
            AllTrackers.Remove(bt);
            TrackersByCompany.Remove(bt.CompanyName);
        }

        public void RemoveTracker(string name)
        {
            if(TrackersByCompany.TryGetValue(name, out var tracker))
            {
                RemoveTracker(tracker);
            }
        }

        public void Reset()
        {
            TrackersByCompany.Clear();
            AllTrackers.Clear();
            SelectedTracker = null;
        }

        //public void Serialize(string Filename)
        //{
        //    var xs = new XmlSerializer(typeof(BillTrackerManager));

        //    FileStream fsout = new FileStream(Filename, FileMode.Create, FileAccess.Write);
        //    try
        //    {
        //        using (fsout)
        //        {
        //            xs.Serialize(fsout, this);
        //            Console.WriteLine("Object Serialized");
        //        }
        //    }
        //    catch
        //    {
        //        Console.WriteLine("An error has occured");
        //    }
        //}
    }
}
 