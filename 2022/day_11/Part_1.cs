namespace Day11;

public partial class Day11_Part1
{
    public class Ground
    {
        private char v;
        public int X { get; }
        public int Y { get; }

        public Ground(char v, int x, int y)
        {
            if (v == 'S')
                this.v = 'a';
            else if (v == 'E')
                this.v = 'z';
            else
                this.v = v;

            this.X = x;
            this.Y = y;


            IsStart = v == 'S';
            IsEnd = v == 'E';
        }

        public bool CanStep(Ground from)
        {
            return from.v - v >= -1;
        }

        public bool IsStart { get; }
        public bool IsEnd { get; }
    }
    Dictionary<(int x, int y), Ground> map = new Dictionary<(int x, int y), Ground>();

    internal void Run()
    {
        var input = Input
            .input
            .Split(Environment.NewLine)
            .Select(s => s.ToCharArray())
            .ToList();

        for (int x = 0; x < input[0].Count(); x++)
        {
            for (int y = 0; y < input.Count; y++)
            {
                map.Add((x, y), new Ground(input[y][x], x, y));
            }
        }

        bool found = false;
        var current = map.Values.First(s => s.IsStart);
        int steps = 0;
        List<Ground> currentSteps = new List<Ground>();
        currentSteps.Add(current);

        do
        {
            List<Ground> nextSteps = new List<Ground>();
            foreach (var step in currentSteps)
            {
                if (step.X > 0)
                {
                    if (map.TryGetValue((step.X - 1, step.Y), out Ground next) && next.CanStep(step))
                    {
                        if (next.IsEnd)
                        {
                            found = true;
                            break;
                        }
                        nextSteps.Add(next);
                        map.Remove((next.X, next.Y));
                    }
                }

                if (step.X < input[0].Count() - 1)
                {
                    if (map.TryGetValue((step.X + 1, step.Y), out Ground next) && next.CanStep(step))
                    {
                        if (next.IsEnd)
                        {
                            found = true;
                            break;
                        }
                        nextSteps.Add(next);
                        map.Remove((next.X, next.Y));

                    }
                }

                if (step.Y > 0)
                {
                    if (map.TryGetValue((step.X, step.Y - 1), out Ground next) && next.CanStep(step))
                    {
                        if (next.IsEnd)
                        {
                            found = true;
                            break;
                        }
                        nextSteps.Add(next);
                        map.Remove((next.X, next.Y));

                    }
                }

                if (step.Y < input.Count - 1)
                {
                    if (map.TryGetValue((step.X, step.Y + 1), out Ground next) && next.CanStep(step))
                    {
                        if (next.IsEnd)
                        {
                            found = true;
                            break;
                        }
                        nextSteps.Add(next);
                        map.Remove((next.X, next.Y));

                    }
                }
            }

            Console.WriteLine($"next steps {nextSteps.Count}; steps {steps}");
            currentSteps = nextSteps;

            steps++;
        } while (!found);

        Console.WriteLine($"found in {steps}");
    }
}