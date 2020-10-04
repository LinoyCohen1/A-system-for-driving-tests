using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;


namespace BL
{
    public interface IBL
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
        object FindObjectById(int num);
        List<Tester> GetListOfTesters();
        List<Trainee> GetListOfTrainees();
        List<Test> GetListOfTests();


         int sumOfTestsInWeek(DateTime date, int testerId);

        IEnumerable<IGrouping<Enums.Vehicle, Tester>> groupByExperience(bool sort = false);

        IEnumerable<IGrouping<Enums.Schools, Trainee>> groupBySchool(bool sort = false);

        IEnumerable<IGrouping<string, Trainee>> groupByTeacher(bool sort = false);

        int numOfTests(Trainee tr);

        IEnumerable<IGrouping<int, Trainee>> groupByNumOfTests(bool sort = false);


    }
}
