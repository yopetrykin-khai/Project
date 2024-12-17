using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Fuel:IComparable<Fuel>
    {
        public string Name {  get; set; }
        public double Costperl { get; set; }
        public double Amount { get; set; }
        public FuelType Type { get; set; }
        public Fuel(string name, FuelType fuel, double cost, double amount) 
        {
            Name = name;
            Costperl = cost;
            Type = fuel;
            Amount = amount;
        }
        public int CompareTo(Fuel other)
        {
            if (other == null) return 1;
            return Costperl.CompareTo(other.Costperl);
        }
    }
}
