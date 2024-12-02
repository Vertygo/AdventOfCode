namespace Day2;

public partial class Day2_Part2
{
    internal void Run()
    {
        var reports = Input.input
           .Split(Environment.NewLine)                                  // get reports
            .Select(s => s.Split(' ', StringSplitOptions.TrimEntries))  // get levels per report
            .Select(s => s.Select(int.Parse))
            .ToList();

        var safeReports = 0;
        for (int i = 0; i < reports.Count; i++)
        {
            var isSafe = true;
            
            // run through report combinations by removing one level
            for (int z = 0; z < reports[i].Count(); z++)
            {
                var levels = reports[i].ToList();
                levels.RemoveAt(z); // remove one level
                isSafe = true;

                for (int x = 1; x < levels.Count; x++)
                {
                    var isIncreasing = levels[1] - levels[0] > 0;

                    if (isIncreasing && levels[x] - levels[x - 1] > 0 && levels[x] - levels[x - 1] <= 3)
                    {
                        continue;
                    }
                    if (!isIncreasing && levels[x - 1] - levels[x] > 0 && levels[x - 1] - levels[x] <= 3)
                    {
                        continue;
                    }
                    isSafe = false;
                }

                if(isSafe)
                {
                    break;
                }
            }

            if (isSafe)
            {
                Console.WriteLine($"{i + 1} | {string.Join(' ', reports[i])} is safe");
                safeReports += 1;
            }
            isSafe = true;
        }

        Console.WriteLine(safeReports);
    }
}