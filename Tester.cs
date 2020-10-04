//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Xml.Serialization;
//using static BE.Enums;

////לשאול על גיל הבוחן איך אפשר לחשב
//namespace BE
//{
    
//   public class Tester 
//    {
        
//        //תז בוחן
//        public int TesterId { get; set; }

//        //שם פרטי בוחן
//        public string TesterFirstName { get; set; }

//        //שם משפחה בוחן
//        public string TesterLastName { get; set; }

//        //תאריך לידה בוחן
//        public DateTime TesterBirthDate { get; set; }
//        //מין בוחן 
//        public Gender TesterGender { get; set; }

//        //טלפון בוחן
//        public int TesterPhone { get; set; }

//        //כתובת בוחן
//        public string TesterStreet { get; set; }
//        public int TesterNumBuilding { get; set; }
//        public string TesterCity { get; set; }

//        //מס שנות ניסיון בוחן 
//        public int TesterExperience { get; set; }

//        //מס מבחנים מקסימלי בשבוע 
//        public int TesterMaxTests { get; set; }

//        //סוג רכב בוחן
//        public Vehicle TesterCar { get; set; }

//        //סוג נתמחות בוחן 
//        public gearBox TesterGearBox { get; set; }
        

//        //מרחק מקסימלי מהכתובת 
//        public double TesterMaxDistance {get; set; }

      
//        //זמינות בוחן
//        public bool[,] TesterAvailability { get; set; } = new bool[5, 6];

//        //העמסה של tostring
//        public override string ToString()
//        {
//            // return "Tester`s first name: " + TesterFirstName +" \nTester`s last name: " + TesterLastName+ " \nTester`s id: " + TesterId;
//            return this.toStringProperty();
//        }


//    }

//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace BE
{
    public class Tester
    {
        int testerId;
        string testerLastName;
        string testerFirstName;
        DateTime testerBirthDate;
        string testerStreet;
        int testerNumBuilding;
        string testerCity;
        Enums.Gender testerGender;
        string testerPhone;
        int testerExperience;
        int testerMaxTests;
        Enums.Vehicle testerCar;
        double testerMaxDistance;
        Enums.gearBox testerGearBox;
        bool[,] testerAvailability = new bool[5, 6];

        //  public Tester(int my_id, string my_firstName, string my_lastName, Enums.Gender my_testerGender, string my_phone, string my_street, int my_buildingNum, string my_city,
        // DateTime my_testerBirth, Enums.Vehicle my_kindOfVehicle, Enums.gearBox my_testerGearbox,
        //int my_experience, int my_maxTests, double my_maxDis)
        //{

        //    TesterId = my_id;
        //    TesterFirstName = my_firstName;
        //    TesterLastName = my_lastName;
        //    TesterGender = my_testerGender;
        //    TesterPhone = my_phone;
        //    TesterStreet = my_street;
        //    TesterExperience = my_experience;
        //    TesterMaxTests = my_maxTests;
        //    TesterNumBuilding = my_buildingNum;
        //    TesterCity = my_city;
        //    TesterBirthDate = my_testerBirth;
        //    TesterCar = my_kindOfVehicle;
        //    TesterGearBox = my_testerGearbox;
        //    TesterMaxDistance = my_maxDis;

        //}
    // public Tester() { TesterPhone = "05"; }
    //public Tester(Tester other)
    //{
    //    foreach (PropertyInfo property in other.GetType().GetRuntimeProperties())
    //        property.SetValue(this, property.GetValue(other));
    //}

    public Enums.gearBox TesterGearBox
        {
            get { return testerGearBox; }
            set { testerGearBox = value; }
        }
        public int TesterId
        {
            get { return testerId; }
            set { testerId = value; }
        }
        public string TesterLastName
        {
            get { return testerLastName; }
            set { testerLastName = value; }
        }
        public string TesterFirstName
        {
            get { return testerFirstName; }
            set { testerFirstName = value; }
        }
        public DateTime TesterBirthDate
        {
            get { return testerBirthDate; }
            set { testerBirthDate = value; }
        }
        public Enums.Gender TesterGender
        {
            get { return testerGender; }
            set { testerGender = value; }
        }
        public Enums.Vehicle TesterCar
        {
            get { return testerCar; }
            set { testerCar = value; }
        }
        public string TesterStreet
        {
            get { return testerStreet; }
            set { testerStreet = value; }
        }
        public int TesterNumBuilding
        {
            get { return testerNumBuilding; }
            set { testerNumBuilding = value; }
        }
        public string TesterCity
        {
            get { return testerCity; }
            set { testerCity = value; }
        }

        public string TesterPhone
        {
            get { return testerPhone; }
            set { testerPhone = value; }
        }
        public int TesterExperience
        {
            get { return testerExperience; }
            set { testerExperience = value; }
        }
        public int TesterMaxTests
        {
            get { return testerMaxTests; }
            set { testerMaxTests = value; }
        }
        ////
        public double TesterMaxDistance
        {
            get { return testerMaxDistance; }
            set { testerMaxDistance = value; }

        }

        public bool[,] TesterAvailability
        {
            get { return testerAvailability; }
            set
            {
                testerAvailability = value;


            }

        }
        public override string ToString()
        {
            return ("Tester details:" + '\n' + "Id: " + testerId + '\n' + "First Name: " + testerFirstName +
                '\n' + "Last Name: " + testerLastName + '\n' + "Tester Birth: " + TesterBirthDate + '\n' +
                "Tester's Street:" + testerStreet + '\n' + "Tester's buildingNum  " + testerNumBuilding +
                '\n' + "City: " + testerCity + '\n' + "Tester's Gender" + testerGender + '\n' + "Tester's Gearbox: " + TesterGearBox + '\n' + "phone number: " + testerPhone + '\n'
                + "max tests in a week: " + testerMaxTests + '\n' + "years of experience: " + testerExperience + '\n' +
                "tester kind of vehicle: " + testerCar + '\n'
                + "maximum distance from trainee: " + testerMaxDistance);


        }

    }
}

