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
using System.Windows.Shapes;

namespace ProjekatPlatforme.Administrator
{
    /// <summary>
    /// Interaction logic for AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void ExitApp(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void LogOff(object sender, RoutedEventArgs e)
        {
            Application.loginUser = null;
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWindow.Show();
            
        }

        private void CoachReview(object sender, RoutedEventArgs e)
        {
            CoachReview coachReviewWin = new CoachReview();
            this.Visibility = Visibility.Hidden;
            coachReviewWin.Show();
        }

        private void BeginnerReview(object sender, RoutedEventArgs e)
        {
            BeginnerReview beginnerReviewWin = new BeginnerReview();
            this.Visibility = Visibility.Hidden;
            beginnerReviewWin.Show();
        }

        private void TrainingReview(object sender, RoutedEventArgs e)
        {
            TrainingReview trainingReviewWin = new TrainingReview();
            this.Visibility = Visibility.Hidden;
            trainingReviewWin.Show();
        }

        private void YourData(object sender, RoutedEventArgs e)
        {
            AdminData adminData = new AdminData();
            this.Visibility = Visibility.Hidden;
            adminData.Show();
        }

        private void ButtonSearch(object sender, RoutedEventArgs e)
        {
            SearchUsers search = new SearchUsers();
            this.Visibility= Visibility.Hidden;
            search.Show();
        }
    }
}
