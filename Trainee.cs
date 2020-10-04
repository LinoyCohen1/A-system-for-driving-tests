using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static BE.Enums;

namespace BE
{
    public class Trainee 
    {
        
        //תז תלמיד
        public int TraineeId { get; set; }

        //שם פרטי תלמיד
        public string TraineeFirstName { get; set; }

        //שם משפחה תלמיד
        public string TraineeLastName { get; set; }

        //תאריך לידה תלמיד
        public DateTime TraineeBirthDate { get; set; }

        //מין תלמיד
        public Gender TraineeGender { get; set; }

        //טלפון תלמיד
        public int TraineePhone { get; set; }

        //כתובת תלמיד
        public string streetTrainee { get; set; }
        public int numBuildingTrainee { get; set; }
        public string cityTrainee { get; set; }

        //סוג רכב תלמיד
        public Vehicle TraineeCar { get; set; }

        //סוג תיבת הילוכים תלמיד
        public gearBox TraineeGearBox { set; get; }

        //שם בייס לנהיגה תלמיד
        public Schools TraineeSchool { get; set; }

        //שם מורה נהיגה
        public string TraineeTesterName { get; set; }

        //מס שיעורי נהיגה
        public int TraineeNumLessons { get; set; }
        DateTime dateLastTest;
        public DateTime DateLastTest////////
        {
            get { return dateLastTest; }
            set { dateLastTest = value; }
        }
        //מספר טסטים שניגש ולא עבר
        public int TraineeNumTests { set; get; }

        public override string ToString()
        {
            return this.toStringProperty();
          //  return "Trainee`s first name: " + TraineeFirstName + "\nTrainee`s last name: " + TraineeLastName + " \nTrainee`s id: " + TraineeId;

        }

       




    }

}
