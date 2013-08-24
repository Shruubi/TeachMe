using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeachMe;

namespace TeachMeTests
{
    [TestClass]
    public class DequeTest
    {
        [TestMethod]
        [Timeout(30000)]
        public void canCreateDeque()
        {
            Deque<int> d = new Deque<int>();
            Assert.IsNotNull(d, "Deque created a null object");
        }

        [TestMethod]
        [Timeout(30000)]
        public void canPush()
        {
            Deque<int> d = new Deque<int>();
            d.Push(1);
            d.Push(2);

            Assert.AreEqual<int>(d.Head.Data, 2, "head does not equal 2");
            Assert.AreEqual<int>(d.Tail.Data, 1, "tail does not refer to the first pushed value");
        }

        [TestMethod]
        [Timeout(30000)]
        public void canPop()
        {
            //
            Deque<int> d = new Deque<int>();
            d.Push(1);
            d.Push(2);
            int fpop = d.Pop();
            int spop = d.Pop();

            Assert.AreEqual<int>(fpop, 2, "fpop does not equal 2");
            Assert.AreEqual<int>(spop, 1, "spop does not refer to the first pushed value");
        }

        [TestMethod]
        [Timeout(30000)]
        public void canEnqueue()
        {
            Deque<int> d = new Deque<int>();
            d.Enqueue(1);
            d.Enqueue(2);

            Assert.AreEqual<int>(d.Head.Data, 1, "head does not equal 1");
            Assert.AreEqual<int>(d.Tail.Data, 2, "tail does not refer to the second enqueued value");
        }

        [TestMethod]
        [Timeout(30000)]
        public void canDequeue()
        {
            Deque<int> d = new Deque<int>();
            d.Enqueue(1);
            d.Enqueue(2);
            int fpop = d.Dequeue();
            int spop = d.Dequeue();

            Assert.AreEqual<int>(fpop, 2, "fpop does not equal 1");
            Assert.AreEqual<int>(spop, 1, "spop does not refer to the second enqueued value");
        }

        [TestMethod]
        [Timeout(30000)]
        public void willClear()
        {
            Deque<int> d = new Deque<int>();
            d.Enqueue(1);
            d.Enqueue(2);
            d.Push(3);
            d.Push(4);

            Assert.AreNotEqual<int>(d.Count, 0, "deque is not proper size");
            d.Clear();
            Assert.AreEqual<int>(d.Count, 0, "structure did not get cleared");
        }

        [TestMethod]
        [Timeout(30000)]
        public void doesContain()
        {
            Deque<int> d = new Deque<int>();
            d.Push(1);
            d.Push(2);
            d.Push(3);
            d.Push(4);

            Assert.IsTrue(d.Contains(3), "deque failed to identify if it contains a value");
        }

        [TestMethod]
        [Timeout(30000)]
        public void doesNotContain()
        {
            Deque<int> d = new Deque<int>();
            d.Push(1);
            d.Push(2);
            d.Push(3);
            d.Push(4);

            Assert.IsFalse(d.Contains(7), "deque failed to identify if it does not contain a value");
        }

        [TestMethod]
        [Timeout(30000)]
        public void copyToArray()
        {
            Deque<int> d = new Deque<int>();
            d.Push(4);
            d.Push(3);
            d.Push(2);
            d.Push(1);

            int[] a = new int[4];
            d.CopyTo(a, 0);

            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual<int>(i + 1, a[i], "values do not match up");
            }
        }

        [TestMethod]
        [Timeout(30000)]
        public void removeSuccess()
        {
            Deque<int> d = new Deque<int>();
            d.Push(1);
            d.Push(2);
            d.Push(3);
            d.Push(4);
            d.Remove(3);
            Assert.IsFalse(d.Contains(3), "deque did not remove value");
        }

        [TestMethod]
        [Timeout(30000)]
        public void removeFail()
        {
            Deque<int> d = new Deque<int>();
            d.Push(1);
            d.Push(2);
            d.Push(3);
            d.Push(4);
            Assert.IsFalse(d.Remove(7), "returned true on a value that doesn't exist in structure");
        }

        [TestMethod]
        [Timeout(30000)]
        public void canEnumerate()
        {
            Deque<int> d = new Deque<int>();
            d.Push(1);
            d.Push(2);
            d.Push(3);
            d.Push(4);

            int j = 4;

            foreach(var i in d)
            {
                Assert.AreEqual<int>(j, i, "values do not match up");
                j--;
            }
        }
    }
}
