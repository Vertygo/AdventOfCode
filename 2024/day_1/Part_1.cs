namespace Day1;

public partial class Day1_Part1
{
    internal void Run()
    {
        var lines = Input.input
           .Split(Environment.NewLine)                                       // get location pairs (rows)
           .SelectMany(s => s.Split("   ", StringSplitOptions.TrimEntries))  // split locations left and right
           .Select((string value, int idx) => (lr: idx % 2 == 0, value: int.Parse(value)))
           .ToList();

        var sum = 0;
        var leftList = lines.Where(s => !s.lr).Select(s => s.value).OrderBy(s => s).ToList();
        var rightList = lines.Where(s => s.lr).Select(s => s.value).OrderBy(s => s).ToList();

        for (int i = 0; i < leftList.Count; i++)
        {
            // Console.WriteLine($"{leftList[i]} - {rightList[i]} = {leftList[i] - rightList[i]}");
            
            sum += Math.Abs(leftList[i] - rightList[i]);
        }

        Console.WriteLine(sum);
    }
}