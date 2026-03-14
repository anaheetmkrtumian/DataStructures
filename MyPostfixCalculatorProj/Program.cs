using System;
using System.Collections.Generic;

namespace PostfixAlgorithm;

public class Program
{
    private static void Main()
    {
        string expression = "5 2 3 * +";
        string[] tokens = expression.Split(' ');

        Stack<int> stack = new Stack<int>();

        foreach (var token in tokens)
        {
            if (int.TryParse(token, out int number))
            {
                stack.Push(number);
            }
            else
            {
                int right = stack.Pop();
                int left = stack.Pop();

                int result = 0;

                switch (token)
                {
                    case "+":
                        result = left + right;
                        break;
                    case "-":
                        result = left - right;
                        break;
                    case "*":
                        result = left * right;
                        break;
                    case "/":
                        result = left / right;
                        break;
                }

                stack.Push(result);
            }
        }

        Console.WriteLine(stack.Pop());
    }
}
