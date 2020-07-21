using System;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] arg = { "1","+","4","*","2","-","3","*","4","+","8","-","6","*","2","/","3"};
            //string str = "1+2";
            string[] arg = { "123-(15*2/5)", "+", "3", "*", "2", "-", "4"};
            Calculator calc = new Calculator(arg[0]);
            calc.Calc();
        }
    }
}
