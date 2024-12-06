namespace Day5;

public partial class Day5_Part1
{

    internal void Run()
    {
        var input = Input.input.Split(Environment.NewLine + Environment.NewLine);
        var counter = 0;

        if (input is [string pageOrderingStr, string pageUpdatesStr])
        {
            var pageOrdering = pageOrderingStr.Split(Environment.NewLine).Select(s => s.Split('|').Select(int.Parse).ToArray()).ToArray();
            var pageUpdates = pageUpdatesStr.Split(Environment.NewLine).Select(s => s.Split(',').Select(int.Parse).ToList());

            foreach (var update in pageUpdates)
            {
                if (update.All(updateNumber => IsUpdateNumberInRightOrder(updateNumber, update, pageOrdering)))
                {
                    counter += update[update.Count / 2];
                }
            }
        }

        Console.WriteLine(counter);
    }

    private bool IsUpdateNumberInRightOrder(int updateNumber, List<int> update, int[][] pageOrdering)
    {
        var pageOrderingWithNumber = pageOrdering.Where(s => (s[0] == updateNumber || s[1] == updateNumber) && update.IndexOf(s[0]) > -1 && update.IndexOf(s[1]) > -1);
        var allInOrder = pageOrderingWithNumber.All(numbers => update.IndexOf(numbers[0]) < update.IndexOf(numbers[1]));

        return allInOrder;
    }
}