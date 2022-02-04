using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjekatPlatforme.Users
{
    public class Coach : Users
    {

        public Coach()
        {
        }

        public Coach(string firstName, string lastName, string email, int jmbg, string password, int IDAddress, EGender gender, EUserType userType) : base(firstName, lastName, email, jmbg, password, IDAddress, gender, userType)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }

        

        public static void LoadCoaches()
        {
            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                DataSet ds = new DataSet();

                SqlCommand coachCommand = connection.CreateCommand();
                coachCommand.CommandText = @"SELECT * FROM coach WHERE active = 'true'";
                SqlDataAdapter daCoach = new SqlDataAdapter();
                daCoach.SelectCommand = coachCommand;
                daCoach.Fill(ds, "Coach");


                foreach (DataRow row in ds.Tables["Coach"].Rows)
                {
                    Coach c = new Coach();
                    
                    c._jmbg = (int)Convert.ToInt64(row["jmbg"]);
                    c._firstName = (string)row["first_name"];
                    c._lastName = (string)row["last_name"];
                    c._gender = (EGender)Enum.Parse(typeof(EGender), (string)row["gender"]);
                    c._email = (string)row["email"];
                    c._password = (string)row["password"];
                    c._userType = (EUserType)Enum.Parse(typeof(EUserType), (string)row["user_type"]);
                    c._IDAddress = Convert.ToInt16(row["address_id"]);
                    c._active = bool.Parse((string)row["active"]);

                    Application.Instance.Coaches.Add(c);
                }

            }
        }

        public static void AddCoach(Coach c)
        {
            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO coach (jmbg, first_name, last_name, gender, email, password, user_type, active) VALUES (@jmbg, @first_name, @last_name, @gender, @email, @password, 'coach', 'true')";

                command.Parameters.Add(new SqlParameter("@jmbg", c._jmbg));
                command.Parameters.Add(new SqlParameter("@first_name", c._firstName));
                command.Parameters.Add(new SqlParameter("@last_name", c._lastName));
                command.Parameters.Add(new SqlParameter("@gender", c._gender));
                command.Parameters.Add(new SqlParameter("@email", c._email));
                command.Parameters.Add(new SqlParameter("@password", c._password));
                command.Parameters.Add(new SqlParameter("@user_type", "coach"));
                command.Parameters.Add(new SqlParameter("@active", "true"));

                command.ExecuteNonQuery();
            }
        }

        public static void DeleteCoach(long selectedJmbg)
        {
            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                SqlCommand coachCommand = connection.CreateCommand();
                coachCommand.CommandText = @"UPDATE coach SET active = 'False' WHERE jmbg=@jmbg;";

                coachCommand.Parameters.AddWithValue("@jmbg", selectedJmbg);
                coachCommand.Parameters.AddWithValue("@active", "False");

                coachCommand.ExecuteNonQuery();

            }

        }

        public static void AdminEditCoach(long jmbg, string firstName, string lastName, string password, string email)
        {

            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                SqlCommand coachCommand = connection.CreateCommand();
                coachCommand.CommandText = @"UPDATE COACH SET first_name=@firstName, last_name=@lastName, email=@email, password=@password WHERE jmbg = @Jmbg;";

                coachCommand.Parameters.AddWithValue("@Jmbg", jmbg);
                coachCommand.Parameters.Add(new SqlParameter("@firstName", firstName));
                coachCommand.Parameters.Add(new SqlParameter("@lastName", lastName));
                coachCommand.Parameters.Add(new SqlParameter("@email", email));
                coachCommand.Parameters.Add(new SqlParameter("@password", password));

                coachCommand.ExecuteNonQuery();
            }
        }

        public static void EditCoach(string firstName, string lastName, string password, string email, string gender)
        {
            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                SqlCommand coachCommand = connection.CreateCommand();
                coachCommand.CommandText = @"UPDATE COACH SET first_name=@firstName, last_name=@lastName, email=@email, password=@password, gender=@gender WHERE jmbg = @Jmbg;";

                coachCommand.Parameters.AddWithValue("@Jmbg", Application.loginUser.Jmbg);
                coachCommand.Parameters.Add(new SqlParameter("@firstName", firstName));
                coachCommand.Parameters.Add(new SqlParameter("@lastName", lastName));
                coachCommand.Parameters.Add(new SqlParameter("@gender", gender));
                coachCommand.Parameters.Add(new SqlParameter("@email", email));                    
                coachCommand.Parameters.Add(new SqlParameter("@password", password));

                coachCommand.ExecuteNonQuery();
            }
        }








    }
}
