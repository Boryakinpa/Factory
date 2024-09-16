using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._09._24
{
    class ConcreteTeacher : Product
    {
        internal string Experience { get; set; }
        internal List<ConcreteCourse> Courses { get; set; } = new List<ConcreteCourse>();

        internal ConcreteTeacher(string[] parameters)
        {
            Id = parameters[0];
            Experience = parameters[1];
            Name = parameters[2];
        }

        public override string ToString()
        {
            string courses = "null";
            if (Courses != null)
            {
                foreach (ConcreteCourse course in Courses)
                {
                    courses += course.Id + ":";
                }
            }
            return $"teacher;{Id};{Name};{Experience};{courses}";
        }
    }
}
