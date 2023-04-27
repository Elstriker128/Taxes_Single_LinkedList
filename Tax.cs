using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taxes
{
    public class Tax : IComparable<Tax>, IEquatable<Tax>
    {
        /// <summary>
        /// A data class for all the possible taxes
        /// </summary>
        public string TaxCode { get; private set; }
        public string TaxName { get; private set; }
        public double TaxCost { get; private set; }

        /// <summary>
        /// A constructor for a Tax class object
        /// </summary>
        /// <param name="taxCode">the code of the tax</param>
        /// <param name="taxName">the name of the tax</param>
        /// <param name="taxCost">the cost of the tax</param>
        public Tax(string taxCode, string taxName, double taxCost)
        {
            TaxCode = taxCode;
            TaxName = taxName;
            TaxCost = taxCost;
        }
        /// <summary>
        /// An overriden ToString method to print the required tax data
        /// </summary>
        /// <returns>a string that is used to print the required tax data</returns>
        public override string ToString()
        {
            return String.Format($"{this.TaxCode,15} | {this.TaxName,-20} | {this.TaxCost,8} |");
        }
        /// <summary>
        /// This method realises the IComparable add on and it compares two Tax class objects
        /// </summary>
        /// <param name="other">and object of the Tax class</param>
        /// <returns>a number based on the compared value: either 1, -1 or 0</returns>
        public int CompareTo(Tax other)
        {
            if ((object)other == null)
                return 1;

            if (this.TaxName.CompareTo(other.TaxName) != 0)
            {
                return this.TaxName.CompareTo(other.TaxName);
            }
            else return 1;
        }
        /// <summary>
        /// This method realises the IEquatable add on and compares two Tax class objects
        /// </summary>
        /// <param name="other">and object of the Tax class</param>
        /// <returns>either true or false based on if two values are the same or not</returns>
        public bool Equals(Tax other)
        {
            if ((object)other == null)
                return false;
            if (this.TaxCode == other.TaxCode && this.TaxName == other.TaxName)
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
            Tax taxObj = obj as Tax;
            if (taxObj == null)
                return false;
            else
                return Equals(taxObj);
        }
        /// <summary>
        /// An overriden GetHashCode method for comparison of two Tax class objects
        /// </summary>
        /// <returns>hashcode comparison value</returns>
        public override int GetHashCode()
        {
            int hashCode = 303245136;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TaxCode);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TaxName);
            return hashCode;
        }
        /// <summary>
        /// An overlaid "==" operator used for comparison 
        /// </summary>
        /// <param name="first">an object of the Tax class</param>
        /// <param name="second">an object of the Tax class</param>
        /// <returns>either true or false depending on if two objects are the same</returns>
        public static bool operator ==(Tax first, Tax second)
        {
            if (((object)first) == null || ((object)second) == null)
                return Object.Equals(first, second);
            return first.Equals(second);

        }
        /// <summary>
        /// An overlaid "!=" operator used for comparison 
        /// </summary>
        /// <param name="first">an object of the Tax class</param>
        /// <param name="second">an object of the Tax class</param>
        /// <returns>either true or false depending on if two objects are the same</returns>
        public static bool operator !=(Tax first, Tax second)
        {
            if (((object)first) == null || ((object)second) == null)
                return !Object.Equals(first, second);
            return !(first.Equals(second));

        }
        /// <summary>
        /// An overlaid ">" operator used for sorting and comparing 
        /// </summary>
        /// <param name="first">an object of the Tax class</param>
        /// <param name="second">an object of the Tax class</param>
        /// <returns>either true or false depending on which object's specific quality value is bigger</returns>
        public static bool operator >(Tax first, Tax second)
        {
            return first.CompareTo(second) > 0;
        }
        /// <summary>
        /// An overlaid "<" operator used for sorting and comparing 
        /// </summary>
        /// <param name="first">an object of the Tax class</param>
        /// <param name="second">an object of the Tax class</param>
        /// <returns>either true or false depending on which object's specific quality value is bigger</returns>
        public static bool operator <(Tax first, Tax second)
        {
            return first.CompareTo(second) < 0;
        }
        /// <summary>
        /// An overlaid ">=" operator used for sorting and comparing 
        /// </summary>
        /// <param name="first">an object of the Tax class</param>
        /// <param name="second">an object of the Tax class</param>
        /// <returns>either true or false depending on which object's specific quality value is bigger or equal</returns>
        public static bool operator >=(Tax first, Tax second)
        {
            return !(first < second);
        }
        /// <summary>
        /// An overlaid "<=" operator used for sorting and comparing 
        /// </summary>
        /// <param name="first">an object of the Tax class</param>
        /// <param name="second">an object of the Tax class</param>
        /// <returns>either true or false depending on which object's specific quality value is bigger or equal</returns>
        public static bool operator <=(Tax first, Tax second)
        {
            return !(first > second);
        }
    }
}