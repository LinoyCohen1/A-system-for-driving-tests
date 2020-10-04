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
     public class MyFunctions
    {
        static IDAL dal = FactoryDal.getDal;
        static IBL bl = FactoryBl.GetBL();

        //חיפוש אובייקט ברשימות לפי תז
        static public Tester GetTesterByID(int id)
        {
            
            return (dal.GetListOfTesters().FirstOrDefault(x => x.TesterId ==id));
        }

        static public Trainee GetTraineeByID(int id)
        {
            return (dal.GetListOfTrainees().FirstOrDefault(x => x.TraineeId == id));
        }
        static public Test GetTestByID(int idTra, int idTes)
        {
            return (dal.GetListOfTests().FirstOrDefault(x =>( x.TraineeIdTest==idTra && x.TesterIdTest==idTes)));
        }


        //פונ לבדיקת גיל הטסטר
        static public bool TesterAge(DateTime dateBirth)
        {
            DateTime current = DateTime.Now;
            return (dateBirth.AddYears(Configuration.minAgeTester) <= current)&& current <= dateBirth.AddYears(Configuration.maxAgeTester);
        }

        //פונ לבדיקת גיל הנבחן
        static public bool TraineeAge(DateTime dateBirth)
        {
            DateTime current = DateTime.Now;
            return (dateBirth.AddYears(Configuration.minAgeTrainee) <= current&& current<= dateBirth.AddYears(Configuration.maxAgeTrainee));
        }

        //פונ שמחזירה רשימה של כל הטסטרים שהם עם אותה התמחות ואותו גיר הילוכים
        static public List<string> testersCondition(Enums.Vehicle car, Enums.gearBox gearBox)
        {
            List<string> ret = new List<string>();

            foreach (var item in bl.GetListOfTesters())
                if (item.TesterGearBox == gearBox && item.TesterCar == car)
                    ret.Add(item.TesterFirstName+" "+item.TesterLastName);
            return ret;
        }


        //פונ לבדיקה אם עבר שבוע
        static public bool CheckWeek(DateTime dateTest)
        {
            DateTime current = DateTime.Now;
            return (dateTest.AddDays(Configuration.range) <= current);

        }
        //פונקציה שבודקת כמה ספרות יש במספר
        static public int numOfNumbers(int num)
        {
            int counter = 0;
            int num1;
            while (num != 0)
            {
                num1 = num % 10;
                counter++;
                num = num / 10;

            }
            return counter;
        }
       
        //פונ שמקבלת כתובת ומחזירה את כל הבוחנים שגרים במרחק מסים מהכתובת

        public static List<Tester> Distance()
        {
            Random rnd = new Random();
            int distance = rnd.Next(0, 40);//הגרלת מספר בין 0 ל40 קמ
            List<Tester> lst = new List<Tester>();
            foreach (Tester tester in dal.GetListOfTesters())
            {
                if (tester.TesterMaxDistance <= distance)
                    lst.Add(tester);
            }
            return lst;
        }

        //מחזיר את כל הבוחנים הפנויים באותו השעה ובאותו היום
        public static List<Tester> FreeTesters(DateTime dateTime)
        {
            List<Tester> freeTester = (from t in dal.GetListOfTesters()
                                       where (t.TesterAvailability[dateTime.Day, dateTime.Hour] == false)//כלומר הטסטר פנוי 
                                       select t).ToList();

            return freeTester;
        }

        public delegate bool conditionTestDelegate(Test t);
        //פונ שמחזירה את כל המבחנים שעומדים בתנאי מסויים
        public static List<Test> returnTestAccordingCondition(conditionTestDelegate cond)
        {
            List<Test> testCondition = new List<Test>();
            foreach (var item in dal.GetListOfTests())
            {
                if (cond(item) == true)
                    testCondition.Add(item);
            }
            return testCondition;
        }


        //פונ שבודקת אם תלמיד זכאי לרישיון נהיגה
        public static bool IsPassed(Trainee tr)
        {
            var v = dal.GetListOfTests().Last(x => x.TraineeIdTest == tr.TraineeId);
            if (v.TestResult == Enums.Result.passed)
                return true;
            else
                return false;

        }

        //פו מחזירה את כל המבחנים שמתוכננים לפי יום/חודש 
        public static List<Test> tests(DateTime date, string str)
        {
            switch (str)
            {
                case "byDay":
                    {
                        List<Test> testsOfDay = new List<Test>();
                        foreach (var item in dal.GetListOfTests())
                        {
                            if (item.TestEstimatedDate.Day == date.Day && item.TestEstimatedDate.Month == date.Month && item.TestEstimatedDate.Year == date.Year)//אותו יום חודש ושנה
                            {
                                testsOfDay.Add(item);
                            }
                        }
                        return testsOfDay;
                    }

                case "byMonth":
                    {
                        List<Test> testsOfMonth = new List<Test>();
                        foreach (var item in dal.GetListOfTests())
                        {
                            if (item.TestEstimatedDate.Month == date.Month && item.TestEstimatedDate.Year == date.Year)
                            {
                                testsOfMonth.Add(item);
                            }
                        }
                        return testsOfMonth;

                    }
            }

            return null;
        }

        //פונ שמציעה תאריך חילופי אחר 

        static public DateTime alternativeDate(DateTime date, int hour)
        {
            date.AddDays(1);//מוסיפה יום
            while (dal.GetListOfTests().Where(x => x.TestEstimatedDate.DayOfWeek == date.DayOfWeek && x.hourOfTest == hour) != null)//קיים מבחן אחר באותו יום ובאותו שעה כבר
                date.AddDays(1);
            return date;
            
        }

    }
}