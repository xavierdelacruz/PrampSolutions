using System;
using System.Linq;
using System.Collections.Generic;

class Solution
{
    public static int[] SortKMessedArray(int[] arr, int k)
    {
        if (arr.Length <= 1 || k == 0 || k >= arr.Length)
        {
            return arr;
        }

        // Because Pramp would not let me use a PQ, as they are using < NET 6
        // Build our sliding window.
        var pq = new SortedSet<int>();
        for (int i = 0; i < k + 1; i++)
        {
            pq.Add(arr[i]);
        }

        // Start the iteration here.
        // We remove the minimum element of our pq, and put it in the array idx
        // determined by j-(k+1), which is the start of the window.
        for (int j = k + 1; j < arr.Length; j++)
        {
            arr[j - (k + 1)] = pq.Min;
            pq.Remove(pq.Min);
            pq.Add(arr[j]);
        }

        // Finally, we have the remaining elements in our pq
        // They are guaranteed to be sorted
        for (int l = arr.Length - pq.Count; l < arr.Length; l++)
        {
            arr[l] = pq.Min;
            pq.Remove(pq.Min);
        }

        return arr;
    }

    private static void PrintResult(int[] result)
    {
        Console.WriteLine();
        Console.Write("[");
        foreach (var res in result)
        {
            Console.Write(res + ",");
        }
        Console.Write("]");
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        // [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
        var t1 = new int[] { 1, 4, 5, 2, 3, 7, 8, 6, 10, 9 };
        // {1,|4, 5, 2, 3, 7|, 8, 6, 10, 9};
        var k1 = 2;
        PrintResult(SortKMessedArray(t1, k1));

        // Return empty
        var t2 = new int[] { };
        var k2 = 2;
        PrintResult(SortKMessedArray(t2, k2));

        // Return the same array
        var t3 = new int[] { 1, 4, 5, 2, 3, 7, 8, 6, 10, 9 };
        var k3 = 0;
        PrintResult(SortKMessedArray(t3, k3));

        // Return the same array
        var t4 = new int[] { 1, 5, 2 };
        var k4 = 3;
        PrintResult(SortKMessedArray(t4, k4));

        // Return the same array (but it did attempt to sort)
        var t5 = new int[] { 1, 1, 1 };
        var k5 = 2;
        PrintResult(SortKMessedArray(t5, k5));

        // Return the same array
        var t6 = new int[] { 3, 5, 1, 4 };
        var k6 = 1;
        PrintResult(SortKMessedArray(t6, k6));
    }
}