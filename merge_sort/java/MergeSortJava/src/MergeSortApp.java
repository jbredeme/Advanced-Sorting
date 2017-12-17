/**
 * @author Jarid Bredemeier
 *
 */

import java.io.*;
import java.text.*;
import java.util.*;

public class MergeSortApp {
	/**
	 * Demonstration program for merge sort. This application prompts the user for
	 * array size, and a range of numbers used to randomly generate values and populate
	 * the array. Then it displays the unsorted array, sorts the array, then displays the
	 * sorted array for validation of correctness.
	 * 
	 * @param args command-line arguments
	 */
	public static void main(String[] args) throws IOException {
        Random rnd = new Random();
        DateFormat dateFmt = new SimpleDateFormat("yyyy/MM/dd HH:mm:ss");
        Date date = new Date();
        final int MAX_SIZE = 64;
        Boolean isValid;                        //=> do loop flag
        int size = 0;                           //=> size of array
        int[] arr;                              //=> array
        String range;                           //=> range input
        String[] bounds;                        //=> split range input
        int upperBound = 0, lowerBound = 0;     //=> range bounds
        String message = "Welcome to Merge Sort in Java!";
        Scanner scan = new Scanner(System.in);
        
        System.out.println(message);

        do {                            //=> input entry for array size
            isValid = false;
            System.out.println("\nPlease enter an array size greater than 0 and less than or equal to " + MAX_SIZE + ":");
        	
            try {                       //=> guard against non-numeric data
            	size = scan.nextInt();

                try {                   //=> guard against invalid array size
                    if(size <= 0) {
                        throw new ArrayIndexOutOfBoundsException();

                    }

                    try {
                        if(size > MAX_SIZE) {
                            throw new ArrayIndexOutOfBoundsException();

                        }
                        isValid = true;

                    } catch(ArrayIndexOutOfBoundsException e) {
                        System.out.printf(".. Invaild input, %d is larger than %d.\n", size, MAX_SIZE);

                    }

                } catch(ArrayIndexOutOfBoundsException e) {
                    System.out.printf(".. Invaild input, %d is not a valid size.\n", size);

                }

            } catch(InputMismatchException e) {
                System.out.print(".. Invaild input, input must be of TYPE integer.\n");

            } finally {
            	scan.nextLine();		//=> consume the rest of the line

            }
            
        } while (isValid != true);
        
        do {                            //=> input entry for element range
        	isValid = false;
            System.out.println("\nPlease enter a range (integer values only) lower bound <space> upper bound:");
            
            try {                       //=> check for correct range format (two values)
                range = scan.nextLine();
                bounds = range.split("\\s");
                
                if (bounds.length != 2) {
                    throw new ArrayIndexOutOfBoundsException();

                }

                try {                   //=> guard against non-numeric data
                    lowerBound = Integer.parseInt(bounds[0]);
                    upperBound = Integer.parseInt(bounds[1]);


                    try {               //=> guard against non-ascending range
                        if (upperBound < lowerBound) {
                            throw new Exception();
                            
                        } else {
                            isValid = true;

                        }

                    } catch(Exception e){
                        System.out.printf(".. Invaild input, lower bound(%d) is larger than upper bound(%d).\n", lowerBound, upperBound);

                    }

                } catch(Exception e) {
                    System.out.print(".. Invaild input, both inputs must be of TYPE integer.\n");

                }

            } catch (ArrayIndexOutOfBoundsException e) {
                System.out.print(".. Invalid range, range requires two values.\n");

            }

        } while (isValid != true);
        
        scan.close();
        arr = new int[size];                        //=> instantiate the array
        for(int i = 0; i < arr.length; i++) {       //=> populate the array
            arr[i] = rnd.nextInt((upperBound - lowerBound) + 1) + lowerBound;

        }

        System.out.printf("\n\n> Status: Unsorted\n> Timestamp: %s\n> Type: %s\n> Size: %s\n> Range: %d to %d\n", dateFmt.format(date), arr.getClass().getComponentType(), size, lowerBound, upperBound);
        MergeSort.displayArray(arr, arr.length);    //=> display the unsorted array

        MergeSort.mergeSort(arr, arr.length);       //=> sort the array using mergeSort

        System.out.printf("\n\n> Status: Sorted\n> Timestamp: %s\n> Merge Sort (recursive)\n> Type: %s\n> Size: %d\n> Range: %d to %d\n", dateFmt.format(date), arr.getClass().getComponentType(), size, lowerBound, upperBound);
        MergeSort.displayArray(arr, arr.length);    //=> display the sorted array        

	}

}
