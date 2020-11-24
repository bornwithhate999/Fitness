﻿using System;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Gender
    {
        public string Name { get; }
        public Gender(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым или null", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
