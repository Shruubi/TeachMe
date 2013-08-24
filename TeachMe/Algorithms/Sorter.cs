/*
 * An implementation of sorting algorithms designed to work on arrays.
 * 
 * Because I absolutely loathe sorting algorithms, I've mostly referenced implementations from wikibooks. These would probably
 * perform better on the whole than whatever implementation I would cook up.
 * 
 * There are a lot of different sorting methods, I chose to implement 2, one demonstrating a more naive, slower algorithm (bubble sort)
 * and one demonstrating a quick (O(n*logn) performance) quicksort. 
 * 
 * There is also a BogoSort implementation I did half for fun, half to demonstrate a concept. You should not actually run this as at worst
 * case the algorithm will run infinitely. The theoretical runtime is infinite for the same reason that the infinite monkey theorem holds, in
 * that there is a probability of the correct permutation coming out. However, given random number generators suck, practically this algorithm
 * could be infinite.
 * 
 * Note: Definately do not run this on a quantum computer, as while you will get an O(n) sort algorithm, if the list is not in order, theoretically
 * the universe will be destroyed and you will generate 2^n parallel universes where 2^n - 1 will be destroyed while one will have the correct
 * permutation in one go.
 * 
 * This class is a part of the TeachMe Library and should be used for demonstration purposes only, it by no means implements the best or
 * most efficient algorithm for doing tasks, instead choosing one that demonstrates the functions and purpose of the data structure.
 * 
 * Written by: Damon Swayn
 * Reference: http://en.wikibooks.org/wiki/Algorithm_Implementation/Sorting
 * Modified Date: 24/08/2013
 * License: BSD
 */

using System;
using System.Collections.Generic;

namespace TeachMe.Algorithms
{
    public class Sorter<T>
        where T : IComparable<T>
    {
        public Sorter()
        {
        }

        public void BubbleSort(T[] array)
        {
            int length = array.Length - 1; //set our initial length
            while (length > 0)
            {
                int swap = 0; //store our swap index
                for(int i = 0; i < length; i++)
                {
                    if(array[i].CompareTo(array[i + 1]) > 0) //if the current value is larger than the next value
                    {
                        T temp = array[i]; //store our current value in a temp variable
                        array[i] = array[i + 1]; //this and the next instruction just swap the two values
                        array[i + 1] = temp;
                        swap = i; //set our swap index to the current index
                    }
                }
                length = swap; //change our current index
            }
        }

        //swaps the value stored in index left with the value stored in index right
        private void Swap(T[] array, int Left, int Right)
        {
            T tmp = array[Right];
            array[Right] = array[Left];
            array[Left] = tmp;
        }

        //QuickSort is a divide and conquer algorithm in that instead of sorting the list as a whole, it splits the list into subgroups
        //and sorts each individual subgroup.
        //
        //the general idea is:
        // 1 - pick a pivot point
        // 2 - reorder so that items less than the pivot are on the left (before the pivot) and items which are greater than end up on the
        //     right (after the pivot)
        // 3 - repeat this process on each sublist you create recursively until your list is sorted
        public void QuickSort(T[] array, int Left, int Right)
        {
            int LHold = Left; //pick a left limit
            int RHold = Right; //pick a right limit
            int Pivot = Left; //select a pivot
            Left++;

            //this part here basically reorders the elements so that the high elements are in the top half of the list and the bottom elements
            //contain the smaller numbers
            while (Right >= Left)
            {
                if (array[Left].CompareTo(array[Pivot]) >= 0 && array[Right].CompareTo(array[Pivot]) < 0)
                {
                    Swap(array, Left, Right);
                }
                else if (array[Left].CompareTo(array[Pivot]) >= 0)
                {
                    Right--;
                }
                else if (array[Right].CompareTo(array[Pivot]) < 0)
                {
                    Left++;
                }
                else
                {
                    Right--;
                    Left++;
                }
            }

            //recursively run quick sort on the sublists
            Swap(array, Pivot, Right);
            Pivot = Right;
            if (Pivot > LHold)
                QuickSort(array, LHold, Pivot);
            if (RHold > Pivot + 1)
                QuickSort(array, Pivot + 1, RHold);
        }

        private bool isSorted(T[] array)
        {
            if (array.Length <= 1)
                return true;
            for (int i = 1; i < array.Length; i++)
                if (array[i].CompareTo(array[i - 1]) < 0) return false;
            return true;
        }

        private void Shuffle(T[] array)
        {
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                int swapIndex = rand.Next(array.Length);
                T temp = array[swapIndex];
                array[swapIndex] = array[i];
                array[i] = temp;
            }
        }

        //WARNING: DO NOT RUN THIS! THIS IS FOR EDUCATIONAL PURPOSES ONLY!
        public void BogoSort(T[] array)
        {
            //the concept of bogosort is while the array is not sorted, put the elements in a random order and check if they end up sorted
            while (!isSorted(array))
            {
                Shuffle(array);
            }
        }
    }
}
