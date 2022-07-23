using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Specialized;

namespace SortingMethodsLib
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var toSort = GenerateRandomArray();
            toSort.TimSort(64).ToArray();


        }
        public static int[] GenerateRandomArray()
        {
            Random rnd = new Random();
            int[] rndArray = new int[rnd.Next(100, 500)];
            for (int i = 0; i < rndArray.Length; i++)
            {
                rndArray[i] = rnd.Next(1000);
            }

            return rndArray;

        }
    }
}
