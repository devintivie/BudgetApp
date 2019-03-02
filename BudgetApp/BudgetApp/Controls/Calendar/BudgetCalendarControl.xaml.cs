using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BudgetApp
{
    /// <summary>
    /// Interaction logic for MonthView.xaml
    /// </summary>
    public partial class BudgetCalendarControl : UserControl
    {
        public BudgetCalendarControl()
        {
            InitializeComponent();
            //CalendarDaysList.MouseDoubleClick += new MouseButtonEventHandler(CalendarDaysList_DoubleClick); 
        }

        private void TextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TextBox tb = (sender as TextBox);

            if (tb != null)
            {
                tb.SelectAll();
            }
        }

        //private void CalendarDaysList_DoubleClick(object sender, EventArgs e)
        //{
        //    Console.WriteLine(CalendarDaysList.SelectedItem.ToString());
        //}

        //private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    Console.WriteLine(sender.ToString());
        //    var track = ((ListBoxItem)sender).Content as Track;

        //    //track.

        //}
    }
}
