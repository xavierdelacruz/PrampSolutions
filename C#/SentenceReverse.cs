using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class Solution
{
    public static char[] ReverseWords(char[] arr)
    {
      if (arr == null || arr.Length == 0) {
        return arr;
      }
      
      var list = new List<string>();
      var sb = new StringBuilder();
      
      foreach (var c in arr) {
        if (Char.IsLetter(c)) {
          sb.Append(c);
        } else { 
          sb.Insert(0, c);
          list.Add(sb.ToString());
          sb = new StringBuilder();
        }
      }
      
      list.Add(sb.ToString());
      list.Reverse();
      var res = string.Join("", list);
      var finalRes = res.ToCharArray();
      
      return finalRes;
    }
  
    private static void PrintResult(char[] results) {
      Console.WriteLine();
      Console.Write("[");
      foreach (var c in results) {
        Console.Write(c  + ",");
        
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

