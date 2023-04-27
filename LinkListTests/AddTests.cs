using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add.Tests
{
    [TestClass()]
    public class AddTests
    {
        [DataTestMethod()]
        [DataRow("304766622", "Garbage", 9.77, 1)]
        [DataRow("737011199", "Cleaning", 10.55, 1)]
        [DataRow("119990065", "Roads", 10.45, 1)]
        public void Add_OneInList_1(string id, string name, double price, int expected)
        { 
            LinkList<Tax> list = new LinkList<Tax>();
            Tax value = new Tax(id, name, price);
            list.Add(value);

            Assert.AreEqual(list.Count(), expected);

        }
        [DataTestMethod()]
        [DataRow("304766622", "Garbage", 9.77, 2)]
        [DataRow("737011199", "Cleaning", 10.55, 2)]
        [DataRow("119990065", "Roads", 10.45, 2)]
        public void Add_TwoInList_2(string id, string name, double price, int expected)
        {
            LinkList<Tax> list = new LinkList<Tax>();

            Tax value = new Tax(id, name, price);
            Tax second = new Tax("321712002", "Lift", 12.00);

            list.Add(value);
            list.Add(second);

            Assert.AreEqual(list.Count(), expected);

        }
    }
}