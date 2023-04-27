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
    public class CountTests
    {
        [DataTestMethod()]
        [DataRow("458040681", "Garbage", 15.0000, 1)]
        [DataRow("737011199", "Cleaning", 4.895, 1)]
        [DataRow("391134784", "Lift", 10.45, 1)]
        public void Count_CountInAList_1(string id, string name, double price, int expected)
        {
            LinkList<Tax> list = new LinkList<Tax>();
            Tax first = new Tax(id, name, price);

            list.Add(first);

            Assert.AreEqual(expected, list.Count());

        }
        [DataTestMethod()]
        [DataRow("458040681", "Garbage", 15.0000, 3)]
        [DataRow("737011199", "Cleaning", 4.895, 3)]
        [DataRow("391134784", "Lift", 10.45, 3)]
        public void Count_CountInAList_3(string id, string name, double price, int expected)
        {
            LinkList<Tax> list = new LinkList<Tax>();
            Tax first = new Tax(id, name, price);
            Tax second = new Tax("320990481", "Heating", 5.79);
            Tax third = new Tax("148911735", "Window_Washing", 3.145894678);

            list.Add(first);
            list.Add(second);
            list.Add(third);

            Assert.AreEqual(expected, list.Count());

        }
    }
}
