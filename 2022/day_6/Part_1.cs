namespace Day6;


public partial class Day6_Part1
{
    internal void Run()
    {
        for(int i =0;i<Input.input.Length;i++)
        {
            var read = Input.input.Skip(i).Take(4);
            if(read.Distinct().Count() == 4)
            {
                Console.WriteLine($"{i+4}");
                break;
            }
        }
    }
}