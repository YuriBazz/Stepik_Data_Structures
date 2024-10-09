using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
public class Program
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine().Split().Select(x=>int.Parse(x)).ToArray();
        int n = input[0], m = input[1];

        int[] works = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

        (long,long)[] processors = new (long, long)[n];
        for(long i = 0; i < n; ++i)
        {
            processors[i] = (0, i);
        }
        var comparer = new ProcessorComparer();
        foreach(var work in works)
        {
            Console.WriteLine(processors[0].Item2 +" "+ processors[0].Item1);
            processors[0] = (processors[0].Item1 + work, processors[0].Item2);
            SiftDown(processors, comparer);
        }
    }

    public static void SiftDown((long, long)[] array, IComparer<(long, long)> comparer)
    {
        long i = 0;
        while(true)
        {
            long left = 2 * i + 1, right = 2 * i + 2;
            var min = array[i];
            var temp = i;
            if(left < array.Length)
                if(comparer.Compare(array[left],min) < 0)
                    { min = array[left]; temp = left; }
            if(right < array.Length)
                if (comparer.Compare(array[right],min) < 0)
                    { min = array[right]; temp = right; }
            if (min != array[i])
            {
                (array[i], array[temp]) = (array[temp], array[i]);
                i = temp;
            }
            else break;
        }
    }
}

public class ProcessorComparer : IComparer<(long,long)>
{
    public int Compare((long, long) x, (long, long) y)
    {
        if(x.Item1 == y.Item1) return x.Item2.CompareTo(y.Item2);
        return x.Item1.CompareTo(y.Item1);
    }
}