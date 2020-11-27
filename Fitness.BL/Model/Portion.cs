using System;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Portion
    {
        public Food Food { get; }
        public double Weight { get; set; }

        public Portion(Food food, double weight)
        {
            Food = food ?? throw new ArgumentNullException("Еда не может быть null.", nameof(food));

            if(weight <= 0)
            {
                throw new ArgumentException("Масса не может быть меньше 0.", nameof(weight));
            }
            Weight = weight;
        }

        public override string ToString()
        {
            return this.Food.Name + " " + this.Weight;
        }
    }
}
