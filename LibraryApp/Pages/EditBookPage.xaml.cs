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
        Books this_book;

        public EditBookPage(Books book)
        {
            InitializeComponent();

            this.DataContext = book;

            this_book = book;

            AllGenresList.ItemsSource = Core.Context.Genres.ToList();

            List<BooksGenres> list = Core.Context.BooksGenres.Where(bg => bg.BookID == book.BookID).ToList();

            foreach (BooksGenres genres in list)
            {
                ChosenGenresList.Items.Add(genres.Genres);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text.Length > 0 && text.Text.Length > 0)
            {

                List<BooksGenres> list = Core.Context.BooksGenres.Where(bg => bg.BookID == this_book.BookID).ToList();

                foreach (BooksGenres genres in list)
                {
                    if(!ChosenGenresList.Items.Contains(genres.Genres))
                    {
                        Core.Context.BooksGenres.Remove(genres);
                    }
                }

                Core.Context.SaveChanges();

                foreach (Genres gen in ChosenGenresList.Items)
                {
                    if(Core.Context.BooksGenres.Where(bg => bg.BookID == this_book.BookID && bg.GenreID == gen.GenreID).Count() == 0)
                    {
                        Core.Context.BooksGenres.Add(new BooksGenres
                        {
                            GenreID = gen.GenreID,
                            BookID = this_book.BookID,
                        });
                    }
                }

                Core.Context.SaveChanges();
                MessageBox.Show("Книжка изменена");

                NavigationService.Navigate(new AuthorPage());
            }
            else MessageBox.Show("Одно из обязательных полей пустое.");
        }

        private void AddGenre_Click(object sender, RoutedEventArgs e)
        {
            if (AllGenresList.SelectedItem != null)
            {
                ChosenGenresList.Items.Add(AllGenresList.SelectedItem);
            } else
            {
                MessageBox.Show("Выберите жанр.");
            }
        }

        private void RemoveGenre_Click(object sender, RoutedEventArgs e)
        {
            if (ChosenGenresList.SelectedItem != null)
            {
                ChosenGenresList.Items.Remove(ChosenGenresList.SelectedItem);
            }
            else
            {
                MessageBox.Show("Выберите жанр.");
            }
        }
    }
}
