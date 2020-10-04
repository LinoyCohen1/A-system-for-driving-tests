using BE;
using DS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    
    public class Dal_imp :IDAL
    {
        static int numberOfTests = 0;

        #region Tester Functions
        //הוספת טסטר
        public void AddTester(Tester tester)
        {
            try
            {
                foreach (Tester t in DataSource.listOfTesters)
                {
                    if (t.TesterId == tester.TesterId)

                        throw new Exception("The ID number already exists in the system, can not be added");

                }
                DataSource.listOfTesters.Add(tester);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
           
        }
        //מחיקת טסטר
        public void DeleteTester(int testerId)
        {
            if (GetListOfTesters().Where(x => x.TesterId == testerId)!=null)
            {
                var lst = GetListOfTests().Where(x => x.TesterIdTest ==testerId);

                foreach (var item in lst)
                {
                    DataSource.listOfTests.Remove(item);
                }
               var t = GetListOfTesters().Find(x => x.TesterId == testerId); 
                DataSource.listOfTesters.Remove((Tester)t);

            }
            else throw new Exception("Tester with the same id not found...");

        }
        //עדכון פרטי טסטר
        public void UpdateInfoTester( Tester tester)
        {
            int index = DataSource.listOfTesters.FindIndex(t => t.TesterId == tester.TesterId);
            if (index == -1)
                throw new Exception("Tester with the same id not found...");
            DataSource.listOfTesters[index] = tester;
        }
        #endregion

        #region Trainee Functions
        //הוספת תלמיד
        public void AddTrainee(Trainee trainee)
        {

            foreach (Trainee tr in DataSource.listOfTrainees)
            {
                if (tr.TraineeId == trainee.TraineeId)

                    throw new Exception("The ID number already exists in the system, can not be added");

            }

             DataSource.listOfTrainees.Add(trainee);
        }
        //מחיקת תלמיד
        public void DeleteTrainee(int TraineeId)
        {
            if (GetListOfTrainees().Where(x => x.TraineeId == TraineeId)!=null)
            {
                var lst = GetListOfTrainees().Find(x => x.TraineeId == TraineeId);
                
                    DataSource.listOfTrainees.Remove(lst);
                var lst1 = GetListOfTests().Find(x => x.TraineeIdTest == TraineeId);

                DataSource.listOfTests.Remove(lst1);
                //var t = GetListOfTrainees().Where(x => x.TraineeId == TraineeId);
                //DataSource.listOfTrainees.Remove((Trainee)t);

            }
           
           else throw new Exception("Trainee with the same id not found...");

        }
        //עדכון פרטי תלמיד
        public void UpdateInfoTrainee(Trainee trainee)
        { 
            int index = DataSource.listOfTrainees.FindIndex(tr => tr.TraineeId == trainee.TraineeId);
            if (index == -1)
                throw new Exception("Trainee with the same id not found...");
            DataSource.listOfTrainees[index] = trainee;
        }

        #endregion

        #region Test Functions
        //הוספת טסט
        public void AddTest(Test test)
        {
          //  numberOfTests++;
            //test.IdTest= numberOfTests;
            DataSource.listOfTests.Add(test);
        }
        //מחיקת טסט
        public void deleteTest(Test t)
        {
            if (t is Test && GetListOfTests().Any(x => x.NumOfTest == ((Test)t).NumOfTest))
            {
                DataSource.listOfTests.Remove(GetListOfTests().Find(x => x.NumOfTest == ((Test)t).NumOfTest));
            }
            else throw new Exception("The operation was not accomplished. No such test");
        }
        //עדכון טסט
        public void UpdateTest(Test test)
        {
            int index = DataSource.listOfTests.FindIndex(te => (te.TesterIdTest == test.TesterIdTest));
            if (index == -1)
                throw new Exception("Tester with the same id not found...");

            int index1 = DataSource.listOfTests.FindIndex(te => (te.TraineeIdTest == test.TraineeIdTest));
            if (index1 == -1)
                throw new Exception("Trainee with the same id not found...");


            DataSource.listOfTests[index] = test;
        }

        #endregion

        #region GetLists
        public List<BE.Tester> GetListOfTesters(Predicate<BE.Tester> predicate = null)
        {
            return DS.DataSource.listOfTesters;
        }
        public List<Trainee> GetListOfTrainees()
        {
            return DS.DataSource.listOfTrainees;
        }
        public List<Test> GetListOfTests()
        {
            return DS.DataSource.listOfTests;
        }

        #endregion GetLists

    }
}
