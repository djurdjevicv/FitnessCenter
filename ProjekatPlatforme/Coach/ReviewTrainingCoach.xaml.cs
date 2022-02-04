using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for ReviewTrainingCoach.xaml
    /// </summary>
    public partial class ReviewTrainingCoach : Window
    {
        ICollectionView view;
        public ReviewTrainingCoach()
        {
            InitializeComponent();
            view = CollectionViewSource.GetDefaultView(Application.Instance.Trainings);
            dataGrid.ItemsSource = view;
            dataGrid.IsSynchronizedWithCurrentItem = true;
            Application.Instance.Trainings.Clear();
        }

        private void ButtonBack(object sender, RoutedEventArgs e)
        {
            CoachMenu coachMenu = new CoachMenu();
            this.Visibility = Visibility.Hidden;
            coachMenu.Show();
        }

        private void ButtonViewAll(object sender, RoutedEventArgs e)
        {
            Application.Instance.Trainings.Clear();
            Training.Training.LoadTrainingOneCoach();
        }

        private void ButtonSearch(object sender, RoutedEventArgs e)
        {

            if(selectedDate.SelectedDate == null)
            {
                MessageBox.Show("Please select date!");
            }
            else if (selectedDate.SelectedDate != null)
            {
                Application.Instance.Trainings.Clear();
                Training.Training.LoadTrainingByDate(selectedDate.SelectedDate.Value);
            }

        }

        private void ButtonAddTraining(object sender, RoutedEventArgs e)
        {
            Training.AddTrainingCoach add = new Training.AddTrainingCoach();
            this.Visibility = Visibility.Hidden;
            add.Show();
        }

        private void ButtonDelete(object sender, RoutedEventArgs e)
        {
            Training.Training selectedTraining = view.CurrentItem as Training.Training;




            if (selectedTraining != null)
            {
                int selectedTrainingId = selectedTraining.IdTrng;
                Training.ETypeTraining selectedTypeTrng = selectedTraining.TypeTraining;

                if (selectedTypeTrng == Training.ETypeTraining.Reserved)
                {
                    MessageBox.Show("You cannot delete a reserved training!", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (selectedTypeTrng == Training.ETypeTraining.Free)
                {
                    if (MessageBox.Show("Are you sure you want to delete training?", "Confirm option",
                        MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        Application.Instance.Trainings.Remove(selectedTraining);
                        Training.Training.DeleteTrainingAdmin(selectedTrainingId);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select training");
            }


        }
    }
}
