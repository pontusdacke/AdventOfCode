import input_getter
import re
import rectangle

inp = input_getter.getInput()

def part1():
    sum = 0
    n = 1000
    m = 1000
    fabric = [[0] * m for i in range(n)]
    for i in range(len(inp)):
        ra = rectangle.Rectangle.create(re.findall(r'\d+', inp[i]))

        for j in range(i+1, len(inp)):
            rb = rectangle.Rectangle.create(re.findall(r'\d+', inp[j]))
                    
            intersection = rb & ra
            if (intersection != None):
                for rx in range(intersection.x1, intersection.x2):
                    for ry in range(intersection.y1, intersection.y2):
                        if (fabric[rx][ry] == 0):
                            sum += 1
                        fabric[rx][ry] += 1
    print(sum)

def part2():
    allIds = [re.findall(r'\d+', item)[0] for item in inp]
    for i in range(len(inp)):
        ra = rectangle.Rectangle.create(re.findall(r'\d+', inp[i]))
        
        for j in range(0, len(inp)):
            if (i == j):
                continue

            rb = rectangle.Rectangle.create(re.findall(r'\d+', inp[j]))

            if (rb & ra != None):
                if (str(rb.id) in allIds):
                    allIds.remove(str(rb.id))
                if (str(ra.id) in allIds):
                    allIds.remove(str(ra.id))

    print(allIds)
    
print("Part 1:")
part1()
print("Part 2:")
part2()