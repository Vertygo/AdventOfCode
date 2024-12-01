namespace Day1;

public partial class Day1_Part2
{
    internal void Run()
    {
        var lines = Input.input
           .Split(Environment.NewLine)
           .SelectMany(s => s.Split("   ", StringSplitOptions.TrimEntries))  // split locations left and right
           .Select((string value, int idx) => (lr: idx % 2 == 0, value: int.Parse(value)))
           .ToList();

        var sum = 0;
        var leftList = lines.Where(s => !s.lr).Select(s => s.value).OrderBy(s => s).ToList();
        var rightList = lines.Where(s => s.lr).GroupBy(s => s.value, s => s.value).ToDictionary(s => s.Key, s=>s.Count()); //.Select(s => s.value).OrderBy(s => s).ToList();

        for (int i = 0; i < leftList.Count; i++)
        {
            if(rightList.TryGetValue(leftList[i], out int counter))
            {
                sum += leftList[i] * counter;
            }
        }

        Console.WriteLine(sum);
    }
}