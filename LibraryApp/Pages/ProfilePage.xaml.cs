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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();

            Users user = NavigationData.CurrentData as Users;
            this.DataContext = user;

            ReviewsListbox.ItemsSource = Core.Context.Reviews.Where(r => r.UserID == user.UserID).ToList();

            if (!user.Frozen)
            {
                Warning.Visibility = Visibility.Collapsed;
                RequestUnfreeze.Visibility = Visibility.Collapsed;
            }else
            {
                RequestRole.Visibility = Visibility.Collapsed;
            }

        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationData.CurrentData = null;

            NavigationService.Navigate(new CatalogPage(true));

        }

        private void RequestRole_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RequestUnfreeze_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
