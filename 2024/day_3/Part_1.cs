using System.Reflection.Metadata.Ecma335;

namespace Day3;

public partial class Day3_Part1
{
    internal void Run()
    {
        var instructions = Input.input.Split("mul");
        var operations = new List<Operation>();

        foreach (var instruction in instructions)
        {
            if (instruction[0] == '(' && instruction.IndexOf(')') > 0)
            {
                var cleanInstruction = instruction.Substring(1, instruction.IndexOf(')') - 1);
                var values = cleanInstruction.Split(",");
                if (values.Count() == 2 && ulong.TryParse(values[0], out ulong x) && ulong.TryParse(values[1], out ulong y))
                {
                    Console.WriteLine($"{cleanInstruction} => {x} * {y} = {x * y}");
                    operations.Add(new Operation(x, y));
                }
            }
        }

        var result =  operations.Select(s => s.X*s.Y).Aggregate((sum, op) => sum + op);
        
        Console.WriteLine($"result of operation is {result}");
    }

    public record Operation(ulong X, ulong Y);
}