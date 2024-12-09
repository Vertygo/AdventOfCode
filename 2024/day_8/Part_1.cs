namespace Day8;

public partial class Day8_Part1
{

    internal void Run()
    {
        var uniquePositions = new HashSet<(int x, int y)>();
        var antenas = GetAntenaPositionList(Input.input.Split(Environment.NewLine).Select(s => s.ToCharArray()).ToArray());
        var frequencyGroup = antenas.GroupBy(s => s.FrequencyCode);
        var antenasCoordGroup = antenas.GroupBy(s => s.Coord).ToDictionary(g => g.Key, g => g.First());
        (int maxX, int maxY) max = (antenas.Max(s => s.Coord.X), antenas.Max(s => s.Coord.Y));

        foreach (var group in frequencyGroup.Where(g => g.Key != null))
        {
            var positions = group.ToList();
            for (int i = 0; i < group.Count(); i++)
            {
                for (int ii = 0; ii < i; ii++)
                {
                    var p1 = positions[i];
                    var p2 = positions[ii];
                    var p1AntinodeCoordinate = GetAntinodeCoord(p1, p2);
                    var p2AntinodeCoordinate = GetAntinodeCoord(p2, p1);

                    if (IsValidCoordinate(p1AntinodeCoordinate, max))
                    {
                        antenasCoordGroup[new Coord(p1AntinodeCoordinate.x, p1AntinodeCoordinate.y)].HasAntinode = true;
                    }
                    if (IsValidCoordinate(p2AntinodeCoordinate, max))
                    {
                        antenasCoordGroup[new Coord(p2AntinodeCoordinate.x, p2AntinodeCoordinate.y)].HasAntinode = true;
                    }
                }
            }
        }

        Console.WriteLine(antenasCoordGroup.Values.Count(s => s.HasAntinode));
    }

    // check if coordinate is within the bounds
    private bool IsValidCoordinate((int x, int y) coord, (int maxX, int maxY) max)
        => coord.x >= 0 && coord.x <= max.maxX && coord.y >= 0 && coord.y <= max.maxY;

    // get antinode x,y coordinate
    private (int x, int y) GetAntinodeCoord(Position first, Position second)
        => (x: first.Coord.X + (first.Coord.X - second.Coord.X), y: first.Coord.Y + (first.Coord.Y - second.Coord.Y));

    private static IEnumerable<Position> GetAntenaPositionList(char[][] antenas)
    {
        for (int y = 0; y < antenas.Length; y++)
        {
            for (int x = 0; x < antenas[0].Length; x++)
            {
                // "." don't actually have frequency but we need it for map/positions
                var frequencyCode = antenas[y][x] != '.' ? antenas[y][x] : (char?)null;
                var pos = new Position(new Coord(x, y), frequencyCode, false);
                yield return pos;
            }
        }
    }

    class Position(Coord coord, char? frequencyCode, bool hasAntinode)
    {
        public Coord Coord { get; set; } = coord;
        public char? FrequencyCode { get; } = frequencyCode;
        public bool HasAntinode { get; set; } = hasAntinode;
    }

    record Coord(int X, int Y);
}