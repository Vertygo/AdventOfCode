namespace Day10;

public class Operation
{
    public Operation(string operation)
    {
        OperationDesc = operation;
        var opFragments = operation.Split("=", StringSplitOptions.TrimEntries)[1] // take operation after equals => Operation: new = old * old
            .Split(" ");

        Op = new Func<long, long>((old) =>
        {
            // only * / + are supported
            var first = opFragments[0] == "old" ? old : long.Parse(opFragments[0]);
            var second = opFragments[2] == "old" ? old : long.Parse(opFragments[2]);

            return opFragments[1] == "*" ? first * second : first + second;
        });
    }

    public string OperationDesc { get; }
    public Func<long, long> Op { get; }
}

public class Monkey
{
    public string Name { get; }
    public Queue<long> WorryLevels { get; set; } = new Queue<long>();
    public Operation Operation { get; set; }
    private int _testValue = 0;
    private int testTrue = 0;
    private int testFalse = 0;

    public int InspectTimes { get; set; } = 0;

    public Monkey(string monkeyInfo)
    {
        var info = monkeyInfo.Split(Environment.NewLine);
        Name = info[0].Replace(":", "");
        WorryLevels = new Queue<long>(info[1].Split(":")[1].Split(",").Select(long.Parse));
        Operation = new Operation(info[2]);
        _testValue = int.Parse(info[3].Replace("Test: divisible by ", ""));
        testTrue = int.Parse(info[4].Replace("If true: throw to monkey ", ""));
        testFalse = int.Parse(info[5].Replace("If false: throw to monkey ", ""));
    }


    public (long worryLevel, int monkey) Test(long worryLevel)
    {
        InspectTimes++;
        long newWorryLevel = (long)Math.Floor((decimal)Operation.Op.Invoke(worryLevel) / 3);
        bool isDivisible = newWorryLevel % _testValue == 0;

        return (newWorryLevel, isDivisible ? testTrue : testFalse);
    }
}

public partial class Day10_Part1
{
    internal void Run()
    {
        var monkeys = Input.test.Split(Environment.NewLine + Environment.NewLine)
            .Select(s => new Monkey(s))
            .ToList();
            
        for (int i = 0; i < 20; i++)
        {
            foreach (var monkey in monkeys)
            {
                while (monkey.WorryLevels.Count > 0)
                {
                    var worryLevel = monkey.WorryLevels.Dequeue();
                    var (newWorryLevel, monkeyId) = monkey.Test(worryLevel);
                    monkeys[monkeyId].WorryLevels.Enqueue(newWorryLevel);
                }
            }
        }

        long res = monkeys.OrderByDescending(s => s.InspectTimes).Select(s => s.InspectTimes).Take(2).Aggregate((a,b)=> a*b);
        Console.WriteLine($"monkey business {res}");
    }
}