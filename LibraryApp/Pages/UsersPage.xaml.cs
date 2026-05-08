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

            if (btn != null && CheckPasswords())
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

            if (btn != null && CheckPasswords())
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

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            CheckPasswords();
        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null && CheckPasswords())
            {
                Users us = btn.DataContext as Users;

                if (us != null)
                {
                    if(us.RoleID != 3)
                    {
                        us.RoleID += 1;
                        Core.Context.SaveChanges();
                        UsersBox.ItemsSource = Core.Context.Users.ToList();
                    }
                    else
                    {
                        MessageBox.Show("Максимальная роль");
                    }
                }
            }
        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null && CheckPasswords())
            {
                Users us = btn.DataContext as Users;

                if (us != null)
                {
                    if (us.RoleID != 1)
                    {
                        us.RoleID -= 1;   
                        Core.Context.SaveChanges();
                        UsersBox.ItemsSource = Core.Context.Users.ToList();
                    }
                    else
                    {
                        MessageBox.Show("Минимальная роль");
                    }
                }
            }
        }

        private bool CheckPasswords()
        {
            bool flag = true;
            foreach (Users user in UsersBox.ItemsSource)
            {
                if (user.Password == "") { flag = false; break; }
            }
            if (flag) Core.Context.SaveChanges();
            else MessageBox.Show("Операция не может быть выполнена - есть пустой пароль.");
            return flag;
        }
    }
}
