using System;

class Solution
{
    public static int BracketMatch(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return 0;
        }

        int leftCount = 0;
        int rightCount = 0;

        foreach (var t in text)
        {
            if (t.Equals('('))
            {
                leftCount++;
            }

            if (t.Equals(')') && leftCount > 0)
            {
                leftCount--;
                continue;
            }

            if (t.Equals(')') && leftCount <= 0)
            {
                rightCount++;
                continue;
            }
        }

        return rightCount + leftCount;


    }

    static void Main(string[] args)
    {

    }
}

