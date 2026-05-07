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

            AllGenresList.ItemsSource = Core.Context.Genres.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text.Length > 0 && text.Text.Length > 0)
            {
                Users user = NavigationData.CurrentData as Users;

                Books book = new Books
                {
                    Name = Name.Text,
                    Text = text.Text,
                    Description = Desc.Text,
                    AuthorID = user.UserID,
                    ImagePath = "/Images/Books/Placeholder.png",
                    Frozen = false,
                    Rating = 10,
                };

                Core.Context.Books.Add(book);

                Core.Context.SaveChanges();

                //FICCCXX!!

                Books cert_book = Core.Context.Books.First(b => b == book);

                foreach(Genres gen in ChosenGenresList.Items)
                {
                    Core.Context.BooksGenres.Add(new BooksGenres
                    {
                        GenreID = gen.GenreID,
                        BookID = cert_book.BookID,
                    });
                }

                Core.Context.SaveChanges();
                MessageBox.Show("Книжка создана");

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
            if (AllGenresList.SelectedItem != null)
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
