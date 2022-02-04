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

namespace ProjekatPlatforme.Administrator
{
    /// <summary>
    /// Interaction logic for TrainingReview.xaml
    /// </summary>
    public partial class TrainingReview : Window
    {
        ICollectionView view;
        public TrainingReview()
        {
            InitializeComponent();
            view = CollectionViewSource.GetDefaultView(Application.Instance.Trainings);
            dataGrid.ItemsSource = view;
            dataGrid.IsSynchronizedWithCurrentItem = true;
            Application.Instance.Trainings.Clear();
            Training.Training.LoadTraining();






        }

        private void ButtonBack(object sender, RoutedEventArgs e)
        {
            AdminMenu adminMenuWin = new AdminMenu();
            this.Visibility = Visibility.Hidden;
            adminMenuWin.Show();
        }

        private void ButtonDelete(object sender, RoutedEventArgs e)
        {
            Training.Training selectedTraining = view.CurrentItem as Training.Training;

            if(selectedTraining != null)
            {
                int selectedTrainingId = selectedTraining.IdTrng;

                if (MessageBox.Show("Are you sure you want to delete training?", "Confirm option",
                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Application.Instance.Trainings.Remove(selectedTraining);
                    Training.Training.DeleteTrainingAdmin(selectedTrainingId);
                }
            }
            else
            {
                MessageBox.Show("Please select training!");
            }




        }

        private void ButtonAdd(object sender, RoutedEventArgs e)
        {
            Training.AddTrainingAdmin addTraining = new Training.AddTrainingAdmin();
            this.Visibility = Visibility.Hidden;
            addTraining.Show();
        }

        

        private void ButtonEdit(object sender, RoutedEventArgs e)
        {
            Training.Training selectedTraining = view.CurrentItem as Training.Training;
            if (selectedTraining != null)
            {
                int trngId = selectedTraining.IdTrng;
                DateTime selectedDate = selectedTraining.DateTrng;
                TimeSpan selectedTime = selectedTraining.TimeTrng;
                Training.ETypeTraining selectedTrngType = selectedTraining.TypeTraining;
                int selectedJmbgCoach = selectedTraining.JmbgCoach;
                int selectedJmbgBeginner = selectedTraining.JmbgBeginner;

                Training.EditTrainingAdmin editTrainingAdmin = new Training.EditTrainingAdmin(trngId, selectedDate, selectedTime, selectedTrngType, selectedJmbgCoach, selectedJmbgBeginner);
                this.Visibility = Visibility.Hidden;
                editTrainingAdmin.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select training");
            }

        }
    }
}
