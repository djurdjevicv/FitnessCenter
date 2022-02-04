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

namespace ProjekatPlatforme
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void ButtonBack(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            objMainWindow.Show();
        }

        public bool isValid()
        {
            long jmbg = 0;
            try
            {
                jmbg = Convert.ToInt64(txtJMBG.Text);
            }
            catch
            {
                MessageBox.Show("JMBG or password is incorect", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (txtJMBG.Text == string.Empty)
            {
                MessageBox.Show("JMBG or password is incorect", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (txtPassword.Password == string.Empty)
            {
                MessageBox.Show("JMBG or password is incorect", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
        
        private void ButtonSubmit(object sender, RoutedEventArgs e)
        {

            SqlConnection sqlCon = new SqlConnection(Application.CONNECTION_STRING);
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String query = "SELECT * FROM administrator WHERE Jmbg=@Jmbg AND Password=@password AND Active=@Active";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Jmbg", txtJMBG.Text);
                sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Password);
                sqlCmd.Parameters.AddWithValue("@Active", "true");

                if(isValid() == true)
                {
                    using (SqlDataReader reader = sqlCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Application.loginUser = new Users.Administrator();
                            Application.loginUser.Jmbg = reader.GetInt64(0);
                            Application.loginUser.FirstName = reader.GetString(1);
                            Application.loginUser.LastName = reader.GetString(2);
                            Application.loginUser.Gender = (Users.EGender)Enum.Parse(typeof(Users.EGender), reader.GetString(3));
                            Application.loginUser.Email = reader.GetString(4);
                            Application.loginUser.Password = reader.GetString(5);
                            Application.loginUser.UserType = (Users.EUserType)Enum.Parse(typeof(Users.EUserType), reader.GetString(6));
                            Application.loginUser.Active = bool.Parse((string)reader.GetString(7));
                            Application.loginUser.IDAddress = Convert.ToInt32(reader.GetInt16(8));


                            Administrator.AdminMenu adminMenu = new Administrator.AdminMenu();
                            adminMenu.Show();
                            this.Close();
                        }
                        

                    }

                    query = "SELECT * FROM beginner WHERE Jmbg=@Jmbg AND Password=@password AND Active=@Active";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@Jmbg", txtJMBG.Text);
                    sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Password);
                    sqlCmd.Parameters.AddWithValue("@Active", "true");
                    using (SqlDataReader reader = sqlCmd.ExecuteReader())
                    {
                      
                        while (reader.Read())
                        {
                            Application.loginUser = new Users.Beginner();
                            Application.loginUser.Jmbg = reader.GetInt64(0);
                            Application.loginUser.FirstName = reader.GetString(1);
                            Application.loginUser.LastName = reader.GetString(2);
                            Application.loginUser.Gender = (Users.EGender)Enum.Parse(typeof(Users.EGender), reader.GetString(3));
                            Application.loginUser.Email = reader.GetString(4);
                            Application.loginUser.Password = reader.GetString(5);
                            Application.loginUser.UserType = (Users.EUserType)Enum.Parse(typeof(Users.EUserType), reader.GetString(6));
                            Application.loginUser.Active = bool.Parse((string)reader.GetString(7));
                            Application.loginUser.IDAddress = Convert.ToInt32(reader.GetInt16(8));
                            Beginner.BegginerMenu beginnerMenu = new Beginner.BegginerMenu();
                            beginnerMenu.Show();
                            this.Close();
                        }

                    }

                    query = "SELECT * FROM coach WHERE Jmbg=@Jmbg AND Password=@password AND Active=@Active";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@Jmbg", txtJMBG.Text);
                    sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Password);
                    sqlCmd.Parameters.AddWithValue("@Active", "true");
                    using (SqlDataReader reader = sqlCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Application.loginUser = new Users.Coach();
                            Application.loginUser.Jmbg = reader.GetInt64(0);
                            Application.loginUser.FirstName = reader.GetString(1);
                            Application.loginUser.LastName = reader.GetString(2);
                            Application.loginUser.Gender = (Users.EGender)Enum.Parse(typeof(Users.EGender), reader.GetString(3));
                            Application.loginUser.Email = reader.GetString(4);
                            Application.loginUser.Password = reader.GetString(5);
                            Application.loginUser.UserType = (Users.EUserType)Enum.Parse(typeof(Users.EUserType), reader.GetString(6));
                            Application.loginUser.Active = bool.Parse((string)reader.GetString(7));
                            Application.loginUser.IDAddress = Convert.ToInt32(reader.GetInt16(8));
                            Coach.CoachMenu coachMenu = new Coach.CoachMenu();
                            coachMenu.Show();
                            this.Close();
                        }
                        
                    }
                    if (Application.loginUser == null)
                    {
                        MessageBox.Show("JMBG or password is incorect", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            finally
            {
                sqlCon.Close();
            }
        }


    }
}
