using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 3, 5, 6 };
            BinarySearch(array, 7);
        }

        private static int BinarySearch(int[] array, int x)
        {
            int left = array[0];
            int right = array[array.Length - 1];
            int mid;
            if(IsSorted(array)){
                while(left < right)
                {
                    mid = (left + right) / 2;
                    if(x > array[mid])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid;
                    }
                }
                if(array[left] == x)
                {
                    Console.WriteLine("Search successful!");
                    return left;
                }
                else
                {
                    Console.WriteLine("Array does not contain the desired number!");
                    return -1;
                }
            }
            else
            {
                Console.WriteLine("Error! Array is not sorted!");
                return -1;
            }
        }

        private static bool IsSorted(int[] array)
        {
            for(int i = 0; i < array.Length - 1; i++)
            {
                if(array[i] > array[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
