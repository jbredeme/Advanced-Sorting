using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSortLib {

    public class MergeSort {
        /// <summary>
        /// Accepts an unsorted array of integers and the current number of elements in the array then invocates a 
        /// helper function that performs the recursive implemenation of merge sort. Asymptotic run-time O(nlogn).
        /// </summary>
        /// <param name="arr">input array of type integer<./param>
        /// <param name="numElements">number of elements currently in the array.</param>
        public static void mergeSort(int[] arr, int numElements) {
            rMergeSort(arr, 0, (numElements - 1));

        }

        /// <summary>
        /// Implements head recursion to sub-divide an array until it can no longer be divided anymore (atom) which
        /// is the base case. The recursion stack then returns and calls Merge to merge the two sub-arrays into a 
        /// larged combined array. These sub-arrays are a product of the recursive calls and therefore are sorted
        /// arrays (i.e. an array of one element is a sorted array) which facilitates sorting the larger array.
        /// </summary>
        /// <param name="arr">input integer array to be sorted.</param>
        /// <param name="lowerBound">begining array index of arr.</param>
        /// <param name="upperBound">last array index of arr.</param>
        private static void rMergeSort(int[] arr, int lowerBound, int upperBound) {
            int middle;

            if(lowerBound < upperBound) {                   //=> base case, when array length is size one
                middle = (upperBound + lowerBound) / 2;
                rMergeSort(arr, lowerBound, middle);        //=> recursive call split the array first-half
                rMergeSort(arr, (middle + 1), upperBound);  //=> recursive call split the array second-half
                Merge(arr, lowerBound, middle, upperBound);

            }


        }

        /// <summary>
        /// Merge takes values from an input array and sorts them into a transfer array, the final step is to
        /// copy the contents of the transfer array (which are sorted) back into the input array at the correct
        /// indicies.
        /// </summary>
        /// <param name="arr">input integer array to be sorted.</param>
        /// <param name="lowerBound">begining array index of arr.</param>
        /// <param name="middle">middle index of the array.</param>
        /// <param name="upperBound">last array index of arr.</param>
        private static void Merge(int[] arr, int lowerBound, int middle, int upperBound) {
            int[] xferArr = new int[(upperBound - lowerBound) + 1];
            int x = 0;                                      //=> transfer array index
            int lftLowerBound = lowerBound;                 //=> left-side lower bound index
            int rghtLowerBound = middle + 1;                //=> right-side lower bound index
            
            while ((lftLowerBound <= middle) && (rghtLowerBound <= upperBound)) {   //=> both sides have elements
                if (arr[lftLowerBound] < arr[rghtLowerBound]) {
                    xferArr[x] = arr[lftLowerBound];
                    lftLowerBound += 1;

                } else {
                    xferArr[x] = arr[rghtLowerBound];
                    rghtLowerBound += 1;

                }
                x += 1;

            }

            while(lftLowerBound <= middle) {            //=> left-side has elements
                xferArr[x] = arr[lftLowerBound];
                lftLowerBound += 1;
                x += 1;

            }

            while(rghtLowerBound <= upperBound) {       //=> right-side has elements
                xferArr[x] = arr[rghtLowerBound];
                rghtLowerBound += 1;
                x += 1;

            }

            for(int i = 0; i < xferArr.Length; i++) {   //=> transfer elements back into the orginal array
                arr[lowerBound + i] = xferArr[i];

            }

        }

        /// <summary>
        /// Writes the array to the console window.
        /// </summary>
        /// <param name="arr">input integer array to be displayed.</param>
        /// <param name="numElements">number of elements in the array.</param>
        public static void displayArray(int[] arr, int numElements) {
            for(int i = 0; i < numElements; i++) {
                if(i != (numElements - 1)) {
                    Console.Write(arr[i] + ", ");

                } else {
                    Console.WriteLine(arr[i]);

                }

            }

        }

    }

}