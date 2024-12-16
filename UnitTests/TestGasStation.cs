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
        public void TestCalculate()
        {
            // Arrange
            Worker worker = new Worker("Eugene", 19);
            Manager manager = new Manager("Max", 19);
            FuelType fuel = FuelType.Gasoline92;
            double amount = 500;
            double expected = 25000;
            GasStation gasStation = new GasStation(worker, manager);
            // Act
            double final = gasStation.CalculateFuelCost(fuel, amount);
            // Assert
            Assert.AreEqual(expected, final);

        }
    }
    [TestClass]
    public class TestFuel
    {
        [TestMethod]
        public void TestFinalCost()
        {
            // Arrange
            Fuel fuel = new Fuel("Fuel92", FuelType.Gasoline92, 50, 5000);
            double amount = 500;
            double expected = 25000;
            // Act
            double final = fuel.FinalCost(amount);
            // Assert
            Assert.AreEqual(expected, final);
        }
    }
    [TestClass]
    public class TestWorker
    {
        [TestMethod]
        public void TestSalaryWorker()
        {
            // Arrange
            Fuel fuel = new Fuel("Fuel92", FuelType.Gasoline92, 50, 5000);
            Worker worker = new Worker("Eugene", 20);
            double amount = 500;
            double expected = 25000;
            double expected1 = 40;
            // Act
            double final = fuel.FinalCost(amount);
            double final1 = worker.CalculateSalary();
            // Assert
            Assert.AreEqual(expected1, final1);
        }
    }
    [TestClass]
    public class TestManager
    {
        [TestMethod]
        public void TestSalaryManager()
        {
            // Arrange
            Fuel fuel = new Fuel("Fuel92", FuelType.Gasoline92, 50, 5000);
           Manager manager = new Manager("Eugene", 20);
            double amount = 500;
            double expected = 25000;
            double expected1 = 40;
            // Act
            double final = fuel.FinalCost(amount);
            double final1 = manager.CalculateSalary();
            // Assert
            Assert.AreEqual(expected1, final1);
        }
    }
}
