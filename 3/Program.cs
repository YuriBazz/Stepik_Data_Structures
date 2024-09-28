public class Program
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
        var processor = new Processor(input[0]);
        for(int i = 0; i < input[1]; ++i)
        {

        }
    }
}

public class Processor
{
    public int BufferSize { get; private set; }

    public Processor(int bufferSize)
    {
        BufferSize = bufferSize;
    }

    private Queue<(int, int)> buffer = new Queue<(int, int)> ();

    public void AddToBuffer((int,int) input)
    {
        if (buffer.Count == BufferSize) return;
        buffer.Enqueue(input);
    }
}