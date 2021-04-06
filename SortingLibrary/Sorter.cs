using System;
using System.Collections.Generic;
using System.Text;

namespace SortingLibrary
{
    public class Sorter<T> where T : IComparable<T>
    { 
        public static void BubbleSort(T[] arr)
        {           
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) > 0 )
                    {
                        // here swapping of positions is being done.
                        var temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        public static void SelectionSort(T[] arr)
        {
            int n = arr.Length;
            // temporary variable to store the position of minimum element
            int minimum;
            // reduces the effective size of the array by one in  each iteration.
            for (int i = 0; i < n - 1; i++)
            {
                // assuming the first element to be the minimum of the unsorted array .
                minimum = i;
                // gives the effective size of the unsorted  array .
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j].CompareTo(arr[minimum]) < 0)
                    {   //finds the minimum element
                        minimum = j;
                    }
                }
                // putting minimum element on its proper position.
                var temp = arr[minimum];
                arr[minimum] = arr[i];
                arr[i] = temp;
            }
        }

        public static void InsertionSort(T[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n; i++)
            {
                var temp = arr[i];
                int j = i;

                while (j > 0 && temp.CompareTo(arr[j-1]) < 0)
                {
                    arr[j] = arr[j - 1];
                    j = j - 1;
                }

                arr[j] = temp;
            }

        }

       
    }
}
