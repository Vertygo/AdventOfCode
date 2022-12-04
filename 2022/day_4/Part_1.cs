namespace Day4;

public partial class Day4_Part1
{
    internal void Run()
    {
        var inputs = Input.input.Split(Environment.NewLine);
        var result = 0;

        foreach (var input in inputs)
        {
            var pairs = input.Split(",");
            var pairOne = pairs[0].Split("-");
            string[] pairTwo = pairs[1].Split("-");


            if (int.Parse(pairOne[0]) >= int.Parse(pairTwo[0]) && int.Parse(pairOne[1]) <= int.Parse(pairTwo[1]))
            {
                result++;
            }
            else if (int.Parse(pairTwo[0]) >= int.Parse(pairOne[0]) && int.Parse(pairTwo[1]) <= int.Parse(pairOne[1]))
            {
                result++;
            }

        }

        Console.WriteLine($"Day 4 part 1: {result}");
    }
}