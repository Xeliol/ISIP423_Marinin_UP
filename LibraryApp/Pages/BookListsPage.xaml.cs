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
    /// Логика взаимодействия для BookListsPage.xaml
    /// </summary>
    public partial class BookListsPage : Page
    {
        Users user;

        public BookListsPage()
        {
            InitializeComponent();

            user = NavigationData.CurrentData as Users;

            ListsTab.ItemsSource = Core.Context.Lists.Where(l => l.UserID == user.UserID).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                BooksLists booklist = btn.DataContext as BooksLists;
                Books book = booklist.Books;
                if (book != null)
                {
                    NavigationService.Navigate(new BookPage(book));
                }
            }
        }

        private void ReadingClick(object sender, RoutedEventArgs e)
        {
            ChangeLists(sender, 3);
        }

        private void LaterClick(object sender, RoutedEventArgs e)
        {
            ChangeLists(sender, 2);
        }

        private void FinishedClick(object sender, RoutedEventArgs e)
        {
            ChangeLists(sender, 4);
        }

        private void AbandonedClick(object sender, RoutedEventArgs e)
        {
            ChangeLists(sender, 1);
        }

        /// <summary>
        /// Изменяет список книги, проверяя что она не находится уже в нём.
        /// </summary>
        private void ChangeLists(object sender, int typeID)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                BooksLists booklist = btn.DataContext as BooksLists;
                Books book = booklist.Books;
                Users user = NavigationData.CurrentData as Users;

                if (user != null && book != null)
                {
                    if (Core.Context.BooksLists.Where(l => l.BookID == book.BookID && l.Lists.UserID == user.UserID && l.Lists.TypeID != typeID).Count() > 0)
                    {
                        BooksLists existing_booklist = Core.Context.BooksLists.First(l => l.BookID == book.BookID && l.Lists.UserID == user.UserID);
                        Core.Context.BooksLists.Remove(existing_booklist);
                        Core.Context.SaveChanges();
                    }

                    int idList = Core.Context.Lists.First(l => l.UserID == user.UserID && l.TypeID == typeID).ListID;

                    if (Core.Context.BooksLists.Where(b => b.BookID == book.BookID && b.ListID == idList).Count() == 0)
                    {
                        Core.Context.BooksLists.Add(new BooksLists
                        {
                            BookID = book.BookID,
                            ListID = idList
                        });
                        Core.Context.SaveChanges();
                        ListsTab.ItemsSource = Core.Context.Lists.Where(l => l.UserID == user.UserID).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Уже в списке.");
                    }
                }
                else
                {
                    MessageBox.Show("Только зарегистрированные пользователи могут пользоваться списками.");
                }
            }
        }
    }
}
