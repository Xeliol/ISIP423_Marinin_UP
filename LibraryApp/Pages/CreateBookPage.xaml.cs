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
    /// Логика взаимодействия для CreateBookPage.xaml
    /// </summary>
    public partial class CreateBookPage : Page
    {
        public CreateBookPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text.Length > 0 && text.Text.Length > 0)
            {
                Users user = NavigationData.CurrentData as Users;

                Core.Context.Books.Add(new Books
                {
                    Name = Name.Text,
                    Text = text.Text,
                    Description = Desc.Text,
                    AuthorID = user.UserID,
                    ImagePath = "/Images/Books/Placeholder.png",
                    Frozen = false,
                    Rating = 10,
                });
                Core.Context.SaveChanges();
                MessageBox.Show("Книжка создана");

                NavigationService.Navigate(new AuthorPage());
            }
            else MessageBox.Show("Одно из обязательных полей пустое.");

        }
    }
}
