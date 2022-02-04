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

namespace ProjekatPlatforme.Coach
{
    /// <summary>
    /// Interaction logic for CoachMenu.xaml
    /// </summary>
    public partial class CoachMenu : Window
    {
        public CoachMenu()
        {
            InitializeComponent();
        }

        private void LogOff(object sender, RoutedEventArgs e)
        {
            Application.loginUser = null;
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWindow.Show();
        }

        private void YourAccount(object sender, RoutedEventArgs e)
        {
            Coach.CoachAccountData coachData = new Coach.CoachAccountData();
            this.Visibility = Visibility.Hidden;
            coachData.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ReviewTrainingCoach reviewTraining = new ReviewTrainingCoach();
            this.Visibility = Visibility.Hidden;
            reviewTraining.Show();
        }

        private void ButtonReviewBeginner(object sender, RoutedEventArgs e)
        {
            Beginner.ReviewBeginnerCoach review = new Beginner.ReviewBeginnerCoach();
            this.Visibility = Visibility.Hidden;
            review.Show();
        }
    }
}
