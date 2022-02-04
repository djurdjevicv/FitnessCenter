using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    /// Interaction logic for AddTrainingAdmin.xaml
    /// </summary>
    public partial class AddTrainingAdmin : Window
    {
        Training training;
        
        public AddTrainingAdmin()
        {
            InitializeComponent();
            finCoaches();
            findTermins();
        }

        private void finCoaches()
        {
            foreach (Users.Coach coachs in Application.Instance.Coaches)
            {
                coach.Items.Add(coachs.Jmbg);
            }
        }

        public void findTermins()
        {
            foreach(string training in Application.terminsForTrainings)
            {
                time.Items.Add(training);
            }

        }

        private void ButtonBack(object sender, RoutedEventArgs e)
        {
            Administrator.TrainingReview trainingReview = new Administrator.TrainingReview();
            this.Visibility = Visibility.Hidden;
            trainingReview.ShowDialog();
        }

        private bool isValid()
        {

            foreach (Training trng in Application.listTrainings)
            {
                if (date.SelectedDate < DateTime.Now)
                {
                    MessageBox.Show("Invalid selected date!");
                    return false;
                }
                if (date.SelectedDate == null)
                {
                    MessageBox.Show("Please select date for training");
                    return false;
                }

                if (time.SelectedItem == null)
                {
                    MessageBox.Show("Please select time for training");
                    return false;
                }
                if (coach.SelectedItem == null)
                {
                    MessageBox.Show("Please select coach");
                    return false;
                }

                string datumIzBaze = trng.DateTrng.ToString();
                TimeSpan test = TimeSpan.Parse(time.Text);
                int selectedCoach = int.Parse(coach.SelectedItem.ToString());

                if (date.ToString() == datumIzBaze && selectedCoach == trng.JmbgCoach && test == trng.TimeTrng)
                {

                    MessageBox.Show("Vec imate zakazan trening za ovaj datum i ovo vreme");
                    return false;
                }
            }

            return true;
        }

        private void ButtonSubmit(object sender, RoutedEventArgs e)
        {
            string durationTrng = "60min";
            int jmbgBeginner = 0;

            int trngId = Training.newTrainingId();



            if (isValid())
            {
                DateTime selectedDate = Convert.ToDateTime(date.Text);
                int selectedCoach = Convert.ToInt32(coach.Text);
                TimeSpan selectedTime = TimeSpan.Parse(time.Text);

                training = new Training(trngId, selectedDate, selectedTime, durationTrng, ETypeTraining.Free, selectedCoach, jmbgBeginner);
                Application.Instance.Trainings.Add(training);
                Training.AddTraining(training);
                Application.listTrainings.Add(training);

                MessageBox.Show("Successfully added training");
                Administrator.TrainingReview trainingReview = new Administrator.TrainingReview();
                this.Visibility = Visibility.Hidden;
                trainingReview.ShowDialog();
            }

        }
    }
}
