using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Taxes
{
    public class InOutUtils
    {
        /// <summary>
        /// This method reads all citizens from a data file
        /// </summary>
        /// <param name="fv">a direction towards the first uploaded file's data</param>
        /// <param name="first">an object of the LinkList<type> class</param>
        public static void ReadPeople(Stream fv, LinkList<Person> first)
        {
            string line;
            using (var file = new StreamReader(fv, Encoding.UTF8))
            {
                while ((line = file.ReadLine()) != null)
                {
                    var values = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    string surnameAndname = values[0];
                    string address = values[1];
                    string paidMonth = values[2];
                    string paidCode = values[3];
                    int paidAmount = int.Parse(values[4]);
                    Person person = new Person(surnameAndname, address, paidMonth, paidCode, paidAmount, 0);
                    first.Add(person);
                }
            }
        }
        /// <summary>
        /// This method reads all taxes from a data file
        /// </summary>
        /// <param name="fv">a direction towards the second uploaded file's data</param>
        /// <param name="second">an object of the LinkList<type> class</param>
        public static void ReadTax(Stream fv, LinkList<Tax> second)
        {
            string line;
            using (var file = new StreamReader(fv, Encoding.UTF8))
            {
                while ((line = file.ReadLine()) != null)
                {
                    var values = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string code = values[0];
                    string name = values[1];
                    double cost = double.Parse(values[2]);
                    Tax tax = new Tax(code, name, cost);
                    second.Add(tax);
                }
            }
        }
        /// <summary>
        /// This method prints the required citizen data into a TXT file
        /// </summary>
        /// <param name="fin">an address of the result TXT file</param>
        /// <param name="first">an object of the LinkList<type> class</param>
        /// <param name="header">the required data name</param>
        public static void PrintPeople<Type>(string fin, IEnumerable<Type> first, string header) where Type : IComparable<Type>, IEquatable<Type>
        {
            using (var file = new StreamWriter(fin, true))
            {
                file.WriteLine(new string('-', 105));
                file.WriteLine(header);
                file.WriteLine(new string('-', 105));
                file.WriteLine($"{"Surname and name",-28} | {"Address",-15} | {"Tax month",-15} | {"Tax code",-15} | {"Singular packages",-18} |");
                file.WriteLine(new string('-', 105));
                foreach (Type current in first)
                {
                    file.WriteLine($"{current.ToString()}");
                }
                file.WriteLine(new string('-', 105));
                file.WriteLine();
            }
        }
        /// <summary>
        /// This method prints the filtered citizens to a TXT file
        /// </summary>
        /// <param name="fin">an address of the result TXT file</param>
        /// <param name="third">an object of the LinkList<type> class</param>
        /// <param name="header">the required data name</param>
        public static void PrintFiltered(string fin, LinkList<Person> third, string header)
        {
            using (var file = new StreamWriter(fin, true))
            {
                file.WriteLine(new string('-', 50));
                file.WriteLine(header);
                file.WriteLine(new string('-', 50));
                file.WriteLine($"{"Surname and name",-28} | {"Address",-15} |");
                file.WriteLine(new string('-', 50));
                for (third.Begin(); third.Exist(); third.Next())
                {
                    Person current = third.Get();
                    file.WriteLine($"{current.SurnameAndName,-28} | {current.Address,-15} |");
                }
                file.WriteLine(new string('-', 50));
                file.WriteLine();
            }
        }
        /// <summary>
        /// This method prints the required tax data into a TXT file
        /// </summary>
        /// <param name="fin">an address of the result TXT file</param>
        /// <param name="second">an object of the LinkList<type> class</param>
        /// <param name="header">the required data name</param>
        public static void PrintTax<Type>(string fin, IEnumerable<Type> second, string header) where Type : IComparable<Type>, IEquatable<Type>
        {
            using (var file = new StreamWriter(fin, true))
            {
                file.WriteLine(new string('-', 50));
                file.WriteLine(header);
                file.WriteLine(new string('-', 50));
                file.WriteLine($"{"Tax code",-15} | {"Tax name",-20} | {"Tax cost",-8} |");
                file.WriteLine(new string('-', 50));
                foreach (Type current in second)
                {
                    file.WriteLine($"{current.ToString()}");
                }
                file.WriteLine(new string('-', 50));
                file.WriteLine();
            }
        }
    }
}