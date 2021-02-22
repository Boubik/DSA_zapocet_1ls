using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_zapocet_1ls
{
    class Cyklicka_fronta
    {
        private List<int> numbers;
        private int count;
        private int write;
        private int read;
        private int m;

        public Cyklicka_fronta(int count)
        {
            this.count = count;
            numbers = new List<int>();
            write = 0;
            read = 0;
        }

        public void Add(int number)
        {
            if (count != numbers.Count)
            {
                numbers.Add(number);
            }
            else
            {
                numbers[write] = number;
                write++;
                if (write == count)
                {
                    write = 0;
                }
            }
        }

        public int Get()
        {
            if (numbers.Count != read)
            {
                m = numbers[read];
                read++;
                if (read == count)
                {
                    read = 0;
                }

                return m;
            }
            else
            {
                return 0;
            }
        }
    }
}
