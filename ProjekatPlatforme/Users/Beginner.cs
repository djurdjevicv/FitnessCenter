using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatPlatforme.Users
{
    public class Beginner : Users
    {

        public Beginner(string firstName, string lastName, string email, int jmbg, string password, int IDAddress, EGender gender, EUserType userType) : base(firstName, lastName, email, jmbg, password, IDAddress, gender, userType)
        {
        }

        public Beginner()
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static void LoadBeginners()
        {
            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                DataSet ds = new DataSet();

                SqlCommand coachCommand = connection.CreateCommand();
                coachCommand.CommandText = @"SELECT * FROM Beginner WHERE active='true'";
                SqlDataAdapter daCoach = new SqlDataAdapter();
                daCoach.SelectCommand = coachCommand;
                daCoach.Fill(ds, "Beginner");


                foreach (DataRow row in ds.Tables["Beginner"].Rows)
                {
                    Beginner b = new Beginner();

                    b._jmbg = (int)Convert.ToInt64(row["jmbg"]);
                    b._firstName = (string)row["first_name"];
                    b._lastName = (string)row["last_name"];
                    b._gender = (EGender)Enum.Parse(typeof(EGender), (string)row["gender"]);
                    b._email = (string)row["email"];
                    b._password = (string)row["password"];
                    b._userType = (EUserType)Enum.Parse(typeof(EUserType), (string)row["user_type"]);
                    b._IDAddress = Convert.ToInt16(row["address_id"]);
                    b._active = bool.Parse((string)row["active"]);

                    Application.Instance.Beginners.Add(b);
                }

            }
        }

        public static void AddBeginner(Beginner b)
        {
            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO BEGINNER (jmbg, first_name, last_name, gender, email, password, user_type, active) VALUES (@jmbg, @first_name, @last_name, @gender, @email, @password, 'beginner', 'true')";

                command.Parameters.Add(new SqlParameter("@jmbg", b._jmbg));
                command.Parameters.Add(new SqlParameter("@first_name", b._firstName));
                command.Parameters.Add(new SqlParameter("@last_name", b._lastName));
                command.Parameters.Add(new SqlParameter("@gender", b._gender));
                command.Parameters.Add(new SqlParameter("@email", b._email));
                command.Parameters.Add(new SqlParameter("@password", b._password));
                command.Parameters.Add(new SqlParameter("@user_type", "beginner"));
                command.Parameters.Add(new SqlParameter("@active", "true"));

                command.ExecuteNonQuery();

            }
        }

        public static void EditBeginner(string firstName, string lastName, string password, string email, string gender)
        {

            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                SqlCommand coachCommand = connection.CreateCommand();
                coachCommand.CommandText = @"UPDATE beginner SET first_name=@firstName, last_name=@lastName, email=@email, password=@password, gender=@gender WHERE jmbg = @Jmbg;";

                coachCommand.Parameters.AddWithValue("@Jmbg", Application.loginUser.Jmbg);
                coachCommand.Parameters.Add(new SqlParameter("@firstName", firstName));
                coachCommand.Parameters.Add(new SqlParameter("@lastName", lastName));
                coachCommand.Parameters.Add(new SqlParameter("@gender", gender));
                coachCommand.Parameters.Add(new SqlParameter("@email", email));
                coachCommand.Parameters.Add(new SqlParameter("@password", password));

                coachCommand.ExecuteNonQuery();
            }
        }

        public static void EditBeginnerAdmin(long jmbg, string firstName, string lastName, string password, string email, string gender)
        {

            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                SqlCommand coachCommand = connection.CreateCommand();
                coachCommand.CommandText = @"UPDATE beginner SET first_name=@firstName, last_name=@lastName, email=@email, password=@password, gender=@gender WHERE jmbg = @Jmbg;";

                coachCommand.Parameters.AddWithValue("@Jmbg", jmbg);
                coachCommand.Parameters.Add(new SqlParameter("@firstName", firstName));
                coachCommand.Parameters.Add(new SqlParameter("@lastName", lastName));
                coachCommand.Parameters.Add(new SqlParameter("@email", email));
                coachCommand.Parameters.Add(new SqlParameter("@password", password));
                coachCommand.Parameters.Add(new SqlParameter("@gender", gender));

                coachCommand.ExecuteNonQuery();
            }
        }

        public static void DeleteBeginner(long selectedJmbg)
        {
            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                SqlCommand coachCommand = connection.CreateCommand();
                coachCommand.CommandText = @"UPDATE beginner SET active = 'False' WHERE jmbg=@jmbg;";

                coachCommand.Parameters.AddWithValue("@jmbg", selectedJmbg);
                coachCommand.Parameters.AddWithValue("@active", "False");

                coachCommand.ExecuteNonQuery();

            }
        }



    }
}
