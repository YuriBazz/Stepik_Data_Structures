using System.ComponentModel.Design;

public class Program 
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        TreeNode tree = new TreeNode();
        var input = Console.ReadLine().Split();
        for(int node = 0; node < n; node++)
        {
            tree.Add(int.Parse(input[node]), node);
        }


    }
}

public class TreeNode
{ 
    private readonly Dictionary<int, List<int>> Data = new Dictionary<int, List<int>>();

    public void Add(int Key, int Value)
    {
        if(!Data.ContainsKey(Key))
            Data[Key] = new List<int>();
        Data[Key].Add(Value);
    }
}
