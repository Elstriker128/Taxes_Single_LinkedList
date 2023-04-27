using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taxes
{
    public class Person : IComparable<Person>, IEquatable<Person>
    {
        /// <summary>
        /// A data class for all the possible citizens
        /// </summary>
        public string SurnameAndName { get; private set; }
        public string Address { get; private set; }
        public string PaidMonth { get; private set; }
        public string PaidCode { get; private set; }
        public int PaidAmount { get; private set; }
        public double FullPaid { get; set; }

        /// <summary>
        /// A constructor for a Person class object
        /// </summary>
        /// <param name="surnameAndName">the surname and name of the citizen</param>
        /// <param name="address">the address of the citizen</param>
        /// <param name="paidMonth">the month that the citizen paid taxes for</param>
        /// <param name="paidCode">the code of the tax that the citizen paid for</param>
        /// <param name="paidAmount">the amount of singular packets a citizen paid for</param>
        /// <param name="fullPaid">the whole amount a citizen for in taxes</param>
        public Person(string surnameAndName, string address, string paidMonth, string paidCode, int paidAmount, double fullPaid)
        {
            SurnameAndName = surnameAndName;
            Address = address;
            PaidMonth = paidMonth;
            PaidCode = paidCode;
            PaidAmount = paidAmount;
            FullPaid = fullPaid;
        }
        /// <summary>
        /// An overriden ToString method to print the required citizen data
        /// </summary>
        /// <returns>a string that is used to print the required citizen data</returns>
        public override string ToString()
        {

            return String.Format($"{this.SurnameAndName,-28} | {this.Address,-15} | {this.PaidMonth,-15} | {this.PaidCode,15} | {this.PaidAmount,18} |");
        }
        /// <summary>
        /// This method realises the IComparable add on and it compares two Person class objects
        /// </summary>
        /// <param name="other">and object of the Person class</param>
        /// <returns>a number based on the compared value: either 1, -1 or 0</returns>
        public int CompareTo(Person other)
        {
            if ((object)other == null)
                return 1;

            if (this.Address.CompareTo(other.Address) != 0)
            {
                return this.Address.CompareTo(other.Address);
            }
            else
            {
                return this.SurnameAndName.CompareTo(other.SurnameAndName);
            }
        }
        /// <summary>
        /// This method realises the IEquatable add on and compares two Person class objects
        /// </summary>
        /// <param name="other">and object of the Person class</param>
        /// <returns>either true or false based on if two values are the same or not</returns>
        public bool Equals(Person other)
        {
            if ((object)other == null)
                return false;
            if (this.Address == other.Address && this.SurnameAndName == other.SurnameAndName)
                return true;
            else
                return false;
        }
        /// <summary>
        /// An overriden Equals method that uses the IEquatable add on realisation
        /// </summary>
        /// <param name="obj">an object of the base object class</param>
        /// <returns>either false if value is null or a direction towards the IEquatable add on realisation</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Person perObj = obj as Person;
            if (perObj == null)
                return false;
            else
                return Equals(perObj);
        }
        /// <summary>
        /// An overriden GetHashCode method for comparison of two Person class objects
        /// </summary>
        /// <returns>hashcode comparison value</returns>
        public override int GetHashCode()
        {
            int hashCode = -471235233;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SurnameAndName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Address);
            return hashCode;
        }
        /// <summary>
        /// An overlaid "==" operator used for comparison 
        /// </summary>
        /// <param name="first">an object of the Person class</param>
        /// <param name="second">an object of the Person class</param>
        /// <returns>either true or false depending on if two objects are the same</returns>
        public static bool operator ==(Person first, Person second)
        {
            if (((object)first) == null || ((object)second) == null)
                return Object.Equals(first, second);
            return first.Equals(second);

        }
        /// <summary>
        /// An overlaid "!=" operator used for comparison 
        /// </summary>
        /// <param name="first">an object of the Person class</param>
        /// <param name="second">an object of the Person class</param>
        /// <returns>either true or false depending on if two objects are the same</returns>
        public static bool operator !=(Person first, Person second)
        {
            if (((object)first) == null || ((object)second) == null)
                return !Object.Equals(first, second);
            return !(first.Equals(second));

        }
        /// <summary>
        /// An overlaid ">" operator used for sorting and comparing 
        /// </summary>
        /// <param name="first">an object of the Person class</param>
        /// <param name="second">an object of the Person class</param>
        /// <returns>either true or false depending on which object's specific quality value is bigger</returns>
        public static bool operator >(Person first, Person second)
        {
            return first.CompareTo(second) > 0;
        }
        /// <summary>
        /// An overlaid "<" operator used for sorting and comparing 
        /// </summary>
        /// <param name="first">an object of the Person class</param>
        /// <param name="second">an object of the Person class</param>
        /// <returns>either true or false depending on which object's specific quality value is bigger</returns>
        public static bool operator <(Person first, Person second)
        {
            return first.CompareTo(second) < 0;
        }
        /// <summary>
        /// An overlaid ">=" operator used for sorting and comparing 
        /// </summary>
        /// <param name="first">an object of the Person class</param>
        /// <param name="second">an object of the Person class</param>
        /// <returns>either true or false depending on which object's specific quality value is bigger or equal</returns>
        public static bool operator >=(Person first, Person second)
        {
            return !(first < second);
        }
        /// <summary>
        /// An overlaid "<=" operator used for sorting and comparing 
        /// </summary>
        /// <param name="first">an object of the Person class</param>
        /// <param name="second">an object of the Person class</param>
        /// <returns>either true or false depending on which object's specific quality value is bigger or equal</returns>
        public static bool operator <=(Person first, Person second)
        {
            return !(first > second);
        }
    }
}