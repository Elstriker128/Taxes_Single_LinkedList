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
    public class NextTests
    {
        [DataTestMethod()]
        [DataRow("285880034", "Parking", 10.23, true)]
        [DataRow("183673599", "Lighting", 8.895, true)]
        [DataRow("129171764", "Water", 16.88, true)]
        public void Next_NextValueExist_True(string id, string name, double price, bool expected)
        {
            LinkList<Tax> list = new LinkList<Tax>();

            Tax first = new Tax(id, name, price);
            Tax second = new Tax("321712002", "Lift", 12.00);

            list.Add(first);
            list.Add(second);

            list.Begin();
            list.Next();

            var actual = second.Equals(list.Get());

            Assert.AreEqual(expected, actual);

        }
        [DataTestMethod()]
        [DataRow("285880034", "Parking", 10.23, false)]
        [DataRow("183673599", "Lighting", 8.895, false)]
        [DataRow("129171764", "Water", 16.88, false)]
        public void Next_NextValueExist_False(string id, string name, double price, bool expected)
        {
            LinkList<Tax> list = new LinkList<Tax>();

            Tax first = new Tax(id, name, price);
            Tax second = new Tax("321712002", "Lift", 12.00);

            list.Add(first);
            list.Add(null);

            list.Begin();
            list.Next();

            var actual = second.Equals(list.Get());

            Assert.AreEqual(expected, actual);

        }

    }
}
