namespace Day7;

public partial class Day7_Part1
{
    record Equation(long testValue, long[] numbers);
    Dictionary<char, Func<long[], long>> operators = new()
    {
        ['+'] = (long[] numbers) => numbers[0] + numbers[1],
        ['*'] = (long[] numbers) => numbers[0] + numbers[1]
    };

    internal void Run()
    {
        var equations = Input.input.Split(Environment.NewLine).Select(s => CreateEquation(s.Split(':', StringSplitOptions.TrimEntries)));
        var result = equations.Where(CanProduceTestNumber).Sum(s => s.testValue);
        Console.WriteLine(result);
    }

    private bool CanProduceTestNumber(Equation equation)
    {
        var combination = string.Join("", Enumerable.Repeat('+', equation.numbers.Length - 1).ToArray());
        var map = new HashSet<string>(new string[] { combination });

        for (int i = 0; i < equation.numbers.Length - 1; i++)
        {
            for (int cm = 0; cm < map.Count; cm++)
            {
                for (int c = 0; c < operators.Count; c++)
                {
                    var newCombo = new List<char>(map.ElementAt(cm)).ToArray();
                    newCombo[i] = operators.Keys.ElementAt(c);
                    map.Add(string.Join("", newCombo));
                }
            }
        }


        foreach (var combo in map)
        {
            var sum = equation.numbers[0];
            for (var n = 1; n < equation.numbers.Length; n++)
            {
                if (combo[n - 1] == '+')
                {
                    sum += equation.numbers[n];
                }
                else if (combo[n - 1] == '*')
                {
                    sum *= equation.numbers[n];
                }
            }

            if (sum == equation.testValue)
            {
                return true;
            }
        }
        return false;
    }

    private Equation CreateEquation(string[] equation) => new Equation(long.Parse(equation[0]), equation[1].Split(' ').Select(long.Parse).ToArray());
}