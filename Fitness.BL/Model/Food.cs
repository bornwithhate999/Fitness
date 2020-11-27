using System;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Food
    {
        public string Name { get; }
        public double Proteins { get; }
        public double Fats { get; }
        public double Carbohydrates { get; }
        public double Callories { get; }

        public Food(string name) : this(name, 0, 0, 0, 0) {}
        public Food(string name, double callories, double proteins, double fats, double carbohydrates)
        {
            #region проверка аргументов
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или равным null.", nameof(name));
            }
            if(callories < 0)
            {
                throw new ArgumentException("Калории не могут быть меньше 0.", nameof(callories));
            }
            if(proteins < 0)
            {
                throw new ArgumentException("Белки не могут быть меньше 0.", nameof(proteins));
            }
            if(fats < 0)
            {
                throw new ArgumentException("Жиры не могут быть меньше 0.", nameof(fats));
            }
            if (carbohydrates < 0)
            {
                throw new ArgumentException("Углеводы не могут быть меньше 0.", nameof(carbohydrates));
            }
            #endregion

            Name = name;
            Callories = callories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;

        }
    }
}
