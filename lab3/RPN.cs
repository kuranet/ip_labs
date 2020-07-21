using System;
using System.IO;

namespace lab3
{
    class RPN
    {
        public MyQueue<string> output { get; }
        public MyStack<string> stack { get; }

        public RPN(string[] str)
        {
            output = new MyQueue<string>();
            stack = new MyStack<string>();

            foreach(string s in str)
            {
                int num = 0;
                if (Int32.TryParse(s, out num))
                {
                    output.Push(s);
                }
                else 
                {
                    switch (s)
                    {
                        case "+":
                        case "-":
                            if (!stack.IsEmpty() &&( stack.Back() == "*" || stack.Back() == "/"))
                            {
                                while(!stack.IsEmpty())
                                output.Push(stack.Pop());
                            }
                            stack.Push(s); break;
                        case "*":
                        case "/":
                        case "^":
                            if(!stack.IsEmpty() && (stack.Back() == "*" || stack.Back()=="/"))
                            {
                                output.Push(stack.Pop());                                
                            }
                            stack.Push(s);
                            break;
                        case "(":
                            stack.Push(s);
                            break;
                        case ")":
                            while (stack.Back() != "(")
                                output.Push(stack.Pop());
                            stack.Pop();
                            break;
                    }                    
                }
            }
            while (!stack.IsEmpty())
            {
                output.Push(stack.Pop());
            }            
        }
        
    }
}
