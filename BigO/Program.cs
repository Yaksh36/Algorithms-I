using System;
using System.Collections.Generic;
using System.Linq;

namespace BigO
{
    class Program
    {
        static void Main(string[] args)
        {
            bool result = palindromeAlgorithm("nurses run");
            Console.WriteLine(result);
        }

        static bool palindromeAlgorithm(string word)
        {
            string temp = word.Replace(" ","");
            string reverseWord = new string(temp.Reverse().ToArray());

            return temp == reverseWord;
        }


        /*int[] a1 = getArrayWithRandomNumbers(250000);
        int[] a2 = getArrayWithRandomNumbers(250000);

        int[] result = matchingAlgo(a1, a2);
            foreach(int i in result)
            {
                Console.WriteLine(i);
            }
    Console.WriteLine();

        static int[] getArrayWithRandomNumbers(int amount)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < amount; i++)
            {
                int rand = new Random().Next(11);
                result.Add(rand);
            }

            return result.ToArray();
        }

        static int[] matchingAlgo(int[] a1, int[] a2)
        {
            List<int> result = new List<int>();

            foreach(int i in a1)
            {
                foreach(int j in a2)
                {
                    if(i == j)
                    {
                        result.Add(i);
                        break;
                    }
                }
            }
            return result.ToArray();
        }*/



        /*int[] items = { 2, 10, 15, 24, 30, 36, 42, 55, 68, 90, 105, 206 };
        int num = Algo(items);
        Console.WriteLine(num);

        static int Algo(int[] items)
        {
            int y = items[0];
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] > y)
                {
                    y = items[i];
                }
            }

            return y;
        }*/

        /* int[] items = { 2, 10, 15, 24, 30, 36, 42, 55, 68, 90, 105, 206 };

         int target = 90;

         int indexFound = LinearSearch.SearchLinear(items, target);

             if (indexFound != -1)
             {
                 Console.WriteLine(target + " was found at index: " + indexFound);
                 Console.WriteLine("Item at that index is: " + items[indexFound]);
             }
             else
             {
                 Console.WriteLine(target + " was not found in the array");
             }
 Console.ReadLine();*/
    }
}
