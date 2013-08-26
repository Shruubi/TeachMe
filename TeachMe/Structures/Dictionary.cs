using System;
using System.Collections.Generic;

using TeachMe.NodeTypes;

namespace TeachMe.Structures
{
    public class Dictionary<TKey, TValue> :
        IDictionary<TKey, TValue>
        where TKey : IComparable<TKey>
        where TValue : IComparable<TValue>
    {
        public DictionaryNode<TKey, TValue> Head { get; set; }
        public DictionaryNode<TKey, TValue> Tail { get; set; }
        private int _Count;

        public Dictionary()
        {
            this.Head = this.Tail = null; //set head and tail to null
            this._Count = 0;
        }

        public void Add(TKey key, TValue value)
        {
            if (this.Head == null && this.Tail == null) //if the list is empty
            {
                //head and tail refer to the same value because we only have one in the list
                this.Head = this.Tail = new DictionaryNode<TKey, TValue>(key, value);
            }
            else
            {
                DictionaryNode<TKey, TValue> ptr = new DictionaryNode<TKey, TValue>(key, value);
                this.Tail.Next = ptr; //make the current tails next value equal the new value
                this.Tail = this.Tail.Next; //make tail point to our new value
            }
            this._Count++;
        }

        public bool ContainsKey(TKey key)
        {
            DictionaryNode<TKey, TValue> ptr = this.Head;
            while (ptr.Next != null)
            {
                if (ptr.Data.Key.CompareTo(key) == 0)
                {
                    //iterate the list and check if the ptr's key matches the one we are searching for
                    return true;
                }

                ptr = ptr.Next; //otherwise move ptr to the next value
            }

            return false; //if we hit here, the key doesn't exist in the list, return fail
        }

        public ICollection<TKey> Keys
        {
            get 
            {
                List<TKey> k = new List<TKey>(); //list for storing keys
                DictionaryNode<TKey, TValue> ptr = this.Head;
                while (ptr != null)
                {
                    k.Add(ptr.Data.Key); //add all the keys to a list
                    ptr = ptr.Next; //move ptr to the next node
                }
                return k; //return the list
            }
        }

        public bool Remove(TKey key)
        {
            DictionaryNode<TKey, TValue> ptr = this.Head;
            DictionaryNode<TKey, TValue> prv = null;

            while (ptr.Next != null)
            {
                if (ptr.Data.Key.CompareTo(key) == 0) //if we have a match
                {
                    prv.Next = ptr.Next; //make prv's next value refer to ptr.next
                    ptr.Next = null; //unhook ptr from it's next
                    this._Count--;
                    return true; //return success
                }

                prv = ptr; //make prv refer to our current node
                ptr = ptr.Next; //move current to the next value
            }

            return false; //if we hit here then we didn't remove anything, return fail
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            DictionaryNode<TKey, TValue> ptr = this.Head;
            while (ptr.Next != null)
            {
                if (ptr.Data.Key.CompareTo(key) == 0)
                {
                    //iterate the list and check if the ptr's key matches the one we are searching for
                    value = ptr.Data.Value; //because value is a reference, we can directly assign
                    return true;
                }

                ptr = ptr.Next; //otherwise move ptr to the next value
            }

            value = default(TValue); //because we need to modify value before we return. set it to default
            return false;
        }

        public ICollection<TValue> Values
        {
            get
            {
                List<TValue> k = new List<TValue>(); //list for storing values
                DictionaryNode<TKey, TValue> ptr = this.Head;
                while (ptr != null)
                {
                    k.Add(ptr.Data.Value); //add value to list
                    ptr = ptr.Next; //move ptr to next value
                }
                return k; //return list
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                DictionaryNode<TKey, TValue> ptr = this.Head;
                while (ptr != null)
                {
                    if (ptr.Data.Key.CompareTo(key) == 0)
                    {
                        //iterate the list and check if the ptr's key matches the one we are searching for
                        return ptr.Data.Value; //because value is a reference, we can directly assign
                    }

                    ptr = ptr.Next; //otherwise move ptr to the next value
                }
                throw new InvalidOperationException(); //if the key doesn't exist, throw an exception
            }
            set
            {
                DictionaryNode<TKey, TValue> ptr = this.Head;
                while (ptr.Next != null)
                {
                    if (ptr.Data.Key.CompareTo(key) == 0)
                    {
                        //iterate the list and check if the ptr's key matches the one we are searching for
                        //we're making a new object because of read/write issues
                        ptr.Data = new KeyValuePair<TKey,TValue>(ptr.Data.Key, value);
                    }

                    ptr = ptr.Next; //otherwise move ptr to the next value
                }
            }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            if (this.Head == null && this.Tail == null) //if the list is empty
            {
                //head and tail refer to the same value because we only have one in the list
                this.Head = this.Tail = new DictionaryNode<TKey, TValue>(item);
            }
            else
            {
                DictionaryNode<TKey, TValue> ptr = new DictionaryNode<TKey, TValue>(item);
                this.Tail.Next = ptr; //make the current tails next value equal the new value
                this.Tail = this.Tail.Next; //make tail point to our new value
            }

            this._Count++;
        }

        public void Clear()
        {
            this.Head = this.Tail = null; //reset head and tail
            this._Count = 0; //reset count
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            DictionaryNode<TKey, TValue> ptr = this.Head;
            while (ptr != null)
            {
                //if the ptr key and value match the key and value we are looking for, return success
                if (ptr.Data.Key.CompareTo(item.Key) == 0 &&
                    ptr.Data.Value.CompareTo(item.Value) == 0)
                {
                    return true;
                }

                ptr = ptr.Next; //move ptr to the next node
            }

            return false; //return failure if we hit here because the item isn't in the list
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            int index = arrayIndex;
            DictionaryNode<TKey, TValue> ptr = this.Head;

            while (ptr != null)
            {
                array[index] = ptr.Data; //array is a reference, so assign to it directly
                index++; //increment index to next position
                ptr = ptr.Next; //move ptr up one
            }
        }

        public int Count
        {
            get { return this._Count; }
        }

        public bool IsReadOnly
        {
            get { return false; } //item is not readOnly
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            DictionaryNode<TKey, TValue> ptr = this.Head;
            DictionaryNode<TKey, TValue> prv = null;
            while (ptr != null)
            {
                //if the key and value match the key and value we are searching for
                if (ptr.Data.Key.CompareTo(item.Key) == 0 &&
                    ptr.Data.Value.CompareTo(item.Value) == 0)
                {
                    prv.Next = ptr.Next; //prv.next skips the current and goes to next
                    ptr.Next = null; //unhook ptr
                    this._Count--;
                    return true; //return success
                }
                prv = ptr; //make prv refer to ptr
                ptr = ptr.Next; //move ptr to the next node
            }

            return false; //return failure if we hit here because the item isn't in the list
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return new DictionaryEnumerator<TKey, TValue>(this.Head); //get the enumerator object
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new DictionaryEnumerator<TKey, TValue>(this.Head); //same as above
        }
    }

    public class DictionaryEnumerator<TKey, TValue> :
        IEnumerator<KeyValuePair<TKey, TValue>>
        where TKey : IComparable<TKey>
        where TValue : IComparable<TValue>
    {
        public DictionaryNode<TKey, TValue> Head { get; set; }
        public DictionaryNode<TKey, TValue> ptr { get; set; }

        public DictionaryEnumerator(DictionaryNode<TKey, TValue> Head)
        {
            this.Head = Head;
            this.ptr = null;
        }

        public KeyValuePair<TKey, TValue> Current
        {
            get { return ptr.Data; }
        }

        public void Dispose()
        {
        }

        object System.Collections.IEnumerator.Current
        {
            get { return ptr.Data; }
        }

        public bool MoveNext()
        {
            if (this.ptr == null)
            {
                this.ptr = this.Head;
                return true;
            }
            else if (this.ptr.Next == null)
            {
                return false;
            }
            else
            {
                this.ptr = this.ptr.Next;
                return true;
            }
        }

        public void Reset()
        {
            this.ptr = null;
        }
    }
}
