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
    /// Interaction logic for updatetester.xaml
    /// </summary>
    public partial class updateTester : Window
    {
        public static IBL bl;
        Tester MyTester;
        public updateTester()// when we add tester id=0
        {
            InitializeComponent();
          //MyTester = new Tester();
            bl = FactoryBl.GetBL();
        }

        private void BtnOk_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var v = bl.GetListOfTesters().Any(x => x.TesterId == int.Parse(TesterIdtextBox.Text));
                if (v == false)
                    throw new Exception("You are not registered in the system ");
                else
                {
                    testerWindow tw = new testerWindow((MyFunctions.GetTesterByID(int.Parse(TesterIdtextBox.Text))));
                    // bl.UpdateInfoTester(MyFunctions.GetTesterByID(int.Parse(textBox.Text)));
                    tw.AddBTN.Visibility = Visibility.Hidden;
                    tw.RemoveBTN.Visibility = Visibility.Hidden;
                    tw.ShowDialog();
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            WindowTester1 w = new WindowTester1();
            w.Show();
            Close();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}



