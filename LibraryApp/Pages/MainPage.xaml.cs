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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            Users user = NavigationData.CurrentData as Users;
            if (user != null) {
                //Account
            }else
            {
                NavigationService.Navigate(new SignInPage());
            }
        }

        private void CatalogButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new CatalogPage());
        }

        private void ListsButton_Click(object sender, RoutedEventArgs e)
        {
            Users user = NavigationData.CurrentData as Users;
            if (user != null)
            {
                MainFrame.NavigationService.Navigate(new BookListsPage());
            }
            else
            {
                MessageBox.Show("Только зарегистрированные пользователи могут пользоваться списками.");
            }
        }
    }
}
