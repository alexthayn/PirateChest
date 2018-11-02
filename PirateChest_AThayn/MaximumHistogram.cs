using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PirateChest_AThayn
{
    public class MaximumHistogram
    {
        public int maxHistogram(int[] input)
        {
            var stack = new Stack<int>();
            int maxArea = 0;
            int area = 0;
            
            for(int i=0; i < input.Length)
            {
                if(!stack.Any() || input[stack.Peek()] <= input[i])
                {
                    stack.Pop(i++);
                }
            }
        }
    }
}
