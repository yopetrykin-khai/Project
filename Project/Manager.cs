using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Manager:Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public Manager(string name, int age)
        {
            throw new NotImplementedException();
        }
        public override double CalculateSalary()
        {
            throw new NotImplementedException();
        }
    }
}
