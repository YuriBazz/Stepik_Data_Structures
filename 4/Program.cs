


public class Program
{
    public static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var stack = new MyStack();
        for(int i =0; i< n; ++i)
            stack.Execute(Console.ReadLine());
    }
}

public class MyStack
{
    private Stack<int> DataMax;

    public int Max { get { return DataMax.Peek(); } } 

    public MyStack()
    {
        DataMax = new Stack<int>();
    }

    private void Push(int value)
    {
        if (DataMax.Count != 0)
            value = Math.Max(value, DataMax.Peek());
        DataMax.Push(value);
    }

    private void Pop()
    {
        DataMax.Pop();
    }

    public void Execute(string command)
    {
        var input = command.Split();
        switch(input[0]) 
        {
            case "push":
                {
                    Push(int.Parse(input[1]));
                    break;
                }
            case "pop":
                {
                    Pop(); break;
                }
            case "max":
                {
                    Console.WriteLine(Max); break;
                }
        }
    }
}