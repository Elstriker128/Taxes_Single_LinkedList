using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxes;

namespace LinkListTests1
{
    [TestClass()]
    public class SortTests
    {
        [TestMethod()]
        public void Sort_CheckIfElementsAreSortedCorrectly_True()
        {
            LinkList<Tax> list = new LinkList<Tax>();
            
            Tax zero = new Tax("304766622", "Garbage", 12.5);
            Tax one = new Tax("304776624", "Water", 15.0);
            Tax two = new Tax("737011199", "Lift", 17.99);
            Tax three = new Tax("222371103", "Cleaning", 9.99);
            Tax four = new Tax("320990481", "Heating", 5.79);

            list.Add(zero);
            list.Add(one);
            list.Add(two);
            list.Add(three);
            list.Add(four);

            list.Begin();

            list.Sort();

            Assert.AreEqual(three, list.Get());
            list.Next();
            Assert.AreEqual(zero, list.Get());
            list.Next();
            Assert.AreEqual(four, list.Get());
            list.Next();
            Assert.AreEqual(two, list.Get());
            list.Next();
            Assert.AreEqual(one, list.Get());

        }
    }
}
