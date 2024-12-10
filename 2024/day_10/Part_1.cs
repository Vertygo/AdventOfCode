namespace Day10;

public partial class Day10_Part1
{
    internal void Run()
    {
        var heights = Input.input.Split(Environment.NewLine).Select(s => s.ToCharArray()).ToArray();
        var positions = GetHeightPositions(heights).ToList();
        var trailheads = positions.Where(s => s.IsTrailhead).ToList();
        var stepDirections = new (int x, int y)[] { (0, -1), (-1, 0), (1, 0), (0, 1) };

        foreach (var trailhead in trailheads)
        {
            SetAdjecentValidUphilSlope(stepDirections, positions, trailhead);
        }

        var score = trailheads.SelectMany(s => s.PeakCoords.Distinct()).Count();
        Console.WriteLine(score);
    }

    private void SetAdjecentValidUphilSlope((int x, int y)[] stepDirections, List<HeightPosition> positions, HeightPosition currentPosition)
    {
        foreach (var stepDirection in stepDirections)
        {
            var heightPosition = positions.FirstOrDefault(s => s.Coord.X == currentPosition.Coord.X + stepDirection.x && // match X
                s.Coord.Y == currentPosition.Coord.Y + stepDirection.y && // match Y
                s.Height == currentPosition.Height + 1 // match expected height
             );

            if (heightPosition != null)
            {
                currentPosition.Trail.Add(heightPosition);
                SetAdjecentValidUphilSlope(stepDirections, positions, heightPosition);
            }
        }
    }

    private static IEnumerable<HeightPosition> GetHeightPositions(char[][] heights)
    {
        for (int y = 0; y < heights.Length; y++)
        {
            for (int x = 0; x < heights[0].Length; x++)
            {
                yield return new HeightPosition(new Coord(x, y), int.Parse($"{heights[y][x]}"));
            }
        }
    }

    class HeightPosition(Coord coord, int height)
    {
        public bool IsTrailhead { get; } = height == 0;
        public Coord Coord { get; set; } = coord;
        public IEnumerable<Coord> PeakCoords
        {
            get
            {
                if (Height == 9)
                    return new[] { Coord };

                var a = Trail.SelectMany(s => s.PeakCoords); ;
                return a;
            }
        }
        public int Height { get; set; } = height;
        public List<HeightPosition> Trail { get; set; } = new List<HeightPosition>();
    }

    record Coord(int X, int Y);
}