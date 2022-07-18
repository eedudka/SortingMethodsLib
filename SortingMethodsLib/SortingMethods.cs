using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingMethodsLib
{
    internal static class SortingMethods
    {
        private static int HeapSize;
        private static int Bitik;

        private static IList<int> Swaper(ref IList<int> DataToSwap, int i, int j)
        {
            int tempData = DataToSwap[i];
            DataToSwap[i] = DataToSwap[j];
            DataToSwap[j] = tempData;
            return DataToSwap;
        }
        private static int DoPart(ref IList<int> input, int low, int high)
        {
            int pivot = input[high];
            int i = low - 1;

            for (int j = low; j < high - 1; j++)
            {
                if (input[j] <= pivot)
                {
                    i++;
                    Swaper(ref input, i, j);
                }
            }
            Swaper(ref input, i + 1, high);
            return i + 1;
        }
        private static void PreHeapSort(ref IList<int> DataToSort, int index)
        {
            int left = 2 * index + 1;
            int right = 2 * index + 2;
            int largest = index;
            if (left <= HeapSize && DataToSort[left] > DataToSort[index])
            {
                largest = left;
            }

            if (right <= HeapSize && DataToSort[right] > DataToSort[largest])
            {
                largest = right;
            }

            if (largest != index)
            {
                Swaper(ref DataToSort, index, largest);
                PreHeapSort(ref DataToSort, largest);
            }
        }
        

        public static IList<int> BoubleSort(this IList<int> DataToSort)
        {

            for (int firstEl = 0; firstEl < DataToSort.Count; firstEl++)
            {
                for (int secondEl = firstEl + 1; secondEl < DataToSort.Count; secondEl++)
                {
                    if (DataToSort[firstEl] > DataToSort[secondEl])
                    {
                        Swaper(ref DataToSort, secondEl, firstEl);
                    }
                }
            }
            return DataToSort;

        }
        public static IList<int> CoctailSort(this IList<int> DataToSort)
        {
            int begin = 0;
            int end = DataToSort.Count;
            bool b = true;
            while (b)
            {
                b = false;
                begin++;
                for (int i = begin; i < end; i++)
                {
                    if (DataToSort[i] > DataToSort[i + 1])
                    {
                        Swaper(ref DataToSort, i + 1, i);
                        b = true;
                    }

                }
                if (!b) break;
                end--;
                for (int i = end; i > begin; i--)
                {

                    if (DataToSort[i] < DataToSort[i - 1])
                    {

                        Swaper(ref DataToSort, i - 1, i);
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
        public static IList<int> CombSort(this IList<int> DataToSort, double k = 1.2474)
        {

            double stepSize = DataToSort.Count;

            while (stepSize > 1)
            {
                stepSize = stepSize < 1 ? stepSize = 1 : stepSize /= k;
                for (int i = 0; i + stepSize < DataToSort.Count; i++)
                {
                    if (DataToSort[i] > DataToSort[i + (int)stepSize])
                    {
                        Swaper(ref DataToSort, i, i + (int)stepSize);
                    }
                }

            }

            return DataToSort;
        }
        public static IList<int> InsertionSort(this IList<int> DataToSort)
        {
            for (int i = 1; i < DataToSort.Count; i++)
            {
                int tempValue = DataToSort[i];
                int j = i;
                while (j > 0 && DataToSort[j - 1] > tempValue)
                {
                    Swaper(ref DataToSort, j, j - 1);
                    j--;
                }
                DataToSort[j] = tempValue;

            }
            return DataToSort;
        }
        public static IList<int> ShellSort(this IList<int> DataToSort)
        {

            for (int s = DataToSort.Count / 2; s > 0; s /= 2)
            {
                for (int i = s; i < DataToSort.Count; i++)
                {
                    for (int j = i - s; j >= 0 && DataToSort[j] > DataToSort[j + s]; j -= s)
                    {
                        Swaper(ref DataToSort, j, j + s);
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
        public static IList<int> ShellSortK(this IList<int> DataToSort, double k = 1.2474)
        {

            for (int s = (int)(DataToSort.Count / 2 * k); s > 0; s /= (int)(2 * k))
            {
                for (int i = s; i < DataToSort.Count; i++)
                {
                    for (int j = i - s; j >= 0 && DataToSort[j] > DataToSort[j + s]; j -= s)
                    {
                        Swaper(ref DataToSort, j, j + s);
                    }
                }

            }
            return DataToSort;
        }
        public static IList<int> ShellSortHubbard(this IList<int> DataToSort)
        {
            for (int s = DataToSort.Count / 2; s > 0; s /= 2)
            {
                for (int i = s; i < DataToSort.Count; i++)
                {
                    for (int j = i - s; j >= 0 && DataToSort[j] > DataToSort[j + s]; j -= s)
                    {
                        Swaper(ref DataToSort, j, j + s);
                    }
                }

            }
            return DataToSort;
        }
        public static IList<int> QuickSort(this IList<int> DataToSort, int low, int high)
        {
            int pivot_loc = 0;

            if (low < high)
            {
                pivot_loc = DoPart(ref DataToSort, low, high);
                QuickSort(DataToSort, low, pivot_loc - 1);
                QuickSort(DataToSort, pivot_loc + 1, high);
            }

            return DataToSort;
        } //re (need only 1 params for comfortable use)
        public static IList<int> TreeSort(this IList<int> DataToSort)
        {
            TreeSort treeSort = new TreeSort();
            treeSort.treeins(DataToSort.ToArray());
            return DataToSort;

        } //re(need return array)
        public static IList<int> GnomeSort(this IList<int> DataToSort)
        {
            int i = 0;
            while (i < DataToSort.Count)
            {
                if (i == 0 || DataToSort[i - 1] <= DataToSort[i]) i++;
                else
                {
                    Swaper(ref DataToSort, i - 1, i);
                    i--;
                }
            }
            return DataToSort;

        }
        public static IList<int> SelectionSort(this IList<int> DataToSort) //re(sort only 50% array)
        {
            for (int i = 0; i < DataToSort.Count - 1; i++)
            {
                int minValue = DataToSort[i];
                int minIdx = i;
                for (int j = i + 1; j < DataToSort.Count - 1; j++)
                {
                    if (DataToSort[j] < minValue)
                    {
                        minValue = DataToSort[j];
                        minIdx = j;
                    }
                    Swaper(ref DataToSort, i, minIdx);
                }
            }
            return DataToSort;
        }
        public static IList<int> QuickSortWithInsert(this IList<int> DataToSort)
        {
            if (DataToSort.Count - 1 <= 32)
            {
                return DataToSort.InsertionSort();
            }
            int z = (1 + (DataToSort.Count - 1) / 2);
            int ll = 1;
            int rr = DataToSort.Count - 1;
            while (ll <= rr)
            {
                while (ll < z) ll++;
                while (rr > z) rr--;
                if (ll <= rr)
                {
                    Swaper(ref DataToSort, ll, rr);
                    ll++;
                    rr--;
                }
            }
            //if (1 < rr) QuickSortWithInsert(DataToSort, 1, rr + 1);
            //if (ll < DataToSort.Count-1) QuickSortWithInsert(DataToSort, ll, DataToSort.Count-1);
            return DataToSort;
        } // re
        public static IList<int> HeapSort(this IList<int> DataToSort)
        {
            HeapSize = DataToSort.Count - 1;
            for (int i = HeapSize / 2; i >= 0; i--)
            {
                PreHeapSort(ref DataToSort, i);
            }
            for (int i = DataToSort.Count - 1; i >= 0; i--)
            {
                Swaper(ref DataToSort, 0, i);
                HeapSize--;
                PreHeapSort(ref DataToSort, 0);
            }
            return DataToSort;
        }
        //public static IList<int> CountSort(this IList<int> DataToSort)
        //{
        //    int l = DataToSort.Min();
        //    int r= DataToSort.Max();
            
        //    return DataToSort;
        //}

    }
}
