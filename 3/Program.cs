using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
        var currentTime = 0;
        var processor = new Processor(input[0]);

        for(int i = 0; i < input[1]; ++i)
        {
            var package = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            while (processor.BufferCount != 0 && processor.Peek() <= package[0])
            {
                processor.RemoveFromBuffer();
            }
            var temp = currentTime;
            currentTime = Math.Max(currentTime, package[0]) + package[1];
            if (!processor.AddToBuffer(currentTime))
            {
                Console.WriteLine(-1);
                currentTime = temp;
            }
            else
            { 
                Console.WriteLine(currentTime - package[1]);
            }
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

    private Queue<int> buffer = new Queue<int> ();

    public bool AddToBuffer(int input)
    {
        if (buffer.Count == BufferSize) return false;
        buffer.Enqueue(input);
        return true;
    }

    public int BufferCount {  get { return buffer.Count; } }

    public int RemoveFromBuffer()
    {
        if (BufferCount == 0) throw new InvalidOperationException();
        return buffer.Dequeue();
    }

    public int Peek()
    {
        if (buffer.Count == 0) throw new InvalidOperationException();
        return buffer.Peek();
    }
   
}
