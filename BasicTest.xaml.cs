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
    /// Interaction logic for BasicTest.xaml
    /// </summary>
    public partial class BasicTest : Window
    {


        BL.IBL bl;
        Test MyTest;
        public BasicTest(string content, int testcode = 0)
        {
            InitializeComponent();
            btnOK.Content = content;
            Title = (content + " " + "test");//the title of the window
            MyTest = new Test();
            bl = FactoryBl.GetBL();
            if (testcode != 0)//when we update, delete or view trainee we get the id and search it.
            {
                MyTest = (Test)bl.FindObjectById(testcode);
            }
            this.DataContext = MyTest;//fill the data in the window
            this.cmbkindOfvehicle.ItemsSource = Enum.GetValues(typeof(BE.Enums.Vehicle));
            this.cmbgearBox.ItemsSource = Enum.GetValues(typeof(BE.Enums.gearBox));
            this.cmbKipDis.ItemsSource = Enum.GetValues(typeof(BE.Enums.Result));
            this.cmbMirror.ItemsSource = Enum.GetValues(typeof(BE.Enums.Result));
            this.cmbParking.ItemsSource = Enum.GetValues(typeof(BE.Enums.Result));
            this.cmbparallel.ItemsSource = Enum.GetValues(typeof(BE.Enums.Result));
            this.cmbSignaling.ItemsSource = Enum.GetValues(typeof(BE.Enums.Result));
            cmblights.ItemsSource = Enum.GetValues(typeof(BE.Enums.Result));
            cmbrightOfWay.ItemsSource = Enum.GetValues(typeof(BE.Enums.Result));
            cmbseatbelt.ItemsSource = Enum.GetValues(typeof(BE.Enums.Result));
            cmbstopsign.ItemsSource = Enum.GetValues(typeof(BE.Enums.Result));
            //txtFinalMark.ItemsSource= Enum.GetValues(typeof(BE.Enums.Result));
      


            if (content == "Remove" || content == "View")//cant change datacontext only view
            {
                
                textCode.IsEnabled = false;
                textTesterID.IsEnabled = false;
                txTtraineeID.IsEnabled = false;
                textHour.IsEnabled = false;
                textCity.IsEnabled = false;
                textStreet.IsEnabled = false;
                textBuilding.IsEnabled = false;
                cmbkindOfvehicle.IsEnabled = false;
                cmbgearBox.IsEnabled = false;
                cmbgearBox.IsEnabled = false;
                cmbgearBox.IsEnabled = false;
                cmbkindOfvehicle.IsEnabled = false;
                cmbKipDis.IsEnabled = false;
                cmbMirror.IsEnabled = false;
                cmbParking.IsEnabled = false;
                cmbparallel.IsEnabled = false;
                cmbSignaling.IsEnabled = false;
                txtFinalMark.IsEnabled = false;
                DateTest.IsEnabled = false;
                txtNote.IsEnabled = false;
                cmblights.IsEnabled = false;
                cmbrightOfWay.IsEnabled = false;
                cmbseatbelt.IsEnabled = false;
                cmbstopsign.IsEnabled = false;
              if(MyTest.TestResult== BE.Enums.Result.passed)
                {
                    txtFinalMark.Text = "The trainee passed";

                }
              else
                {
                    txtFinalMark.Text = "The trainee failed";

                }



            }
            if (content == "Update")//cant update id of test
            {
                textCode.IsEnabled = false;
                //txtNote.Visibility = System.Windows.Visibility.Hidden;
                //lblfinalmark.Visibility = System.Windows.Visibility.Hidden;
                //lblkeepdis.Visibility = System.Windows.Visibility.Hidden;
                //lblnote.Visibility = System.Windows.Visibility.Hidden;
                //lblmirror.Visibility = System.Windows.Visibility.Hidden;
                //lblparking.Visibility = System.Windows.Visibility.Hidden;
                //lblrevers.Visibility = System.Windows.Visibility.Hidden;
                //lblsignaling.Visibility = System.Windows.Visibility.Hidden;
                //lblmarkofTest.Visibility = System.Windows.Visibility.Hidden;
                //cmbKipDis.Visibility = System.Windows.Visibility.Hidden;
                //cmbMirror.Visibility = System.Windows.Visibility.Hidden;
                //cmbParking.Visibility = System.Windows.Visibility.Hidden;
                //cmbRevers.Visibility = System.Windows.Visibility.Hidden;
                //cmbSignaling.Visibility = System.Windows.Visibility.Hidden;
                //txtFinalMark.Visibility = System.Windows.Visibility.Hidden;
                if (MyTest.TestResult == BE.Enums.Result.passed)
                {
                    txtFinalMark.Text = "The trainee passed";

                }
                else
                {
                    txtFinalMark.Text = "The trainee failed";

                }
            }
            if (content == "Add")
            {
               // textCode.IsEnabled = false;
                textCode.Visibility = Visibility.Visible;
                txtNote.Visibility = System.Windows.Visibility.Hidden;
                lblfinalmark.Visibility = System.Windows.Visibility.Hidden;
                lblkeepdis.Visibility = System.Windows.Visibility.Hidden;
                lblnote.Visibility = System.Windows.Visibility.Hidden;
                lblmirrors.Visibility = System.Windows.Visibility.Hidden;
                lblparallel.Visibility = System.Windows.Visibility.Hidden;
                lblreverse.Visibility = System.Windows.Visibility.Hidden;
                lblsignaling.Visibility = System.Windows.Visibility.Hidden;
                lblmarkofTest.Visibility = System.Windows.Visibility.Hidden;
                cmbKipDis.Visibility = System.Windows.Visibility.Hidden;
                cmbMirror.Visibility = System.Windows.Visibility.Hidden;
                cmbParking.Visibility = System.Windows.Visibility.Hidden;
                cmbparallel.Visibility = System.Windows.Visibility.Hidden;
                cmbSignaling.Visibility = System.Windows.Visibility.Hidden;
                txtFinalMark.Visibility = System.Windows.Visibility.Hidden;
                cmblights.Visibility = System.Windows.Visibility.Hidden;
                cmbrightOfWay.Visibility = System.Windows.Visibility.Hidden;
                cmbseatbelt.Visibility = System.Windows.Visibility.Hidden;
                cmbstopsign.Visibility = System.Windows.Visibility.Hidden;
                lblrightofway.Visibility = System.Windows.Visibility.Hidden;
                lblstopsign.Visibility = System.Windows.Visibility.Hidden;
                lblseat.Visibility = System.Windows.Visibility.Hidden;
                lblights.Visibility = System.Windows.Visibility.Hidden;
            }

        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            TestWindow1 mytestMenu = new TestWindow1();
            try
            {
                if ((string)btnOK.Content == "Add")
                {
                    int numId1 = Convert.ToInt32(textTesterID.Text);
                    if (numId1 < 100000000 || numId1 > 999999999)//check if id is legal
                        throw new Exception("Non-valid Id of tester. Please enter a valid Id.");
                    int numId = Convert.ToInt32(txTtraineeID.Text);
                    if (numId < 100000000 || numId > 999999999)//check if id is legal
                        throw new Exception("Non-valid Id of trainee. Please enter a valid Id.");

                    if ((textTesterID.Text == "") || (txTtraineeID.Text == "") || (textCity.Text == "") || (textBuilding.Text == "") || (textStreet.Text == "")
                        || (cmbgearBox.Text == "") || (cmbkindOfvehicle.Text == ""))//chech the texts box are not empty
                    {
                        throw new Exception("Not all fields are filled in.");
                    }
                    if (DateTest.SelectedDate < DateTime.Today)
                    {
                        throw new Exception("Please, enter a Nonpassed date");
                    }

                    bl.AddTest(MyTest);//ask him if he sure he wants to add?
                    //MyTest.NumOfTest = ++Configuration.TestNum;
                    MyTest = new Test();//clean the datacontext
                    this.DataContext = MyTest;
                    
                    MessageBox.Show("you add a test !");
                    this.Close();
                    mytestMenu.Show();

                }
                else if ((string)btnOK.Content == "Remove")
                {
                    var mbResult = MessageBox.Show("Are you sure you want to remove this test?", "", MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Yes);
                    if (mbResult == MessageBoxResult.OK)
                    {
                        bl.deleteTest(MyTest);
                        MyTest = new Test();//clean the datacontext
                        this.DataContext = MyTest;
                        MessageBox.Show("Test removed");
                        this.Close();
                        
                        mytestMenu.Show();

                    }
                }

                else if ((string)btnOK.Content == "Update")
                {
                    
                    var mbResult = MessageBox.Show("Are you sure you want to update this test?", "", MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Yes);
                    if (mbResult == MessageBoxResult.OK)
                    {

                        if (MyTest.keepDistance == BE.Enums.Result.passed &&
                                 MyTest.mirrorLooking == BE.Enums.Result.passed &&
                                 MyTest.reverseParking == BE.Enums.Result.passed &&
                                 MyTest.parallelParking == BE.Enums.Result.passed &&
                                 MyTest.signaling == BE.Enums.Result.passed &&
                                 MyTest.lights == BE.Enums.Result.passed &&
                                 MyTest.wearSeatBelt == BE.Enums.Result.passed &&
                                 MyTest.giveRightOfWay == BE.Enums.Result.passed &&
                                 MyTest.stopSign == BE.Enums.Result.passed)

                        {


                            MyTest.TestResult = BE.Enums.Result.passed;

                        }
                        else
                        {


                            MyTest.TestResult = BE.Enums.Result.failed;
                        }
                        bl.UpdateTest(MyTest);
                        MyTest = new Test();
                        this.DataContext = MyTest;
                        MessageBox.Show("Test updated");
                        this.Close();

                        mytestMenu.Show();

                    }


                    else
                    {
                        this.Close();
                        //mytestMenu.Show();
                    }
                }

                else
                {
                    MyTest = new Test();
                    this.DataContext = MyTest;
                    this.Close();
                    //mytestMenu.Show();
                }


            }



            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        private void TextHour_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textHour.Text, "[^0-9]"))//check if  hour was fiiled is only numbers
            {
                MessageBox.Show("Please enter hour in only numbers.");
                textHour.Text = textHour.Text.Remove(textHour.Text.Length - 1);
            }
        }

        private void TextBuilding_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBuilding.Text, "[^0-9]"))//check if  building was fiiled is only numbers
            {
                MessageBox.Show("Please enter building in only numbers.");
                textBuilding.Text = textBuilding.Text.Remove(textBuilding.Text.Length - 1);
            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            TestWindow1 m = new TestWindow1();
           
            m.Show();
            this.Close();
        }


        
      
        private void TxtFinalMark_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void textCode_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        
    }
}
