using System;

class Solution
{
  public class Node
  {
    public int key; 
    public Node left {get; set;}
    public Node right {get; set;}
    
    public Node(int keyVal) {
      this.key = keyVal;
    }
  }
    
  public static int findLargestSmallerKey(Node rootNode, int num)
  {    
    return DFS(rootNode, num);
  }
  
  /*
    DFS approach, going as deep as possible, and only exploring the subtree that conforms with the criteria
  */
  private static int DFS(Node rootNode, int num) {
    if (rootNode == null) {
      return -1;
    }
    var rootVal = rootNode.key;
    
    var result = -1;
    if (num > rootVal) {
      result = rootVal;
      result = Math.Max(DFS(rootNode.right, num), result);
    } else {
      result = Math.Max(DFS(rootNode.left, num), result);
    }
    
    return result;
  }
  
  /*
    Iterative, similar to traversing a LinkedList. We do not need to go back and search previous paths.
  */
  private static int Iterative(Node rootNode, int num) {
    var result = -1;
    while (rootNode != null) {
      
     if (num > rootNode.key) {
        result = rootNode.key;
        rootNode = rootNode.right;
      } else {
        rootNode = rootNode.left;
      }
    }
    return result;
  }
  
  static void Main(string[] args)
  {
    var num1 = 17;
    
    // Create nodes here
    var node1 = new Node(20);    
    var node2 = new Node(9);
    var node3 = new Node(25);
    var node4 = new Node(5);
    var node5 = new Node(12);
    var node6 = new Node(11);
    var node7 = new Node(14);
    
    // Connect nodes
    node1.left = node2;
    node1.right = node3;
    
    node2.left = node4;
    node2.right = node5;
    
    node5.left = node6;
    node5.right = node7;
    
    //14
    Console.WriteLine(findLargestSmallerKey(node1, num1) == 14);
    
    // -1
    Console.WriteLine(findLargestSmallerKey(null, num1) == -1);
    
    // 12
    var num2 = 13;
    Console.WriteLine(findLargestSmallerKey(node1, num2) == 12);
    
    // 9
    var num3 = 10;
    Console.WriteLine(findLargestSmallerKey(node1, num3) == 9);
    
    // -1
    var num4 = 4;
    Console.WriteLine(findLargestSmallerKey(node1, num4) == -1);
  }
}

