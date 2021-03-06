﻿using System;
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
         * rozděluje list do listů
         */
        public static List<int> MergeSort(List<int> numbers)
        {
            List<int> l = new List<int>();
            List<int> r = new List<int>();
            List<int> resault = new List<int>();
            int i;

            if (numbers.Count < 2)
            {
                return numbers;
            }
            else
            {
                int half = numbers.Count / 2;

                if (numbers.Count % 2 == 0)
                {
                    i = 0;
                    while (i < half)
                    {
                        l.Add(numbers[i]);
                        r.Add(numbers[i + half]);
                        i++;
                    }
                }
                else
                {
                    i = 0;
                    while (i < half)
                    {
                        l.Add(numbers[i]);
                        i++;
                    }

                    while (i < numbers.Count)
                    {
                        r.Add(numbers[i]);
                        i++;
                    }
                }
            }

            l = MergeSort(l);
            r = MergeSort(r);

            resault = Merge(l, r);

            return resault;
        }


        /**
         * hlavní logika Merge Sortu. Spojuje dva listy a rovná je velikostně
         */
        private static List<int> Merge(List<int> l, List<int> r)
        {
            List<int> resault = new List<int>();
            int fullLenght = l.Count + r.Count;

            int il = 0, ir = 0;

            while (il < l.Count || ir < r.Count)
            {
                //oba nejsou prázdný
                if (il < l.Count && ir < r.Count)
                {
                    //porovnání a přidání nižšího
                    if (l[il] <= r[ir])
                    {
                        resault.Add(l[il]);
                        il++;
                    }
                    else
                    {
                        resault.Add(r[ir]);
                        ir++;
                    }
                }

                //pokuď není prázdný levý
                else if (il < l.Count)
                {
                    resault.Add(l[il]);
                    il++;
                }

                //pokuď není prázdný pravý
                else if (ir < r.Count)
                {
                    resault.Add(r[ir]);
                    ir++;
                }
            }

            return resault;
        }

        /**
         * O(n)
         */
        public static List<int> CountingSort(List<int> numbers)
        {
            int i = 0;
            List<int> resault = new List<int>();
            List<int> count = new List<int>();

            while (i != numbers.Count)
            {
                resault.Add(-1);
                i++;
            }

            //najdeme minimum maximum
            int min = numbers[0];
            int max = numbers[0];
            i = 0;
            while (i != numbers.Count)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
                i++;
            }

            i = 0;
            while (i != (max - min + 1))
            {
                count.Add(0);
                i++;
            }

            i = 0;
            while (i != numbers.Count)
            {
                count[numbers[i] - min]++;
                i++;
            }

            count[0]--;
            i = 1;
            while (i != max - min + 1)
            {
                count[i] = count[i] + count[i - 1];
                i++;
            }

            i = numbers.Count - 1;
            while (i >= 0)
            {
                resault[count[numbers[i] - min]--] = numbers[i];
                i--;
            }

            return resault;
        }
    }
}
