using System;
namespace lab3
{
    class RPN
    {
        MyQueue<string> output;
        MyStack<string> stack;

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
                        case "-": stack.Push(s); break;
                        case "*":
                        case "/": 
                            if(stack.Back() == "*" || stack.Back()=="/")
                            {
                                output.Push(stack.Pop());                                
                            }
                            stack.Push(s);
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
