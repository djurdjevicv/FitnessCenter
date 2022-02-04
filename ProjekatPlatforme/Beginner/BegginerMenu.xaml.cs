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

namespace ProjekatPlatforme.Beginner
{
    /// <summary>
    /// Interaction logic for BegginerMenu.xaml
    /// </summary>
    public partial class BegginerMenu : Window
    {
        public BegginerMenu()
        {
            InitializeComponent();
        }

        private void YourAccount(object sender, RoutedEventArgs e)
        {
            Beginner.BeginnerAccountData beginnerData = new Beginner.BeginnerAccountData();
            this.Visibility = Visibility.Hidden;
            beginnerData.Show();
        }

        private void LogOff(object sender, RoutedEventArgs e)
        {
            Application.loginUser = null;
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWindow.Show();
        }

        private void ButtonReviewTraining(object sender, RoutedEventArgs e)
        {
            Training.ReviewTrainingBeginner review = new Training.ReviewTrainingBeginner();
            this.Visibility = Visibility.Hidden;
            review.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Coach.SearchCoachUnReg searchCoach  = new Coach.SearchCoachUnReg();
            this.Visibility = Visibility.Hidden;
            searchCoach.Show();
        }
    }
}
