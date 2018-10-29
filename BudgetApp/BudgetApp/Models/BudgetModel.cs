using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BudgetApp.Models
{
    [Serializable]
    public class BudgetModel
    {
        #region Properties
        public List<BillTracker> BudgetData { get; set; } = new List<BillTracker>();
        #endregion Properties

        #region Constructors
        public BudgetModel()
        {
            
        }
        #endregion Constructors

        #region Methods
        public void AddBillTracker(BillTracker nBT)
        {
            if (!(BillTrackerExists(nBT)))
            {
                BudgetData.Add(nBT);
                BudgetData.Sort();
            }
        }

        public void RemoveBillTracker(BillTracker nBT)
        {
            BudgetData.Remove(nBT);
        }

        public bool BillTrackerExists(BillTracker btCheck)
        {

            foreach (BillTracker tracker in BudgetData)
            {
                if (btCheck.Equals(tracker))
                {
                    return true;
                }
            }

            return false;
        }

        //private int FindBillTracker(BillTracker btComparison)
        //{
        //    var locIndex = 0;
        //    foreach (BillTracker btsearch in BudgetData)
        //    {
        //        if (btsearch.Equals(btComparison))
        //        {
        //            return locIndex;
        //        }
        //    }
        //    return -1; ;
        //}

        

        

        public override string ToString()
        {
            string tempString = "";
            foreach (BillTracker data in BudgetData)
            {
                tempString += data.ToString() + "\n";
            }
            return tempString;
        }

        public void Serialize(string Filename)
        {
            var xs = new XmlSerializer(typeof(BudgetModel));

            FileStream fsout = new FileStream(Filename, FileMode.Create, FileAccess.Write);
            try
            {
                using (fsout)
                {
                    xs.Serialize(fsout, this);
                    Console.WriteLine("Object Serialized");
                }
            }
            catch
            {
                Console.WriteLine("An error has occured");
            }
        }

        public static BudgetModel Deserialize(string Filename)
        {
            BudgetModel newBD = new BudgetModel();
            XmlSerializer xs = new XmlSerializer(typeof(BudgetModel));

            try
            {
                FileStream fsin = new FileStream(Filename, FileMode.Open, FileAccess.Read);
                using (fsin)
                {
                    newBD = (BudgetModel)xs.Deserialize(fsin);
                    Console.WriteLine("Object Deserialized");
                    Console.WriteLine(newBD.ToString() + "TEsting");
                }
            }

            catch (FileNotFoundException ex)
            {
                newBD.Serialize(Filename);
                Console.WriteLine("File Created");
                //Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine();
            }

            return newBD;
        }

        #endregion Methods
    }
}
