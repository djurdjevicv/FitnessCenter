using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjekatPlatforme.Validations
{
    internal class ValidationForAddNewUser
    {
        public static Boolean IsValid(string jmbg, string firstName, string lastName, string password, string email, string gender_cb, string street, string number, string state, string city)
        {
            //JMBG
            int jmbg1 = 0;
            try
            {
                jmbg1 = Convert.ToInt32(jmbg);
            }
            catch
            {
                MessageBox.Show("Jmbg must be number!");
                return false;
            }
            if (number == "")
            {
                MessageBox.Show("Jmbg is required!");
                return false;
            }
            foreach(Users.Administrator a in Application.Instance.Administrators)
            {
                if (jmbg1 == a.Jmbg)
                {
                    MessageBox.Show("Jmbg already exist!");
                    return false;
                }
            }
            foreach (Users.Coach c in Application.Instance.Coaches)
            {
                if (jmbg1 == c.Jmbg)
                {
                    MessageBox.Show("Jmbg already exist!");
                    return false;
                }
            }
            foreach (Users.Beginner b in Application.Instance.Beginners)
            {
                if (jmbg1 == b.Jmbg)
                {
                    MessageBox.Show("Jmbg already exist!");
                    return false;
                }
            }
            //FIRST NAME
            if (firstName == "")
            {
                MessageBox.Show("First name is required!");
                return false;
            }
            string firstName1 = firstName.Replace(" ", "");
            if (!ValidatorExtensions.IsOnlyString(firstName1))
            {
                MessageBox.Show("The first name must not contain numbers!");
                return false;
            }
            //LAST NAME
            if (lastName == "")
            {
                MessageBox.Show("Last name is required!");
                return false;
            }
            string lastName1 = city.Replace(" ", "");
            if (!ValidatorExtensions.IsOnlyString(lastName1))
            {
                MessageBox.Show("The last name must not contain numbers!");
                return false;
            }
            //PASSWORD
            if (password == "")
            {
                MessageBox.Show("Password is required!");
                return false;
            }
            //EMAIL
            if (email == "")
            {
                MessageBox.Show("Email is required!");
                return false;
            }
            if (!ValidatorExtensions.IsValidEmailAddress(email))
            {
                MessageBox.Show("Email must be like user@gmail.com!");
                return false;
            }
            //GENDER
            if (gender_cb == "")
            {
                MessageBox.Show("Gender is required!");
                return false;
            }
            //STREET
            if (street == "")
            {
                MessageBox.Show("Street is required!");
                return false;
            }
            //NUMBER
            int number1 = 0;
            try
            {
                number1 = Convert.ToInt32(number);
            }
            catch
            {
                MessageBox.Show("Number must be number!");
                return false;
            }
            if (number == "")
            {
                MessageBox.Show("Strret is required!");
                return false;
            }
            //STATE
            if (state == "")
            {
                MessageBox.Show("State is required!");
                return false;
            }
            string state1 = state.Replace(" ", "");
            if (!ValidatorExtensions.IsOnlyString(state1))
            {
                MessageBox.Show("The state must not contain numbers!");
                return false;
            }
            //CITY
            if (city == "")
            {
                MessageBox.Show("City is required!");
                return false;
            }
            string city1 = city.Replace(" ", "");
            if (!ValidatorExtensions.IsOnlyString(city1))
            {
                MessageBox.Show("The city must not contain numbers!");
                return false;
            }

            return true;
        }
    }
}
