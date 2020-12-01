
class Rectangle:
    def intersection(self, other):
        a, b = self, other
        x1 = max(min(a.x1, a.x2), min(b.x1, b.x2))
        y1 = max(min(a.y1, a.y2), min(b.y1, b.y2))
        x2 = min(max(a.x1, a.x2), max(b.x1, b.x2))
        y2 = min(max(a.y1, a.y2), max(b.y1, b.y2))
        if x1<x2 and y1<y2:
            return type(self)(x1, y1, x2, y2, -1)
    __and__ = intersection

    def area(self):
        a = self
        return (int(a.x2) - int(a.x1)) * (int(a.y2) - int(a.y1))

    def __init__(self, x1:int, y1:int, x2:int, y2:int, id:int):
        if x1>x2 or y1>y2:
            raise ValueError("Coordinates are invalid")
        self.x1, self.y1, self.x2, self.y2, self.id = x1, y1, x2, y2, id

    @staticmethod
    def create(nums):
        id = int(nums[0])
        x1 = int(nums[1])
        y1 = int(nums[2])
        x2 = int(nums[3]) + x1
        y2 = int(nums[4]) + y1
        return Rectangle(x1, y1, x2, y2, id)

    def __iter__(self):
        yield self.x1
        yield self.y1
        yield self.x2
        yield self.y2
        yield self.id