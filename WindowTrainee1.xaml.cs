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
using BL;
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for WindowTrainee1.xaml
    /// </summary>
    public partial class WindowTrainee1 : Window
    {
        IBL bl;
        Trainee getTrainee;
        public WindowTrainee1()
        {
            InitializeComponent();
            bl = FactoryBl.GetBL();
        }
        public WindowTrainee1(Trainee trainee)
        {
            InitializeComponent();
            bl = FactoryBl.GetBL();
            getTrainee = trainee;
        }
        private void removeTrainee_Click(object sender, RoutedEventArgs e)
        {
            traineeWindow tw = new traineeWindow(getTrainee);
            tw.AddBTN.Visibility = Visibility.Hidden;
            tw.IDTextBox.IsEnabled = false;
            tw.UpdateBTN.Visibility = Visibility.Hidden;
            tw.TraineeFirstNameTextBox.IsEnabled = false;
            tw.TraineeLastName.IsEnabled = false;
            tw.TraineeBirthDate.IsEnabled = false;
            tw.TraineeGender.IsEnabled = false;
            tw.TraineePhoneNumber.IsEnabled = false;
            tw.TraineeCity.IsEnabled = false;
            tw.TraineeStreet.IsEnabled = false;
            tw.TraineeNumBuilding.IsEnabled = false;
            tw.TraineeCar.IsEnabled = false;
            tw.TraineeGearBox.IsEnabled = false;
            tw.TraineeSchool.IsEnabled = false;
            tw.TraineeTester.IsEnabled = false;
            tw.TraineeNumLessons.IsEnabled = false;
            tw.ShowDialog();
            Close();
        }

        private void addTrainee_Click(object sender, RoutedEventArgs e)
        {
            traineeWindow tw = new traineeWindow();
            tw.UpdateBTN.Visibility = Visibility.Hidden;
            tw.RemoveBTN.Visibility = Visibility.Hidden;
            tw.Show();
           // Close();
        }

        private void updateTrainee_Click(object sender, RoutedEventArgs e)
        {
            //updateTrainee w = new updateTrainee();
            traineeWindow tw = new traineeWindow(getTrainee);
            tw.AddBTN.Visibility = Visibility.Hidden;
            tw.RemoveBTN.Visibility = Visibility.Hidden;
            tw.IDTextBox.IsEnabled = false;
            tw.TraineeFirstNameTextBox.IsEnabled = true;
            tw.TraineeLastName.IsEnabled = true;
            tw.TraineeBirthDate.IsEnabled = false;
            tw.TraineeGender.IsEnabled = false;
            tw.TraineePhoneNumber.IsEnabled = true;
            tw.TraineeCity.IsEnabled = true;
            tw.TraineeStreet.IsEnabled = true;
            tw.TraineeNumBuilding.IsEnabled = true;
            tw.TraineeCar.IsEnabled = true;
            tw.TraineeGearBox.IsEnabled = true;
            tw.TraineeSchool.IsEnabled = true;
            tw.TraineeTester.IsEnabled = true;
            tw.TraineeNumLessons.IsEnabled = true;
            tw.ShowDialog();
            Close();
            //updateTrainee updateTrainee = new updateTrainee();
            //updateTrainee.Show();
            //Close();
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.ShowDialog();
            Close();
        }

        private void ShowTrainees_Click(object sender, RoutedEventArgs e)
        {
            showTrainees sr = new showTrainees();
            sr.ShowDialog();
            Close();
        }

      
    }
}
