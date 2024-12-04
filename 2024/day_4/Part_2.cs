namespace Day4;

public partial class Day4_Part2
{
    char[][] lines = Input.input.Split(Environment.NewLine).Select(s => s.ToCharArray()).ToArray();

    internal void Run()
    {
        var counter = 0;
        var directions = new (char chr, int x, int y)[]
        {
            ('M', -1, 1), ('S', 1, 1), ('M', -1, -1), ('S', 1, -1),
            ('S', -1, 1), ('M', 1, 1), ('S', -1, -1), ('M', 1, -1),
            ('M', -1, 1), ('M', 1, 1), ('S', -1, -1), ('S', 1, -1),
            ('S', -1, 1), ('S', 1, 1), ('M', -1, -1), ('M', 1, -1),
        }.Chunk(4);


        for (int y = 0; y < lines.Count(); y++)
        {
            var lineChars = lines[y];
            for (int x = 0; x < lineChars.Length; x++)
            {
                if (lineChars[x] == 'A')
                {
                    counter += directions.Count(d => FindXmas(x, y, d));
                }
            }
        }

        Console.WriteLine(counter);
    }

    private bool FindXmas(int x, int y, (char chr, int x, int y)[] direction)
    {
        var xmasFound = direction.All(d =>
        {
            var xPos = x + d.x;
            var yPos = y + d.y;

            // make sure we are not out of bounds and we have correct letter
            return xPos > -1 && xPos < lines[0].Length &&
                yPos > -1 && yPos < lines.Length && 
                lines[yPos][xPos] == d.chr;
        });

        return xmasFound;
    }
}