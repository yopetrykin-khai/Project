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
        private double costperl;
        private double finalcost;
        private double amount;
        private FuelType type;
        public double CostPerLitr { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        public double FinalCost(double amountasked)
        {
            throw new NotImplementedException();
        }
        public double Amount { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        public FuelType Type { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        public Fuel(string name, FuelType fuel, double cost, double amount) { throw new NotImplementedException(); }
        public int CompareTo(Fuel other)
        {
            if (other == null) return 1;
            return CostPerLitr.CompareTo(other.CostPerLitr);
        }
    }
}
