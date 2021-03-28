using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator
{
    class Calculator
    {
        private string expression;
        private Stack<string> transformExeption = new Stack<string>();
        public string Calculate(string originExeption)
        {
            Transform transform = new Transform();
            Validation validation = new Validation();
            try
            {
                string temp = validation.Check(originExeption);
                if (temp != "")
                {
                    Console.WriteLine(temp);
                    return "";
                }

                transformExeption = transform.PolishNotation(originExeption);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exeption: " + ex);
            }
            


            return "";
        }
    }
}
