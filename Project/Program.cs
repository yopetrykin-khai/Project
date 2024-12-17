using Project;
using System.ComponentModel.DataAnnotations;

public class Program
{
    public static void Main()
    {
        Manager manager = new Manager("John", 35);
        Worker worker = new Worker("Mike", 28);
        GasStation gasStation = new GasStation(worker, manager);
        gasStation.OnFuelPurchase += message => Console.WriteLine(message);
        gasStation.OnFuelOutOfStock += message => Console.WriteLine(message);
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n--- Menu of Gas station ---");
            Console.WriteLine("1. Add a customer");
            Console.WriteLine("2. ");
            Console.WriteLine("3. Show report of gas station");
            Console.WriteLine("4. Exit");
            Console.Write("Chose: ");
            string input = Console.ReadLine();
            try
            {
                int choice = int.Parse(input);

                switch (choice)
                {
                    case 1:
                        AddCustomer(gasStation);
                        break;
                    case 2:
                        break;
                    case 3:
                        ShowGasStationInfo(gasStation);
                        break;
                    case 4:
                        Console.WriteLine("Finishing programm...");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Wrong number. Try again!");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error. Wrong format!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
    static void AddCustomer(GasStation gasStation)
    {
        bool CheckTheException = false;
        Customer cust = null; 
        Console.WriteLine("1 - Gasoline92");
        Console.WriteLine("2 - Gasoline95");
        Console.WriteLine("3 - Diesel");
        Console.WriteLine("Input customer`s information: Name, Age, Amount of fuel asked, What fuel the client asked for (e.g., John, 30, 20, 1)");

        while (!CheckTheException)
        {
            try
            {
                string s = Console.ReadLine();
                if (Customer.TryParse(s, out cust))
                {
                    Console.WriteLine($"Customer {cust.Name} added successfully.");
                    gasStation.Customers.Add(cust);
                    CheckTheException = true;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error. Wrong format!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        if (cust != null)
        {
            CheckTheException = false;
            while (!CheckTheException)
            {
                try
                {
                    FuelCostCalculator costCalculator = (fuelType, amount) =>
                    {
                        var fuel = gasStation.Fuel.Find(f => f.Type == fuelType);
                        return fuel != null ? fuel.Costperl * amount : 0;
                    };

                    gasStation.BuyFuel(cust.AskedFuel, cust.AmountOfFuelAsked, costCalculator, cust);
                    CheckTheException = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error. Wrong format!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }


    static void ShowGasStationInfo(GasStation gasStation)
    {
        gasStation.Report(gasStation.GetInfo());
    }
}