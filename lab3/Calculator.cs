using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    class Calculator
    {
        RPN rpn;
        public Calculator(string str)
        {
            string[] elements = Parser(str);
            rpn = new RPN(elements);
        }

        string[] Parser(string str)
        {
            int startPos = 0;
            string[] res = new string[0];
            for (int i = 1; i < str.Length; i++)
            {
                if (!Char.IsDigit(str[i]))
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
                else if (i == str.Length - 1)
                {
                    Array.Resize(ref res, res.Length + 1);
                    res[res.Length - 1] = str.Substring(startPos, i - startPos + 1);
                }
            }
            return res;
        }
        public void Calc()
        {
            while (!rpn.output.IsEmpty)
            {
                int num = 0;
                string temp = rpn.output.Pop();
                if (Int32.TryParse(temp, out num))
                {
                    rpn.stack.Push(temp);
                }
                else
                {
                    int first = Convert.ToInt32(rpn.stack.Pop());
                    int second = Convert.ToInt32(rpn.stack.Pop());
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
                    rpn.stack.Push(res.ToString());
                }
            }
        }
    }
}
