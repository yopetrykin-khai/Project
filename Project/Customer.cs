using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
   public class Customer:IPerson
    {

        private string name = "";
        private int age;
        private double amountoffuelasked;
        private FuelType askedfuel;
        private double moneytopay;
        public double MoneyToPay { get { return moneytopay; } set { moneytopay = value; } }
        public double AmountOfFuelAsked
        {
            get { return amountoffuelasked; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception($"The amount of fuel asked must be greater than zero! ({value})");
                }
                if(value > 5000)
                {
                    throw new Exception($"The amount of fuel can not be greater than 5000! ({value})");
                }
                amountoffuelasked = value;
            }
        }
        public FuelType AskedFuel
        {
            get { return askedfuel; }
            set
            {
                if (Enum.IsDefined(typeof(FuelType), value))
                {
                    askedfuel = value;
                }
                else
                {
                    throw new Exception($"Wrong type! Invalid type value({value}).");
                }
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("You should input name for the customer!");
                }
                foreach (char c in value)
                {
                    if (!char.IsLetter(c))
                    {
                        throw new Exception($"English letters only!({value})");
                    }
                    if (c < 'A' || c > 'z')
                    {
                        throw new Exception($"English letters only!({value})");
                    }
                }
                name = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception($"Age of the worker has to be above zero! ({value})");
                }
                age = value;
            }
        }
        public Customer(string name, int age, double amount, FuelType type)
        {
            Name = name;
            Age = age;
            AmountOfFuelAsked = amount;
            AskedFuel = type;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Amount of fuel asked: {AmountOfFuelAsked}, What fuel the client asked for: {(FuelType)AskedFuel}, Amount of money to pay: {MoneyToPay}";
        }
        public static Customer Parse(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentNullException();
            }
            string[] words = s.Split(',', StringSplitOptions.RemoveEmptyEntries);
            if (words.Length != 4) { throw new Exception("Wrong number of parameters"); }
            if (!int.TryParse(words[1], out int type1))
            {
                throw new Exception($"Wrong age!({words[2]})");
            }
            if(!double.TryParse(words[2], out double value))
            {
                throw new Exception($"Wrong amount of fuel the customer asking for!");
            }
            if (!int.TryParse(words[3], out int type))
            {
                throw new Exception($"Wrong type format!({words[1]})");
            }
            return new Customer(words[0], int.Parse(words[1]), double.Parse(words[2]), (FuelType)(int.Parse(words[3])));
        }
        public static bool TryParse(string s, out Customer customer)
        {
            customer = null;
            bool valid = false;
            try
            {
                customer = Parse(s);
                valid = true;
            }
            catch (FormatException e) { Console.WriteLine(e.Message); return false; }
            catch (ArgumentNullException) { Console.WriteLine("The string is empty"); return false; }
            catch (Exception e) { Console.WriteLine(e.Message); return false; }
            return true;
        }
    }
}
