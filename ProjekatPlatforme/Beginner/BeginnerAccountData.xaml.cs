using ProjekatPlatforme.Validations;
using System;
using System.Collections.Generic;
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

namespace ProjekatPlatforme.Beginner
{
    /// <summary>
    /// Interaction logic for BeginnerAccountData.xaml
    /// </summary>
    public partial class BeginnerAccountData : Window
    {
        public BeginnerAccountData()
        {
            InitializeComponent();
            findData();
            findDataAddress();
        }

        private void findData()
        {
            foreach (Users.Beginner beginner in Application.Instance.Beginners)
            {
                if (beginner.Jmbg == Application.loginUser.Jmbg)
                {
                    firstName_txt.Text = beginner.FirstName;
                    lastName_txt.Text = beginner.LastName;
                    password_txt.Password = beginner.Password;
                    email_txt.Text = beginner.Email;
                    if (beginner.Gender == Users.EGender.Male)
                    {
                        gender_cb.SelectedItem = GMale;
                    }
                    else
                    {
                        gender_cb.SelectedItem = GFemale;
                    }
                }

            }
        }

        private void findDataAddress()
        {
            foreach (Address.Address address in Application.Instance.Addresses)
            {
                if (address.IDAddress == Application.loginUser.IDAddress)
                {
                    street_txt.Text = address.Street;
                    number_txt.Text = address.Number.ToString();
                    city_txt.Text = address.City;
                    state_txt.Text = address.State;
                }

            }
        }

        private void ButtonBack(object sender, RoutedEventArgs e)
        {
            BegginerMenu beginnerMenu = new BegginerMenu();
            this.Visibility = Visibility.Hidden;
            beginnerMenu.Show();
        }

        private void ButtonSubmit(object sender, RoutedEventArgs e)
        {
            if (ValidationForEditAccount.IsValid(firstName_txt.Text, lastName_txt.Text, password_txt.Password, email_txt.Text, gender_cb.Text, street_txt.Text, number_txt.Text, state_txt.Text, city_txt.Text) == true)
            {
                Users.Beginner.EditBeginner(firstName_txt.Text, lastName_txt.Text, password_txt.Password, email_txt.Text, gender_cb.Text);
                MessageBox.Show("Succesful edit your data");
                BegginerMenu beginnerMenu = new BegginerMenu();
                this.Visibility = Visibility.Hidden;
                beginnerMenu.Show();
                Address.Address.EditAddress(street_txt.Text, Convert.ToInt32(number_txt.Text), state_txt.Text, city_txt.Text);

                foreach (Users.Beginner beginner in Application.Instance.Beginners)
                {
                    if (beginner.Jmbg == Application.loginUser.Jmbg)
                    {
                        beginner.FirstName = firstName_txt.Text;
                        beginner.LastName = lastName_txt.Text;
                        beginner.Password = password_txt.Password;
                        beginner.Email = email_txt.Text;
                        if (gender_cb.SelectedItem == GMale)
                        {

                            beginner.Gender = Users.EGender.Male;
                        }
                        else
                        {
                            beginner.Gender = Users.EGender.Female;
                        }
                    }
                }
                foreach (Address.Address address in Application.Instance.Addresses)
                {
                    if (address.IDAddress == Application.loginUser.IDAddress)
                    {
                        address.Street = street_txt.Text;
                        address.Number = Convert.ToInt32(number_txt.Text);
                        address.City = city_txt.Text;
                        address.State = state_txt.Text;
                    }

                }
            }

        }
    }
}
