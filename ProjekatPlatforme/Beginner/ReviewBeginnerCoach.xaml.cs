using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ProjekatPlatforme.Beginner
{
    /// <summary>
    /// Interaction logic for ReviewBeginnerCoach.xaml
    /// </summary>
    public partial class ReviewBeginnerCoach : Window
    {
        ICollectionView view;
        public ReviewBeginnerCoach()
        {
            InitializeComponent();
            view = CollectionViewSource.GetDefaultView(Application.Instance.Trainings);
            dataGrid.ItemsSource = view;
            dataGrid.IsSynchronizedWithCurrentItem = true;
            Application.Instance.Trainings.Clear();
            Training.Training.LoadTrainingCoachBeginner();
        }

        private void ButtonBack(object sender, RoutedEventArgs e)
        {
            Coach.CoachMenu coach = new Coach.CoachMenu();
            this.Visibility = Visibility.Hidden;
            coach.Show();
        }
    }
}
