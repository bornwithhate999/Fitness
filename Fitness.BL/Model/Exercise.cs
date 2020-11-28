using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Exercise
    {
        public DateTime Start { get; }
        public DateTime Finish { get; }
        public Activity Activity { get; }
        public User User { get; }

        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            if(finish < start)
            {
                throw new ArgumentException($"Дата окончания не может быть мешьше начала: {start}", nameof(finish));
            }
            Start = start;
            Finish = finish;
            Activity = activity;
            User = user ?? throw new ArgumentNullException("Пользователь не может быть null", nameof(user));
        }

        public override string ToString()
        {
            return $"{Activity.Name} c {Start} до {Finish}";
        }
    }
}
