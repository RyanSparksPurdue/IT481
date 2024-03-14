//IT481 - Ryan Sparks - Unit 7 Assignment
// I designed this to test the different sorting methods interchangeably through using the #define preprocessor directive.
// Comment out the sorting algorithms you wish not to run
// Remove comments from the algorithm you wish to test
// Rather than pulling large data from a source as the assignment suggests, the code will generate a random array of 10, 1000, or 10000 for small, medium, large respectively.

#define MERGE_SORT 
//#define BUBBLE_SORT 
//#define QUICK_SORT

using System;

class Program
{


    public static void MergeSort(int[] arr)
    //Merge sort algorithm from geeksforgeeks. Retrieved from https://www.geeksforgeeks.org/merge-sort/
    {
        if (arr.Length < 2)
            return;

        int mid = arr.Length / 2;
        int[] left = new int[mid];
        int[] right = new int[arr.Length - mid];


        for (int i = 0; i < mid; i++)
        {
            left[i] = arr[i];
        }
        for (int i = mid; i < arr.Length; i++)
        {
            right[i - mid] = arr[i];
        }

        MergeSort(left);
        MergeSort(right);
        Merge(left, right, arr);
    }

    private static void Merge(int[] left, int[] right, int[] arr)
    {
        int i = 0, j = 0, k = 0;


        while (i < left.Length && j < right.Length)
        {
            if (left[i] <= right[j])
            {
                arr[k++] = left[i++];
            }
            else
            {
                arr[k++] = right[j++];
            }
        }


        while (i < left.Length)
        {
            arr[k++] = left[i++];
        }


        while (j < right.Length)
        {
            arr[k++] = right[j++];
        }
    }

    public static void BubbleSort(int[] arr)
    //Bubble sort algorithm from geeksforgeeks. Retrieved from https://www.geeksforgeeks.org/bubble-sort/
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {

                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    public static void QuickSort(int[] arr)
    //Quick sort algorithm from geeksforgeeks. Retrieved from https://www.geeksforgeeks.org/quick-sort/
    {
        QuickSort(arr, 0, arr.Length - 1);
    }

    private static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(arr, low, high);
            QuickSort(arr, low, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, high);
        }
    }

    private static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;
        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
        int temp1 = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = temp1;
        return i + 1;
    }

    static void Main()
    {
        //Good place to verify the sorting method you wish to use is not grey.
#if MERGE_SORT
        Console.WriteLine("*******************************************");
        Console.WriteLine("**************** Merge Sort ****************");
        Console.WriteLine("*******************************************");
#elif BUBBLE_SORT
        Console.WriteLine("*******************************************");
        Console.WriteLine("**************** Bubble Sort ****************");
        Console.WriteLine("*******************************************");
#elif QUICK_SORT
        Console.WriteLine("*******************************************");
        Console.WriteLine("**************** Quick Sort ****************");
        Console.WriteLine("*******************************************");
#endif

        // Small dataset
        int[] smallData = { 9, 7, 5, 3, 1, 8, 6, 4, 2, 0 };
        Console.WriteLine("Small dataset before sorting:");
        PrintArray(smallData);
#if MERGE_SORT
        DateTime startTimeSmallMerge = DateTime.Now;
        MergeSort(smallData);
        DateTime endTimeSmallMerge = DateTime.Now;
        Console.WriteLine("Small dataset after sorting:");
#elif BUBBLE_SORT
        DateTime startTimeSmallBubble = DateTime.Now;
        BubbleSort(smallData);
        DateTime endTimeSmallBubble = DateTime.Now;
        Console.WriteLine("Small dataset after sorting:");
#elif QUICK_SORT
        DateTime startTimeSmallQuick = DateTime.Now;
        QuickSort(smallData);
        DateTime endTimeSmallQuick = DateTime.Now;
        Console.WriteLine("Small dataset after sorting:");
#endif
        PrintArray(smallData);
#if MERGE_SORT
        Console.WriteLine($"Time taken to sort small dataset with Merge Sort: {(endTimeSmallMerge - startTimeSmallMerge).TotalMilliseconds} milliseconds");
#elif BUBBLE_SORT
        Console.WriteLine($"Time taken to sort small dataset with Bubble Sort: {(endTimeSmallBubble - startTimeSmallBubble).TotalMilliseconds} milliseconds");
#elif QUICK_SORT
        Console.WriteLine($"Time taken to sort small dataset with Quick Sort: {(endTimeSmallQuick - startTimeSmallQuick).TotalMilliseconds} milliseconds");
#endif

        Console.WriteLine();

        // Medium dataset
        int[] mediumData = GenerateRandomArray(1000);
        Console.WriteLine("Medium dataset before sorting:");
        PrintArray(mediumData);
        DateTime startTimeMedium = DateTime.Now;
#if MERGE_SORT
        MergeSort(mediumData);
#elif BUBBLE_SORT
        BubbleSort(mediumData);
#elif QUICK_SORT
        QuickSort(mediumData);
#endif
        DateTime endTimeMedium = DateTime.Now;
        Console.WriteLine("Medium dataset after sorting:");
        PrintArray(mediumData);
        Console.WriteLine($"Time taken to sort medium dataset: {(endTimeMedium - startTimeMedium).TotalMilliseconds} milliseconds");
        Console.WriteLine();

        // Large dataset
        int[] largeData = GenerateRandomArray(10000);
        Console.WriteLine("Large dataset before sorting:");
        PrintArray(largeData);
        DateTime startTimeLarge = DateTime.Now;
#if MERGE_SORT
        MergeSort(largeData);
#elif BUBBLE_SORT
        BubbleSort(largeData);
#elif QUICK_SORT
        QuickSort(largeData);
#endif
        DateTime endTimeLarge = DateTime.Now;
        Console.WriteLine("Large dataset after sorting:");
        PrintArray(largeData);
        Console.WriteLine($"Time taken to sort large dataset: {(endTimeLarge - startTimeLarge).TotalMilliseconds} milliseconds");

#if MERGE_SORT
        Console.WriteLine("*******************************************");
        Console.WriteLine("**************** Merge Sort ****************");
        Console.WriteLine("*******************************************");
        Console.WriteLine($"Time taken to sort small dataset with Merge Sort: {(endTimeSmallMerge - startTimeSmallMerge).TotalMilliseconds} milliseconds");
        Console.WriteLine($"Time taken to sort medium dataset with Merge Sort: {(endTimeMedium - startTimeMedium).TotalMilliseconds} milliseconds");
        Console.WriteLine($"Time taken to sort large dataset with Merge Sort: {(endTimeLarge - startTimeLarge).TotalMilliseconds} milliseconds");
#elif BUBBLE_SORT
        Console.WriteLine("*******************************************");
        Console.WriteLine("**************** Bubble Sort ****************");
        Console.WriteLine("*******************************************");
        Console.WriteLine($"Time taken to sort small dataset with Bubble Sort: {(endTimeSmallBubble - startTimeSmallBubble).TotalMilliseconds} milliseconds");
        Console.WriteLine($"Time taken to sort medium dataset with Bubble Sort: {(endTimeMedium - startTimeMedium).TotalMilliseconds} milliseconds");
        Console.WriteLine($"Time taken to sort large dataset with Bubble Sort: {(endTimeLarge - startTimeLarge).TotalMilliseconds} milliseconds");
#elif QUICK_SORT
        Console.WriteLine("*******************************************");
        Console.WriteLine("**************** Quick Sort ****************");
        Console.WriteLine("*******************************************");
        Console.WriteLine($"Time taken to sort small dataset with Quick Sort: {(endTimeSmallQuick - startTimeSmallQuick).TotalMilliseconds} milliseconds");
        Console.WriteLine($"Time taken to sort medium dataset with Quick Sort: {(endTimeMedium - startTimeMedium).TotalMilliseconds} milliseconds");
        Console.WriteLine($"Time taken to sort large dataset with Quick Sort: {(endTimeLarge - startTimeLarge).TotalMilliseconds} milliseconds");
#endif
    }

    static int[] GenerateRandomArray(int size)
    {
        Random random = new Random();
        int[] arr = new int[size];
        for (int i = 0; i < size; i++)
        {
            arr[i] = random.Next();
        }
        return arr;
    }

    static void PrintArray(int[] arr)
    {
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}
