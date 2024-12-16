using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Manager:Employee
    {
        private string name;
        private int age;
        private double salary;
        public override string Name { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        public override int Age { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        public override double Salary { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        public Manager(string name, int age)
        {
            throw new NotImplementedException();
        }
        public override double CalculateSalary()
        {
            throw new NotImplementedException();
        }
        public static Manager Parse(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentNullException();
            }
            string[] words = s.Split(';', StringSplitOptions.RemoveEmptyEntries);
            if (words.Length != 2) { throw new Exception("Wrong number of parameters"); }
            if (!int.TryParse(words[1], out int type1))
            {
                throw new Exception($"Wrong age!({words[2]})");
            }
            return new Manager(words[0], int.Parse(words[1]));
        }
        public static bool TryParse(string s, out Manager manager)
        {
            manager = null;
            bool valid = false;
            try
            {
                manager = Parse(s);
                valid = true;
            }
            catch (FormatException e) { Console.WriteLine(e.Message); return false; }
            catch (ArgumentNullException) { Console.WriteLine("The string is empty"); return false; }
            catch (Exception e) { Console.WriteLine(e.Message); return false; }
            return true;
        }
    }
}
