/*
 * An implementation of a deque, which can be used either as a stack or a queue
 * 
 * This class is a part of the TeachMe Library and should be used for demonstration purposes only, it by no means implements the best or
 * most efficient algorithm for doing tasks, instead choosing one that demonstrates the functions and purpose of the data structure.
 * 
 * Written by: Damon Swayn
 * Modified Date: 19/08/2013
 * License: BSD
 */

using System;
using System.Collections.Generic;

using TeachMe.NodeTypes;

namespace TeachMe
{
    public class Deque<T> :
        ICollection<T>, IEnumerable<T>
        where T : IComparable<T>
    {
        //tracking the head and tail will make life easier
        public SinglyLinkedNode<T> Head { get; set; }
        public SinglyLinkedNode<T> Tail { get; set; }
        private int _Count;

        public Deque()
        {
            this.Head = null;
            this.Tail = null;
            this._Count = 0;
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        //add item in a last in first out manner
        public void Push(T item)
        {
            //empty list condition
            if (this.Head == null && this.Tail == null)
            {
                this.Head = this.Tail = new SinglyLinkedNode<T>(item);
            }
            else
            {
                SinglyLinkedNode<T> nxt = new SinglyLinkedNode<T>(item); //make new object
                nxt.Next = this.Head; //set new objects next pointer to the current head
                this.Head = nxt; //move head to reference the new object
            }
            this._Count++;
        }

        //get next item in a LIFO manner
        public T Pop()
        {
            //empty list condition
            if (this.Head == null && this.Tail == null)
            {
                throw new InvalidOperationException(); //if we have an empty list then throw an invalid operation exception
            }
            //single item in list condition
            else if (this.Head == this.Tail)
            {
                SinglyLinkedNode<T> nxt = this.Head; //make a reference to the top value of the stack
                this.Head = this.Tail = null; //because we only have 1 value in the list, both head and tail will reset to null
                this._Count--;
                return nxt.Data; //return the value in nxt
            }
            //otherwise fetch to head
            else
            {
                SinglyLinkedNode<T> nxt = this.Head; //make reference of the top value
                this.Head = this.Head.Next; //move head to the next value
                nxt.Next = null; //because nxt is a reference to the old head, we can set the next value to null will cause the garbage collector to pick it up
                this._Count--;
                return nxt.Data; //return the value
            }
        }

        //add item in a first in first out manner
        public void Enqueue(T item)
        {
            //empty list condition
            if (this.Head == null && this.Tail == null)
            {
                this.Head = this.Tail = new SinglyLinkedNode<T>(item);
            }
            else
            {
                SinglyLinkedNode<T> nxt = new SinglyLinkedNode<T>(item); //make new object
                this.Tail.Next = nxt; //set the tails next value to our new value
                this.Tail = this.Tail.Next; //move the tail pointer to our new value
            }
            this._Count++;
        }

        //get next item in a FIFO
        public T Dequeue()
        {
            //empty list condition
            if (this.Head == null && this.Tail == null)
            {
                throw new InvalidOperationException(); //if we have an empty list then throw an invalid operation exception
            }
            //single item in list condition
            else if (this.Head == this.Tail)
            {
                SinglyLinkedNode<T> nxt = this.Tail; //since we only have one value, we could reference either head or tail, to be consistent we will use tail
                this.Head = this.Tail = null; //because we only have 1 value in the list, both head and tail will reset to null
                this._Count--;
                return nxt.Data; //return the value in nxt
            }
            //otherwise fetch to tail
            else
            {
                SinglyLinkedNode<T> nxt = this.Tail; //make reference of the top value
                SinglyLinkedNode<T> ptr = this.Head; //we need a pointer because we need to get to the value 1 before the tail

                //because we use a singly linked list, we need to iterate from the top to get the value one before the tail, this is a performance issue we could
                //rectify by using a doubly linked list, then we could say this.Tail.Prev and make this an O(1) operation instead of O(n)
                while (ptr.Next != this.Tail)
                {
                    ptr = ptr.Next;
                }

                ptr.Next = null; //unhook our pointer from the tail
                this.Tail = ptr; //make tail point to the ptr
                this._Count--;
                return nxt.Data; //return our value
            }
        }

        public void Clear()
        {
            this.Tail = this.Head = null; //set both values to null
            this._Count = 0;
        }

        public bool Contains(T item)
        {
            if (this.Head.Data.CompareTo(item) == 0 || this.Tail.Data.CompareTo(item) == 0)
            {
                return true; //we can check head and tail for a O(1) operation, so get this check out of the way
            }
            else
            {
                SinglyLinkedNode<T> ptr = this.Head;
                //iterate from head to tail, if the value matches return true otherwise return false
                while (ptr.Next != null)
                {
                    if (ptr.Data.CompareTo(item) == 0)
                        return true;
                    else
                        ptr = ptr.Next;
                }
                return false;
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            SinglyLinkedNode<T> ptr = this.Head;
            for(int i = arrayIndex; i < this._Count; i++)
            {
                array[i] = ptr.Data;
                ptr = ptr.Next;
            }
        }

        //just a getter for the current structure size
        public int Count
        {
            get { return this._Count; }
        }

        //because this structure is writable, we make it return false to IsReadOnly
        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            SinglyLinkedNode<T> ptr = this.Head;
            SinglyLinkedNode<T> prv = null; //we need to keep track of the previous node so we can unhook pointer

            //if the item is head, removal becomes an O(1) operation, otherwise removal becomes an O(n) operation
            if (this.Head.Data.CompareTo(item) == 0)
            {
                ptr = ptr.Next; //make ptr reference the next node, so we can execute the next instruction on the head ptr
                this.Head.Next = null; //unhook head
                this.Head = ptr; //head now references pointer
                this._Count--; //decrement counter to reflect one less value in list
                return true; //return success
            }

            //because of the same limitation mentioned in Dequeue, we need to make tail removal O(n) iterative, therefore we're not going to include
            //a clause for it, and just make it part of the iteration section
            while (ptr.Next != null)
            {
                if (ptr.Data.CompareTo(item) == 0)
                {
                    prv.Next = ptr.Next; //make the previous's next pointer point to the one after pointer (the one we are removing)
                    ptr.Next = null; //make ptr's next pointer point to null so it is no longer attached to anything and garbage collection will get it
                    this._Count--; //decrement count to reflect one less value
                    return true; //return success
                }
                else
                {
                    prv = ptr; //previous becomes the current node
                    ptr = ptr.Next; //current node becomes the next node
                }
            }

            //if we fall out of the loop then we didn't find the value to remove, so return failure
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DequeEnumerator<T>(this.Head);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new DequeEnumerator<T>(this.Head);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new DequeEnumerator<T>(this.Head);
        }
    }

    public class DequeEnumerator<T> : IEnumerator<T>
    {
        private SinglyLinkedNode<T> root;
        private SinglyLinkedNode<T> ptr;

        public DequeEnumerator(SinglyLinkedNode<T> root)
        {
            this.root = root;
            this.ptr = null;
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
            get { return ptr.Data; }
        }

        public bool MoveNext()
        {
            if (this.ptr == null)
            {
                this.ptr = this.root;
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
            ptr = null;
        }
    }
}
