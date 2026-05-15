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

            Users user = NavigationData.CurrentData as Users;

            this.DataContext = user;

            MainFrame.NavigationService.Navigate(new CatalogPage());

            if (user != null)
            {
                if (user.RoleID == 2) AuthorButton.Visibility = Visibility.Visible;
                else AuthorButton.Visibility = Visibility.Collapsed;

                if (user.RoleID == 3) Admin.Visibility = Visibility.Visible;
                else Admin.Visibility = Visibility.Collapsed;
            } else
            {
                LogOut_Button.Visibility = Visibility.Collapsed;
            }
        }

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            Users user = NavigationData.CurrentData as Users;
            if (user != null) {
                MainFrame.NavigationService.Navigate(new ProfilePage());
            }
            else
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
                if (Core.Context.Lists.Where(l => l.UserID == user.UserID).Count() == 0)
                {
                    for (int i = 1; i <= 4; i++)
                    {
                        Core.Context.Lists.Add(new Lists
                        {
                            UserID = user.UserID,
                            TypeID = i
                        });
                        Core.Context.SaveChanges();
                    }
                }
            }

            if (user != null)
            {
                MainFrame.NavigationService.Navigate(new BookListsPage());
            }
            else
            {
                MessageBox.Show("Только зарегистрированные пользователи могут пользоваться списками.");
            }
        }

        private void Author_Click(object sender, RoutedEventArgs e)
        {
            Users user = NavigationData.CurrentData as Users;

            if (user.Frozen == false) MainFrame.NavigationService.Navigate(new AuthorPage());
            else MessageBox.Show("Ваш аккаунт заморожен. Оспорить заморозку можно на вкладке Профиль.");
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new AdminPage());
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationData.CurrentData = null;

            NavigationService.Navigate(new MainPage());
        }
    }
}
