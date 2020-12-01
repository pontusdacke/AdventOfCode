import input_getter
inp = input_getter.getInput()

def part1():
    print(sum([int(line) for line in inp]))

def part2():
    history = [0]
    sum = 0
    hasHistoryRepeatedItself = False
    while not hasHistoryRepeatedItself:
        for line in inp:
            sum += int(line)
            if sum in history:
                print('first to repeat itself is ' + str(sum))
                hasHistoryRepeatedItself = True
                break
            history.append(sum)


print("Part 1:")
part1()
print("Part 2:")
part2()