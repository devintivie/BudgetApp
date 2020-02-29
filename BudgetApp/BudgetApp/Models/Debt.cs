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
    public class Debt : BaseINPC, IComparable  
    {
        #region PrivateVariables
        #endregion PrivateVariables

        #region Properties
        public DateTime Date { get; set; }
        public double Balance { get; set; }
        #endregion Properties

        #region Constructors

        public Debt()
        {

        }
        #endregion

        public int CompareTo(object obj)
        {
            /*
             * If return < 0, the instance is earlier than obj
             * If return == 0, the instance is the same as obj
             * If return >0, the instance is later than obj
             */


            if (obj == null) return 1;

            if (obj is Debt otherBill)
                return Date.CompareTo(otherBill.Date);
            else
                throw new ArgumentException("Object is not a Bill Object");

        }

        /// <summary>
        /// Positive if debt2 is after debt1, Negative if debt2 is before debt1
        /// 0 if debt1 and debt2 are on the same day
        /// </summary>
        public static int CompareBillDate(Debt debt1, Debt debt2)
        {
            var dateCompare = (debt1.Date - debt2.Date).TotalDays;
            return (int)dateCompare;
        }

        /// <summary>
        /// Positive if date occurs after debt.DueDate, Negative if debt is before debt.DueDate
        /// 0 if debt.DueDate is on same day as date
        /// </summary>
        public static int CompareDate(Bill debt, DateTime date)
        {
            var dateCompare = (debt.DueDate - date).TotalDays;
            return (int)dateCompare;
        }

        override public string ToString()
        {
            string amountString = Balance.ToString("C", CultureInfo.CurrentCulture);
            string tempString = String.Format("{0} is due on {1:D}", Balance.ToString("C", CultureInfo.CurrentCulture), Date);

            return tempString;
        }
    }
}
