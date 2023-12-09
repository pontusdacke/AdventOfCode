var input = File.ReadAllLines("./input.txt");


var set = new Dictionary<string, (int count, List<int> nums)>();
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
            var (isAdjacent, gearX, gearY) = IsAdjacentToGear(fromX, toX, fromY, toY);
            if (isAdjacent)
            {
                var key = $"{gearX}, {gearY}";
                if (set.ContainsKey(key))
                {
                    set[key] = (set[key].count + 1, [.. set[key].nums, num]);
                }
                else
                {
                    set.Add(key, (1, [num]));
                }
            }
            
            x += length;
        }
    }
}

long sum = 0;
foreach (var kvp in set)
{
    if (kvp.Value.count == 2)
    {
        sum += kvp.Value.nums[0] * kvp.Value.nums[1];
    }
}

(bool, int gearX, int gearY) IsAdjacentToGear(int fromX, int toX, int fromY, int toY)
{
    for (int x = fromX; x <= toX; x++)
    {
        for (int y = fromY; y <= toY; y++)
        {
            var c = input[y][x];
            if (c == '*') return (true, x, y);
        }
    }
    return (false, 0, 0);
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