namespace Day1;

public partial class Day1_Part2
{
    internal void Run()
    {
        var inputParsed = Input.input.Split(Environment.NewLine + Environment.NewLine); //.Select(i => int.Parse(i)).ToArray();
        
        List<int> weights = new List<int>();
        int i = 0;
        foreach(var v in inputParsed)
        {
            i++;
            var weight = v.Split(Environment.NewLine).Select(int.Parse).Sum();
            weights.Add(weight);
        }
        Console.WriteLine($"Elf with most calories {weights.OrderByDescending(s => s).Take(3).Sum()}");
    }
}