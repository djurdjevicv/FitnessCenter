using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatPlatforme.Training
{
    class Training
    {

        private int _idTrng;
        public int IdTrng
        {
            get { return _idTrng; }
            set { _idTrng = value; }
        }

        private DateTime _dateTrng;
        public DateTime DateTrng
        {
            get { return _dateTrng; }
            set { _dateTrng = value; }
        }

        private TimeSpan _timeTrng;
        public TimeSpan TimeTrng
        {
            get { return _timeTrng; }
            set { _timeTrng = value; }
        }

        private string _durationTrng;
        public string DurationTrng
        {
            get { return _durationTrng; }
            set { _durationTrng = value; }
        }

        private ETypeTraining _typeTraining;
        public ETypeTraining TypeTraining
        {
            get { return _typeTraining; }
            set { _typeTraining = value; }
        }

        private int _jmbgCoach;
        public int JmbgCoach
        {
            get { return _jmbgCoach; }
            set { _jmbgCoach = value; }
        }

        private int _jmbgBeginner;
        public int JmbgBeginner
        {
            get { return _jmbgBeginner; }
            set { _jmbgBeginner = value; }
        }

        protected bool _active;
        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }

        public Training(int idTrng, DateTime dateTrng, TimeSpan timeTrng, string durationTrng, ETypeTraining typeTraining, int jmbgCoach, int jmbgBeginner)
        {
            _idTrng = idTrng;
            _dateTrng = dateTrng;
            _timeTrng = timeTrng;
            _durationTrng = durationTrng;
            _typeTraining = typeTraining;
            _jmbgCoach = jmbgCoach;
            _jmbgBeginner = jmbgBeginner;
            _active = true;
        }

        public Training()
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }


        public static void getidTrngDB()
        {
            string Sql = "select trng_id from training";
            SqlConnection conn = new SqlConnection(Application.CONNECTION_STRING);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();

            List<int> idTrng = new List<int>();

            while (DR.Read())
            {
                idTrng.Add(DR.GetInt16(0));
            }

            Console.WriteLine(idTrng);
        }

        public static void LoadAllTraining()
        {
            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                DataSet ds = new DataSet();

                SqlCommand coachCommand = connection.CreateCommand();
                coachCommand.CommandText = @"SELECT * FROM training";
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = coachCommand;
                da.Fill(ds, "Training");


                foreach (DataRow row in ds.Tables["Training"].Rows)
                {
                    Training t = new Training();

                    t._idTrng = (int)Convert.ToInt16(row["trng_id"]);
                    t._dateTrng = (DateTime)row["date_trng"];
                    t._timeTrng = (TimeSpan)row["time_trng"];
                    t._durationTrng = (string)row["duration"];
                    t._typeTraining = (ETypeTraining)Enum.Parse(typeof(ETypeTraining), (string)row["type_trng"]);
                    t._jmbgCoach = (int)Convert.ToInt64(row["jmbg_coach"]);
                    if (!DBNull.Value.Equals(row["jmbg_beginner"]))
                    {
                        t._jmbgBeginner = (int)Convert.ToInt64(row["jmbg_beginner"]);
                    }
                    t._active = bool.Parse((string)row["active"]);

                    Application.listTrainings.Add(t);
                }

            }
        }

        public static void LoadTraining()
        {
            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                DataSet ds = new DataSet();

                SqlCommand coachCommand = connection.CreateCommand();
                coachCommand.CommandText = @"SELECT * FROM training WHERE active = 'True'";
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = coachCommand;
                da.Fill(ds, "Training");


                foreach (DataRow row in ds.Tables["Training"].Rows)
                {
                    Training t = new Training();

                    t._idTrng = (int)Convert.ToInt16(row["trng_id"]);
                    t._dateTrng = (DateTime)row["date_trng"];
                    t._timeTrng = (TimeSpan)row["time_trng"];
                    t._durationTrng = (string)row["duration"];
                    t._typeTraining = (ETypeTraining)Enum.Parse(typeof(ETypeTraining), (string)row["type_trng"]);
                    t._jmbgCoach = (int)Convert.ToInt64(row["jmbg_coach"]);
                    if (!DBNull.Value.Equals(row["jmbg_beginner"]))
                    {
                        t._jmbgBeginner = (int)Convert.ToInt64(row["jmbg_beginner"]);
                    }                    
                    t._active = bool.Parse((string)row["active"]);

                    Application.Instance.Trainings.Add(t);
                    Application.listUnDeleteTrainings.Add(t);
                }

            }
        }

        public static int newTrainingId()
        {
            int maks = 0;
            foreach (Training t in Application.listTrainings)
            {
                if (t.IdTrng > maks)
                {
                    maks = t.IdTrng;
                }
            }
            return maks + 1;
        }

        public static void LoadTrainingOneCoach()
        {
            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                DataSet ds = new DataSet();

                SqlCommand coachCommand = connection.CreateCommand();
                coachCommand.CommandText = @"SELECT * FROM training WHERE active = 'True' AND jmbg_coach=@jmbg_coach";
                SqlDataAdapter da = new SqlDataAdapter();
                coachCommand.Parameters.AddWithValue("@jmbg_coach", Application.loginUser.Jmbg);
                da.SelectCommand = coachCommand;
                da.Fill(ds, "Training");


                foreach (DataRow row in ds.Tables["Training"].Rows)
                {
                    Training t = new Training();

                    t._idTrng = (int)Convert.ToInt16(row["trng_id"]);
                    t._dateTrng = (DateTime)row["date_trng"];
                    t._timeTrng = (TimeSpan)row["time_trng"];
                    t._durationTrng = (string)row["duration"];
                    t._typeTraining = (ETypeTraining)Enum.Parse(typeof(ETypeTraining), (string)row["type_trng"]);
                    t._jmbgCoach = (int)Convert.ToInt64(row["jmbg_coach"]);
                    if (!DBNull.Value.Equals(row["jmbg_beginner"]))
                    {
                        t._jmbgBeginner = (int)Convert.ToInt64(row["jmbg_beginner"]);
                    }
                    t._active = bool.Parse((string)row["active"]);

                    Application.Instance.Trainings.Add(t);
                }

            }
        }

        public static void LoadTrainingOneBeginner()
        {
            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                DataSet ds = new DataSet();

                SqlCommand coachCommand = connection.CreateCommand();
                coachCommand.CommandText = @"SELECT * FROM training WHERE active = 'True' AND jmbg_beginner=@jmbg_beginner";
                SqlDataAdapter da = new SqlDataAdapter();
                coachCommand.Parameters.AddWithValue("@jmbg_beginner", Application.loginUser.Jmbg);
                da.SelectCommand = coachCommand;
                da.Fill(ds, "Training");


                foreach (DataRow row in ds.Tables["Training"].Rows)
                {
                    Training t = new Training();

                    t._idTrng = (int)Convert.ToInt16(row["trng_id"]);
                    t._dateTrng = (DateTime)row["date_trng"];
                    t._timeTrng = (TimeSpan)row["time_trng"];
                    t._durationTrng = (string)row["duration"];
                    t._typeTraining = (ETypeTraining)Enum.Parse(typeof(ETypeTraining), (string)row["type_trng"]);
                    t._jmbgCoach = (int)Convert.ToInt64(row["jmbg_coach"]);
                    if (!DBNull.Value.Equals(row["jmbg_beginner"]))
                    {
                        t._jmbgBeginner = (int)Convert.ToInt64(row["jmbg_beginner"]);
                    }
                    t._active = bool.Parse((string)row["active"]);

                    Application.Instance.Trainings.Add(t);
                }

            }
        }

        public static void LoadTrainingByDate(DateTime date)
        {
            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                DataSet ds = new DataSet();

                SqlCommand coachCommand = connection.CreateCommand();
                coachCommand.CommandText = @"SELECT * FROM training WHERE active = 'True' AND jmbg_coach=@jmbg_coach AND date_trng=@date_trng";
                SqlDataAdapter da = new SqlDataAdapter();
                coachCommand.Parameters.AddWithValue("@jmbg_coach", Application.loginUser.Jmbg);
                coachCommand.Parameters.AddWithValue("@date_trng", date);
                da.SelectCommand = coachCommand;
                da.Fill(ds, "Training");


                foreach (DataRow row in ds.Tables["Training"].Rows)
                {
                    Training t = new Training();

                    t._idTrng = (int)Convert.ToInt16(row["trng_id"]);
                    t._dateTrng = (DateTime)row["date_trng"];
                    t._timeTrng = (TimeSpan)row["time_trng"];
                    t._durationTrng = (string)row["duration"];
                    t._typeTraining = (ETypeTraining)Enum.Parse(typeof(ETypeTraining), (string)row["type_trng"]);
                    t._jmbgCoach = (int)Convert.ToInt64(row["jmbg_coach"]);
                    if (!DBNull.Value.Equals(row["jmbg_beginner"]))
                    {
                        t._jmbgBeginner = (int)Convert.ToInt64(row["jmbg_beginner"]);
                    }
                    t._active = bool.Parse((string)row["active"]);

                    Application.Instance.Trainings.Add(t);
                }

            }
        }

        public static void LoadTrainingByCoach(int jmbg_coach)
        {
            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                DataSet ds = new DataSet();

                SqlCommand coachCommand = connection.CreateCommand();
                coachCommand.CommandText = @"SELECT * FROM training WHERE active = 'True' AND jmbg_coach=@jmbg_coach";
                SqlDataAdapter da = new SqlDataAdapter();
                coachCommand.Parameters.AddWithValue("@jmbg_coach", jmbg_coach);
                da.SelectCommand = coachCommand;
                da.Fill(ds, "Training");


                foreach (DataRow row in ds.Tables["Training"].Rows)
                {
                    Training t = new Training();

                    t._idTrng = (int)Convert.ToInt16(row["trng_id"]);
                    t._dateTrng = (DateTime)row["date_trng"];
                    t._timeTrng = (TimeSpan)row["time_trng"];
                    t._durationTrng = (string)row["duration"];
                    t._typeTraining = (ETypeTraining)Enum.Parse(typeof(ETypeTraining), (string)row["type_trng"]);
                    t._jmbgCoach = (int)Convert.ToInt64(row["jmbg_coach"]);
                    if (!DBNull.Value.Equals(row["jmbg_beginner"]))
                    {
                        t._jmbgBeginner = (int)Convert.ToInt64(row["jmbg_beginner"]);
                    }
                    t._active = bool.Parse((string)row["active"]);

                    Application.Instance.Trainings.Add(t);
                }

            }
        }

        public static void LoadTrainingCoachBeginner()
        {
            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                DataSet ds = new DataSet();

                SqlCommand coachCommand = connection.CreateCommand();
                coachCommand.CommandText = @"SELECT * FROM training WHERE active = 'True' AND jmbg_coach=@jmbg_coach AND jmbg_beginner is not null";
                SqlDataAdapter da = new SqlDataAdapter();
                coachCommand.Parameters.AddWithValue("@jmbg_coach", Application.loginUser.Jmbg);
                da.SelectCommand = coachCommand;
                da.Fill(ds, "Training");


                foreach (DataRow row in ds.Tables["Training"].Rows)
                {
                    Training t = new Training();

                    t._idTrng = (int)Convert.ToInt16(row["trng_id"]);
                    t._dateTrng = (DateTime)row["date_trng"];
                    t._timeTrng = (TimeSpan)row["time_trng"];
                    t._durationTrng = (string)row["duration"];
                    t._typeTraining = (ETypeTraining)Enum.Parse(typeof(ETypeTraining), (string)row["type_trng"]);
                    t._jmbgCoach = (int)Convert.ToInt64(row["jmbg_coach"]);
                    if (!DBNull.Value.Equals(row["jmbg_beginner"]))
                    {
                        t._jmbgBeginner = (int)Convert.ToInt64(row["jmbg_beginner"]);
                    }
                    t._active = bool.Parse((string)row["active"]);

                    Application.Instance.Trainings.Add(t);
                }

            }
        }

        public static void AddTraining(Training t)
        {
            
            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO training (trng_id, date_trng, time_trng, duration, type_trng, jmbg_coach, active) VALUES (@trng_id, @date_trng, @time_trng, @duration, @type_trng, @jmbg_coach, @active)";

                command.Parameters.Add(new SqlParameter("@trng_id", t._idTrng));
                command.Parameters.Add(new SqlParameter("@date_trng", t._dateTrng));
                command.Parameters.Add(new SqlParameter("@time_trng", t._timeTrng)); 
                command.Parameters.Add(new SqlParameter("@duration", t._durationTrng));
                command.Parameters.Add(new SqlParameter("@type_trng", t._typeTraining));
                command.Parameters.Add(new SqlParameter("@jmbg_coach", t._jmbgCoach));
                command.Parameters.Add(new SqlParameter("@active", "True"));


                command.ExecuteNonQuery();
            }
        }


        public static void DeleteTrainingAdmin(int selectedTrainingId)
        {
            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                SqlCommand coachCommand = connection.CreateCommand();
                coachCommand.CommandText = @"UPDATE training SET active = 'False' WHERE trng_id=@trng_id";

                coachCommand.Parameters.AddWithValue("@trng_id", selectedTrainingId);
                coachCommand.Parameters.AddWithValue("@active", "False");

                coachCommand.ExecuteNonQuery();
            }

        }

        public static void ReserveTrainingBeginner(int selectedTrainingId)
        {
            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                SqlCommand coachCommand = connection.CreateCommand();
                coachCommand.CommandText = @"UPDATE training SET type_trng = 'Reserved', jmbg_beginner=@jmbg_beginner WHERE trng_id=@trng_id";

                coachCommand.Parameters.AddWithValue("@trng_id", selectedTrainingId);
                coachCommand.Parameters.AddWithValue("@jmbg_beginner", Application.loginUser.Jmbg);
                coachCommand.Parameters.AddWithValue("@type_trng", "Reserved");

                coachCommand.ExecuteNonQuery();
            }

        }

        public static void CancleTrainingBeginner(int selectedTrainingId)
        {
            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                SqlCommand coachCommand = connection.CreateCommand();
                coachCommand.CommandText = @"UPDATE training SET type_trng = 'Free', jmbg_beginner=null WHERE trng_id=@trng_id";

                coachCommand.Parameters.AddWithValue("@trng_id", selectedTrainingId);
                coachCommand.Parameters.AddWithValue("@type_trng", "Free");

                coachCommand.ExecuteNonQuery();
            }

        }

        public static void EditTrainingAdmin(int trngId, DateTime date,int coach,int beginner,TimeSpan time,ETypeTraining typeTrng)
        {

            using (SqlConnection connection = new SqlConnection(Application.CONNECTION_STRING))
            {
                connection.Open();

                SqlCommand coachCommand = connection.CreateCommand();
                if(beginner > 0)
                {
                    coachCommand.CommandText = @"UPDATE training SET date_trng=@date_trng, time_trng=@time_trng, type_trng=@type_trng, jmbg_coach=@jmbg_coach, jmbg_beginner=@jmbg_beginner  WHERE trng_id=@trng_id;";

                    coachCommand.Parameters.AddWithValue("@trng_id", trngId);
                    coachCommand.Parameters.Add(new SqlParameter("@date_trng", date));
                    coachCommand.Parameters.Add(new SqlParameter("@time_trng", time));
                    coachCommand.Parameters.Add(new SqlParameter("@type_trng", typeTrng));
                    coachCommand.Parameters.Add(new SqlParameter("@jmbg_coach", coach));
                    coachCommand.Parameters.Add(new SqlParameter("@jmbg_beginner", beginner));

                    coachCommand.ExecuteNonQuery();
                }
                else
                {
                    coachCommand.CommandText = @"UPDATE training SET date_trng=@date_trng, time_trng=@time_trng, type_trng=@type_trng, jmbg_coach=@jmbg_coach  WHERE trng_id=@trng_id;";

                    coachCommand.Parameters.AddWithValue("@trng_id", trngId);
                    coachCommand.Parameters.Add(new SqlParameter("@date_trng", date));
                    coachCommand.Parameters.Add(new SqlParameter("@time_trng", time));
                    coachCommand.Parameters.Add(new SqlParameter("@type_trng", typeTrng));
                    coachCommand.Parameters.Add(new SqlParameter("@jmbg_coach", coach));

                    coachCommand.ExecuteNonQuery();
                }

            }
        }




    }
}
