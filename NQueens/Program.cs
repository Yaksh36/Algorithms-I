using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NQueens
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter n: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("n=" + n);
            new NQueens(n);
            
        }

    }
}