using System;
using System.Diagnostics;
using System.Linq;

namespace PerformanceOfSortAlgos
{
    public static class Sorter
    {   
        //TODO Add exception handling
        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            Debug.Assert(arr != null && arr.Length > 0);

            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }

            Debug.Assert(arr != null && arr.Length > 0);
        }

        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            var length = arr.Length;
            Debug.Assert(startIndex <= endIndex);
            Debug.Assert(startIndex >= 0 && startIndex < length);
            Debug.Assert(endIndex > 0 && endIndex < length);
            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            Debug.Assert(minElementIndex >= startIndex && minElementIndex <= endIndex);
            return minElementIndex;
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            T oldX = x;
            x = y;
            y = oldX;
        }
    }
}
