using System;
using System.Collections.Generic;
using System.Linq;
using Fitness.BL.Model;

namespace Fitness.BL.Controller
{
    public class UserController : ControllerBase
    {
        private const string USERS_FILE_NAME = "users.dat";
        public List<User> Users { get; }
        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;

        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым.", nameof(userName));
            }
            Users = GetUsersData();
            foreach (var user in Users)
            {
                
                Console.WriteLine(user.Name);
            }

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);  
            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        public void SetUserData(string genderName, DateTime bithDate, double weight = 1, double height = 1)
        {
            #region проверка
            if (string.IsNullOrWhiteSpace(genderName))
            {
                throw new ArgumentNullException("Гендер не может быть пустым или null.", nameof(genderName));
            }
            if(bithDate >= DateTime.Now)
            {
                throw new ArgumentException("Дата рождения не может быть больше текущей.", nameof(bithDate));
            }
            if(weight <= 0)
            {
                throw new ArgumentException("Масса тела не может быть меньше либо равно 0.", nameof(weight));
            }
            if(height <= 0)
            {
                throw new ArgumentException("Рост не может быть меньше либо равен 0.", nameof(height));
            }
            #endregion
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = bithDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
        }
        public void Save()
        {
            Save(USERS_FILE_NAME, Users);
        }

        public List<User> GetUsersData()
        {
            return Load<List<User>>(USERS_FILE_NAME) ?? new List<User>();
        }
    }
}
