namespace Day4;

public partial class Day4_Part1
{
    char[][] words = Input.input.Split(Environment.NewLine).Select(s => s.ToCharArray()).ToArray();

    internal void Run()
    {
        var directions = new (char c, int x, int y)[]
        {
            ('M', -1,0), ('A',-2, 0), ('S',-3, 0), // left
            ('M',1,0), ('A',2, 0), ('S',3, 0), // right
            ('M',0,1), ('A',0, 2), ('S',0, 3), // up
            ('M',0,-1), ('A',0, -2), ('S',0, -3), // down
            ('M',-1, 1), ('A',-2, 2), ('S',-3, 3), // left up
            ('M',1, 1), ('A',2, 2), ('S',3, 3), // right up
            ('M',-1, -1), ('A',-2, -2), ('S',-3, -3), // left down
            ('M',1, -1), ('A',2, -2), ('S',3, -3), // right down
        }.Chunk(3);
        var counter = 0;

        for (int y = 0; y < words.Count(); y++)
        {
            var word = words[y];
            for (int x = 0; x < word.Length; x++)
            {
                if (word[x] == 'X')
                {
                    foreach (var direction in directions)
                    {
                        if(SearchXmas(x, y, direction))
                        {
                            counter++;
                        }
                    }
                }
            }
        }

        Console.WriteLine(counter);
    }

    private bool SearchXmas(int x, int y, (char c, int x, int y)[] direction)
    {
        var xmasFound = direction.All(d =>
        {
            var xPos = x + d.x;
            var yPos = y + d.y;

            if (xPos > -1 && xPos < words[0].Length && yPos > -1 && yPos < words.Length)
            {
                if (words[yPos][xPos] == d.c)
                {
                    return true;
                }
            }

            return false;
        });

        return xmasFound;
    }
}