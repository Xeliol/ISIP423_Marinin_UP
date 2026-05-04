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
    /// Логика взаимодействия для BookPage.xaml
    /// </summary>
    public partial class BookPage : Page
    {
        Books book;
        Users user;
        int rating = -1;

        public BookPage(Books bk)
        {
            InitializeComponent();

            user = NavigationData.CurrentData as Users;

            book = bk;
            if (user != null)
            {
                book.RoleID = user.RoleID;
            }

            if (user == null || user.RoleID != 3)
            {
                FreezeButton.Visibility = Visibility.Collapsed;
            }

            this.DataContext = book;

            ReviewsListbox.ItemsSource = Core.Context.Reviews.Where(r => r.BookID == book.BookID && r.Frozen == false).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ReadBookPage(book));
        }

        private void SendButton(object sender, RoutedEventArgs e)
        {
            if (user != null)
            {
                if (ReviewTextBox.Text != "")
                {
                    if(rating != -1)
                    {
                        Core.Context.Reviews.Add(new Reviews
                        {
                            BookID = book.BookID,
                            UserID = user.UserID,
                            Frozen = false,
                            Text = ReviewTextBox.Text,
                            Rating = rating
                        });
                        Core.Context.SaveChanges();

                        Books cur_book = Core.Context.Books.First(b => b.BookID == book.BookID);
                        if (cur_book != null && Core.Context.Reviews.Where(r => r.BookID == book.BookID && r.Frozen == false).Count() > 0)
                        {
                            cur_book.Rating = Core.Context.Reviews.Where(r => r.BookID == book.BookID && r.Frozen == false).Select(r => r.Rating).Average();
                            Core.Context.SaveChanges();
                        }
                        ReviewsListbox.ItemsSource = Core.Context.Reviews.Where(r => r.BookID == book.BookID && r.Frozen == false).ToList();
                    }
                    else MessageBox.Show("Выберите оценку.");
                }
                else MessageBox.Show("Отзыв пуст.");
            }
            else MessageBox.Show("Надо войти в аккаунт, чтобы оставить отзыв.");
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rdbt = sender as RadioButton;
            if (rdbt != null)
            {
                rating = Convert.ToInt32(rdbt.Content.ToString());
            }
        }

        private void FreezeButton_Click(object sender, RoutedEventArgs e)
        {
            Books cur_book = Core.Context.Books.First(b => b.BookID == book.BookID);
            if (cur_book != null)
            {
                cur_book.Frozen = true;
                Core.Context.SaveChanges();
            }
        }

        private void ReviewFreeze_Click(object sender, RoutedEventArgs e)
        {

        }        
    }
}
