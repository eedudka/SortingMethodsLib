# SortingMethodsLib

## This library currently implements such sorts as:
- BoubleSort
- CoctailSort
- CombSort
- InsertionSort
- ShellSort
- ShellSortMemmorySafe
- QuickSort(in process)

## Code Exsample
```C#
 static void Main(string[] args)
        {
            var SortedData = GenerateRandomArray().CombSort();
        }
        public static int[] GenerateRandomArray()
```
- This library works as extension methods for any enumerated structure, which in my opinion makes it more flexible for use in code.