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

namespace ProjekatPlatforme.Beginner
{
    /// <summary>
    /// Interaction logic for AddBeginner.xaml
    /// </summary>
    public partial class AddBeginner : Window
    {
        Users.Beginner beginner;
        Address.Address address;
        public AddBeginner(Users.Beginner b, Address.Address a)
        {
            InitializeComponent();
        }

        public bool isValid()
        {
            return !Validation.GetHasError(jmbg_txt) && !Validation.GetHasError(email_txt) && !Validation.GetHasError(firstName_txt)
                    && !Validation.GetHasError(lastName_txt) && !Validation.GetHasError(street_txt) && !Validation.GetHasError(number_txt)
                    && !Validation.GetHasError(state_txt) && !Validation.GetHasError(city_txt);
        }

        private void ButtonSubmit(object sender, RoutedEventArgs e)
        {

            if (isValid() && (ValidationForAddNewUser.IsValid(jmbg_txt.Text, firstName_txt.Text, lastName_txt.Text, password_txt.Password, email_txt.Text, gender_cb.Text, street_txt.Text, number_txt.Text, state_txt.Text, city_txt.Text) == true))
            {
                if (gender_cb.SelectedItem == GFemale)
                {
                    beginner = new Users.Beginner(firstName_txt.Text, lastName_txt.Text, email_txt.Text, Convert.ToInt32(jmbg_txt.Text), password_txt.Password, 1, Users.EGender.Female, Users.EUserType.beginner);
                    Application.Instance.Beginners.Add(beginner);
                    Users.Beginner.AddBeginner(beginner);

                    address = new Address.Address(street_txt.Text, Convert.ToInt32(number_txt.Text), city_txt.Text, state_txt.Text);
                    Application.Instance.Addresses.Add(address);
                    Address.Address.AddAddress(address);
                    MessageBox.Show("Successful add new beginner!");
                    Address.Address.setAddresNewBeginner();
                    Application.Instance.Addresses.Clear();
                    Address.Address.LoadAddresses();
                    Administrator.BeginnerReview beginnerRew = new Administrator.BeginnerReview();
                    this.Visibility = Visibility.Hidden;
                    beginnerRew.ShowDialog();
                }
                else if (gender_cb.SelectedItem == GMale)
                {
                    beginner = new Users.Beginner(firstName_txt.Text, lastName_txt.Text, email_txt.Text, Convert.ToInt32(jmbg_txt.Text), password_txt.Password, 1, Users.EGender.Male, Users.EUserType.beginner);
                    Application.Instance.Beginners.Add(beginner);
                    Users.Beginner.AddBeginner(beginner);

                    address = new Address.Address(street_txt.Text, Convert.ToInt32(number_txt.Text), city_txt.Text, state_txt.Text);
                    Application.Instance.Addresses.Add(address);
                    Address.Address.AddAddress(address);
                    MessageBox.Show("Successful add new beginner!");
                    Address.Address.setAddresNewBeginner();
                    Application.Instance.Addresses.Clear();
                    Address.Address.LoadAddresses();
                    Administrator.BeginnerReview beginnerRew = new Administrator.BeginnerReview();
                    this.Visibility = Visibility.Hidden;
                    beginnerRew.ShowDialog();
                }
            }


        }

        private void ButtonBack(object sender, RoutedEventArgs e)
        {
            Administrator.BeginnerReview beginnerMenuWin = new Administrator.BeginnerReview();
            this.Visibility = Visibility.Hidden;
            beginnerMenuWin.Show();
        }
    }
}
