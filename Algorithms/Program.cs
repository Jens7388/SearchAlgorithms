using System;
using System.Diagnostics;
using System.Linq;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];
            for(int i = 0; i < 4; i++)
            {
                array[i] = 2;
            }
            for(int i = 4; i < array.Length; i++)
            {
                array[i] = 3;
            }

            BinarySearch(array, 2);
            LinearSearch(array, 2);
        }

        private static int BinarySearch(int[] array, int x)
        {
            int left = array[0];
            int right = array[array.Length - 1];
            int mid;
            if(IsSorted(array))
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();
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
                    int furthestLeft = left;
                    int furthestRight = left;
                    
                    if(array[left - 1] == x)
                    {
                        while(left != 0 && array[left - 1] == x)
                        {
                            furthestLeft = left - 1;
                             left--;
                        }
                    }
                    else if(left != array.Length - 1 && array[left + 1] == x)
                    {
                        while(array[left + 1] == x)
                        {
                            furthestRight = left + 1;
                            left++;
                        }
                    }
                    //  Console.WriteLine("Search successful!");
                    timer.Stop();

                    timer.Reset();
                    Console.WriteLine($"Desired number was found between indexes: {furthestLeft} and {furthestRight}");
                    Console.WriteLine($"Binary search: {timer.ElapsedTicks}");
                    return left;

                }
                else
                {
                    // Console.WriteLine("Array does not contain the desired number!");
                    timer.Stop();
                    Console.WriteLine($"Binary search: {timer.ElapsedTicks}");
                    timer.Reset();
                    return -1;
                }
            }
            else
            {
                Console.WriteLine("Error! Array is not sorted!");
                return -1;
            }
        }

        private static int LinearSearch(int[] array, int x)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for(int i = 0; i < array.Length - 1; i++)
            {
                if(x == array[i])
                {
                    //  Console.WriteLine("Search successful!");
                    timer.Stop();
                    Console.WriteLine($"Linear search: {timer.ElapsedTicks}");
                    timer.Reset();
                    return array[i];
                }
            }
            //     Console.WriteLine("Array does not contain the desired number!");
            timer.Stop();
            Console.WriteLine($"Linear search: {timer.ElapsedTicks}");
            timer.Reset();
            return -1;
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
