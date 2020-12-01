def char_range(c1, c2):
    for c in range(ord(c1), ord(c2)+1):
        yield chr(c)