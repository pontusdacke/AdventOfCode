var input = File.ReadAllLines("./input.txt");

int sum = 0;

foreach (var i in input)
{
    var data = i.Split(":");
    var id = int.Parse(data[0].Substring(5));
    var reds = 0;
    var greens = 0;
    var blues = 0;

    foreach (var set in data[1].Split(";"))
    {
        foreach (var subset in set.Split(","))
        {
            if (subset.Contains("blue")) blues = Math.Max(blues, GetDigits(subset));
            if (subset.Contains("green")) greens = Math.Max(greens, GetDigits(subset));
            if (subset.Contains("red")) reds = Math.Max(reds, GetDigits(subset));
        }
    }

    sum += reds * blues * greens;
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