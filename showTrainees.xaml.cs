using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Windows;
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for DataGridTrainee.xaml
    /// </summary>
    public partial class showTrainees : Window
    {
        IBL bl;
        public showTrainees(List<Trainee> trainee1 = null, IEnumerable<Trainee> trainee2 = null)
        {

            InitializeComponent();
            bl = BL.FactoryBl.GetBL();
            if (trainee1 != null)
                this.dataGridTrainees.ItemsSource = trainee1;
            else if (trainee2 != null)
                this.dataGridTrainees.ItemsSource = trainee2;
            else
                this.dataGridTrainees.ItemsSource = bl.GetListOfTrainees();
            this.txtShowTrainee.Name = "Trainees";
        }




        private void dataGridTrainees_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridTrainees.SelectedItems == null)
                return;
            var selectedTesters = dataGridTrainees.SelectedItem as Tester;
            //  BasicTester myTester = new BasicTester("View", selectedTesters.ID);
            this.Close();
            //myTester.Show();

        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            MainWindow tw = new MainWindow();
            tw.Show();
            Close();
        }
    }
}

