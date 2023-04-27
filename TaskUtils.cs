using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taxes
{
    public class TaskUtils
    {
        private LinkList<Person> LinkList;
        public TaskUtils(LinkList<Person> linkList)
        {
            LinkList = linkList;
        }
        /// <summary>
        /// This method finds the month during which all the taxes were the cheapest and its sum
        /// </summary>
        /// <param name="cheapest">the sum of cheapest taxes</param>
        /// <param name="taxes">an object of the LinkList<Tax> class</param>
        /// <returns>the month during which all the taxes were the cheapest and its sum</returns>
        private string CheapestMonth(out double cheapest, LinkList<Tax> taxes)
        {
            string month = string.Empty;
            cheapest = double.MaxValue;
            for (LinkList.Begin(); LinkList.Exist(); LinkList.Next())
            {
                Person curPerson = LinkList.Get();
                double taxSum = 0;
                string curMonth = curPerson.PaidMonth;
                LinkList<Person> curPeople = new LinkList<Person>(LinkList);
                for (curPeople.Begin(); curPeople.Exist(); curPeople.Next())
                {
                    Person secondPerson = curPeople.Get();
                    if (secondPerson.PaidMonth == curMonth)
                    {
                        taxSum += FindHowMuchPersonPaid(secondPerson, taxes);
                    }
                }
                if (taxSum < cheapest)
                {
                    cheapest = taxSum;
                    month = curMonth;
                }
            }
            return month;
        }
        /// <summary>
        /// This method finds all the taxes that were paid during the cheapest month
        /// </summary>
        /// <param name="month">the name of the cheapest month for taxes</param>
        /// <param name="taxes">an object of the LinkList<Tax> class</param>
        /// <param name="filteredTaxes">an object of the LinkList<Tax> class that consists of the filtered taxes</param>
        public LinkList<Tax> AllTheCheapestTaxes(ref string month, LinkList<Tax> taxes)
        {
            LinkList<Tax> filteredTaxes = new LinkList<Tax>();
            double cheapest;
            month = CheapestMonth(out cheapest, taxes);
            for (LinkList.Begin(); LinkList.Exist(); LinkList.Next())
            {
                Person curPerson = LinkList.Get();
                if (curPerson.PaidMonth == month)
                {
                    for (taxes.Begin(); taxes.Exist(); taxes.Next())
                    {
                        Tax curTax = taxes.Get();
                        if (curPerson.PaidCode == curTax.TaxCode)
                        {
                            filteredTaxes.Add(curTax);
                        }
                    }
                }
            }
            return filteredTaxes;
        }
        /// <summary>
        /// This method finds the sum of all the paid taxes of all citizens that are given in the primary data file
        /// </summary>
        /// <param name="taxes">an object of the LinkList<Tax> class</param>
        /// <returns>the sum of all the paid taxes of all citizens that are given in the primary data file</returns>
        public double FindAllTaxSum(LinkList<Tax> taxes)
        {
            double sum = 0;
            for (LinkList.Begin(); LinkList.Exist(); LinkList.Next())
            {
                Person curPerson = LinkList.Get();
                for (taxes.Begin(); taxes.Exist(); taxes.Next())
                {
                    Tax curTax = taxes.Get();
                    if (curPerson.PaidCode == curTax.TaxCode)
                    {
                        sum += FindHowMuchPersonPaid(curPerson, taxes);
                    }
                }
            }
            return sum;
        }
        /// <summary>
        /// This method finds the amount of taxes that a person has paid in a single month
        /// </summary>
        /// <param name="taxes">an object of the LinkList<Tax> class</param>
        /// <returns>the amount of taxes that a person has paid in a single month</returns>
        private double FindHowMuchPersonPaid(Person current, LinkList<Tax> taxes)
        {
            for (taxes.Begin(); taxes.Exist(); taxes.Next())
            {
                Tax curTax = taxes.Get();
                if (current.PaidCode == curTax.TaxCode)
                {
                    return current.FullPaid = (current.PaidAmount * curTax.TaxCost);
                }
            }
            return 0;
        }
        /// <summary>
        /// This method finds the average amount of taxes paid in a year
        /// </summary>
        /// <param name="taxes">an object of the LinkList<Tax> class</param>
        /// <returns>the average amount of taxes paid in a year</returns>
        private double Average(LinkList<Tax> taxes)
        {
            double sum = FindAllTaxSum(taxes) * 12;
            return sum / LinkList.Count();
        }
        /// <summary>
        /// This method adds all the citizens who paid less taxes in a year than the average cost
        /// </summary>
        /// <param name="taxes">an object of the LinkList<Tax> class</param>
        /// <param name="filered">an object of LinkList<Person> class that consists of the filtered citizens</param>
        public LinkList<Person> AddWhoPaidLessThanAverage(LinkList<Tax> taxes)
        {
            LinkList<Person> filtered = new LinkList<Person>();
            double average = this.Average(taxes);
            for (LinkList.Begin(); LinkList.Exist(); LinkList.Next())
            {
                Person curPerson = LinkList.Get();
                if (FindHowMuchPersonPaid(curPerson, taxes) * 12 < average)
                {
                    filtered.Add(curPerson);
                }
            }
            return filtered;
        }
        /// <summary>
        /// This method filters the citizen linked list of all people who didn't pay the given tax during the given month
        /// </summary>
        /// <param name="month">the given month</param>
        /// <param name="tax">the given tax</param>
        /// <param name="taxes">an object of the LinkList<Tax> class</param>
        public void RemoveWhoDidntPayAtRequired(string month, string tax, LinkList<Tax> taxes)
        {
            Tax requiredTax = this.GetTaxByName(tax, taxes);
            for (LinkList.Begin(); LinkList.Exist(); LinkList.Next())
            {
                Person curPerson = LinkList.Get();
                if ((curPerson.PaidCode != requiredTax.TaxCode) || (curPerson.PaidMonth != month))
                {
                    LinkList.Remove<Person>(curPerson);
                }
            }
        }
        /// <summary>
        /// This method gets the necesarry tax information based on it's name
        /// </summary>
        /// <param name="tax">an object of the Tax class</param>
        /// <returns>the necesarry tax information</returns>
        public Tax GetTaxByName(string tax, LinkList<Tax> taxes)
        {
            for (taxes.Begin(); taxes.Exist(); taxes.Next())
            {
                Tax curTax = taxes.Get();
                if (curTax.TaxName == tax)
                {
                    return curTax;
                }
            }
            return null;
        }
    }
}