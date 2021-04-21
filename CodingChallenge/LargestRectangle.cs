using System;
using System.Collections.Generic;

namespace CodingChallenge
{
    public class LargestRectangle
    {
        /* 
         * Approach
         * 1. Create a stack to track height index
         * 2. Iterate through height array, push index to height stack if current height >= previous height
         *    else if current hegiht is smaller than previous height calculate and track the max retangal area 
         *    while pop height index stack until the stack.Peek() is lower than current index
         * 3. After the iterartion, calculate and track the max retangal area 
         *    while pop height index stack until the stack is empty
         * 4. return the max area   
         */
        public LargestRectangle()
        {
        }

        public long largestRectangle(int[] h)
        {

            int maximumArea = 0;

            Stack<int> stack = new Stack<int>();
            stack.Push(0); // push height array index to the stack

            for (int index = 1; index < h.Length; index++)
            {
                if (h[index] < h[stack.Peek()])
                {
                    maximumArea = PopToLowerHeight(h, stack, index, maximumArea);
                }
                stack.Push(index); // push height array index to the stack
            }
            maximumArea = Popping(h, stack, h.Length, maximumArea);
            return maximumArea;
        }

        
        private int PopToLowerHeight(int[] a, Stack<int> stack, int index, int maximumArea)
        {
            while (stack.Count > 0 && a[index] < a[stack.Peek()])
            {
                int area = CalculateArea(a, stack, index);
                maximumArea = Math.Max(maximumArea, area);
            }
            return maximumArea;
        }

        
        private int Popping(int[] A, Stack<int> stack, int index, int maximumArea)
        {
            while (stack.Count > 0)
            {
                int area = CalculateArea(A, stack, index);
                maximumArea = area > maximumArea ? area : maximumArea;
            }

            return maximumArea;
        }

        private int CalculateArea(int[] h, Stack<int> stack, int index)
        {
            int popHeightIndex = stack.Pop();
            if (stack.Count == 0) 
            {
                return h[popHeightIndex] * index;
            }
            else
            {
                return h[popHeightIndex] * (index - stack.Peek() - 1);
            }
        }
    }
}
