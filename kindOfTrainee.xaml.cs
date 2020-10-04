using System;
using System.Collections.Generic;
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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for kindOfTrainee.xaml
    /// </summary>
    public partial class kindOfTrainee : Window
    {
        public kindOfTrainee()
        {
            InitializeComponent();
        }

      

        private void New_Click(object sender, RoutedEventArgs e)
        {
            traineeWindow tw = new traineeWindow();
            tw.UpdateBTN.Visibility = Visibility.Hidden;
            tw.RemoveBTN.Visibility = Visibility.Hidden;
            tw.Show();
        }

        private void Exist_Click(object sender, RoutedEventArgs e)
        {
            getTraineeID updateTrainee = new getTraineeID();
            updateTrainee.Show();
            Close();
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Show();
            Close();
        }
    }
}
