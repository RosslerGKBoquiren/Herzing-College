package HugeArrayPackage;

public class HugeArray {

    public static void main(String[] args) {
        
        int N = 1000;
        int[] a = new int[N * N * N * N];
        
//        int M = 200;
//        int[] b = new int[M * M * M * M];
//      
    } 
} 




/* from what I understand, the error that is shown is NegativeArraySizeException
 * due to the fact that 'int' data type can only store +- ~2Billion, meanwhile the calculations being performed where N = 1000
 * results in 1Trillion.  Since the result exceeds the maximum it can store, the excess gets wrapped around the negative side of the integer range;
 * hence why the error shows NegativeArraySizeException.*/


/* For the second part, since M = 200; it doesn't result into an error because the results
 * are within the +- 2Billion range where the result of the calculation is 1,600,000,000. */
