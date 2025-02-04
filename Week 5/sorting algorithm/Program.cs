using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorting_algorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 4, 5, 6, 7, 2, 3, 8, 9, 10, 11,};
            for (int i = 0; i < arr.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }

            foreach(int num in arr)
                Console.WriteLine(num);
        }
    }
}
