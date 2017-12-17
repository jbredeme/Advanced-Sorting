using System;
using MergeSortLib;

namespace MergeSortApp {
    /// <summary>
    /// Performs merge sort (recursive implementation) on an integer array.
    /// </summary>
    class MergeSortApp {

        static void Main(string[] args) {
            Random rnd = new Random();
            const int MAX_SIZE = 64;
            Boolean isValid;                        //=> do loop flag
            int size = 0;                           //=> size of array
            int[] arr;                              //=> array
            string range;                           //=> range input
            string[] bounds;                        //=> split range input
            int upperBound = 0, lowerBound = 0;     //=> range bounds
            string message = "Welcome to Merge Sort in C#";

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(message);
 
            do {                            //=> input entry for array size
                Console.ForegroundColor = ConsoleColor.White;
                isValid = false;
                Console.WriteLine("\nPlease enter an array size that is greater than 0 and less than or equal to {0}:", MAX_SIZE);

                try {                       //=> guard against non-numeric data
                    size = Convert.ToInt32(Console.ReadLine());     

                    try {                   //=> guard against invalid array size
                        if (size <= 0) {
                            throw new OverflowException();

                        }

                        try {
                            if (size > MAX_SIZE) {
                                throw new OverflowException();

                            }

                            isValid = true;

                        } catch (OverflowException e) {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine(".. Invaild input, {0} is larger than {1}.\n", size, MAX_SIZE);

                        }
                       
                    }
                    catch (OverflowException e) {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(".. Invaild input, you cannot have an array of size {0}.\n", size);

                    }

                } catch (FormatException e) {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(".. Invaild input, input must be of TYPE integer.\n");

                }

            } while (isValid != true);

            do {                            //=> input entry for element range
                Console.ForegroundColor = ConsoleColor.White;
                isValid = false;

                Console.WriteLine("\nPlease enter a range (integer values only) lower bound <space> upper bound:");
                range = Console.ReadLine();
                bounds = range.Split(' ', '\t');

                try {                       //=> check for correct range format (two values)
                    if (bounds.Length != 2) {
                        throw new ArgumentOutOfRangeException();

                    }

                    try {                   //=> guard against non-numeric data
                        lowerBound = Convert.ToInt32(bounds[0]);
                        upperBound = Convert.ToInt32(bounds[1]);


                        try {               //=> guard against non-ascending range
                            if (upperBound < lowerBound) {
                                throw new Exception();
                                
                            } else {
                                isValid = true;

                            }

                        } catch(Exception e){
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine(".. Invaild input, lower bound({0}) is larger than upper bound({1}).\n", lowerBound, upperBound);

                        }

                    } catch(FormatException e) {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(".. Invaild input, both inputs must be of TYPE integer.\n");

                    }

                } catch (ArgumentOutOfRangeException e) {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(".. Invalid range, range requires two values.\n");

                }

            } while (isValid != true);

            arr = new int[size];                        //=> instantiate the array

            for(int i = 0; i < arr.Length; i++) {       //=> populate the array
                arr[i] = rnd.Next(lowerBound, upperBound);
 
            }
            
            Console.WriteLine("\n\n> Status: Unsorted\n> Timestamp: {0}\n> Type: {1}\n> Size: {2}\n> Range: {3} to {4}\n", DateTime.Now, arr.GetType(), size, lowerBound, upperBound);
            MergeSort.displayArray(arr, arr.Length);    //=> display the unsorted array

            MergeSort.mergeSort(arr, arr.Length);       //=> sort the array using mergeSort

            Console.WriteLine("\n\n> Status: Sorted\n> Timestamp: {0}\n> Merge Sort (recursive)\n> Type: {1}\n> Size: {2}\n> Range: {3} to {4}\n", DateTime.Now, arr.GetType(), size, lowerBound, upperBound);
            MergeSort.displayArray(arr, arr.Length);    //=> display the sorted array

        }

    }

}