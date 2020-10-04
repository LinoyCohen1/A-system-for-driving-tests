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
    /// Interaction logic for TestWindow1.xaml
    /// </summary>
    public partial class TestWindow1 : Window
    {

       
        string action;
        Test test;
        IBL bl;
        
        public TestWindow1()
        {
            
            InitializeComponent();
          //  test = new Test();
            bl = FactoryBl.GetBL();
            btnOKRemove.Visibility = Visibility.Hidden;
            btnOKView.Visibility = Visibility.Hidden;
            btnOK.Visibility = Visibility.Hidden;
            btnID.Visibility = Visibility.Hidden;
            btntextbox.Visibility = Visibility.Hidden;

        }

        private void addTest_Click(object sender, RoutedEventArgs e)
        {

            string content = "Add";
            BasicTest mytest = new BasicTest(content);
            this.Close();
            mytest.Show();
           
        }

        private void updateTest_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            string content = "Update";
            try
            {
                var v = bl.GetListOfTests().Any(x => x.NumOfTest == int.Parse(btntextbox.Text));
                if (v == false)
                    throw new Exception("this test are not registered in the system ");
                else
                {
                    int Id = int.Parse(btntextbox.Text);
                    Test t = (Test)bl.FindObjectById(int.Parse(btntextbox.Text));
                    if (t.keepDistance == BE.Enums.Result.passed &&
                             t.mirrorLooking == BE.Enums.Result.passed &&
                             t.reverseParking == BE.Enums.Result.passed &&
                             t.parallelParking == BE.Enums.Result.passed &&
                             t.signaling == BE.Enums.Result.passed &&
                             t.lights == BE.Enums.Result.passed &&
                             t.wearSeatBelt == BE.Enums.Result.passed &&
                             t.giveRightOfWay == BE.Enums.Result.passed &&
                             t.stopSign == BE.Enums.Result.passed)

                    {


                        t.TestResult = BE.Enums.Result.passed;

                    }
                    else
                    {


                        t.TestResult = BE.Enums.Result.failed;
                    }
                    BasicTest mytest = new BasicTest(content, Id);
                    mytest.txtFinalMark.Visibility = Visibility.Hidden;
                    mytest.lblfinalmark.Visibility = Visibility.Hidden;
                    this.Close();
                    mytest.Show();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
               

        }
        private void btnOKRemove_Click(object sender, RoutedEventArgs e)
        {
            string content = "Remove";
            try
            {
                var v = bl.GetListOfTests().Any(x => x.NumOfTest == int.Parse(btntextbox.Text));
                if (v == false)
                    throw new Exception("this test are not registered in the system ");
                else
                {
                    int Id = int.Parse(btntextbox.Text);
                    BasicTest mytest = new BasicTest(content, Id);
                    this.Close();
                    mytest.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnOKView_Click(object sender, RoutedEventArgs e)
        {
            string content = "View";
            
            try
            {

                var v = bl.GetListOfTests().Any(x => x.NumOfTest == int.Parse(btntextbox.Text));
                if (v == false)
                    throw new Exception("this test are not registered in the system ");
                int Id = int.Parse(btntextbox.Text);
                Test t = (Test)bl.FindObjectById(int.Parse(btntextbox.Text));
                if (t.keepDistance == BE.Enums.Result.passed &&
                         t.mirrorLooking == BE.Enums.Result.passed &&
                         t.reverseParking == BE.Enums.Result.passed &&
                         t.parallelParking == BE.Enums.Result.passed &&
                         t.signaling == BE.Enums.Result.passed &&
                         t.lights == BE.Enums.Result.passed &&
                         t.wearSeatBelt == BE.Enums.Result.passed &&
                         t.giveRightOfWay == BE.Enums.Result.passed &&
                         t.stopSign == BE.Enums.Result.passed)

                {


                    t.TestResult = BE.Enums.Result.passed;

                }
                else
                {


                    t.TestResult = BE.Enums.Result.failed;
                }

                
                BasicTest mytest = new BasicTest(content, Id);
                    this.Close();
                    mytest.Show();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
            private void return_Click(object sender, RoutedEventArgs e)
        {
         
            new MainWindow().Show();
            Close();
        }

        private void UpdateTest_Click_1(object sender, RoutedEventArgs e)
        {
            btnOKRemove.Visibility = Visibility.Hidden;
            btnOKView.Visibility = Visibility.Hidden;
            viewTest.Visibility = Visibility.Hidden;
            removeTest.Visibility = Visibility.Hidden;
            updateTest.Visibility = Visibility.Hidden;
            addTest.Visibility = Visibility.Hidden;
            btnID.Visibility = Visibility.Visible;
            btntextbox.Visibility = Visibility.Visible;
            btnOK.Visibility = Visibility.Visible;
            
        }

        private void RemoveTest_Click(object sender, RoutedEventArgs e)
        {
            btnOKRemove.Visibility = Visibility.Visible;
            btnOKView.Visibility = Visibility.Hidden;
            btnOK.Visibility = Visibility.Hidden;
            viewTest.Visibility = Visibility.Hidden;
            removeTest.Visibility = Visibility.Hidden;
            updateTest.Visibility = Visibility.Hidden;
            addTest.Visibility = Visibility.Hidden;
            btnID.Visibility = Visibility.Visible;
            btntextbox.Visibility = Visibility.Visible;
            
            
        }

        private void ViewTest_Click(object sender, RoutedEventArgs e)
        {
            btnOK.Visibility = Visibility.Hidden;
            btnOKRemove.Visibility = Visibility.Hidden;
            viewTest.Visibility = Visibility.Hidden;
            removeTest.Visibility = Visibility.Hidden;
            updateTest.Visibility = Visibility.Hidden;
            addTest.Visibility = Visibility.Hidden;
            btnID.Visibility = Visibility.Visible;
            btntextbox.Visibility = Visibility.Visible;
            btnOKView.Visibility = Visibility.Visible;
            
        }
    }
}
