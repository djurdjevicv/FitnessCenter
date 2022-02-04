using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
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

namespace ProjekatPlatforme.Training
{
    /// <summary>
    /// Interaction logic for ReviewTrainingBeginner.xaml
    /// </summary>
    public partial class ReviewTrainingBeginner : Window
    {
        ICollectionView view;
        public ReviewTrainingBeginner()
        {
            InitializeComponent();
            view = CollectionViewSource.GetDefaultView(Application.Instance.Trainings);
            dataGrid.ItemsSource = view;
            dataGrid.IsSynchronizedWithCurrentItem = true;
            Application.Instance.Trainings.Clear();
            findCoaches();
        }

        private void findCoaches()
        {
            foreach (Users.Coach coachs in Application.Instance.Coaches)
            {
                coach.Items.Add(coachs.Jmbg);
            }
        }

        private void ButtonBack(object sender, RoutedEventArgs e)
        {
            Beginner.BegginerMenu menu = new Beginner.BegginerMenu();
            this.Visibility = Visibility.Hidden;
            menu.Show();
        }

        private void ButtonViewTrainings(object sender, RoutedEventArgs e)
        {
            Application.Instance.Trainings.Clear();
            Training.LoadTrainingOneBeginner();
        }

        private void ButtonSearch(object sender, RoutedEventArgs e)
        {
            Application.Instance.Trainings.Clear();
            Training.LoadTrainingByCoach(Convert.ToInt32(coach.SelectedItem));
        }

        private void ButtonReserve(object sender, RoutedEventArgs e)
        {
            Training selectedTraining = view.CurrentItem as Training;

            if (selectedTraining != null)
            {
                int selectedTrainingId = selectedTraining.IdTrng;
                ETypeTraining selectedTypeTrng = selectedTraining.TypeTraining;

                if (selectedTypeTrng == ETypeTraining.Reserved)
                {
                    MessageBox.Show("You cannot reserve a reserved training!", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (selectedTypeTrng == ETypeTraining.Free)
                {
                    if (MessageBox.Show("Are you sure you want to reserve training?", "Confirm option",
                        MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        Training.ReserveTrainingBeginner(selectedTrainingId);
                        Application.Instance.Trainings.Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select training");
            }
        }

        private void ButtonCancle(object sender, RoutedEventArgs e)
        {
            Training selectedTraining = view.CurrentItem as Training;

            if(selectedTraining != null)
            {
                int selectedTrainingId = selectedTraining.IdTrng;
                ETypeTraining selectedTypeTrng = selectedTraining.TypeTraining;
                int selectedTrainingJmbgBeginner = selectedTraining.JmbgBeginner;

                if (selectedTrainingJmbgBeginner == Convert.ToInt32(Application.loginUser.Jmbg))
                {
                    if (MessageBox.Show("Are you sure you want to cancle training?", "Confirm option",
                        MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {

                        Training.CancleTrainingBeginner(selectedTrainingId);
                        Application.Instance.Trainings.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Please select your training");
                }

            }
            else
            {
                MessageBox.Show("Please select training");
            }
        }


    }
}
