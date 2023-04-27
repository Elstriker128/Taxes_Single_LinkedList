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
    public class RemoveTests
    {
        [DataTestMethod()]
        [DataRow("304766622", "Heating", 10.57, 0)]
        [DataRow("735011199", "Water", 15.55, 0)]
        [DataRow("113390065", "Roads", 2.239, 0)]
        public void Remove_CheckCountIfRemovedCorrectly_0(string id, string name, double price, int expected)
        {
            LinkList<Tax> list = new LinkList<Tax>();
            Tax first = new Tax(id, name, price);

            list.Add(first);

            list.Remove<Tax>(first);

            Assert.AreEqual(list.Count(), expected);

        }
        [DataTestMethod()]
        [DataRow("304766622", "Heating", 10.57,2)]
        [DataRow("735011199", "Water", 15.55, 2)]
        [DataRow("113390065", "Roads", 2.239, 2)]
        public void Remove_CheckCountIfRemovedCorrectly_2(string id, string name, double price, int expected)
        {
            LinkList<Tax> list = new LinkList<Tax>();
            Tax first = new Tax(id, name, price);
            Tax second = new Tax("321712002", "Lift", 12.00);
            Tax third = new Tax("333465804", "Garbage", 11.02);

            list.Add(first);
            list.Add(second);
            list.Add(third);

            list.Remove<Tax>(third);

            Assert.AreEqual(expected, list.Count());
        }
        [DataTestMethod()]
        [DataRow("304766622", "Heating", 10.57, 3)]
        [DataRow("735011199", "Water", 15.55, 3)]
        [DataRow("113390065", "Roads", 2.239, 3)]
        public void Remove_CheckCountIfRemovedCorrectly_3(string id, string name, double price, int expected)
        {
            LinkList<Tax> list = new LinkList<Tax>();
            Tax first = new Tax(id, name, price);
            Tax second = new Tax("321712002", "Lift", 12.00);
            Tax third = new Tax("333465804", "Garbage", 11.02);
            Tax fourth = new Tax("529920147", "Cleaning", 8.26);

            list.Add(first);
            list.Add(second);
            list.Add(third);
            list.Add(fourth);

            list.Remove<Tax>(third);

            Assert.AreEqual(expected, list.Count());
        }
        [TestMethod()]
        public void Remove_CheckCountIfRemovedCorrectly_null()
        {
            LinkList<Tax> list = new LinkList<Tax>();
            Tax first = null;

            list.Remove<Tax>(first);

            Assert.AreEqual(0, list.Count());

        }
    }
}
