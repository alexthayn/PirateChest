using System.Collections.Generic;
using System.Linq;

/// <summary>
/// https://github.com/mission-peace/interview/blob/master/src/com/interview/stackqueue/MaximumHistogram.java
/// I stole this code from this guy ^
/// </summary>

namespace PirateChest_AThayn
{
    public class MaximumHistogram
    {
        public int maxHistogram(int[] input, int a, int b)
        {
            var stack = new Stack<int>();
            int maxArea = 0;
            int area = 0;
            int i;
            for(i=0; i < input.Length;)
            {
                if(stack.Count() == 0 || input[stack.Peek()] <= input[i])
                {
                    stack.Push(i++);
                }
                else
                {
                    int top = stack.Pop();
                    if (stack.Count() == 0)
                    {
                        area = input[top] * i;
                    }
                    else
                    {
                        area = input[top] * (i - stack.Peek() - 1);
                    }

                    if(area > maxArea)
                    {
                        maxArea = area;
                    }
                }
            }
            while(stack.Count() > 0)
            {
                int top = stack.Pop();

                if(stack.Count() == 0)
                {
                    area = input[top] * i;
                }
                else
                {
                    area = input[top] * (i - stack.Peek() - 1);
                }

                if (area > maxArea)
                    maxArea = area;
            }
            return maxArea;
        }
    }
}
