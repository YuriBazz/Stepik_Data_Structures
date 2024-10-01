using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] array = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
        var minHeap = new MinHeap(array);
        minHeap.Do();
    }
}

public class MinHeap
{
    private readonly int[] Array;
    private readonly List<string> Result = new List<string>();
    private int Count = 0;
    public MinHeap(int[] array)
    { Array = array; }

    public void Do()
    {
        BuildHeap();
        Console.WriteLine(Count);
        foreach (var item in Result)
            Console.WriteLine(item);
    }
    private void BuildHeap()
    {
        for (int i = Array.Length / 2; i > -1; --i)
            SiftDown(i);
    }

    private static int Left(int i) => 2 * i + 1;
    private static int Rigth(int i) => 2 * i + 2;

    private void SiftDown(int i)
    {
        while(i < Array.Length)
        {
            var temp = i;
            var min = Array[i];
            if (Left(i) < Array.Length && min > Array[Left(i)]) { temp = Left(i); min = Array[temp]; }
            if (Rigth(i) < Array.Length && min > Array[Rigth(i)]) { temp = Rigth(i); min = Array[temp]; }
            if (temp != i)
            {
                (Array[i], Array[temp]) = (Array[temp], Array[i]);
                Count++;
                Result.Add(i + " " + temp);
                i = temp;
            }
            else break;
        }
    }
}