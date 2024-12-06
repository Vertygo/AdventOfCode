using System.Text;

namespace Day6;

public partial class Day6_Part2
{
    private record Position(int X, int Y);
    Dictionary<char, (int x, int y, char nextFacing)> directions = new Dictionary<char, (int x, int y, char nextFacing)>()
    {
        ['^'] = new(0, -1, '>'),
        ['>'] = new(1, 0, 'V'),
        ['V'] = new(0, 1, '<'),
        ['<'] = new(-1, 0, '^'),
    };

    internal void Run()
    {
        var mapInput = Input.input.Split(Environment.NewLine).Select(s => s.ToCharArray().ToArray()).ToArray();
        Dictionary<Position, char> map = CreateMap(mapInput);
        var counter = 0;
        var yLen = mapInput.Length;
        var xLen = mapInput[0].Length;

        for (int y = 0; y < yLen; y++)
        {
            Console.WriteLine($"{y} - {counter}");
            for (int x = 0; x < xLen; x++)
            {
                if (IsGuardLoop(new Position(x, y), xLen, yLen, map.ToDictionary()))
                {
                    counter++;
                }
            }
        }

        Console.WriteLine(counter);
    }

    private bool IsGuardLoop(Position obstaclePosition, int xLen, int yLen, Dictionary<Position, char> map)
    {
        char startChr = '^';
        Position currentPosition = map.First(s => s.Value == startChr).Key;
        bool currentPositionOccupied = map[obstaclePosition] == '#' || map[obstaclePosition] == startChr;
        Dictionary<Position, int> counter = new Dictionary<Position, int>();

        if (currentPositionOccupied)
        {
            return false;
        }

        map[obstaclePosition] = '#'; // place obstacle on map

        while (currentPosition.Y != yLen - 1 &&
            currentPosition.Y != 0 &&
            currentPosition.X != xLen - 1 &&
            currentPosition.X != 0)
        {
            var nextFacing = map[currentPosition];
            var direction = directions[nextFacing];

            // change facing and direction if we hit obstacle
            while (map[new(currentPosition.X + direction.x, currentPosition.Y + direction.y)] == '#')
            {
                nextFacing = direction.nextFacing;
                direction = directions[direction.nextFacing];
            }

            // move to next position and set guard facing
            currentPosition = new(currentPosition.X + direction.x, currentPosition.Y + direction.y);
            map[currentPosition] = nextFacing;

            if (!counter.TryAdd(currentPosition, 1))
            {
                counter[currentPosition] += 1;
                // same obstacle can be touched 4 times from different directions
                // 5th time means we are going in a loop
                if (counter[currentPosition] > 4)
                {
                    return true;
                }
            }

            // PrintMap(map, xLen, yLen);
        }

        return false;
    }

    private void PrintMap(Dictionary<Position, char> map, int xLen, int yLen)
    {
        var sb = new StringBuilder();
        for (int y = 0; y < yLen; y++)
        {
            for (int x = 0; x < xLen; x++)
            {
                sb.Append(map[new(x, y)]);
            }
            sb.AppendLine();
        }
        Console.WriteLine(sb.ToString());
        Console.WriteLine();
        Console.WriteLine();
    }

    private Dictionary<Position, char> CreateMap(char[][] mapInput)
    {
        var map = new Dictionary<Position, char>();

        for (int y = 0; y < mapInput.Length; y++)
        {
            for (int x = 0; x < mapInput[y].Length; x++)
            {
                map.Add(new Position(x, y), mapInput[y][x]);
            }
        }

        return map;
    }
}