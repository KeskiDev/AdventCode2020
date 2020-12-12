import math
import numpy

def GetBoardingPassList(text):
    result =[]
    for row in text:
        result.append(row)
    return result

def FindSeatId(boardingPass):
    max_row_num = 127
    min_row_num = 0
    max_col_num = 7
    min_col_num = 0
    
    for r in boardingPass:

        if r == "F" or r == "B":
            diffRow = max_row_num - min_row_num
            halfRow = math.ceil(diffRow/2) - 1

            if r == "F":
                max_row_num = min_row_num + halfRow
            else:
                min_row_num = max_row_num - halfRow

        if r == "R" or r == "L":
            diff_col = max_col_num - min_col_num
            half_col = math.ceil(diff_col/2) - 1

            if r == "L":
                max_col_num = min_col_num + half_col
            else:
                min_col_num = max_col_num - half_col

    return min_row_num * 8 + min_col_num


with open("boarding_pass.txt") as bp:
    n = bp.read().splitlines()

l = GetBoardingPassList(n)
#print(l[2])
# seatid = FindSeatId(l[2])
# print(seatid)

seatIds = []

for boarding in l:
    seatId = FindSeatId(boarding)
    seatIds.append(seatId)

arr = numpy.array(seatIds)
maxSeatId = numpy.amax(arr)

print(maxSeatId)






