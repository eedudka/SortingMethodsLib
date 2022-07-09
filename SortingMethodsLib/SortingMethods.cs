using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingMethodsLib
{
    internal static class SortingMethods
    {
        private static IEnumerable<int> Swaper(this IList<int> DataToSwap, int i, int j)
        {
            int tempData = DataToSwap[i];
            DataToSwap[i] = DataToSwap[j];
            DataToSwap[j] = tempData;
            return DataToSwap;
        }
        public static IEnumerable<int> BoubleSort(this IList<int> DataToSort)
        {

            for (int firstEl = 0; firstEl < DataToSort.Count(); firstEl++)
            {
                for (int secondEl = firstEl + 1; secondEl < DataToSort.Count; secondEl++)
                {
                    if (DataToSort[firstEl] > DataToSort[secondEl])
                    {
                        int tempData = DataToSort[secondEl];
                        DataToSort[secondEl] = DataToSort[firstEl];
                        DataToSort[firstEl] = tempData;
                    }
                }
            }
            return DataToSort;

        }
        public static IEnumerable<int> CoctailSort(this IList<int> DataToSort)
        {
            int begin = 0;
            int end = DataToSort.Count - 1;
            bool b = true;
            while (b)
            {
                b = false;
                begin++;
                for (int i = begin; i < end; i++)
                {
                    if (DataToSort[i] > DataToSort[i + 1])
                    {
                        Swaper(DataToSort, i + 1, i);
                        b = true;
                    }

                }
                if (!b) break;
                end--;
                for (int i = end; i > begin; i--)
                {

                    if (DataToSort[i] < DataToSort[i - 1])
                    {

                        Swaper(DataToSort, i - 1, i);
                        b = true;
                    }

                }
            }
            return DataToSort;
        }
        /// <summary>
        /// </summary>
        /// <param name="k">Step ratio(usually this coefficient is equal to 1.2474)</param>
        /// <param name="DataToSort">Data structure for sort</param>
        /// <returns></returns>
        public static IEnumerable<int> CombSort(this IList<int> DataToSort, double k = 1.2474)
        {

            double stepSize = DataToSort.Count - 1;

            while (stepSize > 1)
            {
                stepSize = stepSize < 1 ? stepSize = 1 : stepSize /= k;
                for (int i = 0; i + stepSize < DataToSort.Count; i++)
                {
                    if (DataToSort[i] > DataToSort[i + (int)stepSize])
                    {
                        Swaper(DataToSort, i, i + (int)stepSize);
                    }
                }

            }

            return DataToSort;
        }
        public static IEnumerable<int> InsertionSort(this IList<int> DataToSort)
        {
            for (int i = 1; i < DataToSort.Count; i++)
            {
                int tempValue = DataToSort[i];
                int j = i;
                while (j > 0 && DataToSort[j - 1] > tempValue)
                {
                    Swaper(DataToSort, j, j - 1);
                    j--;
                }
                DataToSort[j] = tempValue;

            }
            return DataToSort;
        }
        /// <summary>
        /// </summary>
        /// <param name="k">Step ratio(usually this coefficient is equal to 1.2474)</param>
        /// <param name="DataToSort">Data structure for sort</param>
        /// <returns></returns>
        public static IEnumerable<int> ShellSort(this IList<int> DataToSort, double k = 1.2474)
        {
            double stepSize = DataToSort.Count - 1;
            while (stepSize >= 1)
            {
                stepSize = stepSize < 1 ? stepSize = 1 : stepSize /= k;
                for (int i = 0; i + stepSize < DataToSort.Count; i++)
                {
                    int tempValue = DataToSort[i];
                    int j = i;
                    while (j > 0 && DataToSort[j - 1] > tempValue)
                    {
                        Swaper(DataToSort, j, j - 1);
                        j--;
                    }
                    DataToSort[j] = tempValue;
                }
            }
            return DataToSort;
        }
    }
}
