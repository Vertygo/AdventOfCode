namespace Day9;



public partial class Day9_Part1
{
    enum Direction { L, R, D, U }
    record Command(Direction Direction, int Length);

    internal void Run()
    {
        var visited = new Dictionary<(int, int), int>();
        var hx = 0;
        var hy = 0;
        var tx = 0;
        var ty = 0;
        var commands = Input.input.Split(Environment.NewLine)
            .Select(s => new Command(Enum.Parse<Direction>(s.Split(' ')[0].ToString(), true), int.Parse(s.Split(' ')[1].ToString())));

        visited.Add((0, 0), 1);

        foreach (var command in commands)
        {
            if (command.Direction == Direction.U)
            {
                for (int i = 0; i < command.Length; i++)
                {
                    hy++;
                    if (!IsAdjecent(hx, hy, tx, ty))
                    {
                        ty = hy - 1;
                        tx = hx;
                        IncreaseVisit(visited, tx, ty);
                    }
                    PrintOut(visited);
                }

            }
            if (command.Direction == Direction.D)
            {
                for (int i = 0; i < command.Length; i++)
                {
                    hy--;
                    if (!IsAdjecent(hx, hy, tx, ty))
                    {
                        ty = hy + 1;
                        tx = hx;
                        IncreaseVisit(visited, tx, ty);
                    }
                    PrintOut(visited);
                }
            }
            if (command.Direction == Direction.L)
            {
                for (int i = 0; i < command.Length; i++)
                {
                    hx--;
                    if (!IsAdjecent(hx, hy, tx, ty))
                    {
                        tx = hx + 1;
                        ty = hy;
                        IncreaseVisit(visited, tx, ty);
                    }
                    PrintOut(visited);
                }
            }
            if (command.Direction == Direction.R)
            {
                for (int i = 0; i < command.Length; i++)
                {
                    hx++;
                    if (!IsAdjecent(hx, hy, tx, ty))
                    {
                        tx = hx - 1;
                        ty = hy;
                        IncreaseVisit(visited, tx, ty);
                    }
                    PrintOut(visited);
                }
            }
        }

        Console.WriteLine($"Done {visited.Keys.Count}");
        PrintOut(visited);
    }

    private static void PrintOut(Dictionary<(int, int), int> visited)
    {
        // var maxX = visited.Keys.Max(s => s.Item1);
        // var minX = visited.Keys.Min(s => s.Item1);

        // var maxY = visited.Keys.Max(s => s.Item2);
        // var minY = visited.Keys.Min(s => s.Item2);
        // for (int y = maxY; y >= minY; y--)
        // {
        //     for (int x = minX; x <= maxX; x++)
        //     {
        //         if (visited.ContainsKey((x, y)))
        //         {
        //             Console.Write("#");
        //         }
        //         else
        //         {
        //             Console.Write("O");
        //         }
        //     }
        //     Console.WriteLine("");
        // }

        // Console.WriteLine("---------");
    }

    private static void IncreaseVisit(Dictionary<(int, int), int> visited, int tx, int ty)
    {
        if(ty==2 && tx == 0)
        {

        }
        if (visited.ContainsKey((tx, ty)))
        {
            visited[(tx, ty)] = visited[(tx, ty)] + 1;
        }
        else
        {
            visited.Add((tx, ty), 1);
        }
    }

    private bool IsAdjecent(int hx, int hy, int tx, int ty)
    {
        return (hx == tx && ty == hy )  || (hx - 1 == tx && hy == ty) || (hx + 1 == tx && hy == ty) ||
            (hx == tx && hy - 1 == ty) || (hx == tx && hy + 1 == ty) ||
            (hx - 1 == tx && hy - 1 == ty) || (hx + 1 == tx && hy + 1 == ty) ||
            (hx - 1 == tx && hy + 1 == ty) || (hx + 1 == tx && hy - 1 == ty);
    }
}
// 6523