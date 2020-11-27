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
            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();

                DateTime birthDate = ParseDatetime();
                double weight = ParseDouble("вес");
                double height = ParseDouble("рост");

                userController.SetUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("E - ввести приём пищи.");

            var key = Console.ReadKey();
            if(key.Key == ConsoleKey.E)
            {
                var portion = EnterEating();
                eatingController.Add(portion.Food, portion.Weight);

                foreach(var item in eatingController.Eating.Portions)
                {
                    Console.WriteLine(item);
                }
            }
            Console.ReadLine();
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

        private static DateTime ParseDatetime()
        {
            while (true)
            {
                Console.Write("Введите дату рождения:");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты рождения.");
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
