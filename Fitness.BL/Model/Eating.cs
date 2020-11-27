using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Eating
    {
        public DateTime Moment { get; }
        public List<Portion> Portions { get; }
        public User User { get; }


        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть null.", nameof(user));
            Moment = DateTime.Now;
            Portions = new List<Portion>();
        }

        public void Add(Food food, double weight)
        {
            var product = Portions.FirstOrDefault(p => p.Food.Name.Equals(food.Name));
            if(product == null)
            {
                Portions.Add(new Portion(food, weight));
            }
            else
            {
                product.Weight += weight;
            }
        }
    }
}
