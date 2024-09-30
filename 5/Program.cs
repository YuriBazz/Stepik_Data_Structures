using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace _5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var array = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int m = int.Parse(Console.ReadLine());

            var stack = new _Stack(m);
            var results = new List<int>();
            for(int i = 0; i < m; ++i)
                stack.Push(array[i]);
            for(int i = m; i < n; ++i)
            {
                results.Add(stack.Max);
                stack.Pop();
                stack.Push(array[i]);
            }
            results.Add(stack.Max);
            Write(results);
        }

        static void Write(List<int> list)
        {
            var s = new StringBuilder();
            foreach (int i in list)
                s.Append(String.Format("{0} ", i));
            s.Remove(s.Length - 1, 1);
            Console.WriteLine(s.ToString());
        }
    }

    public class _Stack
    {
        private readonly Stack<(int, int)> InputStack;
        private readonly Stack<(int, int)> OutputStack;

        public int InputCount { get {  return InputStack.Count; } }
        public int OutputCount {  get { return OutputStack.Count; } }
        private readonly int Capacity;
        public int Max 
        { 
            get 
            {
                return Math.Max(InputCount == 0 ? int.MinValue : InputStack.Peek().Item2, OutputCount == 0 ? int.MinValue : OutputStack.Peek().Item2);
            } 
        }

        public _Stack(int capacity)
        {
            InputStack = new Stack<(int, int)>();
            OutputStack = new Stack<(int, int)>();
            Capacity = capacity;
        }

        public void Push(int value)
        {
            if (InputCount == Capacity)
                Transfer();
            InputStack.Push((value, Math.Max(value, InputCount == 0 ? value : InputStack.Peek().Item2)));
        }

        public void Pop()
        {
            if (OutputCount == 0)
                Transfer();
            OutputStack.Pop();
        }

        private void Transfer()
        {
            while (OutputCount != Capacity)
            {
                var x = InputStack.Pop();
                OutputStack.Push((x.Item1, Math.Max(x.Item1, OutputCount == 0 ? x.Item1 : OutputStack.Peek().Item2)));
            }
        }
    }

}
