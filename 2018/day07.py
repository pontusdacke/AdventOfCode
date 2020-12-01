from collections import defaultdict
import input_getter
inp = input_getter.getInput()

inp = ["Step C must be finished before step A can begin.",
     "Step C must be finished before step F can begin.",
     "Step A must be finished before step B can begin.",
     "Step A must be finished before step D can begin.",
     "Step B must be finished before step E can begin.",
     "Step D must be finished before step E can begin.",
     "Step F must be finished before step E can begin."]

def part1():
    deps = defaultdict(list)
    presteps = set()
    steps = set()
    for i in inp:
        deps[i[5]].append(i[36])
        presteps.add(i[5])
        steps.add(i[36])

    first = None
    for step in presteps:
        if step not in steps:
            first = step
    
    last = None
    for step in steps:
        if step not in presteps:
            last = step


def part2():
    print("implement me")
    
print("Part 1:")
part1()
print("Part 2:")
part2()