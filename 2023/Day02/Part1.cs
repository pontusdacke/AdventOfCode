var input = File.ReadAllLines("./input.txt");

int maxRed = 12, maxGreen = 13, maxBlue = 14;
int sum = 0;

foreach (var i in input)
{
    var data = i.Split(":");
    var id = int.Parse(data[0].Substring(5));
    var possible = true;
    foreach (var set in data[1].Split(";"))
    {
        foreach (var subset in set.Split(","))
        {
            possible = possible && (
                (subset.Contains("blue") && GetDigits(subset) <= maxBlue)
                || (subset.Contains("green") && GetDigits(subset) <= maxGreen)
                || (subset.Contains("red") && GetDigits(subset) <= maxRed));
        }
    }

    if (possible) sum += id;
}

int GetDigits(string s)
{
    string num = "";
    foreach (var c in s)
    {
        if (char.IsDigit(c)) num += c;
    }
    return int.Parse(num);
}

Console.WriteLine(sum);