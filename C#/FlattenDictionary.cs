using System;
using System.Collections.Generic;

class FlattenDictionarySolution
{
  public static Dictionary<string, string> FlattenDictionary(Dictionary<string, object> dict)
  {
    if (dict.Count == 0) {
      return new Dictionary<string, string>();
    }
    
    int count = dict.Count;
    var result = new Dictionary<string, string>();
    FlattenDictionaryHelper(dict, result, "");
    return result;
  }
  
  private static void FlattenDictionaryHelper(object dict, Dictionary<string, string> result, string str) {
    if (dict.GetType().Equals(typeof(Dictionary<string, object>))) {
      foreach (var kvp in (Dictionary<string, object>) dict) {
        var key = kvp.Key;
        var val = kvp.Value;
        var keyBeingPassed = !string.IsNullOrWhiteSpace(str) && !string.IsNullOrWhiteSpace(key) ? 
           str + "." + key : str + key;
        if (val.GetType().Equals(typeof(Dictionary<string, object>))) {       
          FlattenDictionaryHelper(val, result, keyBeingPassed);
        } else {
          result.Add(keyBeingPassed, val.ToString());        
        }     
      }
    }   
  }
  
  private static void PrintResults(Dictionary<string, string> results) {
    Console.WriteLine();
    foreach(var kvp in results) {
      Console.WriteLine(kvp.Key  + " : " + kvp.Value);
    }
    Console.WriteLine();
  }
  
  static void Main(string[] args)
  {
    var t1 = new Dictionary<string, object>() {
      {"a" , "1"},
      {"b" , "2"},
      {"c" , 
        new Dictionary<string, object>() {
          {"d" , "1"},
          {"e" , 
            new Dictionary<string, object>() {
              {"f" , "5"},
              {"",
                new Dictionary<string, object>() {
                  {"g", 8}
                }
              }
            }
          }
        }
      }
    };
    PrintResults(FlattenDictionary(t1));
    
    var t2 = new Dictionary<string, object>() {};
    PrintResults(FlattenDictionary(t2));
    
    var t3 = new Dictionary<string, object>() {
      {"a" , "1"},
      {"b" , "2"},
      {"c" , 3}
    };
    PrintResults(FlattenDictionary(t3));  
  }
}