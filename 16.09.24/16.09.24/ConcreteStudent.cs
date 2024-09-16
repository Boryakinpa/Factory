using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._09._24
{
    class ConcreteStudent : Product
    {
        internal List<ConcreteCourse> Courses { get; set; } = new List<ConcreteCourse>();

        internal ConcreteStudent(string[] parameters)
        {
            Id = parameters[0];
            Name = parameters[1];
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
            return $"student;{Id};{Name};{courses}";
        }
    }
}
