using System;

class Solution
{
    public static double Root(double x, int n)
    {
      if (x == 0) {
        return (double) 0;
      }
      
      return RootHelper(0, x, n, x);
    }
  
    private static double RootHelper(double start, double end, int n, double target) {

      double mid = (end + start) /2;
      double calculatedVal = Math.Pow(mid, n);

      if (Math.Abs(calculatedVal-target) < 0.001) {
        return mid;
      }
      
      if (calculatedVal > target) {
        end = mid;
      } else {
        start = mid;
      }
      
      return RootHelper(start, end, n, target);      
    }

    static void Main(string[] args)
    {
      var x1 = 9;
      var n1 = 2;
      Console.WriteLine(Root(x1, n1) == 3);
      
      var x2 = 7;
      var n2 = 3;
      Console.WriteLine(Math.Abs(Root(x2, n2) - 1.913) < 0.001);
      var x3 = 0;
      var n3 = 0;
      Console.WriteLine(Root(x3, n3) == 0);
      
      // |y-root(x,n)| < 0.001
    }
}