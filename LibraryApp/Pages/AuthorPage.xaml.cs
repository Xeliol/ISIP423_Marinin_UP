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
    /// Логика взаимодействия для AuthorPage.xaml
    /// </summary>
    public partial class AuthorPage : Page
    {
        public AuthorPage()
        {
            InitializeComponent();

            Users user = NavigationData.CurrentData as Users;

            BooksListBox.ItemsSource = Core.Context.Books.Where(b => b.AuthorID == user.UserID).ToList();
        }

        private void RequestUnfreeze_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                Users user = NavigationData.CurrentData as Users;
                Books book = btn.DataContext as Books;

                if (book != null)
                {
                    Core.Context.UnfreezeRequests.Add(new UnfreezeRequests
                    {
                        BookID = book.BookID,
                        TypeID = 1,
                        UserID = user.UserID,
                    });
                }
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                Books book = btn.DataContext as Books;
                if (book != null)
                {
                    NavigationService.Navigate(new EditBookPage(book));
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                Books book = btn.DataContext as Books;
                if (book != null)
                {
                    NavigationService.Navigate(new BookPage(book));
                }
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateBookPage());
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                Books book = btn.DataContext as Books;
                if (book != null)
                {
                    Core.Context.Books.Remove(book);
                    Core.Context.SaveChanges();

                    Users user = NavigationData.CurrentData as Users;

                    BooksListBox.ItemsSource = Core.Context.Books.Where(b => b.AuthorID == user.UserID).ToList();
                }
            }
        }
    }
}
