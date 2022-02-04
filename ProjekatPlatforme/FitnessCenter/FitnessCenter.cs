using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatPlatforme.FitnessCenter
{
    class FitnessCenter
    {
        private int _fitnessID;

        public int FitnessID
        {
            get { return _fitnessID; }
            set { _fitnessID = value; }
        }

        private string _nameCenter;

        public string NameCenter
        {
            get { return _nameCenter; }
            set { _nameCenter = value; }
        }

        private int _IDAddress;

        public int IDAddress
        {
            get { return _IDAddress; }
            set { _IDAddress = value; }
        }

        public FitnessCenter(int fitnessID, string nameCenter, int iDAddress)
        {
            _fitnessID = fitnessID;
            _nameCenter = nameCenter;
            _IDAddress = iDAddress;
        }
        public FitnessCenter()
        {

        }
        public override string ToString()
        {
            return base.ToString();
        }


        public static void LoadFitnessCenter()
        {
            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                DataSet ds = new DataSet();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"SELECT * FROM fitness_center";
                SqlDataAdapter sqa = new SqlDataAdapter();
                sqa.SelectCommand = command;
                sqa.Fill(ds, "FitnessCenter");


                foreach (DataRow row in ds.Tables["FitnessCenter"].Rows)
                {
                    FitnessCenter fc = new FitnessCenter();

                    fc._fitnessID = (int)Convert.ToInt64(row["fitness_center_id"]);
                    fc._nameCenter = (string)row["name_center"];
                    fc._IDAddress = Convert.ToInt16(row["address_id"]);

                    Application.Instance.FitnessCenters.Add(fc);
                }

            }
        }

    }
}
