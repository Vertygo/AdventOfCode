namespace Day3;

public partial class Day3_Part1
{
    internal void Run()
    {
        var score = Input.input.Split(Environment.NewLine)
            .Select(s => s.Take(s.Length/2).Intersect(s.Skip(s.Length/2)))  // find intersection between two
            .Select(s => s.First())                                         // be blunt about this; its always one char
            .Select(c => char.IsLower(c) ? (int)(c-96) : (int)(c-38))       // score
            .Sum();
        
        Console.WriteLine($"day 3 part 1 solution: {score}");
    }
}