using System.Numerics;

namespace Day10;

public partial class Day10_Part2
{
    public class WorryLevel
    {
        public WorryLevel(string lvl)
        {
            Level = BigInteger.Parse(lvl);
        }

        public BigInteger Level { get; set; }
        public bool IsInspected { get; set; } = false;
    }

    public class Operation
    {
        public Operation(string operation)
        {
            OperationDesc = operation;
            var opFragments = operation.Split("=", StringSplitOptions.TrimEntries)[1] // take operation after equals => Operation: new = old * old
                .Split(" ");

            Op = new Func<BigInteger, BigInteger>((old) =>
            {
                // only * / + are supported
                var first = opFragments[0] == "old" ? old : ulong.Parse(opFragments[0]);
                var second = opFragments[2] == "old" ? old : ulong.Parse(opFragments[2]);

                return opFragments[1] == "*" ? first * second : first + second;
            });
        }

        public string OperationDesc { get; }
        public Func<BigInteger, BigInteger> Op { get; }
    }

    public class Monkey
    {
        public string Name { get; }
        public Queue<WorryLevel> WorryLevels { get; set; } = new Queue<WorryLevel>();
        public Operation Operation { get; set; }
        public int TestValue { get; private set; }
        private int testTrue = 0;
        private int testFalse = 0;

        public long InspectTimes { get; set; } = 0;

        public Monkey(string monkeyInfo)
        {
            var info = monkeyInfo.Split(Environment.NewLine);
            Name = info[0].Replace(":", "");
            WorryLevels = new Queue<WorryLevel>(info[1].Split(":")[1].Split(",").Select(s => new WorryLevel(s)));
            Operation = new Operation(info[2]);
            TestValue = int.Parse(info[3].Replace("Test: divisible by ", ""));
            testTrue = int.Parse(info[4].Replace("If true: throw to monkey ", ""));
            testFalse = int.Parse(info[5].Replace("If false: throw to monkey ", ""));
        }

        public int Test(WorryLevel worryLevel)
        {
            InspectTimes++;
            BigInteger newWorryLevel = Operation.Op.Invoke(worryLevel.Level);
            bool isDivisible = newWorryLevel % (ulong)TestValue == 0;

            worryLevel.Level = newWorryLevel;
            worryLevel.IsInspected = true;

            return isDivisible ? testTrue : testFalse;
        }
    }
    internal void Run()
    {
        var monkeys = Input.input.Split(Environment.NewLine + Environment.NewLine)
            .Select(s => new Monkey(s))
            .ToList();
        var denominator = monkeys.Select(s => s.TestValue).Aggregate((a, b) => a *= b); // number dividable by all test values

        for (int i = 0; i < 10000; i++)
        {
            if (i == 1 || i == 20 || i == 1000)
            {
                Console.WriteLine($"== After round {i} ==");

                foreach (var monkey in monkeys)
                {
                    Console.WriteLine($"{monkey.Name}: inspected items {monkey.InspectTimes} times");
                    Console.WriteLine("Worry level: " + string.Join(",", monkey.WorryLevels.Select(s => s.Level)));
                }
                Console.WriteLine(Environment.NewLine);
            }

            foreach (var monkey in monkeys)
            {
                while (monkey.WorryLevels.Count > 0)
                {
                    var worryLevel = monkey.WorryLevels.Dequeue();
                    var monkeyId = monkey.Test(worryLevel);
                    monkeys[monkeyId].WorryLevels.Enqueue(worryLevel);
                }
            }

            // trim down values if level is greater than denominator
            // otherwise we might overflow
            foreach (var monkey in monkeys)
            {
                foreach (var m in monkey.WorryLevels)
                {
                    if (m.Level > denominator)
                        m.Level = m.Level - (denominator * (m.Level / denominator));
                }
            }
        }

        long res = monkeys.OrderByDescending(s => s.InspectTimes).Select(s => s.InspectTimes).Take(2).Aggregate((a, b) => a * b);
        Console.WriteLine($"monkey business {res}");
    }
}
// 19208763616