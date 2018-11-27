using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingAlgorithms
{
    class Program
    {
        private static Random rdm;
        
        static void Main(string[] args)
        {
            rdm = new Random();
            
            var array = new IComparable[50];
            for(int i = 0; i < array.Length; i++)
                array[i] = (rdm.NextDouble() * (70 - 10)) + 10;
            
            MergeSort(array);
            //Quicksort(array);
            //HeapSort(array);
            
            for(int i = 0; i < array.Length; i++)
                Console.WriteLine("{0}", array[i]);
        }

        #region MERGE
        
        static void MergeSort(IComparable[] array)
        {
            MergeSort(array, 0, array.Length);
        }
        
        static void MergeSort(IComparable[] array, int startIndex, int endIndex)
        {
            if (startIndex < endIndex - 1) {
                int middle = (startIndex + endIndex) / 2;
                int dif = endIndex - startIndex;

                MergeSort(array, startIndex, middle);
                MergeSort(array, middle, endIndex);

                IComparable[] aux = new IComparable[dif];
                for (int i = startIndex, j = middle, k = 0; k < dif; k++)
                    if (i == middle)
                        aux[k] = array[j++];
                    else if (j == endIndex)
                        aux[k] = array[i++];
                    else if (array[j].CompareTo(array[i]) < 0)
                        aux[k] = array[j++];
                    else
                        aux[k] = array[i++];

                for (var k = 0; k < dif; k++)
                    array[startIndex + k] = aux[k];
            }
        }
        
        #endregion

        #region QUICK

        static void Quicksort(IComparable[] elements)
        {
            Quicksort(elements, 0, elements.Length - 1);
        }
        
        static void Quicksort(IComparable[] elements, int left, int right)
        {
            int i = left, j = right;
            IComparable pivot = elements[(left + right) / 2];
 
            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                    i++;
 
                while (elements[j].CompareTo(pivot) > 0)
                    j--;
 
                if (i <= j)
                {
                    // Swap
                    IComparable tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;
 
                    i++;
                    j--;
                }
            }
 
            // Recursive calls
            if (left < j)
                Quicksort(elements, left, j);
 
            if (i < right)
                Quicksort(elements, i, right);
        }
        
        #endregion
        
        #region HEAP
        static void HeapSort (IComparable[] array)
        {
            int heapSize = array.Length;

            BuildMaxHeap (array);

            for (int i = heapSize-1; i >= 1; i--)
            {
                Swap (array, i, 0);
                heapSize--;
                Sink (array, heapSize, 0);
            }
        }

        static void BuildMaxHeap (IComparable[] array)
        {
            int heapSize = array.Length;

            for (int i = (heapSize/2) - 1; i >= 0; i--)
            {
                Sink (array, heapSize, i);
            }
        }

        static void Sink (IComparable[] array, int heapSize, int toSinkPos)
        {
            if (GetLeftKidPos (toSinkPos) >= heapSize)
            {
                // No left kid => no kid at all
                return;
            }

            int largestKidPos;
            bool leftIsLargest;

            if (GetRightKidPos (toSinkPos) >= heapSize || array [GetRightKidPos (toSinkPos)].CompareTo (array [GetLeftKidPos (toSinkPos)]) < 0)
            {
                largestKidPos = GetLeftKidPos (toSinkPos);
                leftIsLargest = true;
            } else
            {
                largestKidPos = GetRightKidPos (toSinkPos);
                leftIsLargest = false;
            }
			


            if (array [largestKidPos].CompareTo (array [toSinkPos]) > 0)
            {
                Swap (array, toSinkPos, largestKidPos);

                if (leftIsLargest)
                {
                    Sink (array, heapSize, GetLeftKidPos (toSinkPos));

                } else
                {
                    Sink (array, heapSize, GetRightKidPos (toSinkPos));
                }
            }

        }

        static void Swap (IComparable[] array, int pos0, int pos1)
        {
            var tmpVal = array [pos0];
            array [pos0] = array [pos1];
            array [pos1] = tmpVal;
        }

        static int GetLeftKidPos (int parentPos)
        {
            return (2 * (parentPos + 1)) - 1;
        }

        static int GetRightKidPos (int parentPos)
        {
            return 2 * (parentPos + 1);
        }
        #endregion
    }
}