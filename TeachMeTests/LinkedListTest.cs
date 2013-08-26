using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TeachMe.Structures;

namespace TeachMeTests
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        [Timeout(30000)]
        public void CanCreateLL()
        {
            SinglyLinkedList<int> l = new SinglyLinkedList<int>();
            Assert.IsNotNull(l, "constructor fails and does not create new object");
        }

        [TestMethod]
        [Timeout(30000)]
        public void CanAdd()
        {
            SinglyLinkedList<int> l = new SinglyLinkedList<int>();
            l.Add(1);
            l.Add(2);
            l.Add(3);

            Assert.AreEqual<int>(1, l.Head.Data, "Head does not match expected value");
            Assert.AreEqual<int>(3, l.Tail.Data, "Tail does not match expected value");
        }

        [TestMethod]
        [Timeout(30000)]
        public void CanClear()
        {
            SinglyLinkedList<int> l = new SinglyLinkedList<int>();
            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Add(4);
            l.Add(5);

            l.Clear();

            Assert.AreEqual<int>(0, l.Count, "Did not clear");
            Assert.IsNull(l.Head, "head is not null");
            Assert.IsNull(l.Tail, "tail is not null");
        }

        [TestMethod]
        [Timeout(30000)]
        public void DoesContain()
        {
            SinglyLinkedList<int> l = new SinglyLinkedList<int>();
            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Add(4);
            l.Add(5);

            Assert.IsTrue(l.Contains(4), "doesn't identify value is in list");
        }

        [TestMethod]
        [Timeout(30000)]
        public void DoesNotContain()
        {
            SinglyLinkedList<int> l = new SinglyLinkedList<int>();
            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Add(4);
            l.Add(5);

            Assert.IsFalse(l.Contains(7), "list thinks a non-existant value is in the list");
        }

        [TestMethod]
        [Timeout(30000)]
        public void GetAt()
        {
            SinglyLinkedList<int> l = new SinglyLinkedList<int>();
            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Add(4);
            l.Add(5);

            Assert.AreEqual<int>(3, l.getAt(2), "need to check my getAt code");
        }

        [TestMethod]
        [Timeout(30000)]
        public void CopyToArray()
        {
            SinglyLinkedList<int> l = new SinglyLinkedList<int>();
            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Add(4);
            l.Add(5);

            int[] array = new int[5];
            l.CopyTo(array, 0);

            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual<int>(i + 1, array[i], "values are not equal");
            }
        }

        [TestMethod]
        [Timeout(30000)]
        public void CanRemove()
        {
            SinglyLinkedList<int> l = new SinglyLinkedList<int>();
            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Add(4);
            l.Add(5);
            l.Remove(3);
            Assert.AreEqual<int>(4, l.getAt(2), "need to check my getAt code");
        }

        [TestMethod]
        [Timeout(30000)]
        public void RemoveFails()
        {
            SinglyLinkedList<int> l = new SinglyLinkedList<int>();
            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Add(4);
            l.Add(5);
            Assert.IsFalse(l.Remove(7), "does not return failure");
        }
    }
}
