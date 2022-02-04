using ProjekatPlatforme.Validations;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for EditTrainingAdmin.xaml
    /// </summary>
    public partial class EditTrainingAdmin : Window
    {
        public EditTrainingAdmin(int trngId, DateTime selectedDate,TimeSpan selectedTime,ETypeTraining selectedTrngType,int selectedJmbgCoach,int selectedJmbgBeginner)
        {
            InitializeComponent();
            findCoaches(selectedJmbgCoach);
            findBeginner(selectedJmbgBeginner);
            findTrainingType(trngId);
            findTrainingTime(trngId, selectedTime);


            time.SelectedItem = selectedTime.ToString(@"hh\:mm");
            id.Text = trngId.ToString();
            date.SelectedDate = selectedDate;

        }

        private void findTrainingType(int id)
        {
            foreach (Training training in Application.listUnDeleteTrainings)
            {
                if(training.IdTrng == id)
                {
                    if (training.TypeTraining == ETypeTraining.Free)
                    {
                        typeTrng.SelectedItem = Free;
                    }
                    else
                    {
                        typeTrng.SelectedItem = Reserved;
                    }
                }

            }
        }
        private void findTrainingTime(int id, TimeSpan selectedTime)
        {
            foreach (string trng in Application.terminsForTrainings)
            {
                time.Items.Add(trng);
            }
            
        }
        private void findCoaches(long selectedJmbgCoach)
        {
            foreach (Users.Coach coachs in Application.Instance.Coaches)
            {
                coach.Items.Add(coachs.Jmbg);
                coach.SelectedValue = selectedJmbgCoach;
            }
        }
        private void findBeginner(long selectedJmbgBeginner)
        {
            foreach (Users.Beginner beginners in Application.Instance.Beginners)
            {
                beginner.Items.Add(beginners.Jmbg);
                beginner.SelectedValue = selectedJmbgBeginner;
            }
        }

        private void ButtonBack(object sender, RoutedEventArgs e)
        {
            Administrator.TrainingReview trainingReview = new Administrator.TrainingReview();
            this.Visibility = Visibility.Hidden;
            trainingReview.ShowDialog();
        }

        private void ButtonSubmit(object sender, RoutedEventArgs e)
        {

            if (typeTrng.SelectedItem == Free)
            {
                if(beginner.SelectedItem != null)
                {
                    MessageBox.Show("This training must be reserved!");
                }
                else if (beginner.SelectedItem == null)
                {
                    if (EditTrainingAdminValidation.isValid(time.SelectedItem.ToString(), coach.SelectedItem.ToString(), date.SelectedDate.ToString(), typeTrng.SelectedItem.ToString()) == true)
                    {
                        Training.EditTrainingAdmin(Convert.ToInt32(id.Text), date.SelectedDate.Value, Convert.ToInt32(coach.Text), Convert.ToInt32(beginner.SelectedItem), TimeSpan.Parse(time.Text), ETypeTraining.Free);
                        MessageBox.Show("Succesful edit training data");
                        Administrator.TrainingReview trainingReview = new Administrator.TrainingReview();
                        this.Visibility = Visibility.Hidden;
                        trainingReview.ShowDialog();
                    }
                }

            }
            if (typeTrng.SelectedItem == Reserved)
            {
                if (beginner.SelectedItem == null)
                {
                    MessageBox.Show("Please select beginner!");
                }
                else if(beginner.SelectedItem != null)
                {
                    if (EditTrainingAdminValidation.isValidRes(time.SelectedItem.ToString(), coach.SelectedItem.ToString(), date.SelectedDate.ToString(), typeTrng.SelectedItem.ToString(), beginner.SelectedItem.ToString()) == true)
                    {
                        Training.EditTrainingAdmin(Convert.ToInt32(id.Text), date.SelectedDate.Value, Convert.ToInt32(coach.Text), Convert.ToInt32(beginner.SelectedItem), TimeSpan.Parse(time.Text), ETypeTraining.Reserved);
                        MessageBox.Show("Succesful edit training data");
                        Administrator.TrainingReview trainingReview = new Administrator.TrainingReview();
                        this.Visibility = Visibility.Hidden;
                        trainingReview.ShowDialog();
                    }
                }

            }




        }
    }
}
