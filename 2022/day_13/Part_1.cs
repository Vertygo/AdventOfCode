namespace Day13;

public partial class Day13_Part1
{
    public enum OrderValue
    {
        Right,
        Wrong,
        Continue,
    }

    public interface IInteger
    {
        OrderValue IsLessThan(IInteger integer);
    }

    public class PacketPair
    {
        private string _left;
        private string _right;

        public IntegerList _leftInteger;
        public IntegerList _rightInteger;


        public PacketPair(string[] input)
        {
            _left = input[0];
            _right = input[1];

            _leftInteger = Parse(_left);
            _rightInteger = Parse(_right);

            if (_left != _leftInteger.ToString())
                throw new Exception($"Left:{Environment.NewLine}{_left}{Environment.NewLine}{_leftInteger.ToString()}");
            if (_right != _rightInteger.ToString())
                throw new Exception($"Right:{Environment.NewLine}{_right}{Environment.NewLine}{_rightInteger.ToString()}");
        }

        private IntegerList Parse(string left)
        {
            var result = new IntegerList();
            IntegerList current = null;
            var entries = new Queue<char>(left.ToCharArray());
            var currentNumber = string.Empty;

            while (entries.Count > 0)
            {
                var c = entries.Dequeue();
                if (c == '[')
                {
                    var n = new IntegerList();

                    if (current == null)
                    {
                        result = n;
                    }
                    else
                    {
                        current.Add(n);
                    }

                    current = n;
                }
                else if (c == ']')
                {
                    if (!string.IsNullOrEmpty(currentNumber))
                    {
                        current.Add(new IntegerValue(int.Parse(currentNumber)));
                        currentNumber = string.Empty;
                    }

                    current = current.Parent;
                }
                else if (c == ',')
                {
                    if (!string.IsNullOrEmpty(currentNumber))
                    {
                        current.Add(new IntegerValue(int.Parse(currentNumber)));
                        currentNumber = string.Empty;
                    }
                }
                else if (char.IsNumber(c))
                {
                    currentNumber += c;
                }
            }

            return result;
        }

        public override string ToString()
        {
            return $"{_left}{Environment.NewLine}{_right}";
        }

        internal bool IsCorrectOrder()
        {
            for (int i = 0; i < _leftInteger.Values.Count; i++)
            {
                if (_rightInteger.Values.Count - 1 < i)
                {
                    return false;
                }

                var left = _leftInteger.Values[i];
                var right = _rightInteger.Values[i];

                switch (left.IsLessThan(right))
                {
                    case OrderValue.Right:
                        return true;
                    case OrderValue.Wrong:
                        return false;
                    case OrderValue.Continue:
                        break;
                }

            }

            return _rightInteger.Values.Count > _leftInteger.Values.Count;
        }
    }

    public class IntegerValue : IInteger
    {
        public int Value { get; init; }
        public IntegerValue(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public OrderValue IsLessThan(IInteger right)
        {
            if (right is IntegerValue)
            {
                if (Value < ((IntegerValue)right).Value)
                {
                    return OrderValue.Right;
                }
                else if (Value > ((IntegerValue)right).Value)
                {
                    return OrderValue.Wrong;
                }
                else
                {
                    return OrderValue.Continue;
                }
            }

            // single value vs list
            switch (right.IsLessThan(this))
            {
                case OrderValue.Right:
                    return OrderValue.Wrong;
                case OrderValue.Wrong:
                    return OrderValue.Right;
                case OrderValue.Continue:
                    return OrderValue.Continue;
                default:
                    throw new NotImplementedException();
            }
        }
    }

    public class IntegerList : IInteger
    {
        // [1,                       1
        //    [1,2],                 array(1,2)
        //          [1, [1,2]],      array(1, array(1,2))
        //                      3]   3
        public List<IInteger> Values { get; set; } = new List<IInteger>();

        public override string ToString()
        {
            return $"[{string.Join(",", Values.Select(s => s.ToString()))}]";
        }

        public void Add(IInteger value)
        {
            Values.Add(value);
            if (value is IntegerList)
            {
                ((IntegerList)value).Parent = this;
            }
        }

        public OrderValue IsLessThan(IInteger right)
        {
            OrderValue result = OrderValue.Continue;

            if (right is IntegerList)
            {
                for (int i = 0; i < Values.Count; i++)
                {
                    if (((IntegerList)right).Values.Count - 1 < i)
                    {
                        return OrderValue.Wrong;
                    }

                    switch (Values[i].IsLessThan(((IntegerList)right).Values[i]))
                    {
                        case OrderValue.Right:
                            return OrderValue.Right;
                        case OrderValue.Wrong:
                            return OrderValue.Wrong;
                        case OrderValue.Continue:
                            break;
                    }
                }

                if (Values.Count < ((IntegerList)right).Values.Count)
                {
                    return OrderValue.Right;
                }
            }
            else
            {
                if (Values.Count == 0)
                {
                    result = OrderValue.Right;
                }
                else if ((right is IntegerValue && Values[0] is IntegerList))
                {
                    result = OrderValue.Wrong;
                }
                else
                {
                    result = Values[0].IsLessThan(right);
                }
            }

            return result;
        }

        public IntegerList Parent { get; private set; }
    }

    internal void Run()
    {
        var packetPairs = Input
            .test2
            .Split(Environment.NewLine + Environment.NewLine)
            .Select(s => new PacketPair(s.Split(Environment.NewLine)))
            .ToList();
        var indiceSum = 0;

        for (int i = 0; i < packetPairs.Count(); i++)
        {
            if (packetPairs[i].IsCorrectOrder())
            {
                Console.WriteLine($"{Environment.NewLine + Environment.NewLine}Right order, index: {i + 1}{Environment.NewLine}{packetPairs[i]}");
                indiceSum += i + 1;
            }
            else
            {
                Console.WriteLine($"{Environment.NewLine + Environment.NewLine}Wrong order, index {i + 1}{Environment.NewLine}{packetPairs[i]}");
            }
        }

        Console.WriteLine($"Right order count {indiceSum}");
    }
}

// 6387
// 6180
// 5836
// 5391
// 5933
// 5597
// 5055