using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatPlatforme
{
    class Application
    {
        

        public const string CONNECTION_STRING = @"Data Source=DESKTOP-SPB35MN;Initial Catalog=project_platforms_db;Integrated Security=True";

        public ObservableCollection<Users.Coach> Coaches { get; set; }
        public ObservableCollection<Users.Beginner> Beginners { get; set; }
        public ObservableCollection<Users.Administrator> Administrators { get; set; }
        public ObservableCollection<Address.Address> Addresses { get; set; }
        public ObservableCollection<Training.Training> Trainings { get; set; }

        public ObservableCollection<FitnessCenter.FitnessCenter> FitnessCenters { get; set; }

        private static Application instance = new Application();
        public static Application Instance
        {
            get
            {
                return instance;
            }
        }

        private Application()
        {
            Coaches = new ObservableCollection<Users.Coach>();
            Beginners = new ObservableCollection<Users.Beginner>();
            Administrators = new ObservableCollection<Users.Administrator>();
            Addresses = new ObservableCollection<Address.Address>();
            Trainings = new ObservableCollection<Training.Training>();
            FitnessCenters = new ObservableCollection<FitnessCenter.FitnessCenter>();
        }

        public static Users.Users loginUser = null;
        public static List<Training.Training> listTrainings = new List<Training.Training>();
        public static List<Training.Training> listUnDeleteTrainings = new List<Training.Training>();
        public static List<string> terminsForTrainings = new List<string>();
        

    }
}
