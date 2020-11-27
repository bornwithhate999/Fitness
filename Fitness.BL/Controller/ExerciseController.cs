using Fitness.BL.Model;
using System;
using System.Collections.Generic;

namespace Fitness.BL.Controller
{
    public class ExerciseController : ControllerBase
    {
        private const string ACTIVITYS_FILE_NAME = "actyvitys.dat";
        private const string EXERCISES_FILE_NAME = "exercises.dat";

        private readonly User _user;
        
        public List<Exercise> Exercises { get; }

        public ExerciseController(User user)
        {
            // TODO: Проверка аргумента
            _user = user;
        }

        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            // TODO Реализация
        }

        private List<Exercise> GetAllExecises()
        {
            return Load<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
        }

        private void Save()
        {
            Save(EXERCISES_FILE_NAME, Exercises);
        }
    }
}
