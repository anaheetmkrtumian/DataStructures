using System;

namespace StackArray
{
    class MyStack<T>
    {
        private T[] elements;
        private int top;
        private int max;

        public int Count { get { return top + 1; } }
        public bool IsEmpty { get { return top == -1; } }

        public MyStack(int size = 10)
        {
            elements = new T[size];
            top = -1;
            max = size;
        }

        public void Push(T item)
        {
            if (top == max - 1)
            {
                max *= 2;
                Array.Resize(ref elements, max);
                Console.WriteLine($"Stack expanded to {max}");
            }
            elements[++top] = item;
        }

        public T Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Stack is empty!");
            }
            return elements[top--];
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Stack is empty!");
            }
            return elements[top];
        }

        public void Clear()
        {
            top = -1;
        }

        public void Display()
        {
            if (IsEmpty)
            {
                Console.WriteLine("Stack is empty!");
                return;
            }

            Console.WriteLine($"Stack elements (top to bottom, total: {Count}):");
            for (int i = top; i >= 0; i--)
            {
                Console.WriteLine($"  [{i}] → {elements[i]}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            MyStack<int> stack = new MyStack<int>(3);

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.Push(40); 

            stack.Display();

            Console.WriteLine($"\nTop element: {stack.Peek()}");
            Console.WriteLine($"Removed: {stack.Pop()}");
            Console.WriteLine($"Stack count after Pop: {stack.Count}");

            stack.Display();
        }
    }
}