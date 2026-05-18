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
    /// Логика взаимодействия для FrozenPage.xaml
    /// </summary>
    public partial class FrozenPage : Page
    {
        public FrozenPage()
        {
            InitializeComponent();

            UsersBox.ItemsSource = Core.Context.Users.Where(u => u.Frozen == true).ToList();

            ReviewListBox.ItemsSource = Core.Context.Reviews.Where(u => u.Frozen == true).ToList();

            BooksListBox.ItemsSource = Core.Context.Books.Where(u => u.Frozen == true).ToList();
        }
        private void UnfreezeUser_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                Users us = btn.DataContext as Users;

                if (us != null)
                {
                    us.Frozen = false;

                    Core.Context.SaveChanges();

                    UsersBox.ItemsSource = Core.Context.Users.Where(u => u.Frozen == true).ToList();
                }
            }
        }

        private void UnfreezeBook_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                Books us = btn.DataContext as Books;

                if (us != null)
                {
                    us.Frozen = false;

                    Core.Context.SaveChanges();

                    BooksListBox.ItemsSource = Core.Context.Books.Where(u => u.Frozen == true).ToList();
                }
            }
        }

        private void UnfreezeReview_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                Reviews us = btn.DataContext as Reviews;

                if (us != null)
                {
                    us.Frozen = false;

                    Core.Context.SaveChanges();

                    Books cur_book = Core.Context.Books.First(b => b.BookID == us.Books.BookID);
                    if (cur_book != null && Core.Context.Reviews.Where(r => r.BookID == cur_book.BookID && r.Frozen == false).Count() > 0)
                    {
                        cur_book.Rating = Math.Round(Core.Context.Reviews.Where(r => r.BookID == cur_book.BookID && r.Frozen == false).Select(r => r.Rating).Average(), 1);
                        Core.Context.SaveChanges();
                    }

                    ReviewListBox.ItemsSource = Core.Context.Reviews.Where(u => u.Frozen == true).ToList();
                }
            }
        }
    }
}
