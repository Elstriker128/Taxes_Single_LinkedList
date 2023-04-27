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
    public class LinkListConstructorNP
    {
        [TestMethod()]
        public void LinkListConstructorNoParam_CheckPrimaryListCount_0()
        {
            LinkList<Tax> list = new LinkList<Tax>();

            Assert.IsTrue(list.Count()==0);

        }
    }
}
