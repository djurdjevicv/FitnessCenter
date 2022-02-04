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

namespace ProjekatPlatforme.Coach
{
    /// <summary>
    /// Interaction logic for CoachAddWindow.xaml
    /// </summary>
    public partial class CoachAddWindow : Window
    {
        Users.Coach coach;
        Address.Address address;

        public CoachAddWindow(Users.Coach c, Address.Address a)
        {
            InitializeComponent();
            coach = c;
            firstName_txt.DataContext = coach;
            lastName_txt.DataContext = coach;
            jmbg_txt.DataContext = coach;
            password_txt.DataContext = coach;
            email_txt.DataContext = coach;
            gender_cb.DataContext = coach;

            address = a;
            street_txt.DataContext = address;
            number_txt.DataContext = address;
            state_txt.DataContext = address;
            city_txt.DataContext = address;

            Application.Instance.Addresses.Clear();
            Address.Address.LoadAddresses();
        }

        public bool isValid()
        {
            return !Validation.GetHasError(jmbg_txt) && !Validation.GetHasError(email_txt) && !Validation.GetHasError(firstName_txt)
                    && !Validation.GetHasError(lastName_txt) && !Validation.GetHasError(street_txt) && !Validation.GetHasError(number_txt)
                    && !Validation.GetHasError(state_txt) && !Validation.GetHasError(city_txt);
        }

        private void ButtonSubmit(object sender, RoutedEventArgs e)
        {
                
            if (isValid() && (ValidationForAddNewUser.IsValid(jmbg_txt.Text,firstName_txt.Text, lastName_txt.Text, password_txt.Password, email_txt.Text, gender_cb.Text, street_txt.Text, number_txt.Text, state_txt.Text, city_txt.Text) == true))
                {
                    if (gender_cb.SelectedItem == GFemale)
                    {
                        coach = new Users.Coach(firstName_txt.Text, lastName_txt.Text, email_txt.Text, Convert.ToInt32(jmbg_txt.Text), password_txt.Password, 1, Users.EGender.Female, Users.EUserType.beginner);
                        Application.Instance.Coaches.Add(coach);
                        Users.Coach.AddCoach(coach);

                        address = new Address.Address(street_txt.Text, Convert.ToInt32(number_txt.Text), city_txt.Text, state_txt.Text);
                        Application.Instance.Addresses.Add(address);
                        Address.Address.AddAddress(address);
                        MessageBox.Show("Successful add new coach!");
                        Address.Address.setAddresNewCoach();
                        Application.Instance.Addresses.Clear();
                        Address.Address.LoadAddresses();
                        Administrator.CoachReview coachRew = new Administrator.CoachReview();
                        this.Visibility = Visibility.Hidden;
                        coachRew.ShowDialog();
                    }
                    else if (gender_cb.SelectedItem == GMale)
                    {
                        coach = new Users.Coach(firstName_txt.Text, lastName_txt.Text, email_txt.Text, Convert.ToInt32(jmbg_txt.Text), password_txt.Password, 1, Users.EGender.Male, Users.EUserType.beginner);
                        Application.Instance.Coaches.Add(coach);
                        Users.Coach.AddCoach(coach);

                        address = new Address.Address(street_txt.Text, Convert.ToInt32(number_txt.Text), city_txt.Text, state_txt.Text);
                        Application.Instance.Addresses.Add(address);
                        Address.Address.AddAddress(address);
                        MessageBox.Show("Successful add new coach!");
                        Address.Address.setAddresNewCoach();
                        Application.Instance.Addresses.Clear();
                        Address.Address.LoadAddresses();
                        Administrator.CoachReview coachRew = new Administrator.CoachReview();
                        this.Visibility = Visibility.Hidden;
                        coachRew.ShowDialog();
                    }
                }
        }


        private void ButtonBack(object sender, RoutedEventArgs e)
        {
            Administrator.CoachReview coachMenuWin = new Administrator.CoachReview();
            this.Visibility = Visibility.Hidden;
            coachMenuWin.Show();
        }

    }
}
