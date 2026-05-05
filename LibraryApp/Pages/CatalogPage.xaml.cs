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
    /// Логика взаимодействия для CatalogPage.xaml
    /// </summary>
    public partial class CatalogPage : Page
    {

        int SortRating = 0;
        int SortName = 0;

        public CatalogPage(bool erase_history = false)
        {
            InitializeComponent();

            if (erase_history)
            {
                this.Loaded += (s, e) => EraseHistory();
            }

            Users user = NavigationData.CurrentData as Users;

            BooksListBox.ItemsSource = Core.Context.Books.Where(b => b.Frozen == false).ToList();

            List<string> GenreSorts = Core.Context.Genres.Select(pt => pt.Name).ToList();

            GenreSorts.Insert(0, "None");

            GenreSortBox.ItemsSource = GenreSorts;

            GenreSortBox.SelectedIndex = 0;

        }

        private void EraseHistory()
        {
            while (NavigationService.CanGoBack)
            {
                try
                {
                    NavigationService.RemoveBackEntry();
                }
                catch (Exception ex)
                {
                    break;
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

        private void ReadingClick(object sender, RoutedEventArgs e)
        {
            CreateLists();

            Button btn = sender as Button;

            if (btn != null)
            {
                Books book = btn.DataContext as Books;

                Users user = NavigationData.CurrentData as Users;

                if (user != null && book != null)
                {
                    if(Core.Context.BooksLists.Where(l => l.BookID == book.BookID && l.Lists.UserID == user.UserID).Count() > 0)
                    {
                        BooksLists existing_booklist = Core.Context.BooksLists.First(l => l.BookID == book.BookID && l.Lists.UserID == user.UserID);
                        Core.Context.BooksLists.Remove(existing_booklist);
                        Core.Context.SaveChanges();
                    }

                    int idList = Core.Context.Lists.First(l => l.UserID == user.UserID && l.TypeID == 3).ListID;

                    if (Core.Context.BooksLists.Where(b => b.BookID == book.BookID && b.ListID == idList).Count() == 0)
                    {
                        Core.Context.BooksLists.Add(new BooksLists{
                            BookID = book.BookID,
                            ListID = idList
                        });
                        Core.Context.SaveChanges();
                    } else
                    {
                        MessageBox.Show("Уже в списке.");
                    }
                } else
                {
                    MessageBox.Show("Только зарегистрированные пользователи могут пользоваться списками.");
                }
            }
        }

        private void LaterClick(object sender, RoutedEventArgs e)
        {
            CreateLists();

            Button btn = sender as Button;

            if (btn != null)
            {
                Books book = btn.DataContext as Books;

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
            CreateLists();

            Button btn = sender as Button;

            if (btn != null)
            {
                Books book = btn.DataContext as Books;

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
            CreateLists();

            Button btn = sender as Button;

            if (btn != null)
            {
                Books book = btn.DataContext as Books;

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

        private void CreateLists()
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
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SortBooks();
        }

        private void SortBooks()
        {
            List<Books> newsrc = Core.Context.Books.Where(b => b.Frozen == false).ToList();

            if (SortName == 1)
            {
                newsrc = newsrc.OrderByDescending(n => n.Name).ToList();
            } else if (SortName == 2)
            {
                newsrc = newsrc.OrderBy(n => n.Name).ToList();
            }

            if (SortRating == 1)
            {
                newsrc = newsrc.OrderByDescending(n => n.Rating).ToList();
            }
            else if (SortRating == 2)
            {
                newsrc = newsrc.OrderBy(n => n.Rating).ToList();
            }

            if (GenreSortBox.SelectedIndex != 0)
            {
                newsrc = newsrc.Where(b => b.Frozen == false && Core.Context.BooksGenres.Where(bg => bg.Genres.Name == GenreSortBox.SelectedItem).Select(g => g.BookID).Contains(b.BookID)).ToList();
            }

            if (SearchBox.Text.Length != 0)
            {
                BooksListBox.ItemsSource = newsrc.Where(p => p.Name.ToLower().Contains(SearchBox.Text.ToLower()));
            }
            else BooksListBox.ItemsSource = newsrc;
        }
        private void NameSort_Click(object sender, RoutedEventArgs e)
        {
            if(SortName == 0 || SortName == 2)
            {
                SortName = 1;
                SortRating = 0;
                NameSort.Content = "Name🔽";
            }
            else if (SortName == 1)
            {
                SortName= 2;
                SortRating = 0;
                NameSort.Content = "Name🔼";
            }
            SortBooks();
        }

        private void RatingSort_Click(object sender, RoutedEventArgs e)
        {
            if (SortRating == 0 || SortRating == 2)
            {
                SortRating = 1;
                SortName = 0;
                RatingSort.Content = "Rating🔽";
            }
            else if (SortRating == 1)
            {
                SortRating = 2;
                SortName = 0;
                RatingSort.Content = "Rating🔼";
            }
            SortBooks();
        }

        private void GenreSortBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SortBooks();
        }
    }
}
