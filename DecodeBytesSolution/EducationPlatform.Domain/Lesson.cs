using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Domain
{
    public class Lesson
    {
       public string Name { get; }
       public string Description { get; }
        public DateOnly Date { get; }
        public TimeRange Time { get; }
        public Lesson(string name, string description, DateOnly date, TimeRange time)
        {
            Name = name;
            Description = description;
            Date = date;
            Time = time;
        }
    }
}
