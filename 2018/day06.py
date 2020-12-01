
import re
from collections import defaultdict
import input_getter
inp = input_getter.getInput()

class Point:
    def __init__(self,x:int,y:int):
        self.x = x
        self.y = y
    def __eq__(self, another):
        return hasattr(another, 'x') and self.x == another.x and hasattr(another, 'y') and self.y == another.y
    def __hash__(self):
        return hash((self.x, self.y))


def md(a:Point, b:Point):
    return abs(a.x - b.x) + abs(a.y - b.y) # |a−c|+|b−d|

def part1():
    coords = []
    for coord in inp:
        xandy = re.findall(r'\d+', coord)
        x = int(xandy[0])
        y = int(xandy[1])
        coords.append(Point(x, y))

    distances = defaultdict(list)
    for i in coords:
        for j in coords:
            if i == j:
                continue
            d = md(i, j)
            distances[i].append(d)

    mostArea = 0
    for key in distances:
        distances[key].sort()
        if (distances[key][0] > mostArea):
            mostArea = distances[key][0]

    print('Answer: ', mostArea)
    
def part2():
    print("implement me")
    
print("Part 1:")
part1()
print("Part 2:")
part2()