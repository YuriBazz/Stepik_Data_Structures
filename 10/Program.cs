using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var phonebook = new Phonebook();
        for(int i =0; i < n; ++i)
        {
            phonebook.Execute(Console.ReadLine());
        }
    }
}

public class Phonebook
{
    private readonly Dictionary<string, string> Data = new Dictionary<string, string>();

    private void Add(string number, string name) => Data[number] = name;

    private void Remove(string number) => Data.Remove(number);

    private string Find(string number)
    {
        if(Data.ContainsKey(number))
            return Data[number];
        return "not found";
    }

    public void Execute(string command)
    {
        var token = command.Split();
        switch (token[0])
        {
            case "add":
                {
                    Add(token[1], token[2]); break;
                }
            case "find":
                {
                    Console.WriteLine(Find(token[1])); break;
                }
            case "del":
                {
                    Remove(token[1]); break;
                }
        }

    }
}