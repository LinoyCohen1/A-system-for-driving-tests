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
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for DataGridTester.xaml
    /// </summary>
    public partial class showTesters : Window
    {
        IBL bl;
        public showTesters(List<Tester> testers1 = null, IEnumerable<Tester> testers2 = null)
        {

            InitializeComponent();
            bl = FactoryBl.GetBL();
            if (testers1 != null)
                dataGridTesters.ItemsSource = testers1;
            else if (testers2 != null)
                dataGridTesters.ItemsSource = testers2;
            else
               dataGridTesters.ItemsSource = bl.GetListOfTesters();
           
        }


      
        private void dataGridTesters_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridTesters.SelectedItems == null)
                return;
            var selectedTesters = dataGridTesters.SelectedItem as Tester;
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