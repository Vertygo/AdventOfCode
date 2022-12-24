namespace Day6;

public partial class Day6_Part2
{
    internal void Run()
    {
        for(int i =0;i<Input.input.Length;i++)
        {
            var read = Input.input.Skip(i).Take(14);
            if(read.Distinct().Count() == 14)
            {
                Console.WriteLine($"{i+14}");
                break;
            }
        }
    }
}