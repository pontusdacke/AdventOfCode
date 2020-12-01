import input_getter
inp = input_getter.getInput()

def part1():
    twos = 0
    threes = 0
    for line in inp:
        counter = {}
        for char in line:
            if char not in counter:
                counter[char] = 1
            else:
                counter[char] += 1
        
        addTwos = False
        addThrees = False
        for key in counter:
            if counter[key] == 2:
                addTwos = True
            if counter[key] == 3:
                addThrees = True
        if (addTwos):
            twos += 1
        if (addThrees):
            threes += 1

    print(twos * threes)

def part2():
    def differenceCount(lineA, lineB):
        diff = 0
        for i in range(len(lineA)):
            if lineA[i] != lineB[i]:
                diff += 1
        return diff

    def getCorrectString(lineA, lineB):
        for i in range(len(lineA)):
            if lineA[i] == lineB[i]:
                    print(lineA[i], end="")

    for i in range(len(inp)):
        for j in range(i, len(inp)):
            if inp[i] != inp[j]:
                diff = differenceCount(inp[i], inp[j])
                if (diff == 1):
                    getCorrectString(inp[i], inp[j])
    
print("Part 1:")
part1()
print("Part 2:")
part2()