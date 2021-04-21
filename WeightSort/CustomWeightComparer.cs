using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WeightSort
{
    public class CustomWeightComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            
            var numberOne = x.Sum(num => int.Parse(num.ToString())); 
            var numberTwo = y.Sum(num => int.Parse(num.ToString()));

            if (numberOne == numberTwo)
            {
                return x.CompareTo(y);
            }
            else
            {
                return numberOne.CompareTo(numberTwo);
            }

        }
    }
}