using Microsoft.VisualBasic.FileIO;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using System;
using Project;
using System.Xml.Linq;

namespace UnitTests
{
    [TestClass]
    public class TestGasStation
    {
        [TestMethod]
        public void TestCalculateFuelCost()
        {
            // Arrange
            Worker worker = new Worker("Eugene", 19);
            Manager manager = new Manager("Max", 25);
            FuelType fuel = FuelType.Gasoline92;
            double amount = 500;
            double expected = 25000;
            GasStation gasStation = new GasStation(worker, manager);

            // Act
            double final = gasStation.Fuel.Find(f => f.Type == fuel).Costperl * amount;

            // Assert
            Assert.AreEqual(expected, final);
        }

        [TestMethod]
        public void TestAddCustomer()
        {
            // Arrange
            Worker worker = new Worker("Eugene", 19);
            Manager manager = new Manager("Max", 25);
            GasStation gasStation = new GasStation(worker, manager);
            Customer customer = new Customer("Alice", 28, 40, (FuelType)2);
            // Act
            gasStation.Customers.Add(customer);
            // Assert
            Assert.AreEqual(1, gasStation.Customers.Count);
            Assert.AreEqual("Alice", gasStation.Customers[0].Name);
        }

        [TestMethod]
        public void TestRefillFuelStock()
        {
            // Arrange
            Worker worker = new Worker("Eugene", 19);
            Manager manager = new Manager("Max", 25);
            GasStation gasStation = new GasStation(worker, manager);
            FuelType fuelType = FuelType.Gasoline92;
            double refillAmount = 1000;
            double initialAmount = gasStation.Fuel.Find(f => f.Type == fuelType).Amount;
            // Act
            gasStation.Fuel.Find(f => f.Type == fuelType).Amount += refillAmount;
            // Assert
            Assert.AreEqual(initialAmount + refillAmount, gasStation.Fuel.Find(f => f.Type == fuelType).Amount);
        }

        [TestMethod]
        public void TestCalculateBudget()
        {
            // Arrange
            Worker worker = new Worker("Eugene", 19);
            Manager manager = new Manager("Max", 25);
            GasStation gasStation = new GasStation(worker, manager);
            Customer customer = new Customer("Alice", 28, 40, (FuelType)2);
            double initialAmount = gasStation.Fuel.Find(f => f.Type == customer.AskedFuel).Amount;
            double expectedCost = gasStation.Fuel.Find(f => f.Type == customer.AskedFuel).Costperl * customer.AmountOfFuelAsked;
            gasStation.Customers.Add(customer);
            // Act
            gasStation.BuyFuel(customer.AskedFuel, customer.AmountOfFuelAsked, (fuelType, amount) => expectedCost, customer); 
            gasStation.UpdateBudget();
            // Assert
            Assert.AreEqual(2200, gasStation.CalculateBudget);
        }

        [TestMethod]
        public void TestBuyFuel_SuccessfulPurchase()
        {
            // Arrange
            Worker worker = new Worker("Eugene", 19);
            Manager manager = new Manager("Max", 25);
            GasStation gasStation = new GasStation(worker, manager);
            Customer customer = new Customer("John", 30, 50, (FuelType)1);
            double initialAmount = gasStation.Fuel.Find(f => f.Type == customer.AskedFuel).Amount;
            double expectedCost = gasStation.Fuel.Find(f => f.Type == customer.AskedFuel).Costperl * customer.AmountOfFuelAsked;
            // Act
            gasStation.BuyFuel(customer.AskedFuel, customer.AmountOfFuelAsked, (fuelType, amount) => expectedCost, customer);
            // Assert
            Assert.AreEqual(initialAmount - 50, gasStation.Fuel.Find(f => f.Type == customer.AskedFuel).Amount);
            Assert.AreEqual(expectedCost, customer.MoneyToPay);
        }

        [TestMethod]
        public void TestBuyFuel_InsufficientStock()
        {
            // Arrange
            Worker worker = new Worker("Eugene", 19);
            Manager manager = new Manager("Max", 25);
            GasStation gasStation = new GasStation(worker, manager);
            Customer customer = new Customer ("John",30,5000,(FuelType)1);
            Customer customer1 = new Customer ("Alice",30,5000,(FuelType)1);
            double initialAmount = gasStation.Fuel.Find(f => f.Type == customer.AskedFuel).Amount;
            double expectedCost = gasStation.Fuel.Find(f => f.Type == customer.AskedFuel).Costperl * initialAmount;
            // Act
            gasStation.BuyFuel(customer.AskedFuel, customer.AmountOfFuelAsked, (fuelType, amount) => expectedCost, customer);
            gasStation.BuyFuel(customer1.AskedFuel, customer1.AmountOfFuelAsked, (fuelType, amount) => expectedCost, customer1);
            // Assert
            Assert.AreEqual(0, gasStation.Fuel.Find(f => f.Type == customer.AskedFuel).Amount);
            Assert.AreEqual(expectedCost, customer1.MoneyToPay);
        }
    }

}
