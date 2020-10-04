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
    /// Interaction logic for updateTrainee.xaml
    /// </summary>
    public partial class getTraineeID : Window
    {
        public static IBL bl;
        public getTraineeID()
        {
            InitializeComponent();
            bl = FactoryBl.GetBL();
        }

        

        private void BtnOk_Click_trainee(object sender, RoutedEventArgs e)
        {
            try
            {
              var v=  bl.GetListOfTrainees().Any(x => x.TraineeId == int.Parse(textBox.Text));
                if (v == false)
                    throw new Exception("You are not registered in the system, please register first ");
                else
                {
                    WindowTrainee1 w = new WindowTrainee1(MyFunctions.GetTraineeByID(int.Parse(textBox.Text)));
                    w.Show();
                    Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
                
            //WindowTrainee1 w = new WindowTrainee1(MyFunctions.GetTraineeByID(int.Parse(textBox.Text)));
            //w.Show();
            //Close();
            //traineeWindow tw = new traineeWindow(MyFunctions.GetTraineeByID(int.Parse(textBox.Text)));
            //tw.AddBTN.Visibility = Visibility.Hidden;
            //tw.RemoveBTN.Visibility = Visibility.Hidden;
            //tw.IDTextBox.IsEnabled = false;
            //tw.TraineeFirstNameTextBox.IsEnabled = true;
            //tw.TraineeLastName.IsEnabled = true;
            //tw.TraineeBirthDate.IsEnabled = false;
            //tw.TraineeGender.IsEnabled = false;
            //tw.TraineePhoneNumber.IsEnabled = true;
            //tw.TraineeCity.IsEnabled = true;
            //tw.TraineeStreet.IsEnabled = true;
            //tw.TraineeNumBuilding.IsEnabled = true;
            //tw.TraineeCar.IsEnabled = true;
            //tw.TraineeGearBox.IsEnabled = true;
            //tw.TraineeSchool.IsEnabled = true;
            //tw.TraineeTester.IsEnabled = true;
            //tw.TraineeNumLessons.IsEnabled = true;
            //tw.ShowDialog();
            //Close();

        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            kindOfTrainee w = new kindOfTrainee();
            w.Show();
            Close();

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            sender = textBox.Text;
            //  textBox.Text;
        }
    }
}
