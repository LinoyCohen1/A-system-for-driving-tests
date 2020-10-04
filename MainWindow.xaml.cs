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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BL;
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static IBL BL = FactoryBl.GetBL();

        public MainWindow()
        {
            InitializeComponent();
            //Tester t = new Tester
            //{
            //    TesterId = 209233600,
            //    TesterFirstName = "Ora",
            //    TesterLastName = "Nasri",
            //    TesterBirthDate = DateTime.Parse("18.12.1970"),
            //    TesterGender = Enums.Gender.female,
            //    TesterCar = Enums.Vehicle.privateCar,
            //    TesterGearBox = Enums.gearBox.manual,
            //    TesterCity = "Kfar Saba",
            //    TesterNumBuilding = 4,
            //    TesterStreet = "Hazait",
            //    TesterExperience = 20,
            //    TesterMaxDistance = 50,
            //    TesterMaxTests = 30,
            //    TesterPhone = 0527485631,
            //    TesterAvailability = new bool[,] {{ true, true, true, true, true },
            //                                          { true, true, true, true, true },
            //                                          { true, true, true, true, true },
            //                                          { true, true, true, true, true },
            //                                          { true, true, true, true, true },
            //                                          { true, true, true, true, true }}


            //};
            //BL.AddTester(t);

            //Tester t1 = new Tester
            //{
            //    TesterId = 207818931,
            //    TesterFirstName = "Linoy",
            //    TesterLastName = "Maymon",
            //    TesterBirthDate = DateTime.Parse("31.05.1972"),
            //    TesterGender = Enums.Gender.female,
            //    TesterCar = Enums.Vehicle.heavyTrack,
            //    TesterGearBox = Enums.gearBox.manual,
            //    TesterCity = "Or Yehuda",
            //    TesterNumBuilding = 43,
            //    TesterStreet = "Alexandroni",
            //    TesterExperience = 8,
            //    TesterMaxDistance = 200000,
            //    TesterMaxTests = 30,
            //    TesterPhone = 0585697315,
            //    TesterAvailability = new bool[,] {{ true, true, true, true, true },
            //                                          { true, true, true, true, true },
            //                                          { true, true, true, true, true },
            //                                          { true, true, true, true, true },
            //                                          { true, true, true, true, true },
            //                                          { true, true, true, true, true }}

            //};
            //BL.AddTester(t1);

            //Tester t2 = new Tester
            //{
            //    TesterId = 315267845,
            //    TesterFirstName = "Yakov",
            //    TesterLastName = "Shomron",
            //    TesterBirthDate = DateTime.Parse("02.02.1975"),
            //    TesterGender = Enums.Gender.male,
            //    TesterCar = Enums.Vehicle.mediumTrack,
            //    TesterGearBox = Enums.gearBox.automatic,
            //    TesterCity = "Jerusalem",
            //    TesterNumBuilding = 78,
            //    TesterStreet = "Ben Yehuda",
            //    TesterExperience = 13,
            //    TesterMaxDistance = 70,
            //    TesterMaxTests = 30,
            //    TesterPhone = 0549768215,
            //    TesterAvailability = new bool[,] {{ true, true, true, true, true },
            //                                          { true, true, true, true, true },
            //                                          { true, true, true, true, true },
            //                                          { true, true, true, true, true },
            //                                          { true, true, true, true, true },
            //                                          { true, true, true, true, true }}

            //};
            //BL.AddTester(t2);

            //Tester t3 = new Tester
            //{
            //    TesterId = 215698754,
            //    TesterFirstName = "Israel",
            //    TesterLastName = "Israeli",
            //    TesterBirthDate = DateTime.Parse("01.01.1960"),
            //    TesterGender = Enums.Gender.male,
            //    TesterCar = Enums.Vehicle.twoWheeledCar,
            //    TesterGearBox = Enums.gearBox.automatic,
            //    TesterCity = "Netivot",
            //    TesterNumBuilding = 7,
            //    TesterStreet = "Akiva",
            //    TesterExperience = 35,
            //    TesterMaxDistance = 700,
            //    TesterMaxTests = 30,
            //    TesterPhone = 0502569784,
            //    TesterAvailability = new bool[,] {{ true, true, true, true, true },
            //                                          { true, true, true, true, true },
            //                                          { true, true, true, true, true },
            //                                          { true, true, true, true, true },
            //                                          { true, true, true, true, true },
            //                                          { true, true, true, true, true }}

            //};
            //BL.AddTester(t3);

            //Trainee tr = new Trainee
            //{
            //    TraineeId = 203648759,
            //    TraineeFirstName = "Shay",
            //    TraineeLastName = "Choen",
            //    TraineeBirthDate = DateTime.Parse("05.08.1998"),
            //    TraineeCar = Enums.Vehicle.heavyTrack,
            //    TraineeGearBox = Enums.gearBox.automatic,
            //    TraineeGender = Enums.Gender.male,
            //    TraineeNumLessons = 25,
            //    TraineePhone = 0502589631,
            //    TraineeSchool = Enums.Schools.smartDrive,
            //    TraineeTesterName = "Linoy",
            //    cityTrainee = "Sderot",
            //    numBuildingTrainee = 4,
            //    streetTrainee = "Derech Hapoel"
            //};
            //BL.AddTrainee(tr);
        }

        private void tester_Click(object sender, RoutedEventArgs e)
        {
            WindowTester1 tw = new WindowTester1();
            tw.Show();
         this.Close();
        }

        private void trainee_Click(object sender, RoutedEventArgs e)
        {
            kindOfTrainee w = new kindOfTrainee();
            w.Show();
            Close();
         
        }
        

        private void linq_Click(object sender, RoutedEventArgs e)
        {
            new linqWindow().ShowDialog();
            //groupingWindow lw = new groupingWindow();
            //lw.Show();
            //Close();
        }

      

        private void showLists_Click(object sender, RoutedEventArgs e)
        {
            lists w = new lists();
            w.Show();
            Close();
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            TestWindow1 t = new TestWindow1();
            t.btnID.Visibility = Visibility.Hidden;
            t.btnOK.Visibility = Visibility.Hidden;
            t.btntextbox.Visibility = Visibility.Hidden;
            t.Show();
            Close();
        }
    }
}
