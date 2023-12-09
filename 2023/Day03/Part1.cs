var input = File.ReadAllLines("./input.txt");

var sum = 0;

for (int y = 0; y < input.Length; y++)
{
    for (int x = 0; x < input[0].Length; x++)
    {
        if (char.IsDigit(input[y][x]))
        {
            var length = GetLength(x, y);
            var fromX = Math.Max(0, x - 1);
            var toX = Math.Min(x + length, input[0].Length - 1);
            var fromY = Math.Max(0, y - 1);
            var toY = Math.Min(y + 1, input.Length - 1);
            var num = int.Parse(input[y].Substring(x, length));
            x += length;
            if (IsAdjacentToSymbol(fromX, toX, fromY, toY)) sum += num;
        }
    }
}

bool IsAdjacentToSymbol(int fromX, int toX, int fromY, int toY)
{
    for (int x = fromX; x <= toX; x++)
    {
        for (int y = fromY; y <= toY; y++)
        {
            var c = input[y][x];
            if (!char.IsDigit(c) && c != '.') return true;
        }
    }
    return false;
}

int GetLength(int x, int y)
{
    int currentX = x, len = 0;
    while (currentX < input[0].Length && char.IsDigit(input[y][currentX]))
    {
        currentX++;
        len++;
    }
    return len;
}

Console.WriteLine(sum);