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

            UnfreezeListbox.ItemsSource = Core.Context.UnfreezeRequests.ToList();

            RoleBox.ItemsSource = Core.Context.RoleRequests.ToList();
        }

        private void IgnoreReport_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                Reports rep = btn.DataContext as Reports;

                rep.Solved = true;

                Core.Context.SaveChanges();

                ReportsListbox.ItemsSource = Core.Context.Reports.Where(r => r.Solved == false).ToList();
            }
        }

        private void FreezeReport_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                Reports rep = btn.DataContext as Reports;

                switch(rep.TypeID)
                {
                    case 1:
                        rep.Books.Frozen = true;
                        break;
                    case 2:
                        rep.Reviews.Frozen = true;
                        break;
                    case 3:
                        rep.Users.Frozen = true;
                        break;
                }

                rep.Solved = true;

                Core.Context.SaveChanges();

                ReportsListbox.ItemsSource = Core.Context.Reports.Where(r => r.Solved == false).ToList();
            }
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

        private void RequestToBook_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                UnfreezeRequests rep = btn.DataContext as UnfreezeRequests;

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

        private void IgnoreUnfreeze_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                UnfreezeRequests rep = btn.DataContext as UnfreezeRequests;

                Core.Context.UnfreezeRequests.Remove(rep);

                Core.Context.SaveChanges();

                UnfreezeListbox.ItemsSource = Core.Context.UnfreezeRequests.ToList();
            }
        }

        private void Unfreeze_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                UnfreezeRequests rep = btn.DataContext as UnfreezeRequests;

                switch (rep.TypeID)
                {
                    case 1:
                        rep.Books.Frozen = false;
                        break;
                    case 2:
                        rep.Reviews.Frozen = false;
                        break;
                    case 3:
                        rep.Users1.Frozen = false;
                        break;
                }

                Core.Context.UnfreezeRequests.Remove(rep);

                Core.Context.SaveChanges();

                UnfreezeListbox.ItemsSource = Core.Context.UnfreezeRequests.ToList();
            }
        }

        private void FreezeWithUser_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                Reports rep = btn.DataContext as Reports;

                switch (rep.TypeID)
                {
                    case 1:
                        rep.Books.Frozen = true;
                        rep.Books.Users.Frozen = true;
                        break;
                    case 2:
                        rep.Reviews.Frozen = true;
                        rep.Reviews.Users.Frozen = true;
                        break;
                    case 3:
                        rep.Users.Frozen = true;
                        break;
                }

                rep.Solved = true;

                Core.Context.SaveChanges();

                ReportsListbox.ItemsSource = Core.Context.Reports.Where(r => r.Solved == false).ToList();
            }
        }

        private void GiveRole_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                RoleRequests rep = btn.DataContext as RoleRequests;

                rep.Users.RoleID = 2;

                Core.Context.RoleRequests.Remove(rep);

                Core.Context.SaveChanges();

                RoleBox.ItemsSource = Core.Context.RoleRequests.ToList();
            }
        }

        private void RefuseRole_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                RoleRequests rep = btn.DataContext as RoleRequests;

                Core.Context.RoleRequests.Remove(rep);

                Core.Context.SaveChanges();

                RoleBox.ItemsSource = Core.Context.RoleRequests.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UsersPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FrozenPage());
        }
    }
}
