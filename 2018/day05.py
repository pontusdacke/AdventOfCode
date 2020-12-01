import input_getter
import cr

def reactor(myInput):
    oldlen = 0
    while (oldlen != len(myInput)):
        oldlen = len(myInput)
        for i in range(1, len(myInput)):
            if i >= len(myInput):
                break
            if myInput[i].lower() == myInput[i-1].lower():
                if ((myInput[i].isupper() and not myInput[i-1].isupper()) or (not myInput[i].isupper() and myInput[i-1].isupper())):
                    myInput = myInput[:i-1] + myInput[i+1:]
    return myInput

def part1():
    inp = input_getter.getInput()[0]
    reactedInput = reactor(inp)
    print('Answer: ', len(reactedInput))

def part2():
    scores = {}
    inp = input_getter.getInput()[0]
    
    for c in cr.char_range('a', 'z'):
        betterInp = inp.replace(c, "").replace(str.upper(c), "")
        reactedInput = reactor(betterInp)
        scores[c] = len(reactedInput)

    print('Answer: ', scores[min(scores, key = lambda x: scores[x])])

print("Part 1:")
part1()
print("Part 2:")
part2()