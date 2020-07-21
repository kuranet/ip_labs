using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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
            for (int i = 0; i < str.Length; i++)
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
                double num = 0;
                string temp = rpn.output.Pop();
                if (Double.TryParse(temp, out num))
                {
                    rpn.stack.Push(temp);
                }
                else
                {
                    if (rpn.stack.Size() >= 2)
                    {
                        double first = Convert.ToDouble(rpn.stack.Pop());
                        double second = Convert.ToDouble(rpn.stack.Pop());
                        double res = 0;
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
                            case "^":
                                res = Math.Pow(second, first);
                                break;
                        }
                        rpn.stack.Push(res.ToString());
                    }
                    else
                    {
                        double res = Convert.ToDouble(rpn.stack.Pop());
                        res *= -1;
                        rpn.stack.Push(res.ToString());
                    }
                }
            }
        }
    }
}
