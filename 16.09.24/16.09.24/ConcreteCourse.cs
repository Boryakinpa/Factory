using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._09._24
{
    class ConcreteCourse : Product
    {
        internal List<ConcreteStudent> Students { get; set; } = new List<ConcreteStudent>();
        internal List<ConcreteTeacher> Teachers { get; set; } = new List<ConcreteTeacher>();

        internal ConcreteCourse(string[] parameters)
        {
            Id = parameters[0];
            Name = parameters[1];
        }
        public override string ToString()
        {
            string students = "null";
            string teachers = "null";
            if (Students != null)
            {
                foreach (ConcreteStudent student in Students)
                {
                    students += student.Id + "!" + student.Name + "!" + ":";
                }
            }
            if (Teachers != null)
            {
                foreach (ConcreteTeacher teacher in Teachers)
                {
                    teachers += teacher.Id + "!" + teacher.Experience + "!" + teacher.Name + ":";
                }
            }
            return $"course;{Id};{Name};{students};{teachers}";
        }
    }
}
