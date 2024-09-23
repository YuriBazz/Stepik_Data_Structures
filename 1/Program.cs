using System.Collections.Generic;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine();

        var stack = new Stack<char>();

        var opened = new HashSet<char> { '(', '[','{'};
        var closed = new HashSet<char> { ')', ']', '}' };
        var brackets = new Dictionary<char, char>();
        brackets[')'] = '(';
        brackets[']'] = '[';
        brackets['}'] = '{';

        for (int i = 0; i < input.Length; i++)
        {
            if (opened.Contains(input[i]))
                stack.Push(input[i]);
            if (closed.Contains(input[i]))
            {
                if (stack.Count == 0 || brackets[input[i]] != stack.Pop())
                { Console.WriteLine(i + 1); return; }
            }
        }
        if (stack.Count == 0)
            Console.WriteLine("Success");
        else
            Console.WriteLine(input.Length);
    }
} 