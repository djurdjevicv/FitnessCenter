using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjekatPlatforme.Validations
{
    internal class EditTrainingAdminValidation
    {
        public static Boolean isValid(string time, string coach, string date, string typeTrng)
        {

            if (time == "")
            {
                MessageBox.Show("Time is required");
                return false;
            }
            if (coach == "")
            {
                MessageBox.Show("Coach is required");
                return false;
            }
            if (date == "")
            {
                MessageBox.Show("Date is required");
                return false;
            }
            if (typeTrng == "")
            {
                MessageBox.Show("Type of training is required");
                return false;
            }
            if (typeTrng.ToUpper() == "Free".ToUpper())
            {
                MessageBox.Show("Type of training must be reserved");
                return false;
            }
            if (DateTime.Parse(date) < DateTime.Now)
            {
                MessageBox.Show("Invalid date");
                return false;
            }

            foreach (Training.Training training in Application.listUnDeleteTrainings)
            {
                string datumIzBaze = training.DateTrng.ToString();
                TimeSpan time1 = TimeSpan.Parse(time);
                if (Convert.ToInt64(coach) == training.JmbgCoach && date.ToString() == datumIzBaze && time1 == training.TimeTrng)
                {
                    MessageBox.Show("Already have reserved training!");
                    return false;
                }
            }

            return true;

        }

        public static Boolean isValidRes(string time, string coach, string date, string typeTrng, string beginner)
        {

            if (time == "")
            {
                MessageBox.Show("Time is required");
                return false;
            }
            if (coach == "")
            {
                MessageBox.Show("Coach is required");
                return false;
            }
            if (date == "")
            {
                MessageBox.Show("Date is required");
                return false;
            }
            if (typeTrng == "")
            {
                MessageBox.Show("Type of training is required");
                return false;
            }
            if (DateTime.Parse(date) < DateTime.Now)
            {
                MessageBox.Show("Invalid date");
                return false;
            }

            return true;
        }



    }
}

