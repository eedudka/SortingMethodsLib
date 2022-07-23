using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingMethodsLib
{
    public static class SortingMethods
    {
        private static int HeapSize;

        private static int lowBitonicSort;
        private static int CountBitonicSort;
        const int dirBitonic = 1;
        #region Helps Methods
        private static void Swaper(ref IList<int> DataToSwap, int i, int j)
        {
            int tempData = DataToSwap[i];
            DataToSwap[i] = DataToSwap[j];
            DataToSwap[j] = tempData;
        }
        private static int DoPart(ref IList<int> input, int low, int high)
        {
            int pivot = input[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
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
        private static void CompAndSwapBitonic(IList<int> DataToCS, int i, int j, int dir)
        {
            if ((dir != 0) == (DataToCS[i] > DataToCS[j]))
            {
                Swaper(ref DataToCS, i, j);
            }
        }
        private static void BitonicMerge(IList<int> DataToMerge, int low, int count, int dir)
        {
            if (count > 1)
            {
                int k = count / 2;
                for (int i = low; i < low + k; i++)
                {
                    CompAndSwapBitonic(DataToMerge, i, i + k, dir);
                }

                BitonicMerge(DataToMerge, low, k, dir);
                BitonicMerge(DataToMerge, low + k, k, dir);
            }
        }
        private static void Sort(ref IList<int> DataToSort, int low, int count, int dir)
        {
            if (count > 1)
            {
                int k = count / 2;

                Sort(ref DataToSort, low, k, 1);

                Sort(ref DataToSort, low + k, k, 0);

                BitonicMerge(DataToSort, low, count, dir);
            }
        }
        private static void QuickSort(ref IList<int> DataToSort, int low, int high)
        {
            int pivot_loc = 0;

            if (low < high)
            {
                pivot_loc = DoPart(ref DataToSort, low, high);
                QuickSort(ref DataToSort, low, pivot_loc - 1);
                QuickSort(ref DataToSort, pivot_loc + 1, high);
            }
        }
        private static void MergeMethod(ref IList<int> DataToSort, int left, int mid, int right)
        {
            int[] temp = new int[DataToSort.Count];
            int i, left_end, num_elements, tmp_pos;
            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);
            while ((left <= left_end) && (mid <= right))
            {
                if (DataToSort[left] <= DataToSort[mid])
                    temp[tmp_pos++] = DataToSort[left++];
                else
                    temp[tmp_pos++] = DataToSort[mid++];
            }
            while (left <= left_end)
                temp[tmp_pos++] = DataToSort[left++];
            while (mid <= right)
                temp[tmp_pos++] = DataToSort[mid++];
            for (i = 0; i < num_elements; i++)
            {
                DataToSort[right] = temp[right];
                right--;
            }
        }
        private static void MergeSort(ref IList<int> DataToSort, int left, int right)
        {
            int mid;
            if (right > left)
            {
                mid = (right + left) / 2;
                MergeSort(ref DataToSort, left, mid);
                MergeSort(ref DataToSort, (mid + 1), right);
                MergeMethod(ref DataToSort, left, (mid + 1), right);
            }
        }
        private static void InsertionSort(ref IList<int> DataToSort, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int temp = DataToSort[i];
                int j = i - 1;
                while (j >= left && DataToSort[j] > temp)
                {
                    DataToSort[j + 1] = DataToSort[j];
                    j--;
                }
                DataToSort[j + 1] = temp;
            }

        }
        #endregion
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
        public static IList<int> QuickSort(this IList<int> DataToSort)
        {
            QuickSort(ref DataToSort, 0, DataToSort.Count - 1);
            return DataToSort;
        }
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
        public static IList<int> SelectionSort(this IList<int> DataToSort)
        {
            for (int i = 0; i < DataToSort.Count - 1; i++)
            {
                int minIdx = i;
                for (int j = i + 1; j < DataToSort.Count; j++)
                {
                    if (DataToSort[j] < DataToSort[minIdx])
                    {
                        minIdx = j;
                    }
                }
                Swaper(ref DataToSort, minIdx, i);
            }
            return DataToSort;
        }
        public static IList<int> QuickSortWithInsert(this IList<int> DataToSort)
        {
            if (DataToSort.Count - 1 <= 32)
            {
                //return DataToSort.InsertionSort();
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
        public static IList<int> BitonicSort(this IList<int> DataToSort)
        {
            Sort(ref DataToSort, 0, DataToSort.Count, 1);
            return DataToSort;
        }
        public static IList<int> MergeSort(this IList<int> DataToSort)
        {
            MergeSort(ref DataToSort, 0, DataToSort.Count - 1);

            return DataToSort;
        }
        public static IList<int> InsertionSort(this IList<int> DataToSort)
        {
            InsertionSort(ref DataToSort, 0, DataToSort.Count - 1);
            return DataToSort;

        }
        /// <summary>
        /// </summary>
        /// <param name="DataToSort">Data to sort</param>
        /// <param name="RunSize">Consider size of run</param>
        /// <returns></returns>
        public static IList<int> TimSort(this IList<int> DataToSort,int RunSize=32)
        {
            for (int i = 0; i < DataToSort.Count - 1; i += RunSize)
                InsertionSort(ref DataToSort, i, Math.Min((i + RunSize - 1),
                                            (DataToSort.Count - 1)));

            for (int size = RunSize; size < DataToSort.Count-1;
                                     size = 2 * size)
            {
                for (int left = 0; left < DataToSort.Count-1;
                                     left += 2 * size)
                {
                    int mid = left + size - 1;
                    int right = Math.Min((left + 2 * size - 1),
                                                    (DataToSort.Count - 1));

                    if (mid < right)
                        MergeMethod(ref DataToSort, left, mid, right);
                }
            }
            return DataToSort;
        }

    }
}
