/*
 * An implementation of a dynamically sized array
 * 
 * This class is a part of the TeachMe Library and should be used for demonstration purposes only, it by no means implements the best or
 * most efficient algorithm for doing tasks, instead choosing one that demonstrates the functions and purpose of the data structure.
 * 
 * Written by: Damon Swayn
 * Modified Date: 19/08/2013
 * License: BSD
 */

using System;
using System.Collections;
using System.Collections.Generic;

namespace TeachMe
{
    public class ArrayList<T> : 
        ICollection<T>, IEnumerable<T> //we include ICollection to generate methods and IEnumerable for foreach support
        where T : IComparable<T> //T inherits IComparable so we can compare generics
    {
        private const int RESIZE_VAL = 4; //how much we should resize the array by at each resize
        private T[] _internalArray; // the internal array used
        private int _Size; //private member for storing the number of values in the array

        public int Count
        {
            get
            {
                return this._Size;
            }
        }

        //allows us to access the collection as an array
        public T this[int index]
        {
            get
            {
                try
                {
                    return this._internalArray[index];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException("Error: trying to access an out of range index.");
                }
            }
            set
            {
                try
                {
                    this._internalArray[index] = value;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException("Error: trying to access an out of range index.");
                }
            }
        }

        public ArrayList()
        {
            this._internalArray = new T[RESIZE_VAL];
            this._Size = 0;
        }

        public void Add(T item)
        {
            try
            {
                //because arrays are index based, the next slot to insert to will always be the number stored in size, therefore, we try and insert there
                this._internalArray[_Size] = item;
            }
            catch (Exception)
            {
                //if we hit here, we have tried to access the array past the boundary, we need to reallocate the array and try again
                T[] newarray = new T[this._Size + RESIZE_VAL]; //allocate new array
                Array.Copy(this._internalArray, newarray, this._Size); //copy data to new array
                this._internalArray = newarray; //assign to new array

                //now insert new value
                this._internalArray[_Size] = item;
            }

            this._Size++; //increment size count
        }

        public void Clear()
        {
            Array.Clear(this._internalArray, 0, this._Size); //clears all elements in the array
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this._Size; i++)
            {
                //we check if CompareTo returns 0 because it does if the comparison returns true, if they are the same the method returns true
                if (this._internalArray[i].CompareTo(item) == 0)
                    return true;
            }
            return false; //return false if we hit here because we checked every value for equality
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            //let the standard library do the heavy lifting here, copys the internal array to the specified one
            Array.Copy(this._internalArray, array, arrayIndex);
        }

        public bool IsReadOnly
        {
            get { return false; } //collection is read/writable, so return false
        }

        public bool Remove(T item)
        {
            //lets do this by copying around the item
            if (this.Contains(item))
            {
                int index = Array.IndexOf(this._internalArray, item); //get the index of the item
                T[] newarray = new T[this._Size - 1]; //alloc new array
                Array.Copy(this._internalArray, newarray, index); //copy all elements up to one we are going to remove
                //manual calculation
                int srcstart = index + 1; //calculate the start index for next copy
                this._Size--; //decrement our size counter
                int length = this._Size - index; //number of elements to copy is size - index
                Array.Copy(this._internalArray, srcstart, newarray, index, length); //do second copy
                this._internalArray = newarray; //assign internal array to new array
                return true; //success!
            }
            else
            {
                return false;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ArrayListEnum<T>(this._internalArray); //used for foreach stuff
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator(); //this one is for backwards compatibility with version of .NET without generics (ie less than .NET 2.0)
        }
    }

    //foreach works by storing the collection as it is which is why you cannot modify the collection during a foreach call
    public class ArrayListEnum<TYPE> : IEnumerator<TYPE>
    {
        public TYPE[] _items; //the collection as it stands when foreach is called
        int position = -1; //the current position, defaults to -1 because msdn says so

        public ArrayListEnum(TYPE[] internalArray)
        {
            this._items = internalArray; //assign the array to the one used in our enumerator
        }

        public object Current
        {
            get 
            {
                try
                {
                    return this._items[position]; //try and get the item at the current position
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException(); //msdn says do it this way for safety
                }
            }
        }

        public bool MoveNext()
        {
            position++; //move our index to the next value
            return (position < this._items.Length); //if our position is less than the array length we have a valid index so return true, else return false
        }

        public void Reset()
        {
            position = -1; //reset our position to the start point
        }

        TYPE IEnumerator<TYPE>.Current
        {
            get 
            {
                try
                {
                    return this._items[position]; //try and get the item at the current position
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException(); //msdn says do it this way for safety
                }
            }
        }

        public void Dispose() //ignore, this is to do with garbage collection and other stuff
        {
        }
    }

}
