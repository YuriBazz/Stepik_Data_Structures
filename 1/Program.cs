using System.Collections.Generic;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine();

        var stack = new MyStack<(char, int)>();

        var opened = new HashSet<char> { '(', '[','{'};
        var closed = new HashSet<char> { ')', ']', '}' };
        var brackets = new Dictionary<char, char>();
        brackets[')'] = '(';
        brackets[']'] = '[';
        brackets['}'] = '{';

        for (int i = 0; i < input.Length; i++)
        {
            if (opened.Contains(input[i]))
                stack.Push((input[i],i));
            if (closed.Contains(input[i]))
            {
                if (stack.Count == 0 || brackets[input[i]] != stack.Pop().Item1)
                { Console.WriteLine(i + 1); return; }
            }
        }
        if (stack.Count == 0)
            Console.WriteLine("Success");
        else
            Console.WriteLine(stack.Pop().Item2 + 1);
    }
}

public class MyStack<T>
{
    private readonly Stack<T> Stack;
    public T First { get; private set; }
    public T Pop()
    {
        if (Stack.Count == 0) throw new InvalidProgramException();
        return Stack.Pop();
    }

    public void Push(T input)
    {
        Stack.Push(input);
    }

    public int Count { get { return Stack.Count; } }

    public MyStack()
    {
        this.Stack = new Stack<T>();
    }
}
