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
    /// Interaction logic for testWindow.xaml
    /// </summary>
    public partial class testerWindow : Window
    {
       Tester t;
       
        public static IBL bl;
        private List<string> errorMessages;

        public testerWindow()
        {
            
            InitializeComponent();
            bl = FactoryBl.GetBL();
            t = new Tester();
            mainGridTester.DataContext = t;
            TesterCar.ItemsSource = Enum.GetValues(typeof(Enums.Vehicle));
            TesterGender.ItemsSource = Enum.GetValues(typeof(Enums.Gender));
            TesterGearBox.ItemsSource = Enum.GetValues(typeof(Enums.gearBox));
            errorMessages = new List<string>();
            foreach (var item in availabiltyGrid.Children)  //אתחול המטריצה ב false
            {
                CheckBox cb = item as CheckBox;
                if (item is CheckBox)
                    cb.IsChecked = false;
            }


        }

        public testerWindow(Tester tw)
        {
            InitializeComponent();
            bl = FactoryBl.GetBL();

            //AddBTN.Visibility = Visibility.Hidden;
            //RemoveBTN.Visibility = Visibility.Hidden;
            IDTextBox.IsEnabled = true;
            TesterBirthDate.IsEnabled = false;
            TesterFirstNameTextBox.IsEnabled = true;
            TesterLastName.IsEnabled = true;
            TesterGender.IsEnabled = false;
            TesterPhoneNumber.IsEnabled = true;
            TesterCity.IsEnabled = true;
            TesterStreet.IsEnabled = true;
            TesterNumBuilding.IsEnabled = true;
            TesterExperience.IsEnabled = true;
            TesterMaxTests.IsEnabled = true;
            TesterCar.IsEnabled = true;
            TesterGearBox.IsEnabled = true;
            TesterMaxDistance.IsEnabled = true;
            availabiltyGrid.IsEnabled = true;
            if (tw.TesterAvailability[0, 0] == true)
                sunday9.IsChecked = true;
            if (tw.TesterAvailability[0, 1] == true)
                sunday10.IsChecked = true;
            if (tw.TesterAvailability[0, 2] == true)
                sunday11.IsChecked = true;
            if (tw.TesterAvailability[0, 3] == true)
                sunday12.IsChecked = true;
            if (tw.TesterAvailability[0, 4] == true)
                sunday13.IsChecked = true;
            if (tw.TesterAvailability[0, 5] == true)
                sunday14.IsChecked = true;
            if (tw.TesterAvailability[1, 0] == true)
                monday9.IsChecked = true;
            if (tw.TesterAvailability[1, 1] == true)
                monday10.IsChecked = true;
            if (tw.TesterAvailability[1, 2] == true)
                monday11.IsChecked = true;
            if (tw.TesterAvailability[1, 3] == true)
                monday12.IsChecked = true;
            if (tw.TesterAvailability[1, 4] == true)
                monday13.IsChecked = true;
            if (tw.TesterAvailability[1, 5] == true)
                monday14.IsChecked = true;
            if (tw.TesterAvailability[2, 0] == true)
                tuesday9.IsChecked = true;
            if (tw.TesterAvailability[2, 1] == true)
                tuesday10.IsChecked = true;
            if (tw.TesterAvailability[2, 2] == true)
                tuesday11.IsChecked = true;
            if (tw.TesterAvailability[2, 3] == true)
                tuesday12.IsChecked = true;
            if (tw.TesterAvailability[2, 4] == true)
                tuesday13.IsChecked = true;
            if (tw.TesterAvailability[2, 5] == true)
                tuesday14.IsChecked = true;
            if (tw.TesterAvailability[3, 0] == true)
                wedensday9.IsChecked = true;
            if (tw.TesterAvailability[3, 1] == true)
                wedensday10.IsChecked = true;
            if (tw.TesterAvailability[3, 2] == true)
                wedensday11.IsChecked = true;
            if (tw.TesterAvailability[3, 3] == true)
                wedensday12.IsChecked = true;
            if (tw.TesterAvailability[3, 4] == true)
                wedensday13.IsChecked = true;
            if (tw.TesterAvailability[3, 5] == true)
                wedensday14.IsChecked = true;
            if (tw.TesterAvailability[4, 0] == true)
                thursday9.IsChecked = true;
            if (tw.TesterAvailability[4, 1] == true)
                thursday10.IsChecked = true;
            if (tw.TesterAvailability[4, 2] == true)
                thursday11.IsChecked = true;
            if (tw.TesterAvailability[4, 3] == true)
                thursday12.IsChecked = true;
            if (tw.TesterAvailability[4, 4] == true)
                thursday13.IsChecked = true;
            if (tw.TesterAvailability[4, 5] == true)
                thursday14.IsChecked = true;
            //int i = 0, j = 5;
            //foreach (var item in availabiltyGrid.Children) //עדכון הערכים במטריצה לפי מה שהיה
            //{
            //    if (item is CheckBox)
            //    {
            //        CheckBox cb = item as CheckBox;
            //        if (tr.TesterAvailability[i, j] == true)
            //        {
            //            cb.IsChecked = true;
            //        }
            //        if (j == 0)
            //        {
            //            i++;
            //            j = 5;
            //        }
            //        else
            //            j--;
            //        if (i == 5)
            //            break;
            //    }
            //}
            DataContext = tw;
            TesterCar.ItemsSource = Enum.GetValues(typeof(Enums.Vehicle));
            TesterGender.ItemsSource = Enum.GetValues(typeof(Enums.Gender));
            TesterGearBox.ItemsSource = Enum.GetValues(typeof(Enums.gearBox));
            errorMessages = new List<string>();
         
        }

        private void RemoveBTN_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var v = bl.GetListOfTesters().Exists(x => x.TesterId == int.Parse(IDTextBox.Text));      
                if (v == false)
                    throw new Exception("You are not registered in the system ");
                else
                {
                    MessageBoxResult ans = MessageBox.Show("Are you sure you want delete this tester?", "ATTENTION", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    switch (ans)
                    {
                        case MessageBoxResult.OK:
                            bl.DeleteTester((int.Parse(IDTextBox.Text)));
                            break;
                        case MessageBoxResult.Cancel:
                            break;
                    }
                    MessageBox.Show("Delete successful");
                }
            }
            catch(Exception ex)
            {
                 MessageBox.Show(ex.Message);
            }
        }

        private void UpdateBTN_Click(object sender, RoutedEventArgs e)
        {
            Tester tw = MyFunctions.GetTesterByID(int.Parse(IDTextBox.Text));
            if (sunday9.IsChecked == true)
                tw.TesterAvailability[0, 0] = true;
            if (sunday14.IsChecked == true)
                tw.TesterAvailability[0, 5] = true;
            if (sunday13.IsChecked == true)
                tw.TesterAvailability[0, 4] = true;
            if (sunday12.IsChecked == true)
                tw.TesterAvailability[0, 3] = true;
            if (sunday11.IsChecked == true)
                tw.TesterAvailability[0, 2] = true;
            if (sunday10.IsChecked == true)
                tw.TesterAvailability[0, 1] = true;
            //filled Sunday
            if (monday9.IsChecked == true)
                tw.TesterAvailability[1, 0] = true;
            if (monday14.IsChecked == true)
                tw.TesterAvailability[1, 5] = true;
            if (monday13.IsChecked == true)
                tw.TesterAvailability[1, 4] = true;
            if (monday12.IsChecked == true)
                tw.TesterAvailability[1, 3] = true;
            if (monday11.IsChecked == true)
                tw.TesterAvailability[1, 2] = true;
            if (monday10.IsChecked == true)
                tw.TesterAvailability[1, 1] = true;
            //filled Monday
            if (tuesday9.IsChecked == true)
                tw.TesterAvailability[2, 0] = true;
            if (tuesday14.IsChecked == true)
                tw.TesterAvailability[2, 5] = true;
            if (tuesday13.IsChecked == true)
                tw.TesterAvailability[2, 4] = true;
            if (tuesday12.IsChecked == true)
                tw.TesterAvailability[2, 3] = true;
            if (tuesday11.IsChecked == true)
                tw.TesterAvailability[2, 2] = true;
            if (tuesday10.IsChecked == true)
                tw.TesterAvailability[2, 1] = true;
            //filled Tuesday
            if (wedensday9.IsChecked == true)
                tw.TesterAvailability[3, 0] = true;
            if (wedensday14.IsChecked == true)
                tw.TesterAvailability[3, 5] = true;
            if (wedensday13.IsChecked == true)
                tw.TesterAvailability[3, 4] = true;
            if (wedensday12.IsChecked == true)
                tw.TesterAvailability[3, 3] = true;
            if (wedensday11.IsChecked == true)
                tw.TesterAvailability[3, 2] = true;
            if (wedensday10.IsChecked == true)
                tw.TesterAvailability[3, 1] = true;
            //filled Wensday
            if (thursday9.IsChecked == true)
                tw.TesterAvailability[4, 0] = true;
            if (thursday14.IsChecked == true)
                tw.TesterAvailability[4, 5] = true;
            if (thursday13.IsChecked == true)
                tw.TesterAvailability[4, 4] = true;
            if (thursday12.IsChecked == true)
                tw.TesterAvailability[4, 3] = true;
            if (thursday11.IsChecked == true)
                tw.TesterAvailability[4, 2] = true;
            if (thursday10.IsChecked == true)
                tw.TesterAvailability[4, 1] = true;
            //filled Thursday
            AddBTN.Visibility = Visibility.Hidden;
            RemoveBTN.Visibility = Visibility.Hidden;
            IDTextBox.IsEnabled = false;
            TesterBirthDate.IsEnabled = false;
            TesterFirstNameTextBox.IsEnabled = true;
            TesterLastName.IsEnabled = true;
            TesterGender.IsEnabled = false;
            TesterPhoneNumber.IsEnabled = true;
            TesterCity.IsEnabled = true;
            TesterStreet.IsEnabled = true;
            TesterNumBuilding.IsEnabled = true;
            TesterExperience.IsEnabled = true;
            TesterMaxTests.IsEnabled = true;
            TesterCar.IsEnabled = true;
            TesterGearBox.IsEnabled = true;
            TesterMaxDistance.IsEnabled = true;
            availabiltyGrid.IsEnabled = true;
           
            try
            {
                bool flag = false;
                foreach (var item in availabiltyGrid.Children)
                {

                    if (item is CheckBox)
                    {
                        CheckBox cb = item as CheckBox;
                        if (cb.IsChecked == true)
                        {
                            flag = true;
                            break;
                        }
                    }
                }
                if (flag == false)
                {
                    throw new Exception("You must choose at least 1 hour in week to work ");
                }
                if (errorMessages.Any()) //errorMessages.Count > 0 
                {
                    string err = "Exception:";
                    foreach (var item in errorMessages)
                        err += "\n" + item;

                    MessageBox.Show(err, "EXCEPTION", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
               
                bl.UpdateInfoTester(tw);
                MessageBox.Show("Details updated successfully", "Final step..", MessageBoxButton.OK, MessageBoxImage.Information);
                WindowTester1 w = new WindowTester1();
                w.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

    private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            if (sunday9.IsChecked == true)
                t.TesterAvailability[0, 0] = true;
            if (sunday14.IsChecked == true)
                t.TesterAvailability[0, 5] = true;
            if (sunday13.IsChecked == true)
                t.TesterAvailability[0, 4] = true;
            if (sunday12.IsChecked == true)
                t.TesterAvailability[0, 3] = true;
            if (sunday11.IsChecked == true)
                t.TesterAvailability[0, 2] = true;
            if (sunday10.IsChecked == true)
                t.TesterAvailability[0, 1] = true;
            //filled Sunday
            if (monday9.IsChecked == true)
                t.TesterAvailability[1, 0] = true;
            if (monday14.IsChecked == true)
                t.TesterAvailability[1, 5] = true;
            if (monday13.IsChecked == true)
                t.TesterAvailability[1, 4] = true;
            if (monday12.IsChecked == true)
                t.TesterAvailability[1, 3] = true;
            if (monday11.IsChecked == true)
                t.TesterAvailability[1, 2] = true;
            if (monday10.IsChecked == true)
                t.TesterAvailability[1, 1] = true;
            //filled Monday
            if (tuesday9.IsChecked == true)
                t.TesterAvailability[2, 0] = true;
            if (tuesday14.IsChecked == true)
                t.TesterAvailability[2, 5] = true;
            if (tuesday13.IsChecked == true)
                t.TesterAvailability[2, 4] = true;
            if (tuesday12.IsChecked == true)
                t.TesterAvailability[2, 3] = true;
            if (tuesday11.IsChecked == true)
                t.TesterAvailability[2, 2] = true;
            if (tuesday10.IsChecked == true)
                t.TesterAvailability[2, 1] = true;
            //filled Tuesday
            if (wedensday9.IsChecked == true)
                t.TesterAvailability[3, 0] = true;
            if (wedensday14.IsChecked == true)
                t.TesterAvailability[3, 5] = true;
            if (wedensday13.IsChecked == true)
                t.TesterAvailability[3, 4] = true;
            if (wedensday12.IsChecked == true)
                t.TesterAvailability[3, 3] = true;
            if (wedensday11.IsChecked == true)
                t.TesterAvailability[3, 2] = true;
            if (wedensday10.IsChecked == true)
                t.TesterAvailability[3, 1] = true;
            //filled Wensday
            if (thursday9.IsChecked == true)
                t.TesterAvailability[4, 0] = true;
            if (thursday14.IsChecked == true)
                t.TesterAvailability[4, 5] = true;
            if (thursday13.IsChecked == true)
                t.TesterAvailability[4, 4] = true;
            if (thursday12.IsChecked == true)
                t.TesterAvailability[4, 3] = true;
            if (thursday11.IsChecked == true)
                t.TesterAvailability[4, 2] = true;
            if (thursday10.IsChecked == true)
                t.TesterAvailability[4, 1] = true;

            try
            {
                int numId1 = Convert.ToInt32(IDTextBox.Text);
                if (numId1 < 100000000 || numId1 > 999999999)//check if id is legal
                    throw new Exception("Non-valid Id of tester. Please enter a valid Id.");
                if (IDTextBox.Text == " " || TesterFirstNameTextBox.Text == " " || TesterLastName.Text == "" || TesterBirthDate.SelectedDate == null || TesterGender.SelectedItem == null ||
                    TesterPhoneNumber.Text == "" || TesterCity.Text == "" || TesterStreet.Text == "" || TesterNumBuilding.Text == "" || TesterExperience.Text == "" ||
                    TesterMaxTests.Text == "" || TesterCar.SelectedItem == null || TesterGearBox.SelectedItem == null || TesterMaxDistance.Text == "")
                {
                    throw new Exception("one or more essential fields are empty ");
                }
                bool flag = false;
                foreach (var item in availabiltyGrid.Children)
                {

                    if (item is CheckBox)
                    {
                        CheckBox cb = item as CheckBox;
                        if (cb.IsChecked == true)
                        {
                            flag = true;
                            break;
                        }
                    }
                }
                if (flag == false)
                {
                    throw new Exception("You must choose at least 1 hour in week to work ");
                }

                if (errorMessages.Any()) //errorMessages.Count > 0 
                {
                    string err = "Exception:";
                    foreach (var item in errorMessages)
                        err += "\n" + item;

                    MessageBox.Show(err, "EXCEPTION", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    bl.AddTester(t);
                    MessageBox.Show("the details saved");
                    WindowTester1 w = new WindowTester1();
                    w.Show();
                    Close();
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                errorMessages.Add(e.Error.Exception.Message);
            else
                errorMessages.Remove(e.Error.Exception.Message);

            AddBTN.IsEnabled = !errorMessages.Any();
            RemoveBTN.IsEnabled = !errorMessages.Any();
        }

        
        private void return_Click(object sender, RoutedEventArgs e)
        {
            WindowTester1 mt1 = new WindowTester1();
            mt1.Show();
            Close();
        }

        private void TesterCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(TesterCity.Text, "[^a-z]"))//check if  hour was fiiled is only numbers
            {
                MessageBox.Show("Please enter city in only small letters.");
                TesterCity.Text = TesterCity.Text.Remove(TesterCity.Text.Length - 1);
            }
        }

        private void TesterStreet_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (System.Text.RegularExpressions.Regex.IsMatch(TesterStreet.Text, "[^a-z]"))//check if  hour was fiiled is only numbers
            {
                MessageBox.Show("Please enter street in only small letters.");
                TesterStreet.Text = TesterStreet.Text.Remove(TesterStreet.Text.Length - 1);
            }
        }

        private void TesterNumBuilding_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (System.Text.RegularExpressions.Regex.IsMatch(TesterNumBuilding.Text, "[^0-9]"))//check if  hour was fiiled is only numbers
            {
                MessageBox.Show("Please enter number of building in only numbers.");
                TesterNumBuilding.Text = TesterNumBuilding.Text.Remove(TesterNumBuilding.Text.Length - 1);
            }
        }

        private void TesterExperience_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(TesterExperience.Text, "[^0-9]"))//check if  hour was fiiled is only numbers
            {
                MessageBox.Show("Please enter years in only numbers.");
                TesterExperience.Text = TesterExperience.Text.Remove(TesterExperience.Text.Length - 1);
            }
        }

        private void TesterMaxTests_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(TesterMaxTests.Text, "[^0-9]"))//check if  hour was fiiled is only numbers
            {
                MessageBox.Show("Please enter maximum tests in only numbers.");
                TesterMaxTests.Text = TesterMaxTests.Text.Remove(TesterMaxTests.Text.Length - 1);
            }
        }
    }
}
