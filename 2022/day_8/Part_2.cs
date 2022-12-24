namespace Day8;



public partial class Day8_Part2
{

    internal void Run()
    {
        var count = 0;
        long max = 0;
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
                    long fac = IsHigherLeft(input, input[x][y], x, y) * IsHigherRight(input, input[x][y], x, y) * IsHigherTop(input, input[x][y], x, y) * IsHigherBottom(input, input[x][y], x, y);
                    if (fac > max)
                    {
                        max = fac;
                    }
                }
            }
        }
        Console.WriteLine($"Count {max}");
    }

    private int IsHigherBottom(int[][] input, int v, int x, int y)
    {
        //bool res = true;
        var count = 0;
        for (int i = y + 1; i < input[y].Length; i++)
        {
            count++;
            if (input[x][i] >= v)
            {
                break;
            }
        }
        return count;
    }

    private int IsHigherRight(int[][] input, int v, int x, int y)
    {
        var count = 0;
        for (int i = x + 1; i < input[x].Length; i++)
        {
            count++;
            if (input[i][y] >= v)
            {
                break;
            }
        }
        return count;
    }

    private int IsHigherTop(int[][] input, int v, int x, int y)
    {
        var count = 0;
        for (int i = y - 1; i >= 0; i--)
        {
            count++;
            if (input[x][i] >= v)
            {
                break;
            }
        }
        return count;
    }

    private int IsHigherLeft(int[][] input, int v, int x, int y)
    {
        var count = 0;
        for (int i = x - 1; i >= 0; i--)
        {
            count++;
            if (input[i][y] >= v)
            {
                break;
            }
        }
        return count;
    }
}
