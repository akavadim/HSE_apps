using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskType4.Ganta
{
    struct Work
    {
        string name;
        int duration;

        public Work(string Name, int Duration = 1)
        {
            if (Duration < 0)
                throw new ArgumentOutOfRangeException(nameof(Duration));
            name = Name;
            duration = Duration;
        }

        string Name { get => name; set => name = value; }
        int Duration
        {
            get => duration;
        }
    }
}
