namespace Day10;

public partial class Day10_Part1
{
    internal void Run()
    {
        Queue<(int, int)> instructions = new Queue<(int, int)>(Input.input.Split(Environment.NewLine)
            .Select(s => s.Split(' '))
            .Select(s => s.Length == 1 ? (1, 0) : (2, int.Parse(s[1]))));
        var x = 1;
        var sum = 0;
        var instruction = instructions.Dequeue();

        for (int cycle = 1; cycle <= 220; cycle++)
        {
            instruction.Item1--;

            if ((cycle - 20) % 40 == 0)
            {
                sum += cycle * x;
            }

            if (instruction.Item1 == 0)
            {
                x += instruction.Item2;

                if (instructions.Count == 0)
                    break;

                instruction = instructions.Dequeue();
            }
        }

        Console.WriteLine($"Answer {sum}");
    }
}