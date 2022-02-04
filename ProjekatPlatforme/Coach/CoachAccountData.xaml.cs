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

namespace ProjekatPlatforme.Coach
{
    /// <summary>
    /// Interaction logic for CoachAccountData.xaml
    /// </summary>
    public partial class CoachAccountData : Window
    {

        public CoachAccountData()
        {
            InitializeComponent();
            findData();
            findDataAddress();
        }

        private void findData()
        {
            foreach (Users.Coach coach in Application.Instance.Coaches)
            {
                if (coach.Jmbg == Application.loginUser.Jmbg)
                {
                    firstName_txt.Text = coach.FirstName;
                    lastName_txt.Text = coach.LastName;
                    password_txt.Password = coach.Password;
                    email_txt.Text = coach.Email;
                    if (coach.Gender == Users.EGender.Male)
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

        private void ButtonSubmit(object sender, RoutedEventArgs e)
        {
            if(ValidationForEditAccount.IsValid(firstName_txt.Text, lastName_txt.Text, password_txt.Password, email_txt.Text, gender_cb.Text, street_txt.Text, number_txt.Text, state_txt.Text, city_txt.Text) == true)
            {
                Users.Coach.EditCoach(firstName_txt.Text, lastName_txt.Text, password_txt.Password, email_txt.Text, gender_cb.Text);
                MessageBox.Show("Succesful edit your data");
                CoachMenu coachMenu = new CoachMenu();
                this.Visibility = Visibility.Hidden;
                coachMenu.Show();

                Address.Address.EditAddress(street_txt.Text, Convert.ToInt32(number_txt.Text), state_txt.Text, city_txt.Text);

                foreach (Users.Coach coach in Application.Instance.Coaches)
                {
                    if (coach.Jmbg == Application.loginUser.Jmbg)
                    {
                        coach.FirstName = firstName_txt.Text; 
                        coach.LastName = lastName_txt.Text;
                        coach.Password = password_txt.Password;
                        coach.Email = email_txt.Text;
                        if (gender_cb.SelectedItem == GMale)
                        {
                            coach.Gender = Users.EGender.Male;
                        }
                        else
                        {
                            coach.Gender = Users.EGender.Female;
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

        private void ButtonBack(object sender, RoutedEventArgs e)
        {
            Coach.CoachMenu coachMenu = new Coach.CoachMenu();
            this.Visibility = Visibility.Hidden;
            coachMenu.Show();
        }
    }
}
