using System.Collections;
using System.ComponentModel.Design;
using System.Collections.Generic;

public class Program 
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        TreeModel tree = new TreeModel();
        var input = Console.ReadLine().Split();
        for(int node = 0; node < n; node++)
        {
            tree.Add(int.Parse(input[node]), node);
        }

        var queue = new Queue<(int, int)>();
        var maxHeight = 0;

        foreach (var incdent in tree.GetIncedents(-1))
            queue.Enqueue((incdent, 1));

        while(queue.Count > 0)
        {
            var currentPair = queue.Dequeue();
            
            maxHeight = Math.Max(maxHeight, currentPair.Item2);

            foreach(var  incdent in tree.GetIncedents(currentPair.Item1))
                queue.Enqueue((incdent,  currentPair.Item2 + 1));
        }

        Console.WriteLine(maxHeight);
    }
}

public class TreeModel
{ 
    private readonly Dictionary<int, List<int>> Data = new Dictionary<int, List<int>>();

    public void Add(int Key, int Value)
    {
        if(!Data.ContainsKey(Key))
            Data[Key] = new List<int>();
        Data[Key].Add(Value);
    }

    public IEnumerable<int> GetIncedents(int node)
    {
        if(!Data.ContainsKey(node))
            yield break;
        foreach(var incident in Data[node])
            yield return incident;
    }
}
