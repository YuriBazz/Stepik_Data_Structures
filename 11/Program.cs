using System.Data.SqlTypes;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        int m = int.Parse(Console.ReadLine());
        var table = new MyHashTable(m);
        int n = int.Parse(Console.ReadLine());
        for(int i = 0; i < n; ++i) 
        {
            table.Execute(Console.ReadLine());
        }
    }
}

public class MyHashTable
{
    private readonly int x = 263;
    private readonly long p = 1000000007;
    private readonly int m;
    private readonly ListNode<string>[] Data;
    private readonly ListNode<string>[] Lasts;
    private readonly List<long> X = new List<long>();

    public MyHashTable(int m)
    { 
        this.m = m; Data = new ListNode<string>[m];
        Lasts = new ListNode<string>[m];
        for(int i = 0; i < 15; ++i)
        {
            if(X.Count == 0)
                X.Add(1);
            else
                X.Add((X[X.Count - 1] * x) % p); 
        }
    }
        
    private int GetHashCode(string input)
    {
        long result = 0;
        for(int i = 0; i < input.Length; ++i) 
        {
            result += ((input[i] * X[i]) % p) % m;
        }
        return (int)result % m;
    }

    private void Add(string input)
    {
        var tempIndex = GetHashCode(input);
        var tempNode = new ListNode<string>(input);
        if (Data[tempIndex] != null)
            Data[tempIndex].Previous = tempNode;
        tempNode.Next = Data[tempIndex];
        Data[tempIndex] = tempNode;
        if (Lasts[tempIndex] == null) Lasts[tempIndex] = tempNode;
    }

    private void Remove(string input) 
    {
        var tempIndex = GetHashCode(input);
        if (Data[tempIndex] == null) return;
        Data[tempIndex] = Data[tempIndex].Next;
        Lasts[tempIndex] = Lasts[tempIndex].Previous;
    }

    private IEnumerable<string> Check(int i)
    {
        var temp = Data[i];
        while(temp != null)
        {
            yield return temp.Value + " ";
            temp = temp.Next;
        }
    }

    private bool Find(string input)
    {
        var tempIndex = GetHashCode(input);
        var tempNode = Data[tempIndex];
        while(tempNode != null)
        {
            if(tempNode.Value == input) return true;
            tempNode = tempNode.Next;
        }
        return false;
    }

    public void Execute(string command)
    {
        var token = command.Split();
        switch(token[0]) 
        {
            case "add":
                {
                    Add(token[1]); break;
                }
            case "del":
                {
                    Remove(token[1]); break;
                }
            case "find":
                {
                    if (Find(token[1]))
                        Console.WriteLine("yes");
                    else
                        Console.WriteLine("no");
                    break;
                }
            case "check":
                {
                    var res = new StringBuilder();
                    foreach(var item in Check(int.Parse(token[1])))
                    {
                        res.Append(item);
                    }
                    if(res.Length == 0) { Console.WriteLine(); break; }
                    res.Remove(res.Length - 1, 1);
                    Console.WriteLine(res.ToString());
                    break;
                }
            default:
                {
                    Console.WriteLine("???????????????????????????????");
                    break;
                }
        }
    }
}

public class ListNode<T>
{
    public readonly T Value;
    public ListNode<T> Next = null;
    public ListNode<T> Previous = null;

    public ListNode(T value)
    {
        Value = value;
    }
}