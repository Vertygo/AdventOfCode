namespace Day1;

public partial class Day1_Part1
{
    internal void Run()
    {
        var result = Input.input
            .Split(Environment.NewLine + Environment.NewLine)   // split calories for each elf
            .Select(s => s.Split(Environment.NewLine)           // split calories for the single elf
            .Sum(int.Parse))                                    // sum calories by elf
            .OrderByDescending(s => s)                          // order
            .Take(3)                                            // take first three
            .Sum();                                             // get the sum of top three
        Console.WriteLine(result);
        
        // List<int> weights = new List<int>();
        // foreach(var v in inputParsed)
        // {
        //     var weight = v.Split(Environment.NewLine).Select(int.Parse).Sum();
        //     weights.Add(weight);
        // }
        // Console.WriteLine($"Elf with most calories {weights.Max()}");
    }
}