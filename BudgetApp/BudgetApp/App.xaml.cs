using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BudgetApp.ViewModels;

namespace BudgetApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            (new MainWindow()).Show();

            //Student loan daily interest calculations
            //var startDate = new DateTime(2018, 7, 16);
            //var date1 = new DateTime(2018, 8, 10);
            //var date2 = new DateTime(2018, 9, 10);
            //var date3 = new DateTime(2018, 10, 5);

            //var days1 = (date1 - startDate).TotalDays;
            //var days2 = (date2 - date1).TotalDays;
            //var days3 = (date3 - date2).TotalDays;

            //var principal1 = 3078.91;
            //var principal2 = 3064.07;
            //var principal3 = 3052.29;

            //var finalPrincipal1 = principal1;
            //var finalPrincipal2 = principal2;
            //var finalPrincipal3 = principal3;

            //var rate = 0.0621;
            //for(int i = 0; i < days1; i++)
            //{
            //    finalPrincipal1 = Math.Round(finalPrincipal1 * (1 + rate / 365), 2);
            //}

            //for (int i = 0; i < days2; i++)
            //{
            //    finalPrincipal2 = Math.Round(finalPrincipal2 * (1 + rate / 365), 2);
            //}

            //for (int i = 0; i < days3; i++)
            //{
            //    finalPrincipal3 = Math.Round(finalPrincipal3 * (1 + rate / 365), 2);
            //}

            //var totalInterest1 = finalPrincipal1 - principal1;
            //var totalInterest2 = finalPrincipal2 - principal2;
            //var totalInterest3 = finalPrincipal3 - principal3;

            //Console.WriteLine($"New Principal = {finalPrincipal1}");
            //Console.WriteLine($"Total interest = {totalInterest1}\n");
            //Console.WriteLine($"New Principal = {finalPrincipal2}");
            //Console.WriteLine($"Total interest = {totalInterest2}\n");
            //Console.WriteLine($"New Principal = {finalPrincipal3}");
            //Console.WriteLine($"Total interest = {totalInterest3}\n");
            //view.Show();
        }

        
    }
}
