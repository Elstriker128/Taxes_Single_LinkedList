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
    public class BeginTests
    {
        [DataTestMethod()]
        [DataRow("458040681", "Garbage", 9.77, true)]
        [DataRow("737011199", "Cleaning", 4.895, true)]
        [DataRow("391134784", "Paperwork", 10.45, true)]
        public void Begin_EqualToHead_True(string id, string name, double price, bool expected)
        {
            LinkList<Tax> list = new LinkList<Tax>();
            Tax value = new Tax(id, name, price);
            list.Add(value);

            list.Begin();

            var actual = value.Equals(list.Get());

            Assert.AreEqual(expected, actual);

        }
        [DataTestMethod()]
        [DataRow("458040681", "Garbage", 9.77, false)]
        [DataRow("737011199", "Cleaning", 4.895, false)]
        [DataRow("391134784", "Paperwork", 10.45, false)]
        public void Begin_EqualToHead_False(string id, string name, double price, bool expected)
        {
            LinkList<Tax> list = new LinkList<Tax>();
            Tax value = new Tax(id, name, price);

            list.Add(null);

            list.Begin();
            var actual = value.Equals(list.Get());

            Assert.AreEqual(expected,actual);

        }
    }
}
