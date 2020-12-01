import input_getter
import re
inp = input_getter.getInput()

class Point:
    def __init__(self, px:int, py:int, vx:int, vy:int):
        self.px, self.py, self.vx, self.vy = px, py, vx, vy

    def Tick(self):
        self.px += self.vx
        self.py += self.vy

    def BackTick(self):
        self.px -= self.vx
        self.py -= self.vy


def parseInput(input):
    points = []
    for i in input:
        nums = re.findall(r'[+-]?\d+', i)
        px = int(nums[0])
        py = int(nums[1])
        vx = int(nums[2])
        vy = int(nums[3])
        points.append(Point(px, py, vx, vy))
    return points

def findMinHeight(points):
    newMinHeight = 0
    oldMinHeight = max(p.py for p in points) - min(p.py for p in points)
    count = 0
    while (newMinHeight < oldMinHeight):
        count += 1
        oldMinHeight = max(p.py for p in points) - min(p.py for p in points)
        for p in points:
            p.Tick()
        newMinHeight = max(p.py for p in points) - min(p.py for p in points)
    print(count-1)

def printPoints(points):
    for p in points:
        p.BackTick()

    xmin = min(p.px for p in points)
    xmax = max(p.px for p in points)
    ymin = min(p.py for p in points)
    ymax = max(p.py for p in points)
    for y in range(ymin, ymax+1):
        for x in range(xmin, xmax+1):
            if (containsPoint(points, x, y)):
                print('#', end='')
            else:
                print('.', end='')
        print()

def containsPoint(points, x, y):
    return any(p.px == x and p.py == y for p in points)

def part1and2():
    points = parseInput(inp)
    findMinHeight(points)
    printPoints(points)
    
print("Part 1 & 2:")
part1and2()
