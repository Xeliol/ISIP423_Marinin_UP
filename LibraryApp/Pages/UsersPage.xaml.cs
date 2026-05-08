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
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();

            UsersBox.ItemsSource = Core.Context.Users.ToList();
        }

        private void Unfreeze_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                Users us = btn.DataContext as Users;

                if (us != null)
                {
                    us.Frozen = false;

                    Core.Context.SaveChanges();

                    UsersBox.ItemsSource = Core.Context.Users.ToList();
                }
            }
        }

        private void Freeze_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                Users us = btn.DataContext as Users;

                if (us != null)
                {
                    us.Frozen = true;

                    Core.Context.SaveChanges();

                    UsersBox.ItemsSource = Core.Context.Users.ToList();
                }
            }
        }
    }
}
