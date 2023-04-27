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
    public class ExistTests
    {
        [DataTestMethod()]
        [DataRow("458040681", "Garbage", 15.0000, true)]
        [DataRow("737011199", "Cleaning", 4.895, true)]
        [DataRow("391134784", "Lift", 10.45, true)]
        public void Exist_CurrentValueExists_True(string id, string name, double price, bool expected)
        {
            LinkList<Tax> list = new LinkList<Tax>();
            Tax first = new Tax(id, name, price);

            list.Add(first);

            list.Begin();

            Assert.AreEqual(expected,list.Exist());

        }
        [TestMethod()]
        public void Exist_CurrentValueExists_False()
        {
            LinkList<Tax> list = new LinkList<Tax>();

            Assert.AreEqual(false, list.Exist());

        }
    }
}
