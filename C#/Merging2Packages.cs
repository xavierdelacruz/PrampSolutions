using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    public static int[] GetIndicesOfItemWeights(int[] arr, int limit)
    {
      if (arr.Length == 0) {
        return new int[0];
      }
      
      var dict = new Dictionary<int, int>();
      
      for (int i = 0; i < arr.Length; i++) {
        if (!dict.ContainsKey( arr[i])) {
          dict.Add(arr[i], i);
        } else {
          dict[arr[i]] = i;
        }
      }
      
      for (int j = arr.Length-1; j >= 0; j--) {
        var diff = limit - arr[j];
        
        if (dict.ContainsKey(diff) && dict[diff] != j) {
          return new int[2] {Math.Max(dict[diff], j), Math.Min(dict[diff], j)};
        }
      }      
      return new int[0];      
    }

    static void Main(string[] args)
    {
      // Some test cases
      var arr1 = new int[0];
      var lim1 = 1;
      var ans1 = new int[0];
      Console.WriteLine(ans1.SequenceEqual(GetIndicesOfItemWeights(arr1, lim1)));
      
      var arr2 = new int[1] {1};
      var lim2 = 5;
      var ans2 = new int[0];
      Console.WriteLine(ans2.SequenceEqual(GetIndicesOfItemWeights(arr2, lim2)));
            
      var arr3 = new int[5] { 4, 5, 10, 15, 16};
      var lim3 = 21;
      var ans3 = new int[2] {3, 1};
      Console.WriteLine(ans3.SequenceEqual(GetIndicesOfItemWeights(arr3, lim3)));
      
      var arr4 = new int[5] { 4, 4, 4, 4 ,4};
      var lim4 = 8;
      var ans4 = new int[2] {1, 0};
      Console.WriteLine(ans4.SequenceEqual(GetIndicesOfItemWeights(arr4, lim4)));
  
    }
}

