using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_zapocet_1ls
{
    class Program
    {
        static void Main(string[] args)
        {
            int min = 0;
            int max = 100;
            uint count = 6; // 10^3 - 10^7

            List<int> numbers = new List<int>();
            List<int> sorted_numbers = new List<int>();
            numbers = rnd_cisla(min, max, count);

            // zasobník
            /*Zasobnik z = new Zasobnik();
            z.Push(5);
            z.Push(6);
            Console.WriteLine("\n" + z.Pop());
            z.Push(7);
            Console.WriteLine("\n" + z.Pop());

            Console.WriteLine("\n\nlist\n");
            write_int_list(z.numbers);*/

            // cyklická fronta
            /*Cyklicka_fronta c = new Cyklicka_fronta(3);

            c.Add(1);
            c.Add(2);
            c.Add(3);
            c.Add(4);

            Console.WriteLine(c.Get());
            Console.WriteLine(c.Get());
            Console.WriteLine(c.Get());
            Console.WriteLine(c.Get());*/


            Console.WriteLine("Počáteční list s " + numbers.Count + ":");
            write_int_list(numbers);
            /*
            // BubleSort
            Console.WriteLine("\nseřazený list s Buble sortem:");
            sorted_numbers = Sorty.BubleSort(numbers);
            write_int_list(sorted_numbers);


            Console.WriteLine("\nseřazený list s Merge sortem:");
            sorted_numbers = Sorty.MergeSort(numbers);
            write_int_list(sorted_numbers);


            Console.WriteLine("\nseřazený list s Counting sort:");
            sorted_numbers = Sorty.CountingSort(numbers);
            write_int_list(sorted_numbers);*/

            Console.ReadLine();
        }


        /**
         * vytvoří list náhodných čísel
         */
        static public List<int> rnd_cisla(int min, int max, uint count)
        {
            List<int> numbers = new List<int>();
            Random r = new Random();

            int i = 0;
            while (i != count)
            {
                numbers.Add(r.Next(min, max));
                i++;
            }
            return numbers;
        }

        static public void write_int_list(List<int> numbers)
        {
            foreach (int i in numbers)
            {
                Console.WriteLine(i);
            }
        }

    }
}