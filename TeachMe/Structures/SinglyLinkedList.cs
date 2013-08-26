/*
 * An implementation of a singly linked list
 * 
 * This class is a part of the TeachMe Library and should be used for demonstration purposes only, it by no means implements the best or
 * most efficient algorithm for doing tasks, instead choosing one that demonstrates the functions and purpose of the data structure.
 * 
 * Written by: Damon Swayn
 * Modified Date: 26/08/2013
 * License: BSD
 */

using System;
using System.Collections.Generic;

using TeachMe.NodeTypes;

namespace TeachMe.Structures
{
    public class SinglyLinkedList<T> : 
        ICollection<T>, IEnumerable<T>
        where T : IComparable<T>
    {
        public SinglyLinkedNode<T> Head { get; set; }
        public SinglyLinkedNode<T> Tail { get; set; } //keeping track of tail makes life easier
        private int _Count;

        public SinglyLinkedList()
        {
            this._Count = 0;
            this.Head = this.Tail = null; //chain assign head and tail to null
        }

        public void Add(T item)
        {
            if (this.Head == null && this.Tail == null) //no items in list
            {
                this.Head = this.Tail = new SinglyLinkedNode<T>(item); //because we only have one item, head and tail refer to the same node
            }
            else //otherwise, we just shift tail
            {
                SinglyLinkedNode<T> ptr = new SinglyLinkedNode<T>(item);
                this.Tail.Next = ptr; //make the tails next pointer point to our new node
                this.Tail = this.Tail.Next; //shift tail so it refers to our new nodes
            }

            this._Count++; //increment our counter to reflect the addition of a new value
        }

        public T getAt(int index)
        {
            SinglyLinkedNode<T> ptr = this.Head;
            int i = index;
            while (ptr.Next != null && i != 0)
            {
                ptr = ptr.Next;
                i--;
            }

            if (i > 0 && ptr.Next == null)
                throw new IndexOutOfRangeException();

            return ptr.Data;
        }

        public void Clear()
        {
            this.Head = this.Tail = null; //make head and tail equal null
            this._Count = 0; //reset our counter
        }

        public bool Contains(T item)
        {
            SinglyLinkedNode<T> ptr = this.Head;
            while (ptr.Next != null) //iterate from top to bottom of list
            {
                if (ptr.Data.CompareTo(item) == 0)
                    return true; //if we find a match return success
                else
                    ptr = ptr.Next; //otherwise shift ptr to the next node and try again
            }
            return false; //if we hit here we went over the whole list and didn't find anything
        }

        //i like the idea of CopyTo starting at arrayIndex and iterating from there adding each value from the top of the list
        //to the end. This may not be the .NET standard, but it outlines the basic concept of copying to an array
        public void CopyTo(T[] array, int arrayIndex)
        {
            SinglyLinkedNode<T> ptr = this.Head;
            int i = arrayIndex; //start from array index
            while (ptr != null)
            {
                array[i] = ptr.Data; //because arrays are passed by reference, we can modify them directly
                i++; //increment i
                ptr = ptr.Next; //move our ptr to the next node
            }
        }

        public int Count
        {
            get { return this._Count; } //return the count
        }

        public bool IsReadOnly
        {
            get { return false; } //because we can write to our structure, it is not read-only
        }

        public bool Remove(T item)
        {
            SinglyLinkedNode<T> ptr = this.Head;
            SinglyLinkedNode<T> prv = null; //we need to keep track of the previous ptr to successfully remove
            while (ptr.Next != null)
            {
                if (ptr.Data.CompareTo(item) == 0)
                {
                    prv.Next = ptr.Next; //make the prv's next pointer point to the node after the current
                    ptr.Next = null; //make sure ptr doesn't refer to any previous or next nodes so it's unhooked
                    return true; //return success
                }

                prv = ptr; //make prv refer to the current node
                ptr = ptr.Next; //move ptr to the next node
            }

            return false; //if we hit here, then we didn't find the item, so return failure as the item doesn't exist
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator<T>(this.Head);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new LinkedListEnumerator<T>(this.Head);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new LinkedListEnumerator<T>(this.Head);
        }
    }

    public class LinkedListEnumerator<T> :
        IEnumerator<T>
    {
        public SinglyLinkedNode<T> Head { get; set; }
        public SinglyLinkedNode<T> ptr { get; set; }

        public LinkedListEnumerator(SinglyLinkedNode<T> Head)
        {
            this.Head = Head;
            ptr = null;
        }

        public T Current
        {
            get { return ptr.Data; }
        }

        public void Dispose()
        {
        }

        object System.Collections.IEnumerator.Current
        {
            get { return this.ptr; }
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
                ptr = ptr.Next;
                return true;
            }
        }

        public void Reset()
        {
            this.ptr = null;
        }
    }
}
