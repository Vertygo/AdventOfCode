namespace Day5;

record Movement(int count, int from, int to);

public partial class Day5_Part1
{
    internal void Run()
    {
        var inputs = Input.input.Split(Environment.NewLine + Environment.NewLine);
        var stacksMap = inputs[0].Split(Environment.NewLine).ToList();
        List<Stack<char>> stacks = new List<Stack<char>>();
        var instructions = inputs[1]
            .Split(Environment.NewLine)
            .Select(s => s.Split(' '))
            .Select(s => new Movement(int.Parse(s[1]), int.Parse(s[3]), int.Parse(s[5])));

        var stackCount = stacksMap[0].Chunk(4).Count();
        for (int i = 0; i < stackCount; i++) stacks.Add(new Stack<char>());
        stacksMap.Reverse();
        stacksMap.RemoveAt(0); // remove first line 1 2 3 4 ...

        foreach (var stack in stacksMap)
        {
            for (int i = 0; i < stackCount; i++)
            {
                var crate = stack.Skip(i * 4).Skip(1).First();
                if (crate != ' ')
                {
                    stacks[i].Push(crate);
                }
            }
        }

        foreach (var instruction in instructions)
        {
            for (int i = 0; i < instruction.count; i++)
            {
                var crate = stacks[instruction.from - 1].Pop();
                stacks[instruction.to - 1].Push(crate);
            }
        }

        Console.WriteLine("Crates on top");
        for (int i = 0; i < stackCount; i++)
        {
            Console.Write(stacks[i].Pop());
        }
        Console.WriteLine("");
    }
}