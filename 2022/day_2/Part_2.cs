namespace Day2;

public partial class Day2_Part2
{
    Dictionary<char, int> map = new Dictionary<char, int>
    {
        ['A'] = 1, // rock
        ['B'] = 2, // paper
        ['C'] = 3, // scissor

        ['X'] = 1, // rock
        ['Y'] = 2, // paper
        ['Z'] = 3, // scissor
    };

    Dictionary<char, dynamic> winShape = new Dictionary<char, dynamic>
    {
        ['A'] = new {Win = 'Y', Draw = 'X', Loss = 'Z'},
        ['B'] = new {Win = 'Z', Draw = 'Y', Loss = 'X'},
        ['C'] = new {Win = 'X', Draw = 'Z', Loss = 'Y'},
    };

    Dictionary<char, int> expectedResult = new Dictionary<char, int>
    {
        ['X'] = 0,
        ['Y'] = 3,
        ['Z'] = 6,
    };

    enum ExpectedResult
    {
        Loss = 0,
        Win = 6,
        Draw = 3
    }
    

    internal void Run()
    {
        var result = Input.input.Split(Environment.NewLine);
        var score = 0;

        foreach(var res in result)
        {
            var match = res.Replace(" ", "");
            var points = expectedResult[match[1]];
            ExpectedResult er = (ExpectedResult)expectedResult[match[1]];
            if(er == ExpectedResult.Win)
            {
                points+=map[winShape[match[0]].Win];
            }
            if(er == ExpectedResult.Loss)
            {
                points+=map[winShape[match[0]].Loss];
            }
            if(er == ExpectedResult.Draw)
            {
                points+=map[winShape[match[0]].Draw];
            }
            score+=points;
        }
        Console.WriteLine(score);

    }
}
