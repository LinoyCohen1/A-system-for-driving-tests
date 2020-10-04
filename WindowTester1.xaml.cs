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
    /// Interaction logic for WindowTester1.xaml
    /// </summary>
    public partial class WindowTester1 : Window
    {
        Tester MyTester;
        public static IBL bl;
        public WindowTester1()
        {
            InitializeComponent();
            //the title of the window
            MyTester = new Tester();
            bl = FactoryBl.GetBL();
           
        }
       

            private void addTester_Click(object sender, RoutedEventArgs e)
        {
            testerWindow tw = new testerWindow();
            tw.UpdateBTN.Visibility = Visibility.Hidden;
            tw.RemoveBTN.Visibility= Visibility.Hidden;
            tw.Show();
            Close();
        }

        private void removeTester_Click(object sender, RoutedEventArgs e)
        {
            testerWindow tw = new testerWindow(MyTester);
            tw.AddBTN.Visibility = Visibility.Hidden;
            tw.UpdateBTN.Visibility= Visibility.Hidden;
            tw.TesterFirstNameTextBox.IsEnabled = false;
            tw.TesterLastName.IsEnabled = false;
            tw.TesterGender.IsEnabled = false;
            tw.TesterPhoneNumber.IsEnabled = false;
            tw.TesterCity.IsEnabled = false;
            tw.TesterStreet.IsEnabled = false;
            tw.TesterNumBuilding.IsEnabled = false;
            tw.TesterExperience.IsEnabled = false;
            tw.TesterMaxTests.IsEnabled = false;
            tw.TesterCar.IsEnabled = false;
            tw.TesterGearBox.IsEnabled = false;
            tw.TesterMaxDistance.IsEnabled = false;
            tw.TesterBirthDate.IsEnabled = false;
            tw.availabiltyGrid.IsEnabled = false;
            tw.monday10.IsEnabled = false;
            tw.monday11.IsEnabled = false;
            tw.monday12.IsEnabled = false;
            tw.monday13.IsEnabled = false;
            tw.monday14.IsEnabled = false;
            tw.monday9.IsEnabled = false;
            tw.sunday10.IsEnabled = false;
            tw.sunday11.IsEnabled = false;
            tw.sunday12.IsEnabled = false;
            tw.sunday13.IsEnabled = false;
            tw.sunday14.IsEnabled = false;
            tw.sunday9.IsEnabled = false;
            tw.thursday10.IsEnabled = false;
            tw.thursday11.IsEnabled = false;
            tw.thursday12.IsEnabled = false;
            tw.thursday13.IsEnabled = false;
            tw.thursday14.IsEnabled = false;
            tw.thursday9.IsEnabled = false;
            tw.tuesday10.IsEnabled = false;
            tw.tuesday11.IsEnabled = false;
            tw.tuesday12.IsEnabled = false;
            tw.tuesday13.IsEnabled = false;
            tw.tuesday14.IsEnabled = false;
            tw.tuesday9.IsEnabled = false;
            tw.wedensday10.IsEnabled = false;
            tw.wedensday11.IsEnabled = false;
            tw.wedensday12.IsEnabled = false;
            tw.wedensday13.IsEnabled = false;
            tw.wedensday14.IsEnabled = false;
            tw.wedensday9.IsEnabled = false;
            if (MyTester.TesterAvailability[0, 0] == true)
                tw.sunday9.IsChecked = true;
            if (MyTester.TesterAvailability[0, 1] == true)
                tw.sunday10.IsChecked = true;
            if (MyTester.TesterAvailability[0, 2] == true)
                tw.sunday11.IsChecked = true;
            if (MyTester.TesterAvailability[0, 3] == true)
                tw.sunday12.IsChecked = true;
            if (MyTester.TesterAvailability[0, 4] == true)
                tw.sunday13.IsChecked = true;
            if (MyTester.TesterAvailability[0, 5] == true)
                tw.sunday14.IsChecked = true;
            if (MyTester.TesterAvailability[1, 0] == true)
                tw.monday9.IsChecked = true;
            if (MyTester.TesterAvailability[1, 1] == true)
                tw.monday10.IsChecked = true;
            if (MyTester.TesterAvailability[1, 2] == true)
                tw.monday11.IsChecked = true;
            if (MyTester.TesterAvailability[1, 3] == true)
                tw.monday12.IsChecked = true;
            if (MyTester.TesterAvailability[1, 4] == true)
                tw.monday13.IsChecked = true;
            if (MyTester.TesterAvailability[1, 5] == true)
                tw.monday14.IsChecked = true;
            if (MyTester.TesterAvailability[2, 0] == true)
                tw.tuesday9.IsChecked = true;
            if (MyTester.TesterAvailability[2, 1] == true)
                tw.tuesday10.IsChecked = true;
            if (MyTester.TesterAvailability[2, 2] == true)
                tw.tuesday11.IsChecked = true;
            if (MyTester.TesterAvailability[2, 3] == true)
                tw.tuesday12.IsChecked = true;
            if (MyTester.TesterAvailability[2, 4] == true)
                tw.tuesday13.IsChecked = true;
            if (MyTester.TesterAvailability[2, 5] == true)
                tw.tuesday14.IsChecked = true;
            if (MyTester.TesterAvailability[3, 0] == true)
                tw.wedensday9.IsChecked = true;
            if (MyTester.TesterAvailability[3, 1] == true)
                tw.wedensday10.IsChecked = true;
            if (MyTester.TesterAvailability[3, 2] == true)
                tw.wedensday11.IsChecked = true;
            if (MyTester.TesterAvailability[3, 3] == true)
                tw.wedensday12.IsChecked = true;
            if (MyTester.TesterAvailability[3, 4] == true)
                tw.wedensday13.IsChecked = true;
            if (MyTester.TesterAvailability[3, 5] == true)
                tw.wedensday14.IsChecked = true;
            if (MyTester.TesterAvailability[4, 0] == true)
                tw.thursday9.IsChecked = true;
            if (MyTester.TesterAvailability[4, 1] == true)
                tw.thursday10.IsChecked = true;
            if (MyTester.TesterAvailability[4, 2] == true)
                tw.thursday11.IsChecked = true;
            if (MyTester.TesterAvailability[4, 3] == true)
                tw.thursday12.IsChecked = true;
            if (MyTester.TesterAvailability[4, 4] == true)
                tw.thursday13.IsChecked = true;
            if (MyTester.TesterAvailability[4, 5] == true)
                tw.thursday14.IsChecked = true;

            tw.Show();
            Close();
        }

        private void updateTester_Click_1(object sender, RoutedEventArgs e)
        {
            updateTester updatetester = new updateTester();
          
            updatetester.Show();

            Close();
            //צריך לפתוח את החלון של הטסטר
           
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }

        private void ShowTesters_Click(object sender, RoutedEventArgs e)
        {
            showTesters win = new showTesters();
            win.ShowDialog();
            Close();
        }
        
    }
}
