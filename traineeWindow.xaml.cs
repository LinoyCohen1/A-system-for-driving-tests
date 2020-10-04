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
    /// Interaction logic for traineeWindow.xaml
    /// </summary>
    public partial class traineeWindow : Window
    {
        Trainee trainee;
        BL.IBL bl;
        private List<string> errorMessages;

        public traineeWindow()
        {
            InitializeComponent();
            bl = FactoryBl.GetBL();
            trainee = new Trainee();
            errorMessages = new List<string>();
            mainGridTrainee.DataContext = trainee;
            TraineeGender.ItemsSource = Enum.GetValues(typeof(Enums.Gender));
            TraineeCar.ItemsSource = Enum.GetValues(typeof(Enums.Vehicle));
            TraineeGearBox.ItemsSource = Enum.GetValues(typeof(Enums.gearBox));
            TraineeSchool.ItemsSource = Enum.GetValues(typeof(Enums.Schools));


            //var v = from Tester t in MainWindow.BL.GetListOfTesters()
            //        where (Enums.Vehicle)(TraineeGearBox.SelectionBoxItem) == t.TesterCar && (Enums.gearBox)TraineeGearBox.SelectionBoxItem == t.TesterGearBox
            //        select t;
            
            //foreach (Tester t in bl.GetListOfTesters())

            //    TraineeTester.Items.Add(t.TesterFirstName + " " + t.TesterLastName);

            //TraineeTester.ItemsSource = MyFunctions.testersCondition((Enums.Vehicle)TraineeCar.SelectedItem, (Enums.gearBox)TraineeGearBox.SelectedItem);
        }

        public traineeWindow(Trainee tr)
        {
            InitializeComponent();
            bl = FactoryBl.GetBL();
            mainGridTrainee.DataContext = tr;
            TraineeGender.ItemsSource = Enum.GetValues(typeof(Enums.Gender));
            TraineeCar.ItemsSource = Enum.GetValues(typeof(Enums.Vehicle));
            TraineeGearBox.ItemsSource = Enum.GetValues(typeof(Enums.gearBox));
            TraineeSchool.ItemsSource = Enum.GetValues(typeof(Enums.Schools));
            errorMessages = new List<string>();
        }

        private void RemoveBTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ans = MessageBox.Show("Are you sure you want delete this trainee?", "ATTENTION", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            switch (ans)
            {
                case MessageBoxResult.OK:
                    bl.DeleteTrainee((int.Parse(IDTextBox.Text)));
                    break;
                case MessageBoxResult.Cancel:
                    break;
            }
            MessageBox.Show("Delete successful");
            WindowTrainee1 w = new WindowTrainee1();
            w.Show();
            Close();

        }

        private void UpdateBTN_Click(object sender, RoutedEventArgs e)
        {
            bl.UpdateInfoTrainee(MyFunctions.GetTraineeByID(int.Parse(IDTextBox.Text)));
            MessageBox.Show("Details updated successfully");

        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                int numId1 = Convert.ToInt32(IDTextBox.Text);
                if (numId1 < 100000000 || numId1 > 999999999)//check if id is legal
                    throw new Exception("Non-valid Id of tester. Please enter a valid Id.");
                if (IDTextBox.Text == "" || TraineeFirstNameTextBox.Text == "" || TraineeLastName.Text == "" || TraineeBirthDate.SelectedDate == null ||
                TraineeGender.SelectedItem == null || TraineePhoneNumber.Text == "" || TraineeCity.Text == "" || TraineeStreet.Text == "" ||
                TraineeNumBuilding.Text == "" || TraineeCar.SelectedItem == null || TraineeGearBox.SelectedItem == null ||
                TraineeSchool.SelectedItem == null || TraineeNumLessons.Text == "")
                {
                    throw new Exception("one or more essential fields are empty");
                }
              if (TraineeTester.SelectedIndex == -1)
                    throw new Exception("Sorry,You can't register, There is no teacher who can teach you the type of vehicle you chose");

                trainee.TraineePhone = int.Parse(TraineePhoneNumber.Text);

                if (errorMessages.Any()) //errorMessages.Count > 0 
                {
                    string err = "Exception:";
                    foreach (var item in errorMessages)
                        err += "\n" + item;

                    MessageBox.Show(err);
                    return;
                }
                else
                {
                    bl.AddTrainee(trainee);
                    MessageBox.Show("the details saved");
                    MainWindow w = new MainWindow();
                    w.Show();
                    Close();
                   // trainee = new Trainee();
                    //DataContext = trainee;
                    //Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TraineeSchool_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TraineeCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TraineeTester.ItemsSource = bl.GetListOfTesters().Where(t => t.TesterCar == (Enums.Vehicle)TraineeCar.SelectedItem);
            TraineeTester.DisplayMemberPath = "TesterFirstName";
        }

        private void TraineeGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TraineeGearBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        private void validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                errorMessages.Add(e.Error.Exception.Message);
            else
                errorMessages.Remove(e.Error.Exception.Message);

            this.AddBTN.IsEnabled = !errorMessages.Any();
            UpdateBTN.IsEnabled = !errorMessages.Any();
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            kindOfTrainee w = new kindOfTrainee();
            w.Show();
            Close();
            //Wind;o;wTrainee1 mt1 = new WindowTrainee1();
            //mt1.ShowDialog();

        }

        private void TraineeTester_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TraineeTester_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void NumbersofTest_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(numbersofTest.Text, "[^0-9]"))//check if  number of tests was fiiled is only numbers
            {
                MessageBox.Show("Please enter number of tests in only numbers.");
                numbersofTest.Text = numbersofTest.Text.Remove(numbersofTest.Text.Length - 1);
            }
            if (numbersofTest.Text == "0")
            {
                lastDate.IsEnabled = false;

            }
            else
            {
                lastDate.IsEnabled = true;

            }



        }

        private void TraineeCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(TraineeCity.Text, "[^a-z]"))//check if  hour was fiiled is only numbers
            {
                MessageBox.Show("Please enter city in only small letters.");
                TraineeCity.Text = TraineeCity.Text.Remove(TraineeCity.Text.Length - 1);
            }
        }

        private void TraineeStreet_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(TraineeStreet.Text, "[^a-z]"))//check if  hour was fiiled is only numbers
            {
                MessageBox.Show("Please enter street in only small letters.");
                TraineeStreet.Text = TraineeStreet.Text.Remove(TraineeStreet.Text.Length - 1);
            }
        }

        private void TraineeNumBuilding_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(TraineeNumBuilding.Text, "[^0-9]"))//check if  hour was fiiled is only numbers
            {
                MessageBox.Show("Please enter num building in only numbers.");
                TraineeNumBuilding.Text = TraineeNumBuilding.Text.Remove(TraineeNumBuilding.Text.Length - 1);
            }

        }

        private void TraineePhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (System.Text.RegularExpressions.Regex.IsMatch(TraineePhoneNumber.Text, "[^0-9]"))//check if  hour was fiiled is only numbers
            {
                MessageBox.Show("Please enter phone number in only numbers.");
                TraineePhoneNumber.Text = TraineePhoneNumber.Text.Remove(TraineePhoneNumber.Text.Length - 1);
            }
        }

        private void TraineeNumLessons_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(TraineeNumLessons.Text, "[^0-9]"))//check if  hour was fiiled is only numbers
            {
                MessageBox.Show("Please enter Number Lesson's in only numbers.");
                TraineeNumLessons.Text = TraineeNumLessons.Text.Remove(TraineeNumLessons.Text.Length - 1);
            }
        }
    }
}
