using BudgetApp.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Helpers
{
    public static class MoneyMathHelper
    {
        /// <summary>
        /// This method assumes all billtrackers are sorted from oldest to newest
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<int> SelectableYears()
        {
            var years = new List<int>();
            foreach(var item in BillTrackerManager.Instance.AllTrackers)
            {
                var earliest = item.Bills.FirstOrDefault().DueDate.Year;
                var latest = item.Bills.LastOrDefault().DueDate.Year;
                var numyears = latest - earliest + 1;
                var array = Enumerable.Range(earliest, numyears);
                Console.WriteLine(array);

                foreach(var year in array)
                {
                    if (!years.Contains(year) )
                    {
                        years.Add(year);
                    }
                }

                


            }

            return years;
        }
        



    }
}
