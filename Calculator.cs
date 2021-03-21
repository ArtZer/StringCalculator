using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator
{
    class Calculator
    {
        private string expression;
        private string transformExeption;
        public string Calculate(string originExeption)
        {
            Transform transform = new Transform();
            transformExeption = transform.PolishNotation(originExeption);



            return "";
        }
    }
}
