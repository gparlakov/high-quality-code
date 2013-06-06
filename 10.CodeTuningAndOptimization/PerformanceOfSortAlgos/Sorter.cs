using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

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

        public static List<T> QuickSort<T>(IList<T> unsorted) where T : IComparable<T>
        {
            if (unsorted.Count <= 1 ||
                unsorted[0].CompareTo(unsorted[unsorted.Count - 1]) == 0)
            {
                return unsorted.ToList<T>();
            }

            T pivot = unsorted[0];
            List<T> left = new List<T>();
            List<T> right = new List<T>();
            for (int i = 1; i < unsorted.Count; i++)
            {
                if (unsorted[i].CompareTo(pivot) < 0)
                {
                    left.Add(unsorted[i]);
                }
                else
                {
                    right.Add(unsorted[i]);
                }
            }
            
            left = QuickSort<T>(left);
            right = QuickSort<T>(right);
            left.Add(pivot);
            left.AddRange(right);

            return left;
        }

        public static T[] InsertionSort<T>(T[] unsorted) where T : IComparable<T>
        {
            T[] sorted = new T[unsorted.Length];

            for (int i = 0; i < unsorted.Length; i++)
            {
                for (int j = 1; j < unsorted.Length; j++)
                {
                    if (unsorted[i].CompareTo(unsorted[j]) > 0)
                    {
                        //....TODO
                    }
                }
            }

            return sorted;
        }
    }
}
