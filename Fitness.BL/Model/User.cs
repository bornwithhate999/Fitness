using System;

namespace Fitness.BL.Model
{
    [Serializable]
    public class User
    {
        #region свойства
        public string Name { get; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        #endregion 

        public User(string name,
                    Gender gender,
                    DateTime birthDate,
                    double weight,
                    double height)
        {
            #region проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null.", nameof(name));
            }
            if (gender == null) {
                throw new ArgumentNullException("Гендер пользователя не может быть null.", nameof(gender));
            }
            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата рождения.", nameof(birthDate));
            }
            if (weight <= 0)
            {
                throw new ArgumentException("Вес не может быть меньше нуля.", nameof(weight));
            }
            if (height <= 0)
            {
                throw new ArgumentException("Рост не может быть меньше нуля.", nameof(height));
            }
            #endregion
            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null.", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return this.Name + " " + Age + " лет.";
        } 
    }    
}

