from datetime import datetime
from collections import defaultdict
import input_getter
import re
inp = input_getter.getInput()

class Log:
    def __init__(self, timestamp, text):
        self.text = text
        self.timestamp = timestamp

    def __lt__(self, other):
        return self.timestamp < other.timestamp

    def setGuardId(self, id):
        self.guardid = id

def getLog():
    entrys = []
    for line in inp:
        timestamp = datetime.strptime(line[1:17], '%Y-%m-%d %H:%M')
        text = line[19:]
        log = Log(timestamp, text)
        entrys.append(log)

    entrys.sort()

    gid = None
    for entry in entrys:
        if entry.text.startswith("G"):
            gid = re.findall(r'\d+', entry.text)[0]
        entry.setGuardId(gid)
    return entrys

def populateData(entrys, times, mins):
    sleepTime = None
    currentGuard = 0
    for entry in entrys:
        if entry.text.startswith("G"):
            currentGuard = entry.guardid
        if entry.text.startswith("f"):
            sleepTime = entry.timestamp
        if entry.text.startswith("w"):
            minutes = (entry.timestamp - sleepTime).seconds / 60
            if currentGuard in times:
                times[currentGuard] += minutes
            else:
                times[currentGuard] = minutes

            for i in range(sleepTime.minute, sleepTime.minute + int(minutes)):
                reali = i % 60
                mins[currentGuard].append(reali)
    
    return currentGuard

#8:08
def part1():
    entrys = getLog()
    times = {}
    mins = defaultdict(list)
    anyguard = populateData(entrys, times, mins)
    guardWithMostSleep = anyguard

    for key in times:
        if times[key] > times[guardWithMostSleep]:
            guardWithMostSleep = key

    lst = mins[guardWithMostSleep]
    print('Answer: ', int(guardWithMostSleep) * max(set(lst), key=lst.count))

def part2():
    entrys = getLog()
    times = {}
    mins = defaultdict(list)
    anyguard = populateData(entrys, times, mins)

    mostFrequentSleeper = anyguard
    mostFrequentMinute = 0
    maxOcc = 0
    for key in times:
        lst = mins[key]
        num = max(lst, key=lst.count)
        occ = lst.count(num)
        if (occ > maxOcc):
            maxOcc = occ
            mostFrequentMinute = num
            mostFrequentSleeper = key

    print('Answer: ', int(mostFrequentSleeper) * int(mostFrequentMinute))
    
print("Part 1:")
part1()
print("Part 2:")
part2()