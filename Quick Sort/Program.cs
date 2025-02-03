using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quick_Sort
{
    
    internal class Program
    {
        static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        static int Partition(int[] arr, int left, int right)
        {   // { 5,2, 4, 3, 0,  1 };
            int pivot = arr[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                {
                    if (arr[j] < pivot)
                    {
                        i++;
                        Swap(arr, i, j);
                    }
                }
            }
            Swap(arr, i + 1, right);

            return i +  1;
        }

        static void QuickSort(int[] arr, int left, int right)
        {
            if(left < right)
            {
                int pivot = Partition(arr, left, right);

                QuickSort(arr, pivot, right);
                QuickSort(arr, pivot + 1, right);
            }
        }
        static void Main(string[] args)
        {
            int[] arr = new int[] { 5,2, 4, 3, 0,  1 };
            QuickSort(arr, 0, arr.Length - 1);

            foreach (int num in arr)
            {
                Console.WriteLine(num);
            }
        }
    }
}
