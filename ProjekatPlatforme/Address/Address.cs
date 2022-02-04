using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatPlatforme.Address
{
    public class Address
    {
        private int _IDAddress;

        public int IDAddress
        {
            get { return _IDAddress; }
            set { _IDAddress = value; }
        }

        private string _street;

        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }

        private int _number;

        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        private string _city;

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        private string _state;

        public string State
        {
            get { return _state; }
            set { _state = value; }
        }

        public Address(string street, int number, string city, string state)
        {
            _street = street;
            _number = number;
            _city = city;
            _state = state;
        }

        public Address()
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static void LoadAddresses()
        {
            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                DataSet ds = new DataSet();

                SqlCommand coachCommand = connection.CreateCommand();
                coachCommand.CommandText = @"SELECT * FROM ADDRESS WHERE active = 'True'";
                SqlDataAdapter daCoach = new SqlDataAdapter();
                daCoach.SelectCommand = coachCommand;
                daCoach.Fill(ds, "Address");


                foreach (DataRow row in ds.Tables["Address"].Rows)
                {
                    Address a = new Address();

                    a._IDAddress = Convert.ToInt16(row["address_id"]);
                    a._street = (string)row["street"];
                    a._number = Convert.ToInt16(row["number"]);
                    a._city = (string)row["city"];
                    a._state = (string)row["state"];

                    Application.Instance.Addresses.Add(a);
                }

            }
        }

        public static void AddAddress(Address a)
        {
            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO address (street, number, city, state, active) VALUES (@street, @number, @city, @state, 'True')";

                command.Parameters.Add(new SqlParameter("@street", a._street));
                command.Parameters.Add(new SqlParameter("@number", a._number));
                command.Parameters.Add(new SqlParameter("@city", a._city));
                command.Parameters.Add(new SqlParameter("@state", a._state));
                command.Parameters.Add(new SqlParameter("@active", "true"));

                command.ExecuteNonQuery();
            }
        }

        public static void EditAddress(string street, int number, string state, string city) 
        {

            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                SqlCommand coachCommand = connection.CreateCommand();
                coachCommand.CommandText = @"UPDATE address SET street=@street, number=@number, state=@state, city=@city WHERE address_id = @address_id;";

                coachCommand.Parameters.AddWithValue("@address_id", Application.loginUser.IDAddress);
                coachCommand.Parameters.Add(new SqlParameter("@street", street));
                coachCommand.Parameters.Add(new SqlParameter("@number", number));
                coachCommand.Parameters.Add(new SqlParameter("@state", state));
                coachCommand.Parameters.Add(new SqlParameter("@city", city));

                coachCommand.ExecuteNonQuery();
            }
        }

        public static void EditAddressAdmin(int idAddress, string street, int number, string state, string city)
        {

            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                SqlCommand coachCommand = connection.CreateCommand();
                coachCommand.CommandText = @"UPDATE address SET street=@street, number=@number, state=@state, city=@city WHERE address_id = @address_id;";

                coachCommand.Parameters.AddWithValue("@address_id", idAddress);
                coachCommand.Parameters.Add(new SqlParameter("@street", street));
                coachCommand.Parameters.Add(new SqlParameter("@number", number));
                coachCommand.Parameters.Add(new SqlParameter("@state", state));
                coachCommand.Parameters.Add(new SqlParameter("@city", city));

                coachCommand.ExecuteNonQuery();
            }
        }

        public static void setAddresNewBeginner()
        {
            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"UPDATE beginner SET address_id = (SELECT max(address_id) FROM address) WHERE address_id IS NULL;";
                command.ExecuteNonQuery();
            }
        }

        public static void setAddresNewCoach()
        {
            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"UPDATE coach SET address_id = (SELECT max(address_id) FROM address) WHERE address_id IS NULL;";
                command.ExecuteNonQuery();
            }
        }

        public static void DeleteAddress(int selectedAddress)
        {
            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                SqlCommand coachCommand = connection.CreateCommand();
                coachCommand.CommandText = @"UPDATE address SET active = 'False' WHERE address_id=@address_id;";

                coachCommand.Parameters.AddWithValue("@address_id", Application.loginUser.IDAddress);
                coachCommand.Parameters.AddWithValue("@active", "False");

                coachCommand.ExecuteNonQuery();

            }
        }

        public static void DeleteAddressAdmin(int selectedAddress)
        {
            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                SqlCommand coachCommand = connection.CreateCommand();
                coachCommand.CommandText = @"UPDATE address SET active = 'False' WHERE address_id=@address_id;";

                coachCommand.Parameters.AddWithValue("@address_id", selectedAddress);
                coachCommand.Parameters.AddWithValue("@active", "False");

                coachCommand.ExecuteNonQuery();

            }
        }

    }
}
