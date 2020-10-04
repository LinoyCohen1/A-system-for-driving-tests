using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using DS;
namespace DAL
{
    public interface IDAL
    { 
       
        void AddTester(Tester tester);
        void DeleteTester(int testerId);
        void UpdateInfoTester(Tester tester);
        void AddTrainee(Trainee trainee);
        void DeleteTrainee(int traineeId);
        void UpdateInfoTrainee(Trainee trainee);
        void AddTest(Test test);
        void deleteTest(BE.Test t);
        void UpdateTest(Test test);
        List<BE.Tester> GetListOfTesters(Predicate<BE.Tester> predicate = null);
       // List <Tester> GetListOfTesters();
        List<Trainee> GetListOfTrainees();
        List <Test> GetListOfTests();
    }
}
