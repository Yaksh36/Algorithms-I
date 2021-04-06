using System;

namespace SortingLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[] test = { 1, 5, 4, 3, 8, 2 };
            Sorter<int>.SelectionSort(test);
            foreach(int nu in test){
                Console.WriteLine(nu);
            }

        }
    }
}
