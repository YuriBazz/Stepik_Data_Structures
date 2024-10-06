using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        var token = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
        int n = token[0], m = token[1];
        var tables = new Table[n];
        token = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
        for (int i = 0; i < n; ++i)
        {
            tables[i] = new Table(i + 1, token[i]);
        }
        var currentMax = tables.Max(x => x.Size);
        for (int i = 0; i < m; ++i)
        {
            token = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            var destination = tables[token[0] - 1];
            var sourse = tables[token[1] - 1];
            while (destination.IsRefer)
                destination = destination.Reference;
            while (sourse.IsRefer)
                sourse = sourse.Reference;
            if (!sourse.Equals(destination))
            {
                sourse.RewriteTo(destination);
                currentMax = Math.Max(currentMax, destination.Size);
            }
            Console.WriteLine(currentMax);
        }
    }
}

public class Table
{
    public int Number { get; private set; }
    public bool IsRefer { get { return Reference != null; } }
    public Table? Reference { get; private set; }
    public int Size { get; private set; }

    public void RewriteTo(Table table)
    {
        if (IsRefer)
            Reference.RewriteTo(table);
        table.Size += Size;
        Size = 0;
        Reference = table;
    }

    public Table(int number, int size)
    {
        Number = number;
        Size = size;
        Reference = null;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (!(obj is Table)) return false;
        var table = obj as Table;
        return this.Number == table.Number;
    }
    public override int GetHashCode()
    {
        return Number.GetHashCode();
    }
}