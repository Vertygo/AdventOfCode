namespace Day5;

public partial class Day5_Part2
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
                if (!update.All(updateNumber => IsUpdateNumberInRightOrder(updateNumber, update, pageOrdering)))
                {
                    var fixedUpdate = update.ToArray();
                    //Fix as long as array keeps changing :)
                    while (!fixedUpdate.SequenceEqual(FixOrdering(fixedUpdate, pageOrdering)))
                    {
                        fixedUpdate = FixOrdering(fixedUpdate, pageOrdering);
                    }

                    counter += fixedUpdate[fixedUpdate.Length / 2];
                }
            }
        }

        Console.WriteLine(counter);
    }

    private int[] FixOrdering(int[] update, int[][] pageOrdering)
    {
        var fixedUpdate = update.ToArray();

        foreach (var updateNumber in fixedUpdate)
        {
            var pageOrderingWithNumber = pageOrdering.Where(s =>
                (s[0] == updateNumber || s[1] == updateNumber) && // find page orderings with number
                Array.IndexOf(fixedUpdate, s[0]) > -1 && Array.IndexOf(fixedUpdate, s[1]) > -1 && // rules missing page numbers are ignored
                Array.IndexOf(fixedUpdate, s[0]) > Array.IndexOf(fixedUpdate, s[1])); // select only incorrectly-ordered updates

            foreach (var pageOrderForFix in pageOrderingWithNumber)
            {
                (fixedUpdate[Array.IndexOf(fixedUpdate, pageOrderForFix[0])], fixedUpdate[Array.IndexOf(fixedUpdate, pageOrderForFix[1])]) = (fixedUpdate[Array.IndexOf(fixedUpdate, pageOrderForFix[1])], fixedUpdate[Array.IndexOf(fixedUpdate, pageOrderForFix[0])]);
            }
        }

        return fixedUpdate;
    }

    private bool IsUpdateNumberInRightOrder(int updateNumber, List<int> update, int[][] pageOrdering)
    {
        var pageOrderingWithNumber = pageOrdering.Where(s => (s[0] == updateNumber || s[1] == updateNumber) && update.IndexOf(s[0]) > -1 && update.IndexOf(s[1]) > -1);
        var allInOrder = pageOrderingWithNumber.All(numbers => update.IndexOf(numbers[0]) < update.IndexOf(numbers[1]));

        return allInOrder;
    }
}