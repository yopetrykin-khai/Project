using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class GasStation
    {
        private double budget;
        public Manager Manager { get; set; }
        public Worker Worker { get; set; }
        public List<Customer> Customer { get; set; }
        public List<Fuel> Fuel { get; set; }
        public double Budget { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        public GasStation(Worker worker, Manager manager)
        {
            throw new NotImplementedException();
        }

    }
}
