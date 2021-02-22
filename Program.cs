using System;
using System.Collections.Generic;
using System.IO;

namespace DSA_zapocet_1ls
{
    class Program
    {
        static void Main(string[] args)
        {
            String cesta = @"C:\Users\cboub\Desktop\"; //cesta do složky, kde budou zapisovýny a čteny soubory

            Console.WriteLine("1) Zásobník");
            Console.WriteLine("2) Cyklická fronta");
            Console.WriteLine("3) Sorty");
            uint menu = get_menu(3);
            uint zasobnik_menu;
            int cislo;

            switch (menu)
            {

                // zasobník
                case 1:
                    Zasobnik z = new Zasobnik();
                    do
                    {
                        Console.WriteLine("\n1) Push\n2) Pop\n3) Exit");
                        zasobnik_menu = get_menu(3);

                        switch (zasobnik_menu)
                        {
                            case 1:
                                cislo = get_cislo();
                                z.Push(cislo);
                                break;

                            case 2:
                                Console.WriteLine("\nPop: " + z.Pop());
                                break;

                            case 3:
                                return;
                        }
                    } while (true);

                // cyklická fronta
                case 2:
                    Console.Write("\n");
                    int cyklicka_fronta = (int)get_menu(-1, "Velikost Cyklické fronty: ");
                    Cyklicka_fronta c = new Cyklicka_fronta(cyklicka_fronta);
                    do
                    {
                        Console.WriteLine("\n1) Add\n2) Get\n3) Exit");
                        zasobnik_menu = get_menu(3);

                        switch (zasobnik_menu)
                        {
                            case 1:
                                cislo = get_cislo();
                                c.Add(cislo);
                                break;

                            case 2:
                                Console.WriteLine("\nPop: " + c.Get());
                                break;

                            case 3:
                                return;
                        }
                    } while (true);

                    c.Add(1);
                    c.Add(2);
                    c.Add(3);
                    c.Add(4);

                    Console.WriteLine(c.Get());
                    Console.WriteLine(c.Get());
                    Console.WriteLine(c.Get());
                    Console.WriteLine(c.Get());

                    break;

                //sorty
                case 3:
                    int min = get_min();
                    int max = get_max(min);
                    uint count = get_count(); // 10^3 - 10^7 (uint)Math.Pow(10, 3)
                    Console.WriteLine("\nGeneruji náhodná čísla");

                    List<int> numbers = new List<int>();
                    List<int> sorted_numbers = new List<int>();
                    numbers = rnd_cisla(min, max, count);

                    write_int_list(numbers, cesta, "cisla.txt");


                    // Buble sort
                    Console.WriteLine("\nŘadím podle Buble sortu");
                    sorted_numbers = Sorty.BubleSort(read_numbers(cesta, "cisla.txt"));
                    write_int_list(sorted_numbers, cesta, "BubleSort.txt");


                    //Merge sort
                    Console.WriteLine("\nŘadím podle Merge sortem:");
                    sorted_numbers = Sorty.MergeSort(read_numbers(cesta, "cisla.txt"));
                    write_int_list(sorted_numbers, cesta, "MergeSort.txt");


                    //Couting sort
                    Console.WriteLine("\nŘadím podle Counting sort:");
                    sorted_numbers = Sorty.CountingSort(read_numbers(cesta, "cisla.txt"));
                    write_int_list(sorted_numbers, cesta, "CountingSort.txt");
                    break;
            }

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

        /**
         * print list of int as lines on console
         */
        static public List<int> read_numbers(String cesta, String filename)
        {
            List<int> numbers = new List<int>();

            string[] lines = File.ReadAllLines(cesta + filename);

            int cislo;
            foreach (string line in lines)
            {
                if (Int32.TryParse(line, out cislo))
                {
                    numbers.Add(cislo);
                }
            }

            return numbers;
        }

        /**
         * print list of int as lines on console
         */
        static public void write_int_list(List<int> numbers)
        {
            foreach (int i in numbers)
            {
                Console.WriteLine(i);
            }
        }

        /**
         * print list of int as lines on console
         */
        static public void write_int_list(List<int> numbers, String cesta, String filename)
        {
            string outup = "";
            using (StreamWriter outputFile = new StreamWriter(cesta + filename))
            {
                foreach (int i in numbers)
                {
                    outup += i.ToString() + "\n";
                }
                outputFile.WriteLine(outup);
            }
        }

        static public int get_cislo()
        {
            Console.Write("Zadej číslo: ");
            int cislo;

            while (!Int32.TryParse(Console.ReadLine(), out cislo))
            {
                Console.Write("\nZadej číslo: ");
            }

            return cislo;
        }
        static public int get_min()
        {
            Console.Write("Zadej minimum: ");
            int min;

            while (!Int32.TryParse(Console.ReadLine(), out min))
            {
                Console.Write("\nZadej minimum: ");
            }

            return min;
        }

        static public int get_max(int min)
        {
            Console.Write("Zadej maximum: ");
            int max;

            while (true)
            {
                if (!Int32.TryParse(Console.ReadLine(), out max))
                {
                    Console.Write("\nZadej maximum: ");
                }
                else if (min < max)
                {
                    break;
                }
                else
                {
                    Console.Write("\nZadej maximum: ");
                }
            }

            return max;
        }

        static public uint get_count()
        {
            Console.Write("Zadej počet čísel: ");
            uint count;

            while (true)
            {
                if (!UInt32.TryParse(Console.ReadLine(), out count))
                {
                    Console.Write("\nZadej počet čísel: ");
                }
                else if (count > 0)
                {
                    break;
                }
                else
                {
                    Console.Write("\nZadej maximum: ");
                }
            }

            return count;
        }

        static public uint get_menu(int max, string otazka = "Vyber si: ")
        {
            Console.Write(otazka);
            uint menu;

            while (true)
            {
                if (!UInt32.TryParse(Console.ReadLine(), out menu))
                {
                    Console.Write("\n" + otazka);
                }
                else if (menu > 0 && (menu <= max || max == -1))
                {
                    break;
                }
                else
                {
                    Console.Write("\n" + otazka);
                }
            }

            return menu;
        }

    }
}