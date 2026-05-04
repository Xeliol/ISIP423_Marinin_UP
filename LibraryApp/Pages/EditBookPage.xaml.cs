using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using static System.Net.Mime.MediaTypeNames;

namespace LibraryApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditBookPage.xaml
    /// </summary>
    public partial class EditBookPage : Page
    {
        public EditBookPage(Books book)
        {
            InitializeComponent();

            this.DataContext = book;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text.Length > 0 && text.Text.Length > 0)
            {
                Core.Context.SaveChanges();
                MessageBox.Show("Книжка изменена");

                NavigationService.Navigate(new AuthorPage());
            }
            else MessageBox.Show("Одно из обязательных полей пустое.");
        }
    }
}
