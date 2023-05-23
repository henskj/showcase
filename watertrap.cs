using System;
using System.Diagnostics;

public class Solution {
    public int Trap(int[] height) {
        int cur = 0;
        int walls = 0;
        int water = 0;
        for (int i = 0; i < height.Length; i++) {
            if (cur == 0 && height[cur] == 0) {
                if (height[i] > height[cur]) {
                    cur = i;
                }
            }
            if (height[i] > 0) {
                walls++;
            }
        }
        if (walls == 1) {
            return 0;
        }
        if (cur+1 >= height.Length) {
            return 0;
        }
        while (cur < height.Length-1) {
            int highest = cur+1;
            while (height[cur] <= height[highest]) {
                cur++;
                highest++;
                if (cur >= height.Length || highest >= height.Length) {
                    return water;
                }
            }
            int start = highest;
            for (int i = highest; i < height.Length; i++) {
                if (height[i] > height[highest]) {
                    highest = i;
                    if (height[highest] >= height[cur]) {
                        break;
                    }
                }
            }
            if (start == highest) {
                cur++;
                if (cur >= height.Length) {
                    return water;
                }
                continue;
            }
            int distance = highest - cur - 1;
            int addWater = distance * Math.Max(height[cur],height[highest]);
            int difference = Math.Abs(height[cur] - height[highest]);
            if (difference > 0) {
                addWater -= distance * difference;
            }
            for (int i = cur+1; i < highest; i++) {
                addWater -= height[i];
            }
            cur = highest;
            water += addWater;
        }
        return water;
    }
}

class Program {
    static void Main(string[] args) {
        Solution solution = new Solution();
        int[] heights1 = {0,1,0,2,1,0,1,3,2,1,2,1};
        int result = solution.Trap(heights1);
        Console.WriteLine($"Test 1. Expected 6. Got {result}");
        
        int[] heights2 = {4,2,0,3,2,5};
        int result2 = solution.Trap(heights2);
        Console.WriteLine($"Test 2. Expected 9. Got {result2}");

        int[] heights3 = {0};
        int result3 = solution.Trap(heights3);
        Console.WriteLine($"Test 3. Expected 0. Got {result3}");

        int[] heights4 = {0,0,5,0,0};
        int result4 = solution.Trap(heights4);
        Console.WriteLine($"Test 4. Expected 0. Got {result4}");

        int[] heights5 = {5};
        int result5 = solution.Trap(heights5);
        Console.WriteLine($"Test 5. Expected 0. Got {result5}");

        int[] heights6 = {9,0,0,0,9};
        int result6 = solution.Trap(heights6);
        Console.WriteLine($"Test 6. Expected 27. Got {result6}");

        int[] heights7 = {9,8,7,6,9};
        int result7 = solution.Trap(heights7);
        Console.WriteLine($"Test 7. Expected 6. Got {result7}");

        int[] heights8 = {1,2,3,2,1};
        int result8 = solution.Trap(heights8);
        Console.WriteLine($"Test 8. Expected 0. Got {result8}");
    }
}