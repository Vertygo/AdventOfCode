namespace Day8;



public partial class Day8_Part1
{

    internal void Run()
    {
        var count = 0;
        var input = Input.input.Split(Environment.NewLine).Select(s => s.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray()).ToArray();
        for (int x = 0; x < input.GetUpperBound(0) + 1; x++)
        {
            for (int y = 0; y < input[x].Length; y++)
            {

                if (x == 0 || y == 0 || x == input.GetUpperBound(0) || y == input[x].Length - 1)
                {
                    count++;
                }
                else
                {
                    if (IsHigherLeft(input, input[x][y], x, y) ||
                        IsHigherRight(input, input[x][y], x, y) ||
                        IsHigherTop(input, input[x][y], x, y) ||
                         IsHigherBottom(input, input[x][y], x, y))
                    {
                        count++;
                    }
                }
            }
        }
        Console.WriteLine($"Count {count}");
    }

    private bool IsHigherBottom(int[][] input, int v, int x, int y)
    {
        for (int i = y + 1; i < input[y].Length; i++)
        {
            if (input[x][i] >= v)
            {
                return false;
            }
        }
        return true;
    }

    private bool IsHigherRight(int[][] input, int v, int x, int y)
    {
        for (int i = x + 1; i < input[x].Length; i++)
        {
            if (input[i][y] >= v)
            {
                return false;
            }
        }
        return true;
    }

    private bool IsHigherTop(int[][] input, int v, int x, int y)
    {
        for (int i = y - 1; i >= 0; i--)
        {
            if (input[x][i] >= v)
            {
                return false;
            }
        }
        return true;
    }

    private bool IsHigherLeft(int[][] input, int v, int x, int y)
    {
        for (int i = x - 1; i >= 0; i--)
        {
            if (input[i][y] >= v)
            {
                return false;
            }
        }
        return true;
    }
}
