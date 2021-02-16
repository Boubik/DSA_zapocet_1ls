using System.Collections.Generic;

namespace DSA_zapocet_1ls
{
    internal class Zasobnik
    {
        public List<int> numbers;
        public int i;
        public Zasobnik()
        {
            numbers = new List<int>();
        }

        public void Push(int number)
        {
            numbers.Add(number);
        }

        public int Pop()
        {
            if(numbers.Count > 0)
            {
                i = numbers[(numbers.Count - 1)];
                numbers.RemoveAt(numbers.Count - 1);
                return i;
            }
            else
            {
                return 0;
            }
        }
    }
}