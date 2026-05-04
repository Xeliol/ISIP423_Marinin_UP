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
            user = NavigationData.CurrentData as Users;

            if (user != null)
            {
                if(Core.Context.Lists.Where(l => l.UserID == user.UserID).Count() == 0)
                {
                    for(int i = 1; i <= 4; i++)
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

            InitializeComponent();

            ListsListBox.ItemsSource = Core.Context.Lists.ToList();
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
            Button btn = sender as Button;

            if (btn != null)
            {
                BooksLists booklist = btn.DataContext as BooksLists;
                Books book = booklist.Books;
                Users user = NavigationData.CurrentData as Users;

                if (user != null && book != null)
                {
                    if (Core.Context.BooksLists.Where(l => l.BookID == book.BookID && l.Lists.UserID == user.UserID).Count() > 0)
                    {
                        BooksLists existing_booklist = Core.Context.BooksLists.First(l => l.BookID == book.BookID && l.Lists.UserID == user.UserID);
                        Core.Context.BooksLists.Remove(existing_booklist);
                        Core.Context.SaveChanges();
                    }

                    int idList = Core.Context.Lists.First(l => l.UserID == user.UserID && l.TypeID == 3).ListID;

                    if (Core.Context.BooksLists.Where(b => b.BookID == book.BookID && b.ListID == idList).Count() == 0)
                    {
                        Core.Context.BooksLists.Add(new BooksLists
                        {
                            BookID = book.BookID,
                            ListID = idList
                        });
                        Core.Context.SaveChanges();
                        ListsListBox.ItemsSource = Core.Context.Lists.ToList();
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

        private void LaterClick(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                BooksLists booklist = btn.DataContext as BooksLists;
                Books book = booklist.Books;
                Users user = NavigationData.CurrentData as Users;

                if (user != null && book != null)
                {
                    if (Core.Context.BooksLists.Where(l => l.BookID == book.BookID && l.Lists.UserID == user.UserID).Count() > 0)
                    {
                        BooksLists existing_booklist = Core.Context.BooksLists.First(l => l.BookID == book.BookID && l.Lists.UserID == user.UserID);
                        Core.Context.BooksLists.Remove(existing_booklist);
                        Core.Context.SaveChanges();
                    }

                    int idList = Core.Context.Lists.First(l => l.UserID == user.UserID && l.TypeID == 2).ListID;

                    if (Core.Context.BooksLists.Where(b => b.BookID == book.BookID && b.ListID == idList).Count() == 0)
                    {
                        Core.Context.BooksLists.Add(new BooksLists
                        {
                            BookID = book.BookID,
                            ListID = idList
                        });
                        Core.Context.SaveChanges();
                        ListsListBox.ItemsSource = Core.Context.Lists.ToList();
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

        private void FinishedClick(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                BooksLists booklist = btn.DataContext as BooksLists;
                Books book = booklist.Books;
                Users user = NavigationData.CurrentData as Users;

                if (user != null && book != null)
                {
                    if (Core.Context.BooksLists.Where(l => l.BookID == book.BookID && l.Lists.UserID == user.UserID).Count() > 0)
                    {
                        BooksLists existing_booklist = Core.Context.BooksLists.First(l => l.BookID == book.BookID && l.Lists.UserID == user.UserID);
                        Core.Context.BooksLists.Remove(existing_booklist);
                        Core.Context.SaveChanges();
                    }

                    int idList = Core.Context.Lists.First(l => l.UserID == user.UserID && l.TypeID == 4).ListID;

                    if (Core.Context.BooksLists.Where(b => b.BookID == book.BookID && b.ListID == idList).Count() == 0)
                    {
                        Core.Context.BooksLists.Add(new BooksLists
                        {
                            BookID = book.BookID,
                            ListID = idList
                        });
                        Core.Context.SaveChanges();
                        ListsListBox.ItemsSource = Core.Context.Lists.ToList();
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

        private void AbandonedClick(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                BooksLists booklist = btn.DataContext as BooksLists;
                Books book = booklist.Books;
                Users user = NavigationData.CurrentData as Users;

                if (user != null && book != null)
                {
                    if (Core.Context.BooksLists.Where(l => l.BookID == book.BookID && l.Lists.UserID == user.UserID).Count() > 0)
                    {
                        BooksLists existing_booklist = Core.Context.BooksLists.First(l => l.BookID == book.BookID && l.Lists.UserID == user.UserID);
                        Core.Context.BooksLists.Remove(existing_booklist);
                        Core.Context.SaveChanges();
                    }

                    int idList = Core.Context.Lists.First(l => l.UserID == user.UserID && l.TypeID == 1).ListID;

                    if (Core.Context.BooksLists.Where(b => b.BookID == book.BookID && b.ListID == idList).Count() == 0)
                    {
                        Core.Context.BooksLists.Add(new BooksLists
                        {
                            BookID = book.BookID,
                            ListID = idList
                        });
                        Core.Context.SaveChanges();
                        ListsListBox.ItemsSource = Core.Context.Lists.ToList();
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
