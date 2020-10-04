using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;
using BE;
using DS;
namespace DAL
{
    class Dal_XML_imp : IDAL
    {

        XElement testerRoot;
        XElement traineeRoot;
        XElement testRoot;
        string testerPath = @"Tester";
        string traineePath = @"Trainee";
        string testPath = @"Test";
        public Dal_XML_imp()
        {
            if (!File.Exists(testerPath))
                CreateTestersFiles();
            if (!File.Exists(traineePath))
                CreateTraineesFiles();
            if (!File.Exists(testPath))
                CreateTestsFiles();
            LoadTesters();
            LoadTrainees();
            LoadTests();
        }
        private void CreateTestersFiles()
        {

            testerRoot = new XElement("Testers");
            testerRoot.Save(testerPath);
        }
        private void CreateTraineesFiles()
        {

            traineeRoot = new XElement("Trainees");
            traineeRoot.Save(traineePath);
        }
        private void CreateTestsFiles()
        {

            testRoot = new XElement("Tests");
            testRoot.Save(testPath);
        }
        private void LoadTesters()
        {
            try
            {
                testerRoot = XElement.Load(testerPath);
            }
            catch
            {
                throw new Exception("Tester XML::File upload problem");
            }
        }
        private void LoadTrainees()
        {
            try
            {
                traineeRoot = XElement.Load(traineePath);
            }
            catch
            {
                throw new Exception("Trainee XML::File upload problem");
            }
        }
        private void LoadTests()
        {
            try
            {
                testRoot = XElement.Load(testPath);
            }
            catch
            {
                throw new Exception("Test XML::File upload problem");
            }
        }
        // get lists:
        public List<BE.Tester> GetListOfTesters(Predicate<BE.Tester> predicate = null)
        {
            LoadTesters();
            List<Tester> testers = new List<Tester>();
            try
            {

                testers = (from p in testerRoot.Elements()
                           select new Tester
                           {
                               TesterId = Convert.ToInt32(p.Element("testerId").Value),
                               TesterFirstName = p.Element("name").Element("testerFirstName").Value,
                               TesterLastName = p.Element("name").Element("testerLastName").Value,
                               TesterBirthDate = Convert.ToDateTime(p.Element("testerBirthDate").Value),
                               TesterGender = (Enums.Gender)Enum.Parse(typeof(Enums.Gender), p.Element("testerGender").Value),
                               TesterPhone = p.Element("testerPhone").Value,
                               TesterCity = p.Element("address").Element("testerCity").Value,
                               TesterStreet = p.Element("address").Element("testerStreet").Value,
                               TesterNumBuilding = Convert.ToInt32(p.Element("address").Element("testerNumBuilding").Value),
                               TesterExperience = Convert.ToInt32(p.Element("testerExperience").Value),
                               TesterMaxTests = Convert.ToInt32(p.Element("testerMaxTests").Value),
                               TesterCar = (Enums.Vehicle)Enum.Parse(typeof(Enums.Vehicle), p.Element("testerCar").Value),
                               TesterAvailability = new bool[,] {
                                     {
                                           Convert.ToBoolean(p.Element("testerAvailability").Element("sunday9").Value),
                                           Convert.ToBoolean(p.Element("testerAvailability").Element("sunday10").Value),
                                           Convert.ToBoolean(p.Element("testerAvailability").Element("sunday11").Value),
                                           Convert.ToBoolean(p.Element("testerAvailability").Element("sunday12").Value),
                                           Convert.ToBoolean(p.Element("testerAvailability").Element("sunday13").Value),
                                           Convert.ToBoolean(p.Element("testerAvailability").Element("sunday14").Value),




                                       },
                                      {
                                           Convert.ToBoolean(p.Element("testerAvailability").Element("monday9").Value),
                                           Convert.ToBoolean(p.Element("testerAvailability").Element("monday10").Value),
                                           Convert.ToBoolean(p.Element("testerAvailability").Element("monday11").Value),
                                           Convert.ToBoolean(p.Element("testerAvailability").Element("monday12").Value),
                                           Convert.ToBoolean(p.Element("testerAvailability").Element("monday13").Value),
                                           Convert.ToBoolean(p.Element("testerAvailability").Element("monday14").Value),

                                                                                },
                                        {

                                        Convert.ToBoolean(p.Element("testerAvailability").Element("tuesday9").Value),
                                        Convert.ToBoolean(p.Element("testerAvailability").Element("tuesday10").Value),
                                       Convert.ToBoolean(p.Element("testerAvailability").Element("tuesday11").Value),
                                       Convert.ToBoolean(p.Element("testerAvailability").Element("tuesday12").Value),
                                        Convert.ToBoolean(p.Element("testerAvailability").Element("tuesday13").Value),
                                       Convert.ToBoolean(p.Element("testerAvailability").Element("tuesday14").Value),

                                       },
                                        {
                                        Convert.ToBoolean(p.Element("testerAvailability").Element("wedensday9").Value),
                                        Convert.ToBoolean(p.Element("testerAvailability").Element("wedensday10").Value),
                                        Convert.ToBoolean(p.Element("testerAvailability").Element("wedensday11").Value),
                                        Convert.ToBoolean(p.Element("testerAvailability").Element("wedensday12").Value),
                                        Convert.ToBoolean(p.Element("testerAvailability").Element("wedensday13").Value),
                                        Convert.ToBoolean(p.Element("testerAvailability").Element("wedensday14").Value),
                                   },
                                   {

                                        Convert.ToBoolean(p.Element("testerAvailability").Element("thursday9").Value),
                                        Convert.ToBoolean(p.Element("testerAvailability").Element("thursday10").Value),
                                       Convert.ToBoolean(p.Element("testerAvailability").Element("thursday11").Value),
                                       Convert.ToBoolean(p.Element("testerAvailability").Element("thursday12").Value),
                                       Convert.ToBoolean(p.Element("testerAvailability").Element("thursday13").Value),
                                       Convert.ToBoolean(p.Element("testerAvailability").Element("thursday14").Value),
                                   },

                               },
                               TesterMaxDistance = Convert.ToInt32(p.Element("testerMaxDistance").Value),
                               TesterGearBox = (Enums.gearBox)Enum.Parse(typeof(Enums.gearBox), p.Element("testerGearBox").Value),

                           }).ToList();

            }
            catch
            {
                testers = null;
                throw new Exception("problem in getTestersList");
            }
            return testers;
        }

        public List<Trainee> GetListOfTrainees()
        {
            LoadTrainees();
            List<Trainee> trainees=new List<Trainee>();
            try
            {
                trainees = (from p in traineeRoot.Elements()
                            select new Trainee()
                            {
                                TraineeId = Convert.ToInt32(p.Element("TraineeId").Value),
                                TraineeFirstName = p.Element("Name").Element("TraineeFirstName").Value,
                                TraineeLastName = p.Element("Name").Element("TraineeLastName").Value,
                                TraineeBirthDate = Convert.ToDateTime(p.Element("TraineeBirthDate").Value),
                                TraineeGender = (Enums.Gender)Enum.Parse(typeof(Enums.Gender), p.Element("TraineeGender").Value),
                                TraineePhone = int.Parse(p.Element("TraineePhone").Value),
                                cityTrainee = p.Element("Address").Element("cityTrainee").Value,
                                streetTrainee = p.Element("Address").Element("streetTrainee").Value,
                                numBuildingTrainee = Convert.ToInt32(p.Element("Address").Element("numBuildingTrainee").Value),
                                TraineeNumTests = int.Parse(p.Element("TraineeNumTests").Value),
                                TraineeCar = (Enums.Vehicle)Enum.Parse(typeof(Enums.Vehicle), p.Element("TraineeCar").Value),
                                TraineeGearBox = (Enums.gearBox)Enum.Parse(typeof(Enums.gearBox), p.Element("TraineeGearBox").Value),
                                TraineeSchool = (Enums.Schools)Enum.Parse(typeof(Enums.Schools), p.Element("TraineeSchool").Value),
                                TraineeTesterName = p.Element("TraineeTesterName").Value,
                                DateLastTest= Convert.ToDateTime(p.Element("DateLastTest").Value),
                                TraineeNumLessons = int.Parse(p.Element("TraineeNumLessons").Value),

                            }).ToList();
            }
            catch
            {
                trainees = null;
                throw new Exception("problem in getTraineesList");
            }
            return trainees;

        }

        public List<Test> GetListOfTests()
        {
            LoadTests();
            List<Test> tests=new List<Test>() ;
            try
            {
                tests = (from p in testRoot.Elements()
                         select new Test()
                         {
                             NumOfTest = int.Parse(p.Element("NumOfTest").Value),
                             TesterIdTest = int.Parse(p.Element("TesterIdTest").Value),
                             TraineeIdTest = int.Parse(p.Element("TraineeIdTest").Value),
                             TestEstimatedDate = Convert.ToDateTime(p.Element("TestEstimatedDate").Value),
                             hourOfTest = int.Parse(p.Element("hourOfTest").Value),
                             TestCity = p.Element("Address").Element("TestCity").Value,
                             TestStreet = p.Element("Address").Element("TestStreet").Value,
                             TestNumBuilding = Convert.ToInt32(p.Element("Address").Element("TestNumBuilding").Value),
                             testCar = (Enums.Vehicle)Enum.Parse(typeof(Enums.Vehicle), p.Element("TestCar").Value),
                             testCarGearBox = (Enums.gearBox)Enum.Parse(typeof(Enums.gearBox), p.Element("TestCarGearBox").Value),
                             TestResult = (Enums.Result)Enum.Parse(typeof(Enums.Result), p.Element("TestResult").Value),
                             keepDistance = (Enums.Result)Enum.Parse(typeof(Enums.Result), p.Element("KeepDistance").Value),
                             mirrorLooking = (Enums.Result)Enum.Parse(typeof(Enums.Result), p.Element("mirrorLooking").Value),
                             stopSign = (Enums.Result)Enum.Parse(typeof(Enums.Result), p.Element("stopSign").Value),
                             wearSeatBelt = (Enums.Result)Enum.Parse(typeof(Enums.Result), p.Element("wearSeatBelt").Value),
                             lights = (Enums.Result)Enum.Parse(typeof(Enums.Result), p.Element("lights").Value),
                             reverseParking = (Enums.Result)Enum.Parse(typeof(Enums.Result), p.Element("reverseParking").Value),
                             parallelParking = (Enums.Result)Enum.Parse(typeof(Enums.Result), p.Element("parallelParking").Value),
                             signaling = (Enums.Result)Enum.Parse(typeof(Enums.Result), p.Element("signaling").Value),
                             giveRightOfWay = (Enums.Result)Enum.Parse(typeof(Enums.Result), p.Element("giveRightOfWay").Value),
                             Comments = p.Element("Comments").Value,
                         }).ToList();
            }
            catch
            {
                tests = null;
                throw new Exception("problem in getTestsList");
            }
            return tests;

        }

        //ADD:
        public void AddTester(Tester tester)
        {


            if (GetListOfTesters().Exists(x => x.TesterId == tester.TesterId))
                throw new Exception("The operation was not accomplished. A tester with the same id already exists.");
            if (GetListOfTrainees().Exists(x => x.TraineeId == tester.TesterId))
                throw new Exception("The operation was not accomplished. A trainee with the same id already exists.");
            XElement TesterId = new XElement("testerId", tester.TesterId);
            XElement TesterFirstName = new XElement("testerFirstName", tester.TesterFirstName);
            XElement TesterLastName = new XElement("testerLastName", tester.TesterLastName);
            XElement Name = new XElement("name", TesterFirstName, TesterLastName);
            XElement TesterBirthDate = new XElement("testerBirthDate", tester.TesterBirthDate);
            XElement TesterGender = new XElement("testerGender", tester.TesterGender);
            XElement TesterPhone = new XElement("testerPhone", tester.TesterPhone);
            XElement TesterCity = new XElement("testerCity", tester.TesterCity);
            XElement TesterStreet = new XElement("testerStreet", tester.TesterStreet);
            XElement TesterNumBuilding = new XElement("testerNumBuilding", tester.TesterNumBuilding);
            XElement Address = new XElement("address", TesterCity, TesterStreet, TesterNumBuilding);
            XElement TesterExperience = new XElement("testerExperience", tester.TesterExperience);
            XElement TesterMaxTests = new XElement("testerMaxTests", tester.TesterMaxTests);
            XElement TesterCar = new XElement("testerCar", tester.TesterCar);
            XElement hour1 = new XElement("sunday9", tester.TesterAvailability[0, 0]);
            XElement hour2 = new XElement("sunday10", tester.TesterAvailability[0, 1]);
            XElement hour3 = new XElement("sunday11", tester.TesterAvailability[0, 2]);
            XElement hour4 = new XElement("sunday12", tester.TesterAvailability[0, 3]);
            XElement hour5 = new XElement("sunday13", tester.TesterAvailability[0, 4]);
            XElement hour6 = new XElement("sunday14", tester.TesterAvailability[0, 5]);
            XElement hour7 = new XElement("monday9", tester.TesterAvailability[1, 0]);
            XElement hour8 = new XElement("monday10", tester.TesterAvailability[1, 1]);
            XElement hour9 = new XElement("monday11", tester.TesterAvailability[1, 2]);
            XElement hour10 = new XElement("monday12", tester.TesterAvailability[1, 3]);
            XElement hour11 = new XElement("monday13", tester.TesterAvailability[1, 4]);
            XElement hour12 = new XElement("monday14", tester.TesterAvailability[1, 5]);
            XElement hour13 = new XElement("tuesday9", tester.TesterAvailability[2, 0]);
            XElement hour14 = new XElement("tuesday10", tester.TesterAvailability[2, 1]);
            XElement hour15 = new XElement("tuesday11", tester.TesterAvailability[2, 2]);
            XElement hour16 = new XElement("tuesday12", tester.TesterAvailability[2, 3]);
            XElement hour17 = new XElement("tuesday13", tester.TesterAvailability[2, 4]);
            XElement hour18 = new XElement("tuesday14", tester.TesterAvailability[2, 5]);
            XElement hour19 = new XElement("wedensday9", tester.TesterAvailability[3, 0]);
            XElement hour20 = new XElement("wedensday10", tester.TesterAvailability[3, 1]);
            XElement hour21 = new XElement("wedensday11", tester.TesterAvailability[2, 2]);
            XElement hour22 = new XElement("wedensday12", tester.TesterAvailability[3, 3]);
            XElement hour23 = new XElement("wedensday13", tester.TesterAvailability[3, 4]);
            XElement hour24 = new XElement("wedensday14", tester.TesterAvailability[3, 5]);
            XElement hour25 = new XElement("thursday9", tester.TesterAvailability[4, 0]);
            XElement hour26 = new XElement("thursday10", tester.TesterAvailability[4, 1]);
            XElement hour27 = new XElement("thursday11", tester.TesterAvailability[4, 2]);
            XElement hour28 = new XElement("thursday12", tester.TesterAvailability[4, 3]);
            XElement hour29 = new XElement("thursday13", tester.TesterAvailability[4, 4]);
            XElement hour30 = new XElement("thursday14", tester.TesterAvailability[4, 5]);
            XElement TesterAvailability = new XElement("testerAvailability", hour1, hour2, hour3, hour4, hour5, hour6, hour7, hour8, hour9, hour10, hour11, hour12, hour13, hour14, hour15, hour16,
                hour17, hour18, hour19, hour20, hour21, hour22, hour23, hour24, hour25, hour26, hour27, hour28, hour29, hour30);
            XElement TesterMaxDistance = new XElement("testerMaxDistance", tester.TesterMaxDistance);
            XElement TesterGearBox = new XElement("testerGearBox", tester.TesterGearBox);
            testerRoot.Add(new XElement("tester", TesterId, Name, TesterBirthDate, TesterGender, TesterPhone, Address, TesterExperience, TesterMaxTests, TesterCar, TesterAvailability, TesterMaxDistance, TesterGearBox));
            testerRoot.Save(testerPath);
        }


        public void AddTrainee(Trainee trainee)
        {


            if (GetListOfTrainees().Exists(x => x.TraineeId == trainee.TraineeId))

                throw new Exception("The operation was not accomplished. A trainee with the same id already exists.");
            else if (GetListOfTesters().Exists(x => x.TesterId == trainee.TraineeId))
            {
                throw new Exception("The operation was not accomplished. A tester with the same id already exists.");
            }
            else
            {
                XElement TraineeId = new XElement("TraineeId", trainee.TraineeId);
                XElement TraineeFirstName = new XElement("TraineeFirstName", trainee.TraineeFirstName);
                XElement TraineeLastName = new XElement("TraineeLastName", trainee.TraineeLastName);
                XElement Name = new XElement("Name", TraineeFirstName, TraineeLastName);
                XElement TraineeBirthDate = new XElement("TraineeBirthDate", trainee.TraineeBirthDate);
                XElement TraineeGender = new XElement("TraineeGender", trainee.TraineeGender);
                XElement TraineePhone = new XElement("TraineePhone", trainee.TraineePhone);
                XElement streetTrainee = new XElement("streetTrainee", trainee.streetTrainee);
                XElement cityTrainee = new XElement("cityTrainee", trainee.cityTrainee);
                XElement numBuildingTrainee = new XElement("numBuildingTrainee", trainee.numBuildingTrainee);
                XElement Address = new XElement("Address", cityTrainee, streetTrainee, numBuildingTrainee);
                XElement TraineeSchool = new XElement("TraineeSchool", trainee.TraineeSchool);
                XElement TraineeTesterName = new XElement("TraineeTesterName", trainee.TraineeTesterName);
                XElement TraineeCar = new XElement("TraineeCar", trainee.TraineeCar);
                XElement TraineeGearBox = new XElement("TraineeGearBox", trainee.TraineeGearBox);
                XElement TraineeNumTests = new XElement("TraineeNumTests", trainee.TraineeNumTests);
                XElement TraineeNumLessons = new XElement("TraineeNumLessons", trainee.TraineeNumLessons);
                XElement DateLastTest = new XElement("DateLastTest", trainee.DateLastTest);
                traineeRoot.Add(new XElement("Trainee", TraineeId, Name, TraineeBirthDate, TraineeGender, TraineePhone,
                    Address, TraineeSchool, TraineeTesterName, TraineeCar, TraineeGearBox, TraineeNumTests, TraineeNumLessons, DateLastTest));
                traineeRoot.Save(traineePath);
            }

        }

        public void AddTest(Test test)
        {


            XElement NumOfTest = new XElement("NumOfTest", test.NumOfTest);
            XElement TesterIdTest = new XElement("TesterIdTest", test.TesterIdTest);
            XElement TraineeIdTest = new XElement("TraineeIdTest", test.TraineeIdTest);
            XElement TestEstimatedDate = new XElement("TestEstimatedDate", test.TestEstimatedDate);
            XElement hourOfTest = new XElement("hourOfTest", test.hourOfTest);
            XElement TestStreet = new XElement("TestStreet", test.TestStreet);
            XElement TestCity = new XElement("TestCity", test.TestCity);
            XElement TestNumBuilding = new XElement("TestNumBuilding", test.TestNumBuilding);
            XElement Address = new XElement("Address", TestCity, TestStreet, TestNumBuilding);
            XElement testCar = new XElement("testCar", test.testCar);
            XElement TestCarGearBox = new XElement("TestCarGearBox", test.testCarGearBox);
            XElement TestResult = new XElement("TestResult", test.TestResult);
            XElement KeepDistance = new XElement("KeepDistance", test.keepDistance);
            XElement mirrorLooking = new XElement("mirrorLooking", test.mirrorLooking);
            XElement stopSign = new XElement("stopSign", test.stopSign);
            XElement wearSeatBelt = new XElement("wearSeatBelt", test.wearSeatBelt);
            XElement reverseParking = new XElement("reverseParking", test.reverseParking);
            XElement lights = new XElement("lights", test.lights);
            XElement parallelParking = new XElement("parallelParking", test.parallelParking);
            XElement signaling = new XElement("signaling", test.signaling);
            XElement giveRightOfWay = new XElement("giveRightOfWay", test.giveRightOfWay);
            XElement Comments = new XElement("Comments", test.Comments);
            testRoot.Add(new XElement("Test", NumOfTest, TesterIdTest, TraineeIdTest, TestEstimatedDate, hourOfTest,
                    Address, testCar, TestCarGearBox, TestResult, KeepDistance, stopSign, mirrorLooking, giveRightOfWay, signaling,
                    reverseParking, parallelParking, wearSeatBelt, lights, Comments));
            testRoot.Save(testPath);


        }

        //DELETE:
        public void DeleteTester(int id)//מחיקת טסטר מוחק גם מבחן אבל רק אחד
        {
            XElement testerElement;
            XElement testElement;
            try
            {
                testerElement = (from p in testerRoot.Elements()
                                 where Convert.ToInt32(p.Element("testerId").Value) == id
                                 select p).FirstOrDefault();
                testerElement.Remove();
                testerRoot.Save(testerPath);
                testElement = (from p in testRoot.Elements()
                               where Convert.ToInt32(p.Element("TesterIdTest").Value) == id
                               select p).FirstOrDefault();
                testElement.Remove();
                testRoot.Save(testPath);
            }
            catch
            {
                throw new Exception("RemoveTester xml:: no such tester exists");
            }
        }

        public void DeleteTrainee(int id)//מוחק גם את המבחן אבל רק אחד
        {
            XElement traineeElement;
            XElement testElenent;
            try
            {
                traineeElement = (from p in traineeRoot.Elements()
                                  where Convert.ToInt32(p.Element("TraineeId").Value) == id
                                  select p).FirstOrDefault();
                traineeElement.Remove();
                traineeRoot.Save(traineePath);
                testElenent = (from p in testRoot.Elements()
                               where Convert.ToInt32(p.Element("TraineeIdTest").Value) == id//לא בטוח שצריך המרה לאינט
                               select p).FirstOrDefault();
                testElenent.Remove();
                testRoot.Save(testPath);
            }
            catch
            {
                throw new Exception("RemoveTrainee xml:: no such trainee exists");
            }
        }
        public void deleteTest(Test test)
        {
            XElement testElement;
            try
            {
                testElement = (from p in testRoot.Elements()
                               where Convert.ToInt32(p.Element("NumOfTest").Value) == test.NumOfTest
                               select p).FirstOrDefault();
                testElement.Remove();
                testRoot.Save(testPath);
            }
            catch
            {
                throw new Exception("RemoveTest xml:: no such test exists");
            }
        }

        //UPDATE:
        public void UpdateInfoTester(Tester tester)
        {
            XElement testerElement = (from p in testerRoot.Elements()
                                      where Convert.ToInt32(p.Element("testerId").Value) == tester.TesterId
                                      select p).FirstOrDefault();
            testerElement.Element("name").Element("testerFirstName").Value = tester.TesterFirstName;
            testerElement.Element("name").Element("testerLastName").Value = tester.TesterLastName;
            testerElement.Element("testerBirthDate").Value = tester.TesterBirthDate.ToShortDateString();
            testerElement.Element("testerGender").Value = Enum.GetName(tester.TesterGender.GetType(), tester.TesterGender);
            testerElement.Element("testerPhone").Value = Convert.ToString(tester.TesterPhone);
            testerElement.Element("address").Element("testerCity").Value = tester.TesterCity;
            testerElement.Element("address").Element("testerStreet").Value = tester.TesterStreet;
            testerElement.Element("address").Element("testerNumBuilding").Value = tester.TesterNumBuilding.ToString();
            testerElement.Element("testerExperience").Value = tester.TesterExperience.ToString();
            testerElement.Element("testerMaxTests").Value = tester.TesterMaxTests.ToString();
            testerElement.Element("testerCar").Value = Enum.GetName(tester.TesterCar.GetType(), tester.TesterCar);
            {
                testerElement.Element("testerAvailability").Element("sunday9").Value = tester.TesterAvailability[0, 0].ToString();//ScheduleArr
                testerElement.Element("testerAvailability").Element("sunday10").Value = tester.TesterAvailability[0, 1].ToString();
                testerElement.Element("testerAvailability").Element("sunday11").Value = tester.TesterAvailability[0, 2].ToString();
                testerElement.Element("testerAvailability").Element("sunday12").Value = tester.TesterAvailability[0, 3].ToString();
                testerElement.Element("testerAvailability").Element("sunday13").Value = tester.TesterAvailability[0, 4].ToString();
                testerElement.Element("testerAvailability").Element("sunday14").Value = tester.TesterAvailability[0, 5].ToString();
                testerElement.Element("testerAvailability").Element("monday9").Value = tester.TesterAvailability[1, 0].ToString();
                testerElement.Element("testerAvailability").Element("monday10").Value = tester.TesterAvailability[1, 1].ToString();
                testerElement.Element("testerAvailability").Element("monday11").Value = tester.TesterAvailability[1, 2].ToString();
                testerElement.Element("testerAvailability").Element("monday12").Value = tester.TesterAvailability[1, 3].ToString();
                testerElement.Element("testerAvailability").Element("monday13").Value = tester.TesterAvailability[1, 4].ToString();
                testerElement.Element("testerAvailability").Element("monday14").Value = tester.TesterAvailability[1, 5].ToString();
                testerElement.Element("testerAvailability").Element("tuesday9").Value = tester.TesterAvailability[2, 0].ToString();
                testerElement.Element("testerAvailability").Element("tuesday10").Value = tester.TesterAvailability[2, 1].ToString();
                testerElement.Element("testerAvailability").Element("tuesday11").Value = tester.TesterAvailability[2, 2].ToString();
                testerElement.Element("testerAvailability").Element("tuesday12").Value = tester.TesterAvailability[2, 3].ToString();
                testerElement.Element("testerAvailability").Element("tuesday13").Value = tester.TesterAvailability[2, 4].ToString();
                testerElement.Element("testerAvailability").Element("tuesday14").Value = tester.TesterAvailability[2, 5].ToString();
                testerElement.Element("testerAvailability").Element("wedensday9").Value = tester.TesterAvailability[3, 0].ToString();
                testerElement.Element("testerAvailability").Element("wedensday10").Value = tester.TesterAvailability[3, 1].ToString();
                testerElement.Element("testerAvailability").Element("wedensday11").Value = tester.TesterAvailability[3, 2].ToString();
                testerElement.Element("testerAvailability").Element("wedensday12").Value = tester.TesterAvailability[3, 3].ToString();
                testerElement.Element("testerAvailability").Element("wedenesday13").Value = tester.TesterAvailability[3, 4].ToString();
                testerElement.Element("testerAvailability").Element("wedensday14").Value = tester.TesterAvailability[3, 5].ToString();
                testerElement.Element("testerAvailability").Element("thursday9").Value = tester.TesterAvailability[4, 0].ToString();
                testerElement.Element("testerAvailability").Element("thursday10").Value = tester.TesterAvailability[4, 1].ToString();
                testerElement.Element("testerAvailability").Element("thursday11").Value = tester.TesterAvailability[4, 2].ToString();
                testerElement.Element("testerAvailability").Element("thursday12").Value = tester.TesterAvailability[4, 3].ToString();
                testerElement.Element("testerAvailability").Element("thursday13").Value = tester.TesterAvailability[4, 4].ToString();
                testerElement.Element("testerAvailability").Element("thursday14").Value = tester.TesterAvailability[4, 5].ToString();
            }
            testerElement.Element("testerMaxDistance").Value = tester.TesterMaxDistance.ToString();
            testerElement.Element("testerGearBox").Value = Enum.GetName(tester.TesterGearBox.GetType(), tester.TesterGearBox);

            testerRoot.Save(testerPath);
        }
        public void UpdateInfoTrainee(Trainee trainee)
        {
            XElement traineeElement = (from p in traineeRoot.Elements()
                                       where Convert.ToInt32(p.Element("TraineeId").Value) == trainee.TraineeId
                                       select p).FirstOrDefault();
            traineeElement.Element("Name").Element("TraineeFirstName").Value = trainee.TraineeFirstName;
            traineeElement.Element("Name").Element("TraineeLastName").Value = trainee.TraineeLastName;
            traineeElement.Element("TraineeBirthDate").Value = trainee.TraineeBirthDate.ToShortDateString();
            traineeElement.Element("TraineeGender").Value = Enum.GetName(trainee.TraineeGender.GetType(), trainee.TraineeGender);
            traineeElement.Element("TraineePhone").Value =Convert.ToString( trainee.TraineePhone);
            traineeElement.Element("Address").Element("cityTrainee").Value = trainee.cityTrainee;
            traineeElement.Element("Address").Element("streetTrainee").Value = trainee.streetTrainee;
            traineeElement.Element("Address").Element("numBuildingTrainee").Value = trainee.numBuildingTrainee.ToString();
            traineeElement.Element("TraineeCar").Value = Enum.GetName(trainee.TraineeCar.GetType(), trainee.TraineeCar);
            traineeElement.Element("TraineeGearBox").Value = Enum.GetName(trainee.TraineeGearBox.GetType(), trainee.TraineeGearBox);
            traineeElement.Element("TraineeSchool").Value = Enum.GetName(trainee.TraineeSchool.GetType(), trainee.TraineeSchool);
            traineeElement.Element("TraineeTesterName").Value = trainee.TraineeTesterName;
            traineeElement.Element("TraineeNumLessons").Value = trainee.TraineeNumLessons.ToString();
            traineeElement.Element("TraineeNumTests").Value = trainee.TraineeNumTests.ToString();
            traineeRoot.Save(traineePath);
        }

        public void UpdateTest(Test test)
        {
            XElement testElement = (from p in testRoot.Elements()
                                    where Convert.ToInt32(p.Element("NumOfTest").Value) == test.NumOfTest
                                    select p).FirstOrDefault();
            testElement.Element("TesterIdTest").Value = test.TesterIdTest.ToString();
            testElement.Element("TraineeIdTest").Value = test.TraineeIdTest.ToString();
            testElement.Element("TestEstimatedDate").Value = test.TestEstimatedDate.ToShortDateString();
            testElement.Element("hourOfTest").Value = test.hourOfTest.ToString();
            testElement.Element("Address").Element("TestCity").Value = test.TestCity;
            testElement.Element("Address").Element("TestStreet").Value = test.TestStreet;
            testElement.Element("Address").Element("TestNumBuilding").Value = test.TestNumBuilding.ToString();
            testElement.Element("testCar").Value = Enum.GetName(test.testCar.GetType(), test.testCar);
            testElement.Element("TestCarGearBox").Value = Enum.GetName(test.testCarGearBox.GetType(), test.testCarGearBox);
            testElement.Element("TestResult").Value = Enum.GetName(test.TestResult.GetType(), test.TestResult);
            testElement.Element("KeepDistance").Value = Enum.GetName(test.keepDistance.GetType(), test.keepDistance);
            testElement.Element("mirrorLooking").Value = Enum.GetName(test.mirrorLooking.GetType(), test.mirrorLooking);
            testElement.Element("stopSign").Value = Enum.GetName(test.stopSign.GetType(), test.stopSign);
            testElement.Element("wearSeatBelt").Value = Enum.GetName(test.wearSeatBelt.GetType(), test.wearSeatBelt);
            testElement.Element("lights").Value = Enum.GetName(test.lights.GetType(), test.lights);
            testElement.Element("reverseParking").Value = Enum.GetName(test.reverseParking.GetType(), test.reverseParking);
            testElement.Element("parallelParking").Value = Enum.GetName(test.parallelParking.GetType(), test.parallelParking);
            testElement.Element("signaling").Value = Enum.GetName(test.signaling.GetType(), test.signaling);
            testElement.Element("giveRightOfWay").Value = Enum.GetName(test.giveRightOfWay.GetType(), test.giveRightOfWay);
            testElement.Element("Comments").Value = test.Comments;
            testRoot.Save(testPath);
        }


        //public IEnumerable<Test> GetAllTestsByTester(Tester tester)
        //{
        //    return getTestsList().FindAll(x => x.IdOfTester == tester.ID);
        //}
        //public IEnumerable<Test> GetAllTestsOfTrainee(Trainee trainee)
        //{
        //    return getTestsList().FindAll(x => x.IdOfTester == trainee.ID);//
        //}

    }
}
