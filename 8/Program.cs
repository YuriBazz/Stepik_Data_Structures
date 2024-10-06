using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

public class Program
{
    public static void Main(string[] args)
    {
        var token = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
        int n = token[0], m = token[1];
        var tables = new (int,int)[n];
        token = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
        for(int i = 0; i < n; ++i)
        {
            tables[i] = (i + 1, token[i]);
        }
        var currentMax = tables.Max(x => x.Item2);
        for(int i = 0; i < m ; ++i)
        {
            token = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            var destination = tables[token[0] - 1];
            var sourse = tables[token[1] - 1];
            
            Console.WriteLine(currentMax);
        }
    }

    

    private static void Union(this int[] array,int i,int j)
    {
        int x = array.Find(i);
    }
}

public class ArrayExtention
{
    public static int Find(this int[] array, int i)
    {
        if (i != array[i])
            array[i] = Find(array, array[i]);
        return array[i];
    }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string? ToString()
    {
        return base.ToString();
    }
}
