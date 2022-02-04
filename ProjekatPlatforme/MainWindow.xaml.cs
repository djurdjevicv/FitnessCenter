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

namespace ProjekatPlatforme
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Application.Instance.Coaches.Clear();
            Users.Coach.LoadCoaches();

            Application.Instance.Administrators.Clear();
            Users.Administrator.LoadAdministrators();

            Application.Instance.Beginners.Clear();
            Users.Beginner.LoadBeginners();

            Application.Instance.Addresses.Clear();
            Address.Address.LoadAddresses();

            Application.Instance.FitnessCenters.Clear();
            FitnessCenter.FitnessCenter.LoadFitnessCenter();

            Application.Instance.Trainings.Clear();
            Training.Training.LoadTraining();
            Training.Training.LoadAllTraining();
            Application.terminsForTrainings.Clear();
            Application.terminsForTrainings.Add("08:00");
            Application.terminsForTrainings.Add("09:00");
            Application.terminsForTrainings.Add("10:00");
            Application.terminsForTrainings.Add("11:00");
            Application.terminsForTrainings.Add("12:00");
            Application.terminsForTrainings.Add("13:00");
            Application.terminsForTrainings.Add("14:00");
            Application.terminsForTrainings.Add("15:00");
            Application.terminsForTrainings.Add("16:00");
        }

        private void LogIn(object sender, RoutedEventArgs e)
        {
            LogIn objLogin = new LogIn();
            this.Visibility = Visibility.Hidden;
            objLogin.Show();
        }


        private void SignUp(object sender, RoutedEventArgs e)
        {
            Users.Beginner newBeginner = new Users.Beginner();
            Address.Address newAddress = new Address.Address();
            SignUp sign = new SignUp(newBeginner, newAddress);
            this.Visibility = Visibility.Hidden;
            sign.ShowDialog();
        }


        private void ButtonExit(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void AboutCoachBtn(object sender, RoutedEventArgs e)
        {
            Coach.CoachReviewWindow coachWin = new Coach.CoachReviewWindow();
            this.Visibility = Visibility.Hidden;
            coachWin.Show();
        }

        private void AboutUsBtn(object sender, RoutedEventArgs e)
        {
            FitnessCenter.FitnessCenterReview fitnessCenterWin = new FitnessCenter.FitnessCenterReview();
            this.Visibility = Visibility.Hidden;
            fitnessCenterWin.Show();
        }
    }
}
