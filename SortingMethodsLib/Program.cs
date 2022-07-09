using System;

namespace SortingMethodsLib
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var SortedData = GenerateRandomArray().CombSort();
        }
        public static int[] GenerateRandomArray()
        {
            Random rnd = new Random();
            int[] rndArray = new int[rnd.Next(1000)];
            for (int i = 0; i < rndArray.Length; i++)
            {
                rndArray[i] = rnd.Next(int.MaxValue);
            }

            return rndArray;

        }
    }
}
