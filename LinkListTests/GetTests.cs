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
    public class GetTests
    {
        [DataTestMethod()]
        [DataRow("304766622", "Washing", 1.00)]
        [DataRow("833827673", "Sweeping", 9.74)]
        [DataRow("580569700", "Leaf_Blowing", 11.99)]
        public void Get_ReturnSameValue_True(string id, string name, double price)
        {
            LinkList<Tax> list = new LinkList<Tax>();
            Tax value = new Tax(id, name, price);
            list.Add(value);

            list.Begin();

            Tax gotten = list.Get();

            Assert.IsTrue(value.Equals(gotten));

        }
        [DataTestMethod()]
        [DataRow("304766622", "Washing", 1.00)]
        [DataRow("833827673", "Sweeping", 9.74)]
        [DataRow("580569700", "Leaf_Blowing", 11.99)]
        public void Get_ReturnSameValue_False(string id, string name, double price)
        {
            LinkList<Tax> list = new LinkList<Tax>();
            Tax value = new Tax(id, name, price);
            list.Add(value);

            list.Begin();

            Tax gotten = null;

            Assert.IsFalse(list.Get().Equals(gotten));

        }
    }
}
