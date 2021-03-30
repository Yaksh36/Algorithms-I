using System;
using System.IO;

namespace IsomorphicStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application Start ----------------");

            string[] lines = File.ReadAllLines("C:/Users/Yaksh Patel/Downloads/IsomorphInput1.txt");
            foreach (string s in lines)
            {
                Console.WriteLine(s);
            }
        }
    }
}
