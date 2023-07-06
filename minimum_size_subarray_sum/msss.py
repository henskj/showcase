def minSubArrayLen(self, target: int, nums: List[int]) -> int:
    point1 = 0
    point2 = 0
    shortest = float('inf') #initialise the shortest possible to infinity
    tot = 0
    if nums[0] >= target:
        return 1
    while point2 < len(nums) or tot >= target:
        if tot >= target:
            if point2 - point1 < shortest:
                shortest = point2 - point1
        if tot < target:
            tot += nums[point2]
            point2 += 1
            if point2 < len(nums):
                if nums[point2] >= target:
                    return 1
        else:
            tot -= nums[point1]
            point1 += 1
    return shortest if shortest < 10 ** 5 + 1 else 0
