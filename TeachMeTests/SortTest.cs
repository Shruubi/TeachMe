using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TeachMe.Algorithms;

namespace TeachMeTests
{
    [TestClass]
    public class SortTest
    {
        [TestMethod]
        [Timeout(30000)]
        public void BubbleSort()
        {
            int[] lst = new int[50];
            int[] cpy = new int[50];

            Sorter<int> s = new Sorter<int>();
            Random r = new Random();

            for(int i = 0; i < 50; i++)
            {
                lst[i] = r.Next(1000);
            }

            Array.Copy(lst, cpy, 50);
            Array.Sort(cpy);

            s.BubbleSort(lst);

            for (int i = 0; i < 50; i++)
            {
                Assert.AreEqual<int>(cpy[i], lst[i], "elements do not match");
            }
        }

        [TestMethod]
        [Timeout(30000)]
        public void QuickSort()
        {
            int[] lst = new int[50];
            int[] cpy = new int[50];

            Sorter<int> s = new Sorter<int>();
            Random r = new Random();

            for (int i = 0; i < 50; i++)
            {
                lst[i] = r.Next(1000);
            }

            Array.Copy(lst, cpy, 50);
            Array.Sort(cpy);

            s.QuickSort(lst, 0, lst.Length - 1);

            for (int i = 0; i < 50; i++)
            {
                Assert.AreEqual<int>(cpy[i], lst[i], "elements do not match");
            }
        }
    }
}
