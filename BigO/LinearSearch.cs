using System;
using System.Collections.Generic;
using System.Text;

namespace BigO
{
    class LinearSearch
    {
        public static int SearchLinear(int[] items, int target)
        {
            int index = -1;

            for(int i = 0; i < items.Length; i++)
            {
                if(target == items[i])
                {
                    index = i;
                }
            }

            return index;
        }
    }
}
