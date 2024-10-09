using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

public class Program
{
    public static void Main(string[] args)
    {
        var token = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray(); ;
        var numbers = new Set(token[0]);
        
        for(int i = 0; i < token[0]; ++i)
        {
            numbers.Add(i);
        }

        for(int i = 0; i < token[1]; ++i)
        {
            var input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            numbers.Union(input[0] - 1, input[1] - 1);
        }

        for(int i =0; i < token[2]; ++i)
        {
            var input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            if (!numbers.CanBeDifferet(input[0] -1, input[1] - 1))
            {
                Console.WriteLine(0);
                return;
            }
        }
        Console.WriteLine(1);
    }
}

public class Set
{
    private int Current;

    private int[] Values;
    private int[] Rank;
    private int[] Parent;

    public Set(int length)
    {
        Values = new int[length];
        Rank = new int[length];
        Parent = new int[length];
    }

    public void Add(int value)
    {
        if (Current >= Values.Length) throw new IndexOutOfRangeException();
        Values[Current] = value;
        Rank[Current] = 0;
        Parent[Current] = value;
        Current++;
    }
    

    public int Find(int value)
    {
        if (value != Parent[value])
            Parent[value] = Find(Parent[value]);
        return Parent[value];
    }

    public void Union(int i, int j)
    {
        int i_id = Find(i), j_id = Find(j);
        if (i_id == j_id) return;
        if (Rank[i_id] > Rank[j_id])
            Parent[j_id] = i_id;
        else
        {
            Parent[i_id] = j_id;
            if (Rank[i_id] == Rank[j_id])
                Rank[j_id]++;
        }
    }

    public bool CanBeDifferet(int i, int j) => Parent[i] != Parent[j];

}