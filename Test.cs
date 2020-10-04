using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using static BE.Enums;

namespace BE
{
    public class Test 
    {

        public Test(int idTester, int idTrainee, DateTime testDate, string street, int building, string city,Result keepDistance, string comments,int hour,
         Result _testResult, Result _reverseParking ,Result _parallelParking ,Result _mirrorLooking ,Result _signaling,Result _giveRightOfWay, Result _stopSign ,Result _wearSeatBelt, Result _lights )
        {
            NumOfTest = ++Configuration.TestNum;
            TesterIdTest = idTester;
            TraineeIdTest = idTrainee;
            TestEstimatedDate = testDate;
            TestStreet = street;
            TestNumBuilding = building;
            TestCity = city;
            reverseParking = _reverseParking;
            parallelParking = _parallelParking;
            mirrorLooking = _mirrorLooking;
            signaling = _signaling;
            giveRightOfWay = _giveRightOfWay;
            stopSign = _stopSign;
            wearSeatBelt = _wearSeatBelt;
            lights = _lights;
            TestResult = _testResult;
            Comments = comments;
        }

        public Test()
        {
           NumOfTest = ++Configuration.TestNum;
        }

        public Test(Test other)
        {
            foreach (PropertyInfo property in other.GetType().GetProperties())//GetRuntimeProperties
                property.SetValue(this, property.GetValue(other,null),null);//בלי null
        }
        //קוד טסט 
        //קוד רץ
        public int NumOfTest { get; set; }

        //מס זיהוי בוחן
        public int TesterIdTest { get; set; }

        //מס זיהוי תלמיד
        public int TraineeIdTest { get; set; }

        //שעת הטסט
        public int hourOfTest { get; set; }

        //תאריך משוער הטסט
        public DateTime TestEstimatedDate { get; set; }

        //תאריך טסט בפועל
        //public DateTime TestActualDate { get; set; }

        //כתובת יציאת המבחן
        public string TestStreet { get; set; }
        public int TestNumBuilding { get; set; }
        public string TestCity { get; set; }

        //הקריטריוניום ומידת העמידה בהם
        //   public Critirions TestCriterions { get; set; }

        public Result keepDistance { get; set; }
        public Result reverseParking { get; set; }
        public Result parallelParking { get; set; }
        public Result mirrorLooking { get; set; }
        public Result signaling { get; set; }
        public Result giveRightOfWay { get; set; }
        public Result stopSign { get; set; }
        public Result wearSeatBelt { get; set; }
        public Result lights { get; set; }

        //ציון המבחן
        public Result TestResult { get; set; }

        //סוג הרכב שבמבחן
        public Vehicle testCar { get; set; }
        //סוג ההתמחות של הרכב במבחן
        public gearBox testCarGearBox { get; set; }

        //הערות הבוחן
        public string Comments { set; get; }

        //העמסה של tostring
        public override string ToString()
        {
            return this.toStringProperty();
            //return "Tester id: " + TesterIdTest + "\nTrainee id: " + TraineeIdTest + "\nThe result is: " + TestResult;

        }
        

    }
}

