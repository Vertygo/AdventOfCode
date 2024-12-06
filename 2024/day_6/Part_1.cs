using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Day6;

public partial class Day6_Part1
{
    private record Position(int X, int Y);

    internal void Run()
    {
        var visitedPositions = new HashSet<Position>();
        var mapInput = Input.input.Split(Environment.NewLine).Select(s => s.ToCharArray().ToArray()).ToArray();
        Dictionary<Position, char> map = CreateMap(mapInput);
        Position currentPosition = map.First(s => s.Value == '^').Key;

        var directions = new Dictionary<char, (int x, int y, char nextDirection)>()
        {
            ['^'] = new(0, -1, '>'),
            ['>'] = new(1, 0, 'V'),
            ['V'] = new(0, 1, '<'),
            ['<'] = new(-1, 0, '^'),
        };

        while (currentPosition.Y != mapInput.Length - 1 && 
            currentPosition.Y != 0 &&
            currentPosition.X != mapInput[0].Length -1 &&
            currentPosition.X != 0)
        {
            visitedPositions.Add(currentPosition);
            var nextDirection = map[currentPosition];
            var direction = directions[nextDirection];
            
            // change direction if we hit obstacle
            while (map[new(currentPosition.X + direction.x, currentPosition.Y + direction.y)] == '#')
            {
                nextDirection = direction.nextDirection;
                direction = directions[direction.nextDirection];
            }

            // move to next position and set guard direction
            currentPosition = new(currentPosition.X + direction.x, currentPosition.Y + direction.y);
            map[currentPosition] = nextDirection;
            //PrintMap(map, mapInput[0].Length, mapInput.Length);
        }

        Console.WriteLine(visitedPositions.Count+1);
    }

    private void PrintMap(Dictionary<Position, char> map, int xLen, int yLen)
    {
        var sb = new StringBuilder();
        for (int y = 0; y < yLen; y++)
        {
            for (int x = 0; x < xLen; x++)
            {
                sb.Append(map[new (x,y)]);
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