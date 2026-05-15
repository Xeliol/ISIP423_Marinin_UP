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
    /// Логика взаимодействия для SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        public SignInPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            bool auth = Auth(LoginBox.Text, PassBox.Password);
            if (auth)
            {
                Users log_user = Core.Context.Users.ToList().Where(p => p.Login == LoginBox.Text).Where(p => p.Password == PassBox.Password).First();
                NavigationData.CurrentData = log_user;

                MessageBox.Show("Logged in!");
                NavigationService.Navigate(new MainPage());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterPage());
        }

        /// <summary>
        /// Этот метод проверяет можно ли авторизовать пользователя
        /// </summary>
        /// <param name="login">Введённый логин пользователя</param>
        /// <param name="password">Введённый пароль пользователя</param> 
        /// <returns>Можно ли авторизовать пользователя? (Ложь/Истина)</returns>
        public bool Auth(string login, string password)
        {
            var log_user = Core.Context.Users.ToList().Where(p => p.Login == login);
            if (log_user.Count() != 0)
            {
                log_user = Core.Context.Users.ToList().Where(p => p.Login == login).Where(p => p.Password == password);
                if (log_user.Count() != 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Wrong Password.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("No such user.");
                return false;
            }
        }
    }
}
