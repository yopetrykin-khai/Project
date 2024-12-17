using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public abstract class Employee:IPerson
    {
        public abstract string Name { get; set; }
        public abstract int Age { get; set; }
        public abstract double Salary {  get; set; }
        public virtual void CalculateSalary(double cost)
        {
            double salary = cost;
            Salary = salary;
        }

    }
}
