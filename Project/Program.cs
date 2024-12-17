using Project;
using System.ComponentModel.DataAnnotations;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Starting work of gas station");
        var program = new Program();
        Manager manager = program.AddManager();
        Worker worker = program.AddWorker();
        GasStation gasStation = new GasStation(worker, manager);
        Console.WriteLine("Gas station successfully created!");
        bool exit = false;
        while (!exit)
        {
                gasStation.OnFuelPurchase += message => Console.WriteLine(message);
                gasStation.OnFuelOutOfStock += message => Console.WriteLine(message);
                exit = false;
                while (!exit)
                {
                    Console.WriteLine("\n--- Menu of Gas station ---");
                    Console.WriteLine("1. Add a customer");
                    Console.WriteLine("2. Refill Fuel");
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
                                RefillFuelStock(gasStation);
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
                        Console.WriteLine($"Customer {cust.Name} added.");
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
        }
        static void RefillFuelStock(GasStation gasStation)
        {
            bool validFuelType = false;
            FuelType fuelType = FuelType.Gasoline92;
            while (!validFuelType)
            {
                Console.WriteLine("Select fuel type to refill:");
                Console.WriteLine("1 - Gasoline92");
                Console.WriteLine("2 - Gasoline95");
                Console.WriteLine("3 - Diesel");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        fuelType = FuelType.Gasoline92;
                        validFuelType = true;
                        break;
                    case "2":
                        fuelType = FuelType.Gasoline95;
                        validFuelType = true;
                        break;
                    case "3":
                        fuelType = FuelType.Diesel;
                        validFuelType = true;
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please enter 1, 2, or 3.");
                        break;
                }
            }
            bool validAmount = false;
            while (!validAmount)
            {
                Console.Write("Enter amount of fuel to add: ");
                string amountInput = Console.ReadLine();
                if (double.TryParse(amountInput, out double amount) && amount > 0)
                {
                    try
                    {
                        var fuel = gasStation.Fuel.Find(f => f.Type == fuelType);

                        if (fuel != null)
                        {
                            fuel.Amount += amount;
                            Console.WriteLine($"Fuel stock refilled successfully. New amount of {fuelType}: {fuel.Amount}L.");
                            validAmount = true;
                        }
                        else
                        {
                            Console.WriteLine("Fuel type not found in the gas station.");
                            validAmount = true;
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid amount. Please enter a positive number.");
                }
            }
        }

        static void ShowGasStationInfo(GasStation gasStation)
        {
            gasStation.Report(gasStation.GetInfo());
        }


 public Manager AddManager()
    {
        Console.WriteLine("Enter Manager's information in format: Name, Age");

        while (true)
        {
            try
            {
                string input = Console.ReadLine();
                if (Manager.TryParse(input, out Manager manager))
                {
                    Console.WriteLine($"Manager {manager.Name} successfully added.");
                    return manager;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error. Wrong format! Please enter data in the format: Name, Age");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Error. Input cannot be empty. Please try again.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
    public Worker AddWorker()
    {
        Console.WriteLine("Enter Worker's information in format: Name, Age");

        while (true)
        {
            try
            {
                string input = Console.ReadLine();
                if (Worker.TryParse(input, out Worker worker))
                {
                    Console.WriteLine($"Worker {worker.Name} successfully added.");
                    return worker;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error. Wrong format! Please enter data in the format: Name, Age");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    } 
}