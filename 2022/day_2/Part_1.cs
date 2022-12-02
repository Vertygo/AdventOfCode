namespace Day2;

public partial class Day2_Part1
{
    int GetGamePoints(char opponent, char me)
    {
        return (int)(me - opponent) switch
        {
            1 or -2 => 6,
            0 => 3,
            _ => 0 // 2, -1
        };
    }

    internal void Run()
    {
        var result = Input.input.Split(Environment.NewLine);
        var score = result
            .Select(s => new {Opponent = s[0], Me = (char)(s[2]-23)})       // convert to base X=>A Y=>B Z=>C
            .Select(s => GetGamePoints(s.Opponent, s.Me) + (char)(s.Me-64)) // A-64 = 1; B-64 = 2; C-64 = 3
            .Sum();
            
        Console.WriteLine(score);
    }
}