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
    public class LinkListConstructorWP
    {
        [DataTestMethod()]
        [DataRow("570610490", "Heating", 10.47)]
        [DataRow("131112954", "Water", 10.55)]
        [DataRow("589349117", "Roads", 2.25)]
        public void LinkListConstructorWithParam_CheckCountIfEqualOnBothLists_1(string id, string name, double price)
        {
            LinkList<Tax> flist = new LinkList<Tax>();
            Tax first = new Tax(id, name, price);

            flist.Add(first);

            LinkList<Tax> slist = new LinkList<Tax>(flist);

            Assert.AreEqual(flist.Count(), slist.Count());

        }
        [DataTestMethod()]
        [DataRow("570610490", "Heating", 10.47)]
        [DataRow("131112954", "Water", 10.55)]
        [DataRow("589349117", "Roads", 2.25)]
        public void LinkListConstructorWithParam_CheckCountIfEqualOnBothLists_2(string id, string name, double price)
        {
            LinkList<Tax> flist = new LinkList<Tax>();
            Tax first = new Tax(id, name, price);
            Tax second = new Tax("321712002", "Lift", 12.00);

            flist.Add(first);
            flist.Add(second);

            LinkList<Tax> slist = new LinkList<Tax>(flist);

            Assert.AreEqual(flist.Count(), slist.Count());

        }
        [DataTestMethod()]
        [DataRow("570610490", "Heating", 10.47)]
        [DataRow("131112954", "Water", 10.55)]
        [DataRow("589349117", "Roads", 2.25)]
        public void LinkListConstructorWithParam_CheckCountIfEqualOnBothLists_3(string id, string name, double price)
        {
            LinkList<Tax> flist = new LinkList<Tax>();
            Tax first = new Tax(id, name, price);
            Tax second = new Tax("321712002", "Lift", 12.00);
            Tax third = new Tax("333465804", "Garbage", 11.02);

            flist.Add(first);
            flist.Add(second);
            flist.Add(third);

            LinkList<Tax> slist = new LinkList<Tax>(flist);

            Assert.AreEqual(flist.Count(), slist.Count());

        }
    }
}
