using System;
using MyLinkedListLib;
using MyStackProj;
using MyQueueProj;
using PostfixAlgorithm;
using MyBinaryTreeProj;
using BinaryTreeProj;

namespace DataStructuresDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region MyLinkedList Test
            Console.WriteLine("=== MyLinkedList Test ===");
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);
            list.AddFirst(5);

            Console.WriteLine("Elements:");
            foreach (var item in list) Console.Write(item + " ");
            Console.WriteLine();

            Console.WriteLine("Count: " + list.Count);
            Console.WriteLine("Contains 20: " + list.Contains(20));
            Console.WriteLine("Element at index 2: " + list.GetAt(2));

            list.RemoveFirst();
            list.RemoveLast();
            list.Remove(20);

            Console.WriteLine("After Removes:");
            foreach (var item in list) Console.Write(item + " ");
            Console.WriteLine();

            int[] array = new int[list.Count];
            list.CopyTo(array, 0);
            Console.WriteLine("Copied to array:");
            foreach (var item in array) Console.Write(item + " ");
            Console.WriteLine();

            list.Clear();
            Console.WriteLine("After Clear, Count: " + list.Count);
            Console.WriteLine();
            #endregion

            #region MyStack Test
            Console.WriteLine("=== MyStack Test ===");
            MyStack<int> stack = new MyStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            Console.WriteLine("Count: " + stack.Count);
            Console.WriteLine("Peek: " + stack.Peek());
            Console.WriteLine("Pop: " + stack.Pop());
            Console.WriteLine("New Peek: " + stack.Peek());

            stack.Pop();
            stack.Pop();
            try
            {
                stack.Pop();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on Pop empty stack: " + ex.Message);
            }
            Console.WriteLine();
            #endregion

            #region MyQueue Test
            Console.WriteLine("=== MyQueue Test ===");
            MyQueue<int> queue = new MyQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Console.WriteLine("Count: " + queue.Count);
            Console.WriteLine("Peek: " + queue.Peek());
            Console.WriteLine("Dequeue: " + queue.Dequeue());

            Console.WriteLine("Queue elements:");
            foreach (var item in queue) Console.Write(item + " ");
            Console.WriteLine();

            queue.Clear();
            Console.WriteLine("After Clear, Count: " + queue.Count);
            try
            {
                queue.Dequeue();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on Dequeue empty queue: " + ex.Message);
            }
            Console.WriteLine();
            #endregion

            #region PostfixCalculator Test
            Console.WriteLine("=== Postfix Calculator Test ===");
            string expression = "5 2 3 * +"; // (2*3)+5
            string[] tokens = expression.Split(' ');
            Stack<int> calcStack = new Stack<int>();

            foreach (var token in tokens)
            {
                if (int.TryParse(token, out int num)) calcStack.Push(num);
                else
                {
                    int right = calcStack.Pop();
                    int left = calcStack.Pop();
                    int result = token switch
                    {
                        "+" => left + right,
                        "-" => left - right,
                        "*" => left * right,
                        "/" => left / right,
                        _ => 0
                    };
                    calcStack.Push(result);
                }
            }
            Console.WriteLine($"Expression: {expression}");
            Console.WriteLine("Result: " + calcStack.Pop());
            Console.WriteLine();
            #endregion

            #region MyBinaryTree Test
            Console.WriteLine("=== MyBinaryTree Test ===");
            MyBinaryTree<int> tree = new MyBinaryTree<int>();
            tree.Add(10);
            tree.Add(5);
            tree.Add(15);
            tree.Add(3);
            tree.Add(7);

            Console.WriteLine("Tree InOrder (sorted):");
            tree.PrintSorted();

            Console.WriteLine("Contains 7: " + tree.Contains(7));
            Console.WriteLine("Contains 20: " + tree.Contains(20));

            tree.Remove(5);
            Console.WriteLine("After removing 5:");
            tree.PrintSorted();
            Console.WriteLine();
            #endregion

            Console.WriteLine("=== Demo Finished ===");
            Console.ReadLine();
        }
    }
}
