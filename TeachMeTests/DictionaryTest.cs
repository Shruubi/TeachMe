using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TeachMe.Structures;

namespace TeachMeTests
{
    [TestClass]
    public class DictionaryTest
    {
        [TestMethod]
        [Timeout(30000)]
        public void willCreate()
        {
            TeachMe.Structures.Dictionary<int, int> d = new TeachMe.Structures.Dictionary<int, int>();
            Assert.IsNotNull(d, "did not create object");
        }

        [TestMethod]
        [Timeout(30000)]
        public void canAdd1()
        {
            TeachMe.Structures.Dictionary<int, int> d = new TeachMe.Structures.Dictionary<int, int>();
            KeyValuePair<int, int> kv = new KeyValuePair<int,int>(1, 5);
            d.Add(kv);
            KeyValuePair<int, int> kv2 = new KeyValuePair<int, int>(2, 7);
            d.Add(kv2);
            Assert.AreEqual<int>(5, d[1], "value does not match");
            Assert.AreEqual<int>(7, d[2], "value does not match");
        }

        [TestMethod]
        [Timeout(30000)]
        public void canAdd2()
        {
            TeachMe.Structures.Dictionary<int, int> d = new TeachMe.Structures.Dictionary<int, int>();
            d.Add(1, 5);
            d.Add(2, 7);
            Assert.AreEqual<int>(5, d[1], "values do not match");
            Assert.AreEqual<int>(7, d[2], "values do not match");
        }

        [TestMethod]
        [Timeout(30000)]
        public void KeyList()
        {
            TeachMe.Structures.Dictionary<int, int> d = new TeachMe.Structures.Dictionary<int, int>();
            for (int i = 0; i < 10; i++)
            {
                d.Add(i, i);
            }
            List<int> keys = (List<int>)d.Keys;
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual<int>(i, keys[i], "values do not match");
            }
        }

        [TestMethod]
        [Timeout(30000)]
        public void ValueList()
        {
            TeachMe.Structures.Dictionary<int, int> d = new TeachMe.Structures.Dictionary<int, int>();
            for (int i = 0; i < 10; i++)
            {
                d.Add(i, i);
            }
            List<int> keys = (List<int>)d.Values;
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual<int>(i, keys[i], "values do not match");
            }
        }

        [TestMethod]
        [Timeout(30000)]
        public void ContainsKeys()
        {
            TeachMe.Structures.Dictionary<int, int> d = new TeachMe.Structures.Dictionary<int, int>();
            for (int i = 0; i < 10; i++)
            {
                d.Add(i, i);
            }
            Assert.IsTrue(d.ContainsKey(5), "list fails on identifying existing key");
            Assert.IsFalse(d.ContainsKey(100), "list thinks it contains non-existant key");
        }

        [TestMethod]
        [Timeout(30000)]
        public void Remove()
        {
            TeachMe.Structures.Dictionary<int, int> d = new TeachMe.Structures.Dictionary<int, int>();
            for (int i = 0; i < 10; i++)
            {
                d.Add(i, i);
            }

            KeyValuePair<int, int> kv = new KeyValuePair<int, int>(4, 4);
            d.Remove(kv);

            Assert.IsFalse(d.Contains(kv), "did not remove");
            Assert.IsFalse(d.Remove(kv), "removed a non-existant value");
        }

        [TestMethod]
        [Timeout(30000)]
        public void copyTo()
        {
            TeachMe.Structures.Dictionary<int, int> d = new TeachMe.Structures.Dictionary<int, int>();
            for (int i = 0; i < 10; i++)
            {
                d.Add(i, i);
            }

            KeyValuePair<int, int>[] array = new KeyValuePair<int, int>[10];
            d.CopyTo(array, 0);
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual<int>(d[i], array[i].Key, "values do not match");
            }
        }

        [TestMethod]
        [Timeout(30000)]
        public void Enumerator()
        {
            TeachMe.Structures.Dictionary<int, int> d = new TeachMe.Structures.Dictionary<int, int>();
            for (int i = 0; i < 10; i++)
            {
                d.Add(i, i);
            }

            int index = 0;
            foreach (var i in d)
            {
                Assert.AreEqual<int>(index, i.Key, "key does not match");
                Assert.AreEqual<int>(index, i.Value, "value does not match");
                index++;
            }
        }
    }
}
