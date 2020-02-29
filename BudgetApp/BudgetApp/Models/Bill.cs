using IvieBaseClasses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BudgetApp.Models
{
    [Serializable]
    public class Bill : BaseINPC, IComparable  
    {
        #region PrivateVariables
        const string DEFUALT_CONFIRMATION = "None";
        #endregion PrivateVariables

        #region Properties

        private DateTime dueDate;
        public DateTime DueDate
        {
            get { return dueDate; }
            set
            {
                if (dueDate != value)
                {
                    dueDate = value;
                    GetBillStatus();
                }
            }
        }

        public double AmountDue { get; set; }
        public string Confirmation { get; set; }

        private bool isPaid;
        public bool IsPaid
        {
            get { return isPaid; }
            set
            {
                if (isPaid != value)
                {
                    isPaid = value;
                    GetBillStatus();
                }
            }
        }

        public string AccountID { get; set; }

        [XmlIgnore]
        public BillStatus BillStatus { get; set; }


        #endregion Properties

        #region Constructors

        public Bill() : this(0.0, DateTime.Now.Date) { }

        public Bill(int month, int day, string acctID = "0000") : this(0, month, day, acctID) { }

        public Bill(double iAmount, int month, int day, string acctID = "0000") : this(iAmount, new DateTime(DateTime.Now.Year, month, day), acctID) { }

        //public Bill(double iAmount, int month, int day) : this(iAmount, new DateTime(DateTime.Now.Year, month, day), acctID) { }

        public Bill(double iAmount, DateTime iDueDate, string acctID = "0000")
        {
            DueDate = iDueDate;
            AmountDue = iAmount;
            Confirmation = DEFUALT_CONFIRMATION;
            IsPaid = false;
            AccountID = acctID;
            GetBillStatus();

        }
        #endregion

        private void GetBillStatus()
        {
            BillStatus = BillStatusHelper.GetBillStatus(DateTime.Today, DueDate, IsPaid);
        }



        public int CompareTo(object obj)
        {
            /*
             * If return < 0, the instance is earlier than obj
             * If return == 0, the instance is the same as obj
             * If return >0, the instance is later than obj
             */


            if (obj == null) return 1;

            if (obj is Bill otherBill)
                return DueDate.CompareTo(otherBill.DueDate);
            else
                throw new ArgumentException("Object is not a Bill Object");

        }

        /// <summary>
        /// Positive if bill2 is after bill1, Negative if bill2 is before bill1
        /// 0 if bill1 and bill2 are on the same day
        /// </summary>
        public static int CompareBillDate(Bill bill1, Bill bill2)
        {
            var dateCompare = (bill1.DueDate - bill2.DueDate).TotalDays;
            return (int)dateCompare;

        }

        /// <summary>
        /// Positive if date occurs after bill.DueDate, Negative if bill is before bill.DueDate
        /// 0 if bill.DueDate is on same day as date
        /// </summary>
        public static int CompareDate(Bill bill, DateTime date)
        {
            var dateCompare = (bill.DueDate - date).TotalDays;
            return (int)dateCompare;
        }

        override public string ToString()
        {
            string amountString = AmountDue.ToString("C", CultureInfo.CurrentCulture);
            string tempString = String.Format("{0} is due on {1:D}", AmountDue.ToString("C", CultureInfo.CurrentCulture), DueDate);

            return tempString;
        }
    }
}
