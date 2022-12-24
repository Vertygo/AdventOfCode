namespace Day10;

public partial class Day10_Part2
{

    internal void Run()
    {
        Queue<(int, int)> instructions = new Queue<(int, int)>(Input.input.Split(Environment.NewLine)
            .Select(s => s.Split(' '))
            .Select(s => s.Length == 1 ? (1, 0) : (2, int.Parse(s[1]))));
        var x = 1;
        var instruction = instructions.Dequeue();
        var crt = "";

        for (int height = 0; height <= 5; height++)
        {
            for (int cycle = 1; cycle <= 40; cycle++)
            {
                instruction.Item1--;

                crt += x - 1 <= cycle - 1 && x + 1 >= cycle - 1 ? "#" : ".";

                if (instruction.Item1 == 0)
                {
                    x += instruction.Item2;

                    if (instructions.Count == 0)
                        break;

                    instruction = instructions.Dequeue();
                }


            }
        }

        Console.WriteLine($"{string.Join(Environment.NewLine, crt.Chunk(40).Select(s => string.Join("", s)))}");
    }
}
