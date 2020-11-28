using System;
using Fitness.BL.Controller;
using Fitness.BL.Model;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение Fitness.");

            Console.Write("Введите имя пользователя: ");
            var name = Console.ReadLine();

            

            var userController = new UserController(name);
            var eatingController = new EatingContoller(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();

                DateTime birthDate = ParseDatetime("дата рождения");
                double weight = ParseDouble("вес");
                double height = ParseDouble("рост");

                userController.SetUserData(gender, birthDate, weight, height);
            }
            
            while(true)
            {
                Console.Clear();
                Console.WriteLine(userController.CurrentUser);

                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("E - ввести приём пищи.");
                Console.WriteLine("A - ввести упражнение.");
                Console.WriteLine("Q - выйти из программы.");

                var key = Console.ReadKey();
                Console.WriteLine();

                Console.Clear();
                Console.WriteLine(userController.CurrentUser);

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        Console.WriteLine("Приём пищи:");
                        var portion = EnterEating();
                        eatingController.Add(portion.Food, portion.Weight);

                        foreach (var item in eatingController.Eating.Portions)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case ConsoleKey.A:
                        Console.WriteLine("Упражнение:");
                        var exercise = EnterExercise();
                        exerciseController.Add(exercise.Activity, exercise.Start, exercise.End);

                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
            }
           
                
            
        }

        private static (DateTime Start, DateTime End, Activity Activity) EnterExercise()
        {

            var activity = GetActivity();

            var start = ParseDatetime("начало упражнения");

            var end = ParseDatetime("Конец упражнения");

            return (start, end, activity);
        }

        private static Activity GetActivity()
        {
            Console.Write("Введите название активности: ");
            var activityName = Console.ReadLine();

            var calloriesPerMinute = ParseDouble("калорий/минуту");

            return new Activity(activityName, calloriesPerMinute);
        }

        private static (Food Food, double Weight) EnterEating()
        {

            var food = GetFood();

            var weight = ParseDouble("вес порции");

            return (food, weight);
        }

        private static Food GetFood()
        {
            Console.Write("Введите имя продукта: ");
            var foodName = Console.ReadLine();

            var foodCallories = ParseDouble("калории");

            var foodProteins = ParseDouble("белок");

            var foodFats = ParseDouble("жиры"); ;

            var foodCarbohydrates = ParseDouble("угдеводы");

            return new Food(foodName, foodCallories, foodProteins, foodFats, foodCarbohydrates);
        }

        private static DateTime ParseDatetime(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}:");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {name}.");
                }
            }
        }

        private static double ParseDouble(string name) 
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля {name}.");
                }
            }
        }
    }
}
