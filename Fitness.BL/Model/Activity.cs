using System;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Activity
    {
        public string Name { get; }
        public double CaloriesPerMinute { get; }

        public Activity(string name, double caloriesPerMinute)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Название не может быть пустым или null.", nameof(name));
            }
            if (caloriesPerMinute < 0)
            {
                throw new ArgumentException("Калорий\\минуту не может быть меньше 0.", nameof(caloriesPerMinute));
            }
            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
