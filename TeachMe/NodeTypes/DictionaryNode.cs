using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachMe.NodeTypes
{
    public class DictionaryNode<TKey, TValue>
        where TKey : IComparable<TKey>
        where TValue : IComparable<TValue>
    {
        public KeyValuePair<TKey, TValue> Data { get; set; }
        public DictionaryNode<TKey, TValue> Next { get; set; }

        public DictionaryNode(TKey key, TValue val)
        {
            KeyValuePair<TKey, TValue> kvp = new KeyValuePair<TKey, TValue>(key, val);
            this.Data = kvp;
            this.Next = null;
        }

        public DictionaryNode(KeyValuePair<TKey, TValue> kvpair)
        {
            this.Data = kvpair;
            this.Next = null;
        }

        public DictionaryNode()
        {
            this.Data = default(KeyValuePair<TKey, TValue>);
            this.Next = null;
        }
    }
}
