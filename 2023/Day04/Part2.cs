var input = File.ReadAllLines("./input.txt");

var scratchcards = new Dictionary<int, int>();

for (int i = 0; i < input.Length; i++)
{
    scratchcards.Add(i + 1, 1);
}

foreach (var row in input)
{
    var data = row.Split(":");
    var card = int.Parse(data[0].Split(" ").Where(x => x != "").Last());
    var allNums = data[1].Split("|");
    var myNums = allNums[0].Split(" ").Where(x => x != "").Select(x => int.Parse(x));
    var winningNums = allNums[1].Split(" ").Where(x => x != "").Select(x => int.Parse(x));
    var matching = myNums.Intersect(winningNums).Count();

    for (int i = card + 1; i <= card + matching; i++)
        scratchcards[i] += scratchcards[card];
}

Console.WriteLine(scratchcards.Sum(x => x.Value));