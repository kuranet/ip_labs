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
                        case "-":
                            if (!stack.IsEmpty() &&( stack.Back() == "*" || stack.Back() == "/"))
                            {
                                while(!stack.IsEmpty())
                                output.Push(stack.Pop());
                            }
                            stack.Push(s); break;
                        case "*":
                        case "/": 
                            if(!stack.IsEmpty() && (stack.Back() == "*" || stack.Back()=="/"))
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
        public void Calc()
        {
            while (!output.IsEmpty)
            {
                int num = 0;
                string temp = output.Pop();
                if (Int32.TryParse(temp, out num))
                {
                    stack.Push(temp);
                }
                else
                {
                    int first = Convert.ToInt32(stack.Pop());
                    int second = Convert.ToInt32(stack.Pop());
                    int res = 0;
                    switch (temp)
                    {
                        case "+":
                            res = first + second;
                            break;
                        case "-":
                            res = second - first;
                            break;
                        case "*":
                            res = first * second;
                            break;
                        case "/":
                            res = second / first;
                            break;
                    }
                    stack.Push(res.ToString());
                }
            }
        }
    }
}
