namespace Day10;

public partial class Day10_Part2
{
    Coord[] stepDirections = { new(0, -1), new(-1, 0), new(1, 0), new(0, 1) }; // top, left, right, down
    internal void Run()
    {
        var heights = Input.input.Split(Environment.NewLine).Select(s => s.ToCharArray()).ToArray();
        var mapHeights = GetMapHeights(heights).ToList();
        var trailheads = mapHeights.Where(s => s.IsTrailhead);

        foreach (var trailhead in trailheads)
        {
            SetAdjecentValidUphilSlopes(mapHeights, trailhead);
        }

        var score = trailheads.Sum(s => s.Score);
        Console.WriteLine(score);
    }

    private void SetAdjecentValidUphilSlopes(IEnumerable<MapHeight> mapHeights, MapHeight currentMapHeight)
    {
        foreach (var stepDirection in stepDirections)
        {
            var adjecentMapHeight = mapHeights.FirstOrDefault(mh => mh.Coord == currentMapHeight.Coord + stepDirection && // find position at new coordinate
                mh.Height == currentMapHeight.Height + 1 // match position expected height
             );

            if (adjecentMapHeight != null && !currentMapHeight.Trail.Any(s => s.Coord.X == adjecentMapHeight.Coord.X && s.Coord.Y == adjecentMapHeight.Coord.Y))
            {
                currentMapHeight.Trail.Add(adjecentMapHeight);
                SetAdjecentValidUphilSlopes(mapHeights, adjecentMapHeight);
            }
        }
    }

    private static IEnumerable<MapHeight> GetMapHeights(char[][] heights)
    {
        for (int y = 0; y < heights.Length; y++)
        {
            for (int x = 0; x < heights[0].Length; x++)
            {
                yield return new MapHeight(new Coord(x, y), int.Parse($"{heights[y][x]}"));
            }
        }
    }

    class MapHeight(Coord coord, int height)
    {
        public bool IsTrailhead { get; } = height == 0;
        public Coord Coord { get; set; } = coord;
        public int Score
        {
            get
            {
                if (Height == 9)
                    return 1;

                return Trail.Select(s => s.Score).Sum();
            }
        }
        public int Height { get; set; } = height;
        public List<MapHeight> Trail { get; set; } = new List<MapHeight>();
    }

    record Coord(int X, int Y)
    {
        public static Coord operator +(Coord first, Coord second) => new Coord(first.X + second.X, first.Y + second.Y);
    }
}