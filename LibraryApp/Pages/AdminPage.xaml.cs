using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();

            ReportsListbox.ItemsSource = Core.Context.Reports.Where(r => r.Solved == false).ToList();
        }

        private void IgnoreReport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FreezeReport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReportToBook_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                Reports rep = btn.DataContext as Reports;

                if (rep.Books != null)
                {
                    NavigationService.Navigate(new BookPage(rep.Books));
                }
                else if (rep.Reviews != null)
                {
                    NavigationService.Navigate(new BookPage(rep.Reviews.Books));
                }
            }
        }
    }
}
