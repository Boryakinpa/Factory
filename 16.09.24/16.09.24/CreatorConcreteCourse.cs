using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._09._24
{
    class CreatorConcreteCourse : Creator
    {
        public override Product FactoryMethod(string[] parameters) { return new ConcreteCourse(parameters); }
    }
}
