using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TeachMe.Algorithms;

namespace TeachMeTests
{
    [TestClass]
    public class SearchTests
    {
        [TestMethod]
        [Timeout(30000)]
        public void LinearSearch()
        {
            List<int> lst = new List<int>();
            Searcher<int> searcher = new Searcher<int>();
            lst.Add(1);
            lst.Add(2);
            lst.Add(3);
            lst.Add(4);
            lst.Add(5);
            lst.Add(6);
            lst.Add(7);
            lst.Add(8);
            lst.Add(9);
            lst.Add(10);
            lst.Add(11);
            lst.Add(12);
            lst.Add(13);
            lst.Add(14);
            lst.Add(15);
            lst.Add(16);
            lst.Add(17);
            lst.Add(18);
            lst.Add(19);
            lst.Add(20);

            Assert.AreEqual<int>(13, searcher.LinearSearch(lst, 14), "did not find element at appropriate index");
        }

        [TestMethod]
        [Timeout(30000)]
        public void BinarySearch()
        {
            List<int> lst = new List<int>();
            Searcher<int> searcher = new Searcher<int>();
            lst.Add(1);
            lst.Add(2);
            lst.Add(3);
            lst.Add(4);
            lst.Add(5);
            lst.Add(6);
            lst.Add(7);
            lst.Add(8);
            lst.Add(9);
            lst.Add(10);
            lst.Add(11);
            lst.Add(12);
            lst.Add(13);
            lst.Add(14);
            lst.Add(15);
            lst.Add(16);
            lst.Add(17);
            lst.Add(18);
            lst.Add(19);
            lst.Add(20);

            Assert.AreEqual<int>(13, searcher.LinearSearch(lst, 14), "did not find element at appropriate index");
        }
    }
}
