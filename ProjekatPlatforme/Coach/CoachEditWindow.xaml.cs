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
    /// Interaction logic for CoachEditWindow.xaml
    /// </summary>
    public partial class CoachEditWindow : Window
    {

        long coachJmbg;
        int addressId;

        public CoachEditWindow(long selectedJmbg, string selectedFirstName,string selectedLastName, string selectedPassword, string selectedEmail, int slectedAddressId, Users.EGender selectedGender)
        {
            InitializeComponent();
            getDbValue(selectedJmbg, selectedFirstName, selectedLastName, selectedPassword, selectedEmail, selectedGender);
            findDataAddress(slectedAddressId);
            coachJmbg = selectedJmbg;
            addressId = slectedAddressId;
        }

        private void getDbValue(long selectedJmbg,string selectedFirstName, string selectedLastName, string selectedPassword, string selectedEmail, Users.EGender selectedGender)
        {
            jmbg_txt.Text = selectedJmbg.ToString();
            firstName_txt.Text = selectedFirstName;
            lastName_txt.Text = selectedLastName;
            password_txt.Password = selectedPassword;
            email_txt.Text = selectedEmail;
            if (selectedGender == Users.EGender.Male)
            {
                gender_cb.SelectedItem = GMale;
            }
            else
            {
                gender_cb.SelectedItem = GFemale;
            }

        }

        private void findDataAddress(int slectedAddressId)
        {
            foreach (Address.Address address in Application.Instance.Addresses)
            {
                if (address.IDAddress == slectedAddressId)
                {
                    idAddress_txt.Text= address.IDAddress.ToString();
                    street_txt.Text = address.Street;
                    number_txt.Text = address.Number.ToString();
                    city_txt.Text = address.City;
                    state_txt.Text = address.State;
                }

            }
        }


        private void ButtonSubmit(object sender, RoutedEventArgs e)
        {
            if (ValidationForEditAccount.IsValid(firstName_txt.Text, lastName_txt.Text, password_txt.Password, email_txt.Text, gender_cb.Text, street_txt.Text, number_txt.Text, state_txt.Text, city_txt.Text) == true)
            {
                Users.Coach.AdminEditCoach(Convert.ToInt64(jmbg_txt.Text), firstName_txt.Text, lastName_txt.Text, password_txt.Password, email_txt.Text);
                Address.Address.EditAddressAdmin(Convert.ToInt32(idAddress_txt.Text), street_txt.Text, Convert.ToInt32(number_txt.Text), state_txt.Text, city_txt.Text);
                MessageBox.Show("Succesful edit coach data");

                foreach(Address.Address a in Application.Instance.Addresses)
                {
                    if(a.IDAddress == addressId)
                    {
                        a.City = city_txt.Text;
                        a.Street = street_txt.Text;
                        a.Number = Convert.ToInt32(number_txt.Text);
                        a.State = state_txt.Text;
                    }
                }
                Administrator.CoachReview coachRevWin = new Administrator.CoachReview();
                this.Visibility = Visibility.Hidden;
                coachRevWin.Show();
            }

        }

        private void ButtonBack(object sender, RoutedEventArgs e)
        {
            Administrator.CoachReview coachRevWin = new Administrator.CoachReview();
            this.Visibility = Visibility.Hidden;
            coachRevWin.Show();
        }
    }
}
