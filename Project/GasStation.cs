using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Project
{

    public delegate double FuelCostCalculator(FuelType fuelType, double amount);

    public class GasStation:IPrintable
    {
        public Predicate<List<Customer>> isEmpty = (objects) =>
        {
            return objects.Count == 0;
        };
        public Action<string> Report = (message) =>
        {
            Console.WriteLine($"Report of the Gas station`s work: {message}");
        };
        private double budget = 0;
        public Manager Manager { get; set; }
        public Worker Worker { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Fuel> Fuel { get; set; }
        public event Action<string> OnFuelPurchase; 
        public event Action<string> OnFuelOutOfStock;    
        public GasStation(Worker worker, Manager manager)
        {
            Fuel = new List<Fuel>();
            Customers = new List<Customer>();
            Fuel fuel92 = new Fuel("Fuel 92", FuelType.Gasoline92, 50.0, 5000);
            Fuel fuel95 = new Fuel("Fuel 95", FuelType.Gasoline95, 55.0, 5000);
            Fuel diesel = new Fuel("Diesel", FuelType.Diesel, 52.0, 5000);
            Fuel.Add(diesel);
            Fuel.Add(fuel95);
            Fuel.Add(fuel92);
            Fuel.Sort();
            Manager = manager;
            Worker = worker;
        }
        public double CalculateBudget
        {
            get { return budget; }
        }

        public void UpdateBudget()
        {
            if (!isEmpty(Customers))
            {
                double bg = 0;
                foreach (Customer customer in Customers)
                {
                    bg += customer.MoneyToPay;
                }
                budget = bg;
            }
        }

        public void BuyFuel(FuelType fuelType, double amount, FuelCostCalculator costCalculator, Customer customer)
        {
            var fuel = (Fuel.Find(f => f.Type == fuelType));

            if (fuel != null && amount <= fuel.Amount)
            {
                double cost = costCalculator(fuelType, amount);
                customer.MoneyToPay = cost;    
                fuel.Amount -= amount;
                Manager.CalculateSalary(cost);
                Worker.CalculateSalary(cost);
                OnFuelPurchase?.Invoke($"Fuel purchase successful! Fuel type: {fuelType}, Amount: {amount}L, Cost: ${cost}");
            }
            else
            {
                OnFuelOutOfStock?.Invoke($"Insufficient fuel! Requested: {amount}L, Available: {(fuel != null ? fuel.Amount : 0)}L.");
                double cost = costCalculator(fuelType, fuel.Amount);
                customer.MoneyToPay = cost;
                Manager.CalculateSalary(cost);
                Worker.CalculateSalary(cost);
                fuel.Amount = 0;
            }
        }
        public string GetInfo()
        {
            string s = "";
            s += $"\nManager`s name is {Manager.Name}, he is {Manager.Age}, his salary is {Manager.Salary}$ at the moment.\n";
            s += $"Worker`s name is {Worker.Name}, he is {Worker.Age}, his salary is {Worker.Salary}$ at the moment.\n";
            foreach (var fuel in Fuel)
            {
                s+=($" - Fuel type: {fuel.Type}, Amount: {fuel.Amount}L, Cost: ${fuel.Costperl}\n");
            }
            if (!isEmpty(Customers))
            {
                s += "All the clients served:\n";
                int i = 0;
                foreach (Customer customer in Customers)
                {
                    i++;
                    s += $"{i}. {customer.ToString()};\n";
                }
            }
            else
            {
                s += "No clients served yet\n";
            }
            UpdateBudget();
            s += $"Companies budget: {CalculateBudget}$";
            return s;
        }
    }
}
