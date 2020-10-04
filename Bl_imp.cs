using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;


namespace BL
{
   public class Bl_imp:IBL
    {

     IDAL dal = FactoryDal.getDal;
    
        
        #region Tester Functions
        //הוספת טסטר
        public void AddTester(Tester tester)
        { 
          
            if (!MyFunctions.TesterAge(tester.TesterBirthDate))
                throw new Exception("Tester should be between "+Configuration.minAgeTester+ " to "+Configuration.maxAgeTester);

            //בדיקה שמס ספרות תז הוא 9
            if (MyFunctions.numOfNumbers(tester.TesterId) > 9)
                throw new Exception("Your id is invalid");
            else

                dal.AddTester(tester);
        }

        //מחיקת טסטר
        public void DeleteTester(int testerId)
        {
            dal.DeleteTester(testerId);
        }

        //עדכון פרטי טסטר
        public void UpdateInfoTester(Tester tester)
        {
            dal.UpdateInfoTester(tester);
        }

        #endregion

        #region Trainee Functions
        //הוספת תלמיד
        public void AddTrainee(Trainee trainee)
        {

            if (!MyFunctions.TraineeAge(trainee.TraineeBirthDate))
                throw new Exception("Trainee should be between " + Configuration.minAgeTrainee + " to " + Configuration.maxAgeTrainee);

            //בדיקה שמס ספרות תז הוא 9
            if (MyFunctions.numOfNumbers(trainee.TraineeId) > 9)
                throw new Exception("Your id is invalid");

            else
                dal.AddTrainee(trainee);
        }
        //מחיקת תלמיד
        public void DeleteTrainee(int traineeId)
        {
            dal.DeleteTrainee(traineeId);
        }
        //עדכון פרטי תלמיד
        public void UpdateInfoTrainee(Trainee trainee)
        {
            dal.UpdateInfoTrainee(trainee);
        }
        #endregion

        #region Test Functions
        //הוספת מבחן
        public void AddTest(Test test)
        {
            test.TestResult = BE.Enums.Result.failed;
            test.mirrorLooking = BE.Enums.Result.failed;
            test.parallelParking = BE.Enums.Result.failed;
            test.reverseParking = BE.Enums.Result.failed;
            test.signaling = BE.Enums.Result.failed;

            if (!GetListOfTesters().Exists(x => x.TesterId == test.TesterIdTest) || !GetListOfTrainees().Exists(x => x.TraineeId == test.TraineeIdTest))
            {
                throw new Exception("We don't have in our system this trainee's ID or tester's ID");
            }
            int day = (int)test.TestEstimatedDate.DayOfWeek;
            if (day > 5)
            {
                throw new Exception("wrong day");//בדיקה שהיום בשבוע נכון
            }
            if (test.hourOfTest < 9 || test.hourOfTest > 15)
            {
                throw new Exception("wrong hour");//בדיקה שהשעה נכונה
            }
            Tester testerOfTheTest = GetListOfTesters().Find(x => x.TesterId == test.TesterIdTest);//ברשימת הטסטרים הוא מצא את הטסטר עם אותו תז
            if (testerOfTheTest.TesterMaxTests == sumOfTestsInWeek(test.TestEstimatedDate, testerOfTheTest.TesterId))//בדיקה שהטסטר לא עבר את כמות המבחנים השבועית
            {
                DateTime temp = test.TestEstimatedDate.AddDays(7);
                throw new Exception("The tester passed the number of weekly tests. you can try this date:" + temp.ToString());

            }
            if (testerOfTheTest.TesterAvailability
                [day, (test.hourOfTest - 9)] == false)//בדיקה שהטסטר עובד באותו יום ובאותה שעה
            {

                throw new Exception("this tester doesn't work in this hour in this day ");
            }

            if (GetListOfTests().Find(x => x.TesterIdTest == testerOfTheTest.TesterId && x.TestEstimatedDate.Date == test.TestEstimatedDate.Date && x.hourOfTest == test.hourOfTest) != null)//בדיקה שלטסטר אין מבחן אחר
            {
                DateTime date = MyFunctions.alternativeDate(test.TestEstimatedDate, test.hourOfTest);
                throw new Exception("this tester already has a test in this hour in this day. you can change to: " + date.ToString());
            }
            Trainee traineeOfTheTest = GetListOfTrainees().Find(x => x.TraineeId == test.TraineeIdTest);
            if (GetListOfTests().Find(x => x.TraineeIdTest == traineeOfTheTest.TraineeId && x.TestEstimatedDate.Date == test.TestEstimatedDate.Date && x.hourOfTest == test.hourOfTest) != null)//בדיקה שלנבחן איו מבחן אחר
            {
                throw new Exception("this trainee already has a test in this hour in this day");
            }
            if (!GetListOfTrainees().Exists(x => x.TraineeId == ((BE.Test)test).TraineeIdTest))//בדיקה על התז
                throw new Exception("The trainee's ID doesn't exist");
            if (!GetListOfTesters().Exists(x => x.TesterId == ((BE.Test)test).TesterIdTest))
                throw new Exception("The tester's ID doesn't exist");
            var tempTrainee = GetListOfTrainees().Find(x => x.TraineeId == ((BE.Test)test).TraineeIdTest);
            var tempTester = GetListOfTesters().Find(x => x.TesterId == ((BE.Test)test).TesterIdTest);
            int numOfDays = (test.TestEstimatedDate.Day) - tempTrainee.DateLastTest.Day;//די אוף וויק או די
            //if (tempTester.TesterGearBox != tempTrainee.TraineeGearBox)//הבוחן והנבחן על אותה תיבת הילוכים
            //    throw new Exception("The  tester's gearbox and the  trainee's gearbox are differents");
            //if (tempTester.TesterGearBox != test.testCarGearBox)//הבוחן והנבחן על אותה תיבת הילוכים
            //    throw new Exception("The  tester's  and the  trainee's gearbox and the test gearbox you chose are differents");
            //if (tempTester.TesterCar != test.testCar)//הבוחן והנבחן על אותה תיבת הילוכים
            //    throw new Exception("The  tester's  and the  trainee's kind of vehicle and the test kind of vehicle you chose are differents");
            //if (tempTester.TesterGearBox == tempTrainee.TraineeGearBox)//המבחן על אותה תיבת הילוכים
            //    test.testCarGearBox = tempTester.TesterGearBox;
            //if (tempTester.TesterCar != tempTrainee.TraineeCar)//הבוחן והנבחן על אותו סוג רכב
            //    throw new Exception("The  tester's Kind Of Vehicle and the  trainee's Kind Of Vehicle are differents");
            
               //if (!MyFunctions.CheckWeek(GetListOfTests().FindLast(t => test.TraineeIdTest == t.TraineeIdTest).TestEstimatedDate))//ולא עבר שבוע מיום הטסט האחרון 
            //    throw new Exception("Can't add a test, not a week went by ");
            if ((tempTrainee.TraineeNumTests) >= 1 && numOfDays > BE.Configuration.range)//כאשר יש לנבחן יותר ממבחן אחד בדיקה שעבר מספיק זמן
            {
                var tempTest = GetListOfTests().Find(x => x.TraineeIdTest == tempTrainee.TraineeId);
                if (tempTest.testCarGearBox == tempTrainee.TraineeGearBox && tempTest.TestResult == BE.Enums.Result.passed && tempTest.testCar == tempTrainee.TraineeCar)//בדיקה שלא עשה כבר את הבמחן הזה
                    throw new Exception("You already did this test on this vehicle  and passed the test! dont try again!!!");
                else
                {
                    dal.AddTest(test);
                    (GetListOfTrainees().Find(x => x.TraineeId == ((Test)test).TraineeIdTest)).TraineeNumTests++;

                }
            }
            else if (tempTrainee.TraineeNumTests >= 1 && numOfDays < BE.Configuration.range)
            {
                throw new Exception("the range between your tests is too small and needs to be at least over" + BE.Configuration.range.ToString() + " days ");
            }
            else if (tempTrainee.TraineeNumTests == 0 && tempTrainee.TraineeNumLessons >= BE.Configuration.minLessons)//במידה וזה המבחן הראשון בדיקה שעשה מספיק שיעורים
            {
                dal.AddTest(test);
                (GetListOfTrainees().Find(x => x.TraineeId == ((Test)test).TraineeIdTest)).TraineeNumTests++;
            }
               else throw new Exception("you need  at least " +" " + Configuration.minLessons.ToString() + " lessons");
          


            //try
            //{


            //var indexTester = GetListOfTesters().First(t => test.TesterIdTest == t.TesterId);
            //var indexOfLastTest = GetListOfTests().Last(t => test.TraineeIdTest == t.TraineeIdTest);//מחזיר לי את האנדקס של הטסט האחרון שהתלמיד עשה
            //var indexTest = GetListOfTests().First(t => test.TraineeIdTest == t.TraineeIdTest);
            //var indexTrainee = GetListOfTrainees().First(t => test.TraineeIdTest == t.TraineeId);

            //        //בדיקה שתאריך הטסט הוא בימים ראשון עד חמישי
            //        if ((int)test.TestEstimatedDate.DayOfWeek > 5)
            //            throw new Exception("You can add a test between Sunday till Thursday");
            //        if (indexTester.TesterAvailability[test.TestEstimatedDate.Day, (test.hourOfTest - 9)] == false)//בדיקה שהטסטר עובד באותו יום ובאותה שעה
            //        {

            //            throw new Exception("this tester doesn't work in this hour in this day ");
            //        }
            //        //בדיקה שהטסט מתקיים בין השעות 9 ל 15 
            //        if (test.hourOfTest < 9 || test.hourOfTest > 15)
            //            throw new Exception("You can add a test between 9:00 till 15:00");

            //        //בדיקה שמס ספרות תז הוא 9
            //        if (MyFunctions.numOfNumbers(test.TraineeIdTest) != 9)
            //            throw new Exception("Your id is invalid");

            //        if (MyFunctions.numOfNumbers(test.TesterIdTest) != 9)
            //            throw new Exception("Your id is invalid");


            //        //בדיקה שהתלמיד עבר 20 שיערים 

            //        if (indexOfLastTest == null)//כלומר לא היה לו מבחן בעבר
            //        {
            //            if (indexTrainee.TraineeNumLessons < Configuration.minLessons)
            //                throw new Exception("Can't add a test, the lessons`s number smaller than " + Configuration.minLessons + " lessons. ");
            //        }

            //        //בדיקה שעבר שבוע מהטסט הקודם אם היה


            //        if (indexOfLastTest != null &&  // היה לו מבחן 
            //            indexOfLastTest.TestResult == Enums.Result.failed && //וגם נכשל בו 
            //            indexOfLastTest.testCar == indexTrainee.TraineeCar &&  //אותה התמחות 
            //           indexOfLastTest.testCarGearBox == indexTrainee.TraineeGearBox)
            //        {
            //            if (!MyFunctions.CheckWeek(indexOfLastTest.TestActualDate))//ולא עבר שבוע מיום הטסט האחרון 
            //                throw new Exception("Can't add a test, not a week went by ");
            //        }


            //        //בדיקה שהוא לא עבר כבר את הטסט על אותו סוג רכב 

            //        if (indexTest.TestResult == Enums.Result.passed &&
            //            indexTest.testCarGearBox == indexTrainee.TraineeGearBox &&
            //            indexTest.testCar == indexTrainee.TraineeCar)

            //            throw new Exception("You already passed the same test in same gearbox and kind of car ");

            //        //בדיקה שההתמחות של הבוחן והנבחן אותו דבר
            //        if (indexTrainee.TraineeCar != indexTester.TesterCar)
            //            throw new Exception("There is no match btween Tester`s car to Trainee`s car");

            //        //בדיקה שכל הנתונים קיימים



            //        // בדיקה שלא עבר את מספר השיעורים המקסימלי בשבוע
            //        if (indexTester.TesterMaxTests == sumOfTestsInWeek(test.TestEstimatedDate, indexTester.TesterId))
            //            throw new Exception("The tester passed the number of weekly tests");

            //        //בדיקה אם הטסטר עובד באותו יום בכלל
            //        if (indexTester.TesterAvailability[(int)test.TestEstimatedDate.DayOfWeek, test.TestEstimatedDate.Hour] == false)
            //            throw new Exception("The tester does not work at this hour in the day");

            //        // בדיקה שלטסטר אין מבחן אחר באותו יום
            //        if (GetListOfTests().All(x => x.TesterIdTest == indexTester.TesterId && x.TestEstimatedDate == test.TestEstimatedDate && x.TestEstimatedDate.Hour == test.TestEstimatedDate.Hour) != false)
            //            throw new Exception("The tester already has a test in that day and hour");

            //        //בדיקה שלנבחן אין מבחן אחר באותו יום
            //        if (GetListOfTests().All(x => x.TraineeIdTest == indexTrainee.TraineeId && x.TestEstimatedDate == test.TestEstimatedDate && x.TestEstimatedDate.Hour == test.TestEstimatedDate.Hour) != false)
            //            throw new Exception("The trainee already has a test in that day and hour");

            //    }
            //    catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}

            //dal.AddTest(test);
        }

        //עדכון פרטי מבחן 
        public void UpdateTest(Test test)
        {

            dal.UpdateTest(test);

        }
        public void deleteTest(BE.Test t)
        {
            dal.deleteTest(t);


        }
        public object FindObjectById(int num)//return the object(trianee/ tester/ test) according to id/code of test
        {


            BE.Tester tester = GetListOfTesters().Find(x => x.TesterId == num);
            if (tester != null)
                return tester;
            BE.Trainee trainee = GetListOfTrainees().Find(x => x.TraineeId == num);
            if (trainee != null)
                return trainee;
            BE.Test test = GetListOfTests().Find(x => x.NumOfTest == num);
            if (test != null)
                return test;


            else

                throw new Exception("No such Id in our database.");


        }
        #endregion

        #region GetLists
        public List<Tester> GetListOfTesters()
        {
            return dal.GetListOfTesters();
        }
        public List<Trainee> GetListOfTrainees()
        {
            return dal.GetListOfTrainees();
        }
        public List<Test> GetListOfTests()
        {
            return dal.GetListOfTests();
        }

        #endregion GetLists

        #region Groupings
        //פונקציה שמחשבת את מס המבחנים השבועי
        public int sumOfTestsInWeek(DateTime date, int testerId)
        {
            int sum = 0;
            DateTime tmp = date;
            int dayOfWeek = (int)date.DayOfWeek;
            for (int i = 0; i <= dayOfWeek; i++)
            {
                tmp.AddDays(-i);
                sum += GetListOfTests().Count(x => x.TesterIdTest == testerId && x.TestEstimatedDate == tmp);
                tmp = date;
            }
            for (int i = 1; i <= 4-dayOfWeek; i++)
            {
                tmp.AddDays(i);
                sum+=GetListOfTests().Count(x => x.TesterIdTest == testerId && x.TestEstimatedDate == tmp);
                tmp = date;
            }
            return sum;
        }

        //פונ שממקבצת לפי סוג התמחות
        public IEnumerable<IGrouping<Enums.Vehicle, Tester>> groupByExperience(bool sort = false)
        {
            IEnumerable<IGrouping<Enums.Vehicle, Tester>> experienceGroup = from t in GetListOfTesters()
                                                                   group t by t.TesterCar;


            if (sort == true)
            {
                foreach (IGrouping<Enums.Vehicle, Tester> g in experienceGroup)
                {
                    g.OrderBy(t => t.TesterGearBox);
                }

            }
            return experienceGroup;
        }

        //פונ שמקבצת לפי בית ספר
        public IEnumerable<IGrouping<Enums.Schools, Trainee>> groupBySchool(bool sort = false)
        {
            var schoolGroup = from tra in GetListOfTrainees()
                                                                            group tra by tra.TraineeSchool;


            if (sort == true)
            {
                foreach (IGrouping<Enums.Schools, Trainee> g in schoolGroup)
                {
                    g.OrderBy(t=>t);//ממין לפי שמות פרטיים
                }

            }
            return schoolGroup;
        }


        //פונ שמקבצת לפי מורה נהיגה
        public IEnumerable<IGrouping<string, Trainee>> groupByTeacher(bool sort = false)
        {
            IEnumerable<IGrouping<string, Trainee>> teacherGroup = from tr in GetListOfTrainees()
                                                                         group tr by tr.TraineeTesterName;


            if (sort == true)
            {
                foreach (IGrouping< string, Trainee > g in teacherGroup)
                {
                    g.OrderBy(t => t);//ממין לפי שמות פרטיים
                }

            }
            return teacherGroup;
        }



        //פונ שמחזירה את מס המבחנים שתלמיד נבחן בהם 
        public int numOfTests(Trainee tr)
        {
            int numTests = 0;
            foreach (var item in dal.GetListOfTests())
            {
                if (item.TraineeIdTest == tr.TraineeId)
                    numTests++;
            
            }
            return numTests;
        }

        //פונ שמקבצת לפי מספר הטסטים
        public IEnumerable<IGrouping<int, Trainee>> groupByNumOfTests(bool sort = false)
        {
            IEnumerable<IGrouping<int, Trainee>> numTestsGroup = from tr in GetListOfTrainees()
                                                                group tr by numOfTests(tr);


            if (sort == true)
            {
                foreach (IGrouping<int, Trainee> g in numTestsGroup)
                {
                    g.OrderBy(t => t);//ממין לפי שמות פרטיים
                }

            }
            return numTestsGroup;
        }
        #endregion 

    }
}
