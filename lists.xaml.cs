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
    /// Interaction logic for lists.xaml
    /// </summary>
    public partial class lists : Window
    {
        public lists()
        {
            InitializeComponent();
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Show();
            Close();
        }

        private void listTester_Click(object sender, RoutedEventArgs e)
        {
            showTesters w = new showTesters();
            w.Show();
            Close();
        }

        private void listTrainee_Click(object sender, RoutedEventArgs e)
        {
            showTrainees w = new showTrainees();
            w.Show();
            Close();

        }

        private void listTests_Click(object sender, RoutedEventArgs e)
        {
            showTests w = new showTests();
            w.Show();
            Close();
        }
    }
}
