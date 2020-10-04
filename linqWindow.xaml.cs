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
    /// Interaction logic for linqWindow.xaml
    /// </summary>
    public partial class linqWindow : Window
    {
        IBL bl;
        public linqWindow()
        {
            InitializeComponent();
            bl = FactoryBl.GetBL();
        }

        private void groupByExperience_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                groupExperienceUserContro g = new groupExperienceUserContro();
                g.Source = bl.groupByExperience();
                page.Content = g;
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void groupBySchool_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                groupSchoolUserControl1 g = new groupSchoolUserControl1();
                g.Source = bl.groupBySchool();
                page.Content = g;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void groupByNumOfTests_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                groupNumOfTestsUserControl1 g = new groupNumOfTestsUserControl1();
                g.Source = bl.groupByNumOfTests();
                page.Content = g;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void groupByTeacher_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                groupTeacherUserControl1 g = new groupTeacherUserControl1();
                g.Source = bl.groupByTeacher();
                page.Content = g;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
