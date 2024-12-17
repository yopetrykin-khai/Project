using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Manager:Employee
    {
        private string name = "";
        private int age;
        private double salary = 0;
        public override string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("You should input name for the manager!");
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
        public override int Age
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
                if (value < 25)
                {
                    throw new Exception($"Worker has to be older than 25 to work here! ({value})");
                }
                if (value > 65)
                {
                    throw new Exception($"Worker is too old to work here! ({value})");
                }
                age = value;
            }
        }
        public override double Salary
        {
            get
            {
                return salary;
            }
            set
            {
                salary += value;
            }
        }
        public Manager(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public override void CalculateSalary(double cost)
        {
            double salary = cost * 0.5;
            Salary = salary;
        }
        public static Manager Parse(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentNullException();
            }
            string[] words = s.Split(',', StringSplitOptions.RemoveEmptyEntries);
            if (words.Length != 2) { throw new Exception("Wrong number of parameters"); }
            if (!int.TryParse(words[1], out int type1))
            {
                throw new Exception($"Wrong age!({words[1]})");
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
