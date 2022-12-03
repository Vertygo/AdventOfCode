namespace Day3;

public partial class Day3_Part2
{
    internal void Run()
    {
        var score = Input.input.Split(Environment.NewLine)
            .Select((s, i) => new { str = s, idx = i / 3 })
            .GroupBy(i => i.idx)
            .Select(s => s.Select(x => x.str).Aggregate((a, b) => string.Join("", a.Intersect(b))))
            .Select(s => s.First())
            .Select(ch => char.IsLower(ch) ? (int)(ch - 96) : (int)(ch - 38))
            .Sum();

        Console.WriteLine($"day 3 part 2 solution: {score}");
    }
}