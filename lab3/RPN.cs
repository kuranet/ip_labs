﻿using System;
using System.IO;

namespace lab3
{
    class RPN
    {
        MyQueue<string> output;
        MyStack<string> stack;

        public RPN(string sstr)
        {
            string[] str =  Parser(sstr);
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
        string[] Parser(string str)
        {
            int startPos = 0;
            string[] res = new string[0];
            for(int i = 1; i< str.Length; i++)
            {
                if(!Char.IsDigit(str[i]))
                {
                    if ((i - startPos) != 0)
                    {
                        Array.Resize(ref res, res.Length + 2);
                        res[res.Length - 2] = str.Substring(startPos, i - startPos);
                        res[res.Length - 1] = str[i].ToString();
                    }
                    else
                    {
                        Array.Resize(ref res, res.Length + 1);
                        res[res.Length - 1] = str[i].ToString();
                    }
                    startPos = i + 1;    
                    
                }
                else if (i == str.Length-1)
                {
                    Array.Resize(ref res, res.Length + 1);
                    res[res.Length - 1] = str.Substring(startPos, i - startPos+1);
                }
            }
            return res;
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
