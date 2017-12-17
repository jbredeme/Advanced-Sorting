/**
 * @author Jarid Bredemeier
 *
 */

public class MergeSort {
	/**
	 * This is the interface to the user of the class and makes the invocation call
	 * to the supporting class for merge sorting.
	 * 
	 * @param arr an input array of integers.
	 * @param numElements number of elements in the array.
	 */
	public static void mergeSort(int[] arr, int numElements) {
		rMergeSort(arr, 0, (numElements - 1));
		
	}
	
	/**
	 * Recursively divides the array into smaller sub-arrays (conceptually) until
	 * the array is at atomic level (one item). The base case array is then merged
	 * with its other half to form a larger ordered array. All sub-arrays are ordered
	 * because an array of one element is and ordered array.
	 * 
	 * @param arr an input array of integers.
	 * @param lowerBound first position of the array.
	 * @param upperBound position of the last item inserted into the array.
	 */
	private static void rMergeSort(int[] arr, int lowerBound, int upperBound) {
		int middle = (upperBound + lowerBound) / 2;
		
		if(lowerBound < upperBound) {					//=> base case, when array has only one element
			rMergeSort(arr, lowerBound, middle);		//=> left-side of array
			rMergeSort(arr, (middle + 1), upperBound);	//=> right-side of array
			merge(arr, lowerBound, middle, upperBound);
			
		}

		
	}
	
	/**
	 * Takes two halves of a sub-array and merges them in ascending order numerically into a
	 * larger second array. The larger array is then copied back into the original array.
	 * Each sub-ray is also an ordered array (ascending).
	 * 
	 * @param arr an input array of integers.
	 * @param lowerBound first position of the array.
	 * @param middle the middle position of the occupied array.
	 * @param upperBound position of the last item inserted into the array.
	 */
	private static void merge(int[] arr, int lowerBound, int middle, int upperBound) {
		int[] xferArr = new int[(upperBound - lowerBound) + 1];		//=> work array
		int x = 0;													//=> work array index
		int lftLowerBound = lowerBound;								//=> left-side lower bound index
		int rghtLowerBound = middle + 1;							//=> right-side lower bound index
		
		while((lftLowerBound <= middle) && (rghtLowerBound <= upperBound)) {
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

        for(int i = 0; i < xferArr.length; i++) {   //=> transfer elements back into the original array
            arr[lowerBound + i] = xferArr[i];

        }		
		
	}
	
	/**
	 * Prints the elements in an array
	 * 
	 * @param arr integer input array.
	 * @param numElements number of elements in the array.
	 */
	public static void displayArray(int[] arr, int numElements) {
	    for(int i = 0; i < numElements; i++) {
	        if(i != (numElements - 1)) {
	            System.out.print(arr[i] + ", ");
	
	        } else {
	        	System.out.println(arr[i]);
	
	        }
	
	    }
	
	}	
	
}
