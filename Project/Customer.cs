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
        public double MoneyToPay { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        public double AmountOfFuelAsked { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        public FuelType AskedFuel { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        public string Name { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        public int Age { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        public Customer(string name, int age, double amount, FuelType type)
        {
            throw new NotImplementedException();
        }
        public static Customer Parse(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentNullException();
            }
            string[] words = s.Split(';', StringSplitOptions.RemoveEmptyEntries);
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
