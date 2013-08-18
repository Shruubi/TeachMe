using System;
using TeachMe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeachMeTests
{
    [TestClass]
    public class ArrayListTest
    {
        [TestMethod]
        public void TestCreation()
        {
            ArrayList<int> t = new ArrayList<int>();
            Assert.IsNotNull(t);
        }

        [TestMethod]
        public void CanAddValues()
        {
            ArrayList<int> t = new ArrayList<int>();
            t.Add(1);
            t.Add(2);
            t.Add(3);
            t.Add(4);

            Assert.AreEqual<int>(t[0], 1);
            Assert.AreEqual<int>(t[1], 2);
            Assert.AreEqual<int>(t[2], 3);
            Assert.AreEqual<int>(t[3], 4);
        }

        [TestMethod]
        public void willResize()
        {
            ArrayList<int> t = new ArrayList<int>();
            t.Add(1);
            t.Add(2);
            t.Add(3);
            t.Add(4);
            t.Add(5);

            Assert.AreEqual<int>(t[4], 5);
        }

        [TestMethod]
        public void willClear()
        {
            ArrayList<int> t = new ArrayList<int>();
            t.Add(5);
            Assert.AreEqual<int>(t[0], 5); //ensure item was added
            t.Clear();
            Assert.AreEqual<int>(t[0], 0);
        }

        [TestMethod]
        public void containsReturnsTrue()
        {
            ArrayList<int> t = new ArrayList<int>();
            t.Add(1);
            t.Add(2);
            t.Add(3);
            t.Add(4);
            t.Add(5);

            Assert.IsTrue(t.Contains(3));
        }

        [TestMethod]
        public void containsReturnsFalse()
        {
            ArrayList<int> t = new ArrayList<int>();
            t.Add(1);
            t.Add(2);
            t.Add(3);
            t.Add(4);
            t.Add(5);

            Assert.IsFalse(t.Contains(-1));
        }

        [TestMethod]
        public void ensureCopyToCopies()
        {
            ArrayList<int> t = new ArrayList<int>();
            t.Add(1);
            t.Add(2);
            t.Add(3);
            t.Add(4);
            t.Add(5);

            int[] carr = new int[5];
            t.CopyTo(carr, t.Count);

            for (int i = 0; i < t.Count; i++)
            {
                Assert.AreEqual<int>(t[i], carr[i]);
            }
        }

        [TestMethod]
        public void removeSuccess()
        {
            ArrayList<int> t = new ArrayList<int>();
            t.Add(1);
            t.Add(2);
            t.Add(3);
            t.Add(4);
            t.Add(5);
            t.Add(6);

            Assert.IsTrue(t.Remove(4), "removed 4 and returned true");
            Assert.IsFalse(t.Contains(4), "4 is no longer in the collection");
        }

        [TestMethod]
        public void removeFail()
        {
            ArrayList<int> t = new ArrayList<int>();
            t.Add(1);
            t.Add(2);
            t.Add(3);
            t.Add(4);
            t.Add(5);

            Assert.IsFalse(t.Remove(-1));
        }

        [TestMethod]
        public void foreachWorks()
        {
            ArrayList<int> t = new ArrayList<int>();
            t.Add(1);
            t.Add(2);
            t.Add(3);
            t.Add(4);
            t.Add(5);

            int j = 0;
            foreach (var i in t)
            {
                Assert.AreEqual<int>(i, t[j]);
                j++;
            }
        }
    }
}
