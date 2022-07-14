# SortingMethodsLib
## This library currently implements such sorts as:
- BoubleSort(ready)
- CoctailSort(ready)
- CombSort(ready)
- InsertionSort(ready)
- ShellSort(ready)
- ShellSortMemmorySafe(ready)
- QuickSort(ready)
- ShellSortHib(in progress)
- ShellSortSedgwick(in progress)
- ShellSortPratt(in progress)
- TreeSort(in progress)
- GnomeSort(in progress)
- SelectSort(in progress)
- Heapsort(in progress)
- LSDSort(in progress)
- MSDSort(in progress)
- BitonicSort(in progress)
- Timsort(in progress)
- GrailSort(in progress)
- pdqsort(in progress)
- BoostSort(in progress)

*Also, upon completion of the implementation of all these algorithms, Automatic Sorting Selection (ASS) will be implemented*

## Code Exsample
```C#
 static void Main(string[] args)
        {
            var SortedData = GenerateRandomArray().CombSort();
        }
        public static int[] GenerateRandomArray()
```
- This library works as extension methods for any enumerated structure, which in my opinion makes it more flexible for use in code.