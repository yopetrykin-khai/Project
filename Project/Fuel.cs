using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Fuel
    {
        public string Name { get; set; }
        private double cost;
        private double amount;
        private FuelType type;
        public Fuel(string name, FuelType fuel, double cost, double amount) { throw new NotImplementedException(); }
    }
}
