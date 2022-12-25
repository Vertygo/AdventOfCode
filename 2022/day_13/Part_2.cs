namespace Day13;

public partial class Day13_Part2
{
    internal void Run()
    {
        var input = Input
            .input
            .Split(Environment.NewLine)
            .Select(s => s.ToCharArray())
            .ToList();
    }
}