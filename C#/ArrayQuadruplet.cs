using System;
using System.Collections.Generic;

class Solution
{
    public static int[] FindArrayQuadruplet(int[] arr, int s)
    {
      // Check the constraint on the other end, because we are looking for 4 pointers
      if (arr.Length < 4) {
        // ASSUME (Clarify with nahid)
        return new int[0];
      }
      
      // Because we just want to return the FIRST quadruplet that we find
      // let's do some sorting
      // O(nlogn)
      Array.Sort(arr);
      
      int i = 0;
      
      while (i < arr.Length - 3) {
        
        int j = i + 1;
        // I need if statements here to handle duplicates
        
        while (j < arr.Length - 2) {
          
          int k = j + 1;
          int l = arr.Length - 1;
          
          while (k < l) {
            
            var sum = arr[i] + arr[j] + arr[k] + arr[l];
            
            // Three conditions
            // (1) EQUAL
            if (sum == s) {
              return new int[] {arr[i], arr[j], arr[k], arr[l]};
            }
            
            // (2) MORE THAN S, WE NEED TO REDUCE TOTAL
            if (sum > s) {
              l--;
              continue;
            }
            
            // (3) LESS THAN S, WE NEED TO INCREASE TOTAL;
            if (sum < s) {
              k++;
              continue;
            }
          }
          j++;
        }
        i++;
      }
      
      return new int[0];
    }
  
    private static void PrintResult(int[] result) {
      
      Console.WriteLine("===");
      Console.Write("[");
      foreach (var num in result) {
        Console.Write(num + ",");        
      }
      Console.Write("]");
      Console.WriteLine();
    }

    static void Main(string[] args)
    {
        var arr1 = new int[] {
          2, 7, 4, 0, 9, 5, 1, 3
        };
        var sum1 = 20;
        PrintResult(FindArrayQuadruplet(arr1, sum1));
      
        var arr2 = new int[] {
          1, 2, 3
        };
        var sum2 = 12;
        PrintResult(FindArrayQuadruplet(arr2, sum2));
      
        var arr3 = new int[] {
          1, 2, 3, 4
        };
        var sum3 = 12;
        PrintResult(FindArrayQuadruplet(arr3, sum3));
      
        var arr4 = new int[] {
          1, 1, 1, 1
        };
        var sum4 = 4;
        PrintResult(FindArrayQuadruplet(arr4, sum4));
      
        var arr5 = new int[] {
          -1, -1, -1, -1
        };
        var sum5 = -4;
        PrintResult(FindArrayQuadruplet(arr5, sum5));
     }
}

