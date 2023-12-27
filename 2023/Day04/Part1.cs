var input = File.ReadAllLines("./input.txt");

var sum = 0;
foreach (var row in input)
{
    var allNums = row.Split(":")[1].Split("|");
    var myNums = allNums[0].Split(" ").Where(x => x != "").Select(x => int.Parse(x));
    var winningNums = allNums[1].Split(" ").Where(x => x != "").Select(x => int.Parse(x));
    var matching = myNums.Intersect(winningNums).Count();
    var score = (1 << matching) / 2;
    sum += score;
}

Console.WriteLine(sum);