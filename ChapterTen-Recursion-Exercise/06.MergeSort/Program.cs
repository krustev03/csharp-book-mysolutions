using System;

namespace _06.MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 3, 4, 1, 5 };
            Sort(arr, 0, arr.Length - 1);
            Console.WriteLine("Sorted array");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }

        static void Merge(int[] arr, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            int[] L = new int[n1];
            int[] R = new int[n2];

            int i, j;

            for (i = 0; i < n1; i++)
            {
                L[i] = arr[i + left];
            }

            for (j = 0; j < n2; j++)
            {
                R[j] = arr[j + middle + 1];
            }

            i = 0;
            j = 0;
            int k = left;

            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                arr[k] = L[i];
                k++;
                i++;
            }

            while (j < n2)
            {
                arr[k] = R[j];
                k++;
                j++;
            }
        }

        static void Sort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;

                Sort(arr, left, middle);
                Sort(arr, middle + 1, right);
                Merge(arr, left, middle, right);
            }
        }
    }
}
