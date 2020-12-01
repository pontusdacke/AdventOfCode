import requests
import browser_cookie3
import inspect
import re

def getInput():
    frame = inspect.stack()[1]
    filename = frame[0].f_code.co_filename
    dayNumber = int(re.findall(r'\d+', filename)[0])
    chromeCookies = browser_cookie3.chrome()
    result = requests.post(f'https://adventofcode.com/2018/day/{dayNumber}/input', cookies=chromeCookies)
    return result.text.splitlines()