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

                //sorts the left side of the array - becuase upon insertion it becomes unsorted
                while (j > 0 && temp.CompareTo(arr[j-1]) < 0)
                {
                    arr[j] = arr[j - 1];
                    j = j - 1;
                }

                arr[j] = temp;
            }

        }

        public static void MergeSort(T[] arr, int start, int end)
        {
            if (start < end)
            {
                int middle = (start + end-1) / 2;
                
                MergeSort(arr, start, middle);
                MergeSort(arr, middle + 1, end);
                
                Merge(arr, start,middle, end);
            }
        }

        public static void Merge(T[] arr, int start, int middle, int end)
        {
            T[] tempArr = new T[end - start + 1];
            int k=0;
            int l = start ,r = middle+1;

            for (int i = start; i <= end; i++)
            {
                if (l > middle)
                {
                    tempArr[k++] = arr[r++];
                }
                else if (r > end)
                {
                    tempArr[k++] = arr[l++]; 
                }
                else if (arr[l].CompareTo(arr[r]) < 0)
                {
                    tempArr[k++] = arr[l++];
                }
                else{
                    tempArr[k++] = arr[r++];
                }
            }
            for (int n=0 ; n < k ;n ++) {
                arr[ start++ ] = tempArr[ n ] ;                          
            }
        }
        
        
        public static void QuickSort ( T[] arr ,int start , int end ) {
            if( start < end ) {
                int pivPos = Partition(arr ,start , end) ;     
                QuickSort(arr ,start , pivPos); 
                QuickSort( arr,pivPos +1 , end) ; 
            }
        }
        
        static int Partition ( T[] arr,int start ,int end) {
            //The first element is pivot and i will be replaced with pivot
            T pivot = arr[start];
            //add 1 to i becuase the first element is the pivot
            int i = start + 1;
            
            //Move the number lower than pivot to left of pivot and vice versa.
            for(int j = start + 1; j <= end ; j++ )  {
                if ( arr[j].CompareTo(pivot) < 0) {
                    var temp = arr[j];
                    arr[j] = arr[i];
                    arr[i] = temp;
                    i += 1;
                }
            }

            arr[start] = arr[i-1];
            arr[i-1] = pivot; 
            return i-1;      
        }
       
    }
}
