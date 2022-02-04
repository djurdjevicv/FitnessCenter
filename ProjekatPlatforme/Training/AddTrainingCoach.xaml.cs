using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for AddTrainingCoach.xaml
    /// </summary>
    public partial class AddTrainingCoach : Window
    {
        Training training;
        public AddTrainingCoach()
        {
            InitializeComponent();
            findTermins();
        }

        private void findTermins()
        {
            foreach (string training in Application.terminsForTrainings)
            {
                time.Items.Add(training);
            }
        }
        private void ButtonBack(object sender, RoutedEventArgs e)
        {
            Coach.ReviewTrainingCoach review = new Coach.ReviewTrainingCoach();
            this.Visibility = Visibility.Hidden;
            review.Show();
        }

        private bool isValid()
        {

            foreach(Training trng in Application.listTrainings)
            {
                if (date.SelectedDate < DateTime.Now)
                {
                    MessageBox.Show("Invalid selected date!");
                    return false;
                }
                if (date.SelectedDate == null)
                {
                    MessageBox.Show("Please select date!");
                    return false;
                }

                if (time.SelectedItem == null)
                {
                    MessageBox.Show("Please select time!");
                    return false;
                }

                string datumIzBaze = trng.DateTrng.ToString();
                TimeSpan test = TimeSpan.Parse(time.Text);

                if (date.ToString() == datumIzBaze && trng.JmbgCoach == Application.loginUser.Jmbg &&  test == trng.TimeTrng)
                {

                    MessageBox.Show("You already have training for this date and time!");
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
                int selectedCoach = Convert.ToInt32(Application.loginUser.Jmbg);
                TimeSpan selectedTime = TimeSpan.Parse(time.Text);

                training = new Training(trngId, selectedDate, selectedTime, durationTrng, ETypeTraining.Free, selectedCoach, jmbgBeginner);
                Application.Instance.Trainings.Add(training);
                Training.AddTraining(training);
                Application.listTrainings.Add(training);

                MessageBox.Show("Successfully added training");
                Coach.ReviewTrainingCoach review = new Coach.ReviewTrainingCoach();
                this.Visibility = Visibility.Hidden;
                review.Show();
            }



        }

    }
    }

