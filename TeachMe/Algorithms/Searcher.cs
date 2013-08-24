/*
 * An implementation of search algorithms designed to work on C# standard library lists.
 * 
 * This class is a part of the TeachMe Library and should be used for demonstration purposes only, it by no means implements the best or
 * most efficient algorithm for doing tasks, instead choosing one that demonstrates the functions and purpose of the data structure.
 * 
 * Written by: Damon Swayn
 * Modified Date: 24/08/2013
 * License: BSD
 */

using System;
using System.Collections.Generic;

namespace TeachMe.Algorithms
{
    public class Searcher<T>
        where T : IComparable<T>
    {
        public Searcher()
        {
        }

        public int LinearSearch(List<T> list, T itemToFind)
        {
            //a linear search simply starts from the first value and searches every value until it finds the value or it drops out of the loop
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CompareTo(itemToFind) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        //a binary search needs the input list to be sorted, it works by finding the middle (or the closest to middle) index, and asking
        //if the value is less than or greater than the item in the middle, we then run the same check on the given half again and again
        //essentially cutting our search space in half at every iteration
        //
        //based on - http://en.wikibooks.org/wiki/Algorithm_Implementation/Search/Binary_search#C.23_.28common_Algorithm.29
        public int BinarySearch(List<T> list, T itemToFind)
        {
            int low = 0, high = list.Count, midpoint = 0;

            while (low <= high)
            {
                midpoint = low + (high - low) / 2; //make midpoint the middle of the list starting at index low and ending at index high
                if (list[midpoint].CompareTo(itemToFind) == 0)
                    return midpoint; //if the item is found at the midpoint index, return that index
                else if (itemToFind.CompareTo(list[midpoint]) < 0)
                    //if the item we are searching for is less than the element stored at midpoint, move our high index to the low half
                    high = midpoint - 1; 
                else
                    //if the item we are searching for is greater than the element stored at midpoint, move our low index to be one more
                    //than the midpoint, making our search space to be in the top half
                    low = midpoint + 1;
            }

            return -1;
        }
    }
}
