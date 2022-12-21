namespace Day10;

public static class Input
{
    public static string test = @$"Monkey 0:
  Starting items: 79, 98
  Operation: new = old * 19
  Test: divisible by 23
    If true: throw to monkey 2
    If false: throw to monkey 3

Monkey 1:
  Starting items: 54, 65, 75, 74
  Operation: new = old + 6
  Test: divisible by 19
    If true: throw to monkey 2
    If false: throw to monkey 0

Monkey 2:
  Starting items: 79, 60, 97
  Operation: new = old * old
  Test: divisible by 13
    If true: throw to monkey 1
    If false: throw to monkey 3

Monkey 3:
  Starting items: 74
  Operation: new = old + 3
  Test: divisible by 17
    If true: throw to monkey 0
    If false: throw to monkey 1";

    public static string input = @$"Monkey 0:
  Starting items: 59, 74, 65, 86
  Operation: new = old * 19
  Test: divisible by 7
    If true: throw to monkey 6
    If false: throw to monkey 2

Monkey 1:
  Starting items: 62, 84, 72, 91, 68, 78, 51
  Operation: new = old + 1
  Test: divisible by 2
    If true: throw to monkey 2
    If false: throw to monkey 0

Monkey 2:
  Starting items: 78, 84, 96
  Operation: new = old + 8
  Test: divisible by 19
    If true: throw to monkey 6
    If false: throw to monkey 5

Monkey 3:
  Starting items: 97, 86
  Operation: new = old * old
  Test: divisible by 3
    If true: throw to monkey 1
    If false: throw to monkey 0

Monkey 4:
  Starting items: 50
  Operation: new = old + 6
  Test: divisible by 13
    If true: throw to monkey 3
    If false: throw to monkey 1

Monkey 5:
  Starting items: 73, 65, 69, 65, 51
  Operation: new = old * 17
  Test: divisible by 11
    If true: throw to monkey 4
    If false: throw to monkey 7

Monkey 6:
  Starting items: 69, 82, 97, 93, 82, 84, 58, 63
  Operation: new = old + 5
  Test: divisible by 5
    If true: throw to monkey 5
    If false: throw to monkey 7

Monkey 7:
  Starting items: 81, 78, 82, 76, 79, 80
  Operation: new = old + 3
  Test: divisible by 17
    If true: throw to monkey 3
    If false: throw to monkey 4";
}