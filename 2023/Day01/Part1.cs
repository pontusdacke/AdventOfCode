var input = File.ReadAllLines("./input.txt");

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
    }
    for (int d = i.Length - 1; d >= 0; d--)
    {
        if (char.IsDigit(i[d]))
        {
            digits += i[d];
            break;
        }
    }
    sum += int.Parse(digits);
}

Console.WriteLine(sum);