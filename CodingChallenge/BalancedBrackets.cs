using System;
using System.Collections.Generic;

namespace CodingChallenge
{
    public class BalancedBrackets
    {
        public BalancedBrackets()
        {
        }

        /*
         * 1. create a char stack
         * 2. scann the string elements (char) if stack is empty push the char to stack
         * 3. if stack is not empty compare the cha to top element of the stack 
         *    if the top stack is '{', '[', '(' and match the char '}', ']', ')' pop the stack
         *    else push the char to the stack
         * 4. finishing scanning the string if the stack is not empty return false (not balanced), else 
         *    return true (balanced)
         */
        public bool Balanced(string s)
        {

            Stack<char> bb = new Stack<char>();
            foreach (char c in s)
            {
                if (bb.Count <= 0)
                {
                    //Console.WriteLine("push " + c);
                    bb.Push(c);
                    continue;
                }
                char temp = bb.Peek();
                if (c == '}' && temp == '{')
                {
                    //Console.WriteLine("Pop " + temp);
                    bb.Pop();
                }
                else if (c == ']' && temp == '[')
                {
                    //Console.WriteLine("Pop " + temp);
                    bb.Pop();
                }
                else if (c == ')' && temp == '(')
                {
                    //Console.WriteLine("Pop " + temp);
                    bb.Pop();
                }
                else
                {
                    //Console.WriteLine("push " + c);
                    bb.Push(c);
                }
            }
            Console.WriteLine(bb.Count);
            return bb.Count == 0 ? true : false;
        }

    }
}
