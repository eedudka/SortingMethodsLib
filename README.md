# SortingMethodsLib
## This library currently implements such sorts as:
- BoubleSort(ready) 09 jule 22
- CoctailSort(ready) 09 jule 22
- CombSort(ready) 09 jule 22
- InsertionSort(ready) 09 jule 22
- ShellSort(ready) 09 jule 22
- ShellSortK(ready) 16 jule 22
- ShellSortHib(ready) 16 jule 22
- QuickSort(ready) 14 jule 22
- ShellSortSedgwick(in progress)
- ShellSortPratt(in progress) 
- TreeSort(in refactoring) 14 jule 22
- GnomeSort(ready) 17 jule 22
- SelectSort(in refactoring) 17 jule 22
- Heapsort(in progress)
- LSDSort(in progress)
- MSDSort(in progress)
- BitonicSort(in progress)
- Timsort(in progress)
- GrailSort(in progress)
- pdqsort(in progress)
- BoostSort(in progress)
*Also, upon completion of the implementation of all these algorithms, Automatic Sorting Selection (ASS) will be implemented*

11 out of 21 (not counting variations of the same algorithms) are already ready and tested

## Code Exsample
```C#
 static void Main(string[] args)
        {
            var SortedData = GenerateRandomArray().CombSort();
        }
 public static int[] GenerateRandomArray()
```
- This library works as extension methods for any enumerated structure, which in my opinion makes it more flexible for use in code.