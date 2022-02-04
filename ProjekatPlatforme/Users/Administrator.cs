using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatPlatforme.Users
{
    class Administrator : Users
    {

        public Administrator(string firstName, string lastName, string email, int jmbg, string password, int IDAddress, EGender gender, EUserType userType) : base( firstName, lastName, email, jmbg, password, IDAddress, gender, userType)
        {
        }

        public Administrator()
        {
        }
        public override string ToString()
        {
            return base.ToString();
        }

        public static void LoadAdministrators()
        {
            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                DataSet ds = new DataSet();

                SqlCommand coachCommand = connection.CreateCommand();
                coachCommand.CommandText = @"SELECT * FROM ADMINISTRATOR";
                SqlDataAdapter daCoach = new SqlDataAdapter();
                daCoach.SelectCommand = coachCommand;
                daCoach.Fill(ds, "Administrator");


                foreach (DataRow row in ds.Tables["Administrator"].Rows)
                {
                    Administrator a = new Administrator();

                    a._jmbg = (int)Convert.ToInt64(row["jmbg"]);
                    a._firstName = (string)row["first_name"];
                    a._lastName = (string)row["last_name"];
                    a._gender = (EGender)Enum.Parse(typeof(EGender), (string)row["gender"]);
                    a._email = (string)row["email"];
                    a._password = (string)row["password"];
                    a._userType = (EUserType)Enum.Parse(typeof(EUserType), (string)row["user_type"]);
                    a._IDAddress = Convert.ToInt16(row["address_id"]);
                    a._active = bool.Parse((string)row["ACTIVE"]);

                    Application.Instance.Administrators.Add(a);
                }

            }
        }


        public static void EditAdmin(string firstName, string lastName, string password, string email, string gender)
        {
            
            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                SqlCommand coachCommand = connection.CreateCommand();
                coachCommand.CommandText = @"UPDATE administrator SET first_name=@firstName, last_name=@lastName, email=@email, password=@password, gender=@gender WHERE jmbg = @Jmbg;";

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
