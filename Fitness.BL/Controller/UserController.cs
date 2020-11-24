﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Fitness.BL.Model;

namespace Fitness.BL.Controller
{
    public class UserController
    {
        public User User { get; }
        public UserController(string userName, string genderName, DateTime birthDate, double weight, double height)
        {
            var gender = new Gender(genderName);
            var user = new User(userName, gender, birthDate, weight, height);
            User = user;
        }
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if(formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
            }
        }
    }
}
