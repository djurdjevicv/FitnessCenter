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

namespace ProjekatPlatforme.Administrator
{
    /// <summary>
    /// Interaction logic for AdminData.xaml
    /// </summary>
    public partial class AdminData : Window
    {
        
        public AdminData()
        {
            InitializeComponent();
            findData();
            findDataAddress();
        }

        private void findData()
        {
            foreach (Users.Administrator administrator in Application.Instance.Administrators)
            {
                if(administrator.Jmbg == Application.loginUser.Jmbg)
                {
                    firstName_txt.Text = administrator.FirstName;
                    lastName_txt.Text = administrator.LastName;
                    password_txt.Password = administrator.Password;
                    email_txt.Text = administrator.Email;
                    if(administrator.Gender == Users.EGender.Male)
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
            if (ValidationForEditAccount.IsValid(firstName_txt.Text, lastName_txt.Text, password_txt.Password, email_txt.Text, gender_cb.Text, street_txt.Text, number_txt.Text, state_txt.Text, city_txt.Text) == true)
            {
                foreach (Users.Administrator administrator in Application.Instance.Administrators)
                {
                    if (administrator.Jmbg == Application.loginUser.Jmbg)
                    {
                        administrator.FirstName = firstName_txt.Text;
                        administrator.LastName = lastName_txt.Text;
                        administrator.Password = password_txt.Password;
                        administrator.Email = email_txt.Text;
                        if (gender_cb.SelectedItem == GMale)
                        {
                            administrator.Gender = Users.EGender.Male;
                        }
                        else
                        {
                            administrator.Gender = Users.EGender.Female;
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

                if(gender_cb.SelectedItem == GMale)
                {
                    Users.Administrator.EditAdmin(firstName_txt.Text, lastName_txt.Text, password_txt.Password, email_txt.Text, "Male");

                    MessageBox.Show("Succesful edit your data");
                    AdminMenu adminMenu = new AdminMenu();
                    this.Visibility = Visibility.Hidden;
                    adminMenu.Show();
                    Address.Address.EditAddress(street_txt.Text, Convert.ToInt32(number_txt.Text), state_txt.Text, city_txt.Text);
                }
                else
                {
                    Users.Administrator.EditAdmin(firstName_txt.Text, lastName_txt.Text, password_txt.Password, email_txt.Text, "Female");

                    MessageBox.Show("Succesful edit your data");
                    AdminMenu adminMenu = new AdminMenu();
                    this.Visibility = Visibility.Hidden;
                    adminMenu.Show();
                    Address.Address.EditAddress(street_txt.Text, Convert.ToInt32(number_txt.Text), state_txt.Text, city_txt.Text);
                }


            }



        }

        private void ButtonBack(object sender, RoutedEventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu();
            this.Visibility = Visibility.Hidden;
            adminMenu.Show();
        }
    }
}
