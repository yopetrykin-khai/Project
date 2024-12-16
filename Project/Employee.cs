using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal abstract class Employee:IPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary {  get; set; }
        public virtual double CalculateSalary()
        {
            throw new NotImplementedException();
        }

    }
}
