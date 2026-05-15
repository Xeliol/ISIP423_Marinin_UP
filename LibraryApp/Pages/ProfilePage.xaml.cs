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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();

            Users user = NavigationData.CurrentData as Users;
            this.DataContext = user;

            ReviewsListbox.ItemsSource = Core.Context.Reviews.Where(r => r.UserID == user.UserID).ToList();

            if (!user.Frozen)
            {
                Warning.Visibility = Visibility.Collapsed;
                RequestUnfreeze.Visibility = Visibility.Collapsed;
            }else
            {
                RequestRole.Visibility = Visibility.Collapsed;
            }

            if(user.RoleID != 1)
            {
                RequestRole.Visibility = Visibility.Collapsed;
            }

            if (Core.Context.UnfreezeRequests.Where(ur => ur.Users.UserID == user.UserID && ur.TypeID == 3).Count() > 0)
            {
                RequestUnfreeze.IsEnabled = false;
                RequestUnfreeze.Content = "Рассматриватеся...";
                RequestUnfreeze.Foreground = Brushes.Black;
            }

            if (Core.Context.RoleRequests.Where(r => r.Users.UserID == user.UserID).Count() > 0)
            {
                RequestRole.IsEnabled = false;
                RequestRole.Content = "Рассматриватеся...";
                RequestRole.Foreground = Brushes.Black;
            }
        }

        private void RequestRole_Click(object sender, RoutedEventArgs e)
        {
            Users user = NavigationData.CurrentData as Users;

            if (Core.Context.RoleRequests.Where(u => u.UserID == user.UserID).Count() == 0)
            {
                Core.Context.RoleRequests.Add(new RoleRequests
                {
                    UserID = user.UserID
                });

                Core.Context.SaveChanges();

                RequestRole.IsEnabled = false;
                RequestRole.Content = "Рассматриватеся...";
                RequestRole.Foreground = Brushes.Black;
            }
            else
            {
                MessageBox.Show("На рассмотрении.");
            }
        }

        private void RequestUnfreeze_Click(object sender, RoutedEventArgs e)
        {
            Users user = NavigationData.CurrentData as Users;

            if (Core.Context.UnfreezeRequests.Where(u => u.ProfileID == user.UserID && u.TypeID == 3).Count() == 0)
            {
                Core.Context.UnfreezeRequests.Add(new UnfreezeRequests
                {
                    TypeID = 3,
                    UserID = user.UserID,
                    ProfileID = user.UserID,
                });

                Core.Context.SaveChanges();

                RequestUnfreeze.IsEnabled = false;
                RequestUnfreeze.Content = "Рассматриватеся...";
                RequestUnfreeze.Foreground = Brushes.Black;
            }
            else
            {
                MessageBox.Show("Оспорение на рассмотрении.");
            }
        }

        private void RequestReviewUnfreeze_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                Reviews rev = btn.DataContext as Reviews;

                Users user = NavigationData.CurrentData as Users;
                
                if(Core.Context.UnfreezeRequests.Where(u => u.ReviewID == rev.ReviewID && u.TypeID == 2).Count() == 0)
                {
                    Core.Context.UnfreezeRequests.Add(new UnfreezeRequests
                    {
                        TypeID = 2,
                        UserID = user.UserID,
                        ReviewID = rev.ReviewID,
                    });

                    Core.Context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Оспорение на рассмотрении.");
                }
            }
        }
    }
}
