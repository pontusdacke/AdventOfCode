var input = File.ReadAllLines("./input.txt");

bool Match(string num, string line)
{
    if (num.Length > line.Length) return false;
    return line.Substring(0, num.Length) == num;
}

var numbers = new Dictionary<string, string>
{
    ["one"] = "1",
    ["two"] = "2",
    ["three"] = "3",
    ["four"] = "4",
    ["five"] = "5",
    ["six"] = "6",
    ["seven"] = "7",
    ["eight"] = "8",
    ["nine"] = "9",
};

var sum = 0;
foreach (var i in input)
{
    var digits = "";
    for (int c = 0; c < i.Length; c++)
    {
        if (char.IsDigit(i[c]))
        {
            digits += i[c];
            break;
        }
        else if (FindDigit(i, c, out var digs))
        {
            digits += digs;
            break;
        }
    }
    for (int d = i.Length - 1; d >= 0; d--)
    {
        if (char.IsDigit(i[d]))
        {
            digits += i[d];
            break;
        }
        else if (FindDigit(i, d, out var digs))
        {
            digits += digs;
            break;
        }
    }
    sum += int.Parse(digits);
}

bool FindDigit(string line, int i, out string digits)
{
    string toCheck = line.Substring(i);
    foreach (var num in numbers.Keys)
    {
        if (Match(num, toCheck))
        {
            digits = numbers[num];
            return true;
        }
    }
    digits = "";
    return false;
}

Console.WriteLine(sum);
