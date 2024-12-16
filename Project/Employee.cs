using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal abstract class Employee:IPerson
    {
        public abstract string Name { get; set; }
        public abstract int Age { get; set; }
        public abstract double Salary {  get; set; }
        public virtual double CalculateSalary()
        {
            throw new NotImplementedException();
        }

    }
}
