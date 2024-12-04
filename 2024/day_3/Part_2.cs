namespace Day3;

public partial class Day3_Part2
{
    public record Operation(ulong X, ulong Y);

    internal void Run()
    {
        var instructionsInput = Input.input;
        var operations = new List<Operation>();
        var doIndex = 0;
        var dontIndex = 0;
        var doLen = "do()".Length;

        while (hasDoDontInstruction(instructionsInput, ref doIndex, ref dontIndex))
        {
            instructionsInput = (doIndex, dontIndex) switch
            {
                ( > -1, _) when doIndex < dontIndex => instructionsInput.Remove(doIndex, doLen),
                (-1, > -1) => instructionsInput.Remove(dontIndex, instructionsInput.Length - dontIndex),
                _ => instructionsInput.Replace(instructionsInput.Substring(dontIndex, doIndex + doLen - dontIndex), "")
            };
        }

        var instructions = instructionsInput.Split("mul", StringSplitOptions.RemoveEmptyEntries);
        foreach (var instruction in instructions.Where(instruction => instruction[0] == '(' && instruction.IndexOf(')') > 0))
        {
            var cleanInstruction = instruction.Substring(1, instruction.IndexOf(')') - 1);
            var values = cleanInstruction.Split(',');
            if (values.Length == 2 && ulong.TryParse(values[0], out ulong x) && ulong.TryParse(values[1], out ulong y))
            {
                Console.WriteLine($"{cleanInstruction} => {x} * {y} = {x * y}");
                operations.Add(new Operation(x, y));
            }
        }

        var result = operations.Select(s => s.X * s.Y).Aggregate((sum, op) => sum + op);

        Console.WriteLine($"result of operation is {result}");
    }

    private bool hasDoDontInstruction(string instructionsInput, ref int doIndex, ref int dontIndex)
    {
        doIndex = instructionsInput.IndexOf("do()");
        dontIndex = instructionsInput.IndexOf("don't()");
        return doIndex > -1 || dontIndex > -1;
    }
}