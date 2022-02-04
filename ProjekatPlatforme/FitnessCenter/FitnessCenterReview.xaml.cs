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

namespace ProjekatPlatforme.FitnessCenter
{
    /// <summary>
    /// Interaction logic for FitnessCenterReview.xaml
    /// </summary>
    public partial class FitnessCenterReview : Window
    {
        ICollectionView view;
        public FitnessCenterReview()
        {
            InitializeComponent();
            view = CollectionViewSource.GetDefaultView(Application.Instance.FitnessCenters);
            dataGrid.ItemsSource = view;
            dataGrid.IsSynchronizedWithCurrentItem = true;
        }

        private void ButtonBack(object sender, RoutedEventArgs e)
        {
            MainWindow mainWin = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWin.Show();
        }
    }
}
