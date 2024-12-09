namespace Day8;

public partial class Day8_Part2
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
                for (int p = 0; p < i; p++)
                {
                    var p1 = positions[i];
                    var p2 = positions[p];
                    MarkAnitnodes(p1.Coord, p2.Coord, antenasCoordGroup, max);
                    MarkAnitnodes(p2.Coord, p1.Coord, antenasCoordGroup, max);
                    // mark antinode occurance at the position of each antenna
                    antenasCoordGroup[p1.Coord].HasAntinode = true;
                    antenasCoordGroup[p2.Coord].HasAntinode = true;
                }
            }
        }

        Console.WriteLine(antenasCoordGroup.Values.Count(s => s.HasAntinode));
    }

    // check if coordinate is within the bounds
    private bool IsValidCoordinate(Coord coord, (int maxX, int maxY) max)
        => coord.X >= 0 && coord.X <= max.maxX && coord.Y >= 0 && coord.Y <= max.maxY;

    // get antinode x, y coordinate
    private void MarkAnitnodes(Coord first, Coord second, Dictionary<Coord, Position> antenasCoordGroup, (int maxX, int maxY) max)
    {
        var coord = new Coord(first.X + (first.X - second.X), first.Y + (first.Y - second.Y));

        if (IsValidCoordinate(coord, max))
        {
            antenasCoordGroup[new Coord(coord.X, coord.Y)].HasAntinode = true;
            MarkAnitnodes(coord, first, antenasCoordGroup, max);
        }
    }

    private static IEnumerable<Position> GetAntenaPositionList(char[][] antenas)
    {
        for (int y = 0; y < antenas.Length; y++)
        {
            for (int x = 0; x < antenas[0].Length; x++)
            {
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