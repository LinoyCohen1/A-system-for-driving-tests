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
    /// Interaction logic for showTests.xaml
    /// </summary>
    public partial class showTests : Window
    {
        IBL bl;
        public showTests(List<Test> tests1 = null, IEnumerable<Test> tests2 = null)
        {
            InitializeComponent();
            bl = FactoryBl.GetBL();
            if (tests1 != null)
               dataGridTests.ItemsSource = tests1;
            else if (tests2 != null)
                dataGridTests.ItemsSource = tests2;
            else
                dataGridTests.ItemsSource = bl.GetListOfTests();

        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Show();
            Close();
        }
        private void dataGridTests_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (dataGridTests.SelectedItems == null)
                return;
            var selectedTests = dataGridTests.SelectedItem as Test;

            this.Close();
        }

        private void DataGridTests_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
