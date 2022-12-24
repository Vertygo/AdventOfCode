namespace Day9;

public partial class Day9_Part2
{
    enum Direction { L, R, D, U }
    record Command(Direction Direction, int Length);
    class Knot
    {
        public Knot(int x, int y) => (this.x, this.y) = (x, y);
        public int x { get; set; }
        public int y { get; set; }
        public Knot Behind { get; set; }
    }

    static Knot tail = new Knot(0, 0);
    static Knot knot9 = new Knot(0, 0) { Behind = tail };
    static Knot knot8 = new Knot(0, 0) { Behind = knot9 };
    static Knot knot7 = new Knot(0, 0) { Behind = knot8 };
    static Knot knot6 = new Knot(0, 0) { Behind = knot7 };
    static Knot knot5 = new Knot(0, 0) { Behind = knot6 };
    static Knot knot4 = new Knot(0, 0) { Behind = knot5 };
    static Knot knot3 = new Knot(0, 0) { Behind = knot4 };
    static Knot knot2 = new Knot(0, 0) { Behind = knot3 };
    static Knot head = new Knot(0, 0) { Behind = knot2 };

    List<Knot> allKnots = new List<Knot>()
        {
            head,
            knot2,
            knot3,
            knot4,
            knot5,
            knot6,
            knot7,
            knot8,
            knot9,
            tail
        };

    internal void Run()
    {

var points= new HashSet<(int, int)>();

        var visited = new Dictionary<(int, int), int>();
        var commands = Input.input.Split(Environment.NewLine)
            .Select(s => new Command(Enum.Parse<Direction>(s.Split(' ')[0].ToString(), true), int.Parse(s.Split(' ')[1].ToString())));

        visited.Add((0, 0), 1);

        foreach (var command in commands)
        {
            for (int i = 0; i < command.Length; i++)
            {
                var direction = command.Direction;
                var knot = head;

                if (direction == Direction.U)
                {
                    MoveUp(knot);
                    PrintOut(allKnots);
                }
                if (direction == Direction.D)
                {
                    MoveDown(knot);
                    PrintOut(allKnots);

                }
                if (direction == Direction.L)
                {
                    MoveLeft(knot);
                    PrintOut(allKnots);

                }
                if (direction == Direction.R)
                {
                    MoveRight(knot);
                    PrintOut(allKnots);
                }

                points.Add((tail.x, tail.y));
            }
        }

        Console.WriteLine($"Done {points.Count}");
    }

    private void MoveRight(Knot knot)
    {
        knot.x++;
        if (knot.Behind != null && !IsAdjecent(knot.x, knot.y, knot.Behind.x, knot.Behind.y))
        {
            if (SameY(knot.y, knot.Behind.y))
            {
                MoveRight(knot.Behind);
            }
            else
            {
                MoveDiagonal(knot.Behind, knot.x, knot.y);
            }
        }
    }

    private void MoveLeft(Knot knot)
    {
        knot.x--;
        if (knot.Behind != null && !IsAdjecent(knot.x, knot.y, knot.Behind.x, knot.Behind.y))
        {
            if (SameY(knot.y, knot.Behind.y))
            {
                MoveLeft(knot.Behind);
            }
            else
            {
                MoveDiagonal(knot.Behind, knot.x, knot.y);
            }
        }
    }

    private void MoveDown(Knot knot)
    {
        knot.y--;
        if (knot.Behind != null && !IsAdjecent(knot.x, knot.y, knot.Behind.x, knot.Behind.y))
        {
            if (SameX(knot.x, knot.Behind.x))
            {
                MoveDown(knot.Behind);
            }
            else
            {
                MoveDiagonal(knot.Behind, knot.x, knot.y);
            }
        }
    }

    private void MoveUp(Knot knot)
    {
        knot.y++;
        if (knot.Behind != null && !IsAdjecent(knot.x, knot.y, knot.Behind.x, knot.Behind.y))
        {
            if (SameX(knot.x, knot.Behind.x))
            {
                MoveUp(knot.Behind);
            }
            else
            {
                MoveDiagonal(knot.Behind, knot.x, knot.y);
            }
        }
    }

        private bool SameX(int x1, int x2)
    {
        return x1 == x2;
    }

    private void MoveDiagonal(Knot knot, int x, int y)
    {
        if (x < knot.x)
        {
            knot.x--;
        }
        if (x > knot.x)
        {
            knot.x++;
        }

        if(y < knot.y)
        {
            knot.y--;
        }
        if (y > knot.y)
        {
            knot.y++;
        }

        if (knot.Behind != null && !IsAdjecent(knot.x, knot.y, knot.Behind.x, knot.Behind.y))
        {
            MoveDiagonal(knot.Behind, knot.x, knot.y);
        }
    }


    private bool SameY(int y1, int y2)
    {
        return y1 == y2;
    }

    private static void PrintOut(List<Knot> knots)
    {
        // var maxX = knots.Max(s => s.x);
        // var minX = knots.Min(s => s.x);

        // var maxY = knots.Max(s => s.y);
        // var minY = knots.Min(s => s.y);
        // for (int y = maxY; y >= minY; y--)
        // {
        //     for (int x = minX; x <= maxX; x++)
        //     {
        //         if (knots.Any(k => k.x == x && k.y == y))
        //         {
        //             Console.Write("●");
        //         }
        //         else
        //         {
        //             Console.Write("◌");
        //         }
        //     }
        //     Console.WriteLine("");
        // }

        // Console.WriteLine("---------");
    }

    private static void IncreaseVisit(Dictionary<(int, int), int> visited, int tx, int ty)
    {
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
        return (hx == tx && ty == hy) || (hx - 1 == tx && hy == ty) || (hx + 1 == tx && hy == ty) ||
            (hx == tx && hy - 1 == ty) || (hx == tx && hy + 1 == ty) ||
            (hx - 1 == tx && hy - 1 == ty) || (hx + 1 == tx && hy + 1 == ty) ||
            (hx - 1 == tx && hy + 1 == ty) || (hx + 1 == tx && hy - 1 == ty);
    }
}




// private void MoveRight(Knot tail, Dictionary<(int, int), int> visited, Knot knot)
// {
//     if (knot.Behind != null && !IsAdjecent(knot.x, knot.y, knot.Behind.x, knot.Behind.y))
//     {
//         knot.Behind.x = knot.x - 1;
//         //knot.Behind.y = knot.y;

//         if (knot.Behind.Behind != null)
//         {
//             MoveRight(tail, visited, knot.Behind);
//         }

//         if (knot.Behind == tail)
//         {
//             IncreaseVisit(visited, tail.x, tail.y);
//         }
//     }
// }

// private void MoveLeft(Knot tail, Dictionary<(int, int), int> visited, Knot knot)
// {
//     if (knot.Behind != null && !IsAdjecent(knot.x, knot.y, knot.Behind.x, knot.Behind.y))
//     {
//         knot.Behind.x = knot.x + 1;
//         //knot.Behind.y = knot.y;

//         if (knot.Behind.Behind != null)
//         {
//             MoveLeft(tail, visited, knot.Behind);
//         }

//         if (knot.Behind == tail)
//         {
//             IncreaseVisit(visited, tail.x, tail.y);
//         }
//     }
// }

// private void MoveUp(Knot tail, Dictionary<(int, int), int> visited, Knot knot)
// {
//     if (knot.Behind != null && !IsAdjecent(knot.x, knot.y, knot.Behind.x, knot.Behind.y))
//     {
//         knot.Behind.y = knot.y - 1;
//         //knot.Behind.x = knot.x;

//         if (knot.Behind.Behind != null)
//         {
//             MoveUp(tail, visited, knot.Behind);
//         }

//         if (knot.Behind == tail)
//         {
//             IncreaseVisit(visited, tail.x, tail.y);
//         }
//     }
//     PrintOut(allKnots);
// }

// private void MoveDown(Knot tail, Dictionary<(int, int), int> visited, Knot knot)
// {
//     if (knot.Behind != null && !IsAdjecent(knot.x, knot.y, knot.Behind.x, knot.Behind.y))
//     {
//         knot.Behind.y = knot.y + 1;
//         //knot.Behind.x = knot.x;

//         if (knot.Behind.Behind != null)
//         {
//             MoveDown(tail, visited, knot.Behind);
//         }

//         if (knot.Behind == tail)
//         {
//             IncreaseVisit(visited, tail.x, tail.y);
//         }
//     }
// }
