using System;
using MyLinkedListLib;
using MyStackProj;
using MyQueueProj;
using MyBinaryTreeProj;
using MyBubbleSortProject;
using MyInsertionSortProject;
using MySelectionSortProject;

namespace DataStructuresDemo;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Data Structures and Algorithms Validation ===\n");

        #region 1. MyLinkedList Comprehensive Test
        Console.WriteLine("--- LinkedList Validation ---");
        var list = new MyLinkedList<int>();
        list.AddFirst(30);
        list.AddFirst(20);
        list.AddFirst(10); // Testing AddFirst
        list.AddLast(40);
        list.AddLast(50);
        list.AddLast(60);
        list.AddLast(70); // Testing AddLast

        Console.WriteLine($"Node Count: {list.Count}");
        Console.Write("Linear Traversal: ");
        foreach (var item in list) Console.Write(item + " ");
        Console.WriteLine("\n");
        #endregion

        #region 2. MyStack Functional Test
        Console.WriteLine("--- Stack LIFO Validation ---");
        var stack = new MyStack<int>();
        stack.Push(100);
        stack.Push(200);
        stack.Push(300);
        stack.Push(400);
        stack.Push(500);
        stack.Push(600);
        stack.Push(700);

        Console.WriteLine($"Initial Peek: {stack.Peek()}");
        Console.WriteLine($"Pop Execution: {stack.Pop()}");
        Console.WriteLine($"New Peek Latency: {stack.Peek()}");
        Console.WriteLine();
        #endregion

        #region 3. MyQueue FIFO Validation
        Console.WriteLine("--- Queue FIFO Validation ---");
        var queue = new MyQueue<int>();
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);
        queue.Enqueue(40);
        queue.Enqueue(50);
        queue.Enqueue(60);
        queue.Enqueue(70);

        Console.WriteLine($"Head Element Peek: {queue.Peek()}");
        Console.WriteLine($"Dequeue Execution: {queue.Dequeue()}");
        Console.WriteLine($"Next Element in Queue: {queue.Peek()}");
        Console.WriteLine();
        #endregion

        #region 4. Postfix Stack-Based Evaluation
        Console.WriteLine("--- Postfix Algorithm Validation ---");
        // Expression: (10 + 20) * 2 = 60 -> Postfix: 10 20 + 2 *
        string expression = "10 20 + 2 *";
        string[] tokens = expression.Split(' ');
        var calcStack = new System.Collections.Generic.Stack<int>();

        foreach (var token in tokens)
        {
            if (int.TryParse(token, out int num)) calcStack.Push(num);
            else
            {
                int r = calcStack.Pop();
                int l = calcStack.Pop();
                if (token == "+") calcStack.Push(l + r);
                else if (token == "*") calcStack.Push(l * r);
            }
        }
        Console.WriteLine($"Mathematical Evaluation Result: {calcStack.Pop()}");
        Console.WriteLine();
        #endregion

        #region 5. MyBinaryTree Recursive Search Test
        Console.WriteLine("--- Binary Search Tree Validation ---");
        var bst = new MyBinaryTree<int>();
        bst.Add(40);
        bst.Add(20); bst.Add(60);
        bst.Add(10); bst.Add(30);
        bst.Add(50); bst.Add(70);

        Console.Write("In-Order Traversal (Sorted): ");
        bst.PrintSorted();
        Console.WriteLine($"\nContainment Check (70): {bst.Contains(70)}");
        Console.WriteLine($"Containment Check (99): {bst.Contains(99)}");
        #endregion

        #region
            int[] originalArray = { 64, 34, 25, 12, 22, 11, 90 };

            Console.WriteLine("Սկզբնական զանգված՝ " + string.Join(", ", originalArray));
            Console.WriteLine("\nԸնտրեք ալգորիթմը՝");
            Console.WriteLine("1. Bubble Sort");
            Console.WriteLine("2. Insertion Sort");
            Console.WriteLine("3. Selection Sort");

            string choice = Console.ReadLine() ?? "";
            int[] arrayToSort = (int[])originalArray.Clone();

            switch (choice)
            {
                case "1":
                    var bubble = new MyBubbleSort<int>();
                    bubble.Sort(arrayToSort);
                    Console.WriteLine("Bubble Sort-ի արդյունքը՝ " + string.Join(", ", arrayToSort));
                    break;
                case "2":
                    var insertion = new MyInsertionSort<int>();
                    insertion.Sort(arrayToSort);
                    Console.WriteLine("Insertion Sort-ի արդյունքը՝ " + string.Join(", ", arrayToSort));
                    break;
                case "3":
                    var selection = new MySelectionSort<int>();
                    selection.Sort(arrayToSort);
                    Console.WriteLine("Selection Sort-ի արդյունքը՝ " + string.Join(", ", arrayToSort));
                    break;
                default:
                    Console.WriteLine("Սխալ ընտրություն!");
                    break;
            }
        #endregion

    Console.WriteLine("\n============================================");
        Console.ReadLine();
    }
}