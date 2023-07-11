using System;

class Solution
{
    public static int ShiftedArrSearch(int[] shiftArr, int num)
    {
      if (shiftArr.Length == 0) {
        return -1;
      }
      
      // we perform binary search here      
      int lo = 0;
      int hi = shiftArr.Length-1;
      
      while (lo <= hi) {     
        var mid = lo + ((hi - lo)/2);
        
        var midVal = shiftArr[mid];        
        var start = shiftArr[lo];
        var end = shiftArr[hi];
 
        if (midVal == num) {
          return mid;
        }
        
        if (start == num) {
          return lo;
        }
        
        if (end == num) {
          return hi;
        }   
        
        
        if (midVal > num) {
          // Since midVal is larger than num, we need to compare num and midval with start
          if (midVal > start && num < start) {
            lo = mid + 1;
          } else {
            hi = mid-1;
          }
        } else {
          // In this case, midval is smaller than num
          // If this is the case, check if num is larger than start, and midval is smaller than num
          if (midVal < start && num > start) {
            hi = mid - 1;
          } else {
            lo = mid + 1;
          }
        }
      }
      
      return -1;
    }

    static void Main(string[] args)
    {
      var t1 = new int[0];
      var num1 = 0;
      Console.WriteLine(ShiftedArrSearch(t1, num1) == -1);
      
      var t2 = new int[] {9, 12, 17, 2, 4, 5};
      var num2 = 2;
      Console.WriteLine(ShiftedArrSearch(t2, num2) == 3);
      
      var t3 = new int[] {1};
      var num3 = 0;
      Console.WriteLine(ShiftedArrSearch(t3, num3) == -1);
      
      var t4 = new int[] {1, 2, 3, 4, 5};
      var num4 = 4;
      Console.WriteLine(ShiftedArrSearch(t4, num4) == 3);
      
      var t5 = new int[] {9, 10, 11, 7, 8};
      var num5 = 7;
      Console.WriteLine(ShiftedArrSearch(t5, num5) == 3);
      
    }
}

