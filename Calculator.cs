using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator
{
    class Calculator
    {
        private string expression;
        private Queue<string> transformExeption = new Queue<string>();
        public double Solution(string originExeption)
        {
            Transform transform = new Transform();
            Validation validation = new Validation();
            Calculate calculate = new Calculate();

            try
            {
                string temp = validation.Check(originExeption);
                if (temp != "")
                {
                    Console.WriteLine(temp);
                    return 0;
                }

                transformExeption = transform.PolishNotation(originExeption);

                return calculate.PolishNotation(transformExeption);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exeption: " + ex);
            }

            return 0;
        }
    }
}
