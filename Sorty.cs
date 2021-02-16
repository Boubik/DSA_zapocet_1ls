using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_zapocet_1ls
{
    class Sorty
    {

        /**
         * O(n^2)
         */
        public static List<int> BubleSort(List<int> numbers)
        {
            int i = 0, y = 0, m;

            while (i != (numbers.Count - 1))
            {
                y = 0;
                while (y != (numbers.Count - i - 1))
                {
                    if (numbers[y + 1] < numbers[y])
                    {
                        m = numbers[y + 1];
                        numbers[y + 1] = numbers[y];
                        numbers[y] = m;
                    }
                    y++;
                }
                i++;
            }

            return numbers;
        }

        /**
         * O(n * log n)
         */
        public static List<int> MergeSort(List<int> numbers)
        {
            return numbers;
        }
    }
}
