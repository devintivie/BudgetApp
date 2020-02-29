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
    public class DebtTrackerManager : BaseINPC
    {
        #region Singleton
        private static DebtTrackerManager instance;
        public static DebtTrackerManager Instance
        {
            get { return instance ?? (instance = new DebtTrackerManager()); }
        }

        private DebtTrackerManager() { }
        #endregion Singleton

        public Dictionary<string, DebtTracker> TrackersByCompany { get; set; } = new Dictionary<string, DebtTracker>();
        public List<DebtTracker> AllTrackers { get; set; } = new List<DebtTracker>();

        private DebtTracker selectedTracker;
        public DebtTracker SelectedTracker
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
                    Console.WriteLine($"debt tracker notify count = {TrackerCount}");
                }
            }
        }

        private void UpdateTrackerCount()
        {
            TrackerCount = AllTrackers.Count;
        }

        public void AddTracker(DebtTracker dt)
        {
            if (!AllTrackers.Contains(dt))
            {
                TrackersByCompany.Add(dt.CompanyName, dt);
                AllTrackers.Add(dt);
            }
            UpdateTrackerCount();
        }

        public void AddTracker(string name, List<Debt> debts)
        {
            if (!TrackersByCompany.ContainsKey(name))
            {
                var tracker = new DebtTracker(name, debts);
            }
            UpdateTrackerCount();
        }

        public void RemoveTracker(DebtTracker dt)
        {
            AllTrackers.Remove(dt);
            TrackersByCompany.Remove(dt.CompanyName);
            UpdateTrackerCount();
        }

        public void RemoveTracker(string name)
        {
            if (TrackersByCompany.TryGetValue(name, out var tracker))
            {
                RemoveTracker(tracker);
            }
            UpdateTrackerCount();
        }

        public void Reset()
        {
            TrackersByCompany.Clear();
            AllTrackers.Clear();
            SelectedTracker = null;
            UpdateTrackerCount();
        }

        //public void Serialize(string Filename)
        //{
        //    var xs = new XmlSerializer(typeof(DebtTrackerManager));

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
