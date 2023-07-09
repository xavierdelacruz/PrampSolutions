using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class Solution
{
    public static char[] ReverseWords(char[] arr)
    {
        if (arr == null || arr.Length == 0)
        {
            return arr;
        }

        var stack = new Stack<string>();
        var sb = new StringBuilder();

        foreach (var c in arr)
        {
            if (Char.IsLetter(c))
            {
                sb.Append(c);
            }
            else
            {
                if (sb.Length > 0)
                {
                    var str = sb.ToString();
                    stack.Push(str);
                    sb = new StringBuilder();
                }
                var cStr = c.ToString();
                stack.Push(cStr);
            }
        }

        stack.Push(sb.ToString());

        var result = new char[arr.Length];
        int i = 0;
        while (stack.Count > 0)
        {
            foreach (var c in stack.Pop())
            {
                result[i++] = c;
            }
        }

        return result;
    }

    private static void PrintResult(char[] results)
    {
        Console.WriteLine();
        Console.Write("[");
        foreach (var c in results)
        {
            Console.Write(c + ",");

        }
        Console.Write("]");
        Console.WriteLine();
    }

    static void Main(string[] args)
    {

        // Preserve the relative spacing between the words
        var t5 = new char[]
        {
         'p', 'e', 'r', 'f', 'e', 'c', 't', ' ',
         'm', 'a', 'k', 'e', 's', ' ', ' ',
         'p', 'r', 'a', 'c', 't', 'i', 'c', 'e'
        };
        PrintResult(ReverseWords(t5));
    }
}

