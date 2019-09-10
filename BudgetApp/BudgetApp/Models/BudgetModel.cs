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
        public string FriendlyName { get; set; } = "sample";
        public List<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
        public List<DebtTracker> Debts { get; set; } = new List<DebtTracker>();
        #endregion Properties

        #region Constructors
        public BudgetModel()
        {
            
        }
        #endregion Constructors

        #region Methods
        public void AddBillTracker(BillTracker nBT)
        {
            if (!BillTrackerExists(nBT))
            {
                BudgetData.Add(nBT);
                BudgetData.Sort();
            }
        }

        public void AddBankAccount(BankAccount nBA)
        {
            if (!BankAccountExists(nBA))
            {
                BankAccounts.Add(nBA);
            }
        }

        public void AddDebtTracker(DebtTracker nDT)
        {
            if (!DebtTrackerExists(nDT))
            {
                Debts.Add(nDT);
            }
        }

        public void RemoveBillTracker(BillTracker bt)
        {
            BudgetData.Remove(bt);
        }

        public void RemoveBankAccount(BankAccount ba)
        {
            BankAccounts.Remove(ba);
        }

        public void RemoveDebtTracker(DebtTracker dt)
        {
            Debts.Remove(dt);
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

        public bool BankAccountExists(BankAccount baCheck)
        {
            foreach(var account in BankAccounts)
            {
                if (baCheck.Equals(account))
                {
                    return true;
                }
            }
            return false;
        }

        public bool DebtTrackerExists(DebtTracker debtCheck)
        {
            foreach(var item in Debts)
            {
                if (debtCheck.Equals(item))
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

        

        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string tempString = "";
            foreach (BillTracker data in BudgetData)
            {
                tempString += data.ToString() + "\n";
            }
            return tempString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Filename"></param>
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
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                //Console.WriteLine("An error has occured");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Filename"></param>
        /// <returns></returns>
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
                   // Console.WriteLine("Object Deserialized");
                    //Console.WriteLine(newBD.ToString() + "TEsting");
                }
            }

            catch (FileNotFoundException ex)
            {
                newBD.Serialize(Filename);
                //Console.WriteLine("File Created");
                Console.WriteLine(ex.ToString());
            }
            //finally
            //{
            //    Console.WriteLine();
            //}

            return newBD;
        }



        #endregion Methods
    }
}
