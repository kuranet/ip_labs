using System;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arg = { "1","+","2","*","4","/","3"};
            //string str = "1+2";
            RPN myprn = new RPN(arg);
        }
    }
}
