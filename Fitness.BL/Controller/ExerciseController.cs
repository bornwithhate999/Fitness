using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Controller
{
    public class ExerciseController : ControllerBase
    {
        private const string ACTIVITIES_FILE_NAME = "actyvitys.dat";
        private const string EXERCISES_FILE_NAME = "exercises.dat";

        private readonly User _user;
        
        public List<Exercise> Exercises { get; }

        public List<Activity> Activities { get; }

        public ExerciseController(User user)
        {
            _user = user ?? throw new ArgumentNullException("Пользователь не может быть null.", nameof(user));

            Exercises = GetAllExecises();
            Activities = GetAllActivities();
        }

        public void Add(Activity activity, DateTime start, DateTime finish)
        { 
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name );
            if (act == null)
            {
                Activities.Add(activity);

                try
                {
                    var exercise = new Exercise(start, finish, activity, _user);
                    Exercises.Add(exercise);
                    Save();
                }
                catch (ArithmeticException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                var exercise = new Exercise(start, finish, activity, _user);
                Exercises.Add(exercise);
            }
        }

        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();
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
