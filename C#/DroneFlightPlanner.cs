using System;

class Solution
{
    public static int CalcDroneMinEnergy(int[,] route)
    {

        if (route.GetLength(0) <= 1)
        {
            return 0;
        }

        var firstPointHeight = route[0, 2];

        var minHeight = Int32.MaxValue;
        for (int i = 1; i < route.GetLength(0); i++)
        {
            var currHeight = route[i, 2];
            var diff = firstPointHeight - currHeight;
            minHeight = Math.Min(minHeight, diff);
        }
        return minHeight * -1 <= 0 ? 0 : minHeight * -1;
    }

    static void Main(string[] args)
    {
        var t1 = new int[,]  {{0, 2, 10},
                  {3,   5,  0},
                  {9,  20,  6},
                  {10, 12, 15},
                  {10, 10,  8}
            };

        Console.WriteLine(CalcDroneMinEnergy(t1) == 5);

        var t2 = new int[,]  {{0, 0, 10},
                            {0, 0, 20},
                            {0, 0, 30},
                            {0, 0, 15}
             };

        Console.WriteLine(CalcDroneMinEnergy(t2) == 20);

        var t4 = new int[,] { { 0, 2, 10 }, { 10, 10, 8 } };

        Console.WriteLine(CalcDroneMinEnergy(t4) == 0);
    }
}

