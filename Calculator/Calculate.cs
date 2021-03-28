using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class Calculate
    {
        public double PolishNotation(Queue<string> exeption)
        {
            double rezult;
            Stack<double> operand = new Stack<double>();

            operand.Push(double.Parse(exeption.Dequeue()));
            while (exeption.Count > 0)
            {
                string temp = exeption.Dequeue();
                if (CheckOperand(temp))
                    operand.Push(int.Parse(temp));
                else
                {
                    double op1 = operand.Pop();
                    operand.Push(CalculateTwoOpreands(operand.Pop(), op1, temp));
                }  
            }
            return operand.Pop();
        }

        private bool CheckOperand(string st)
        {
            Regex regex = new Regex(@"\d");
            MatchCollection matches = regex.Matches(st);
            return (matches.Count > 0);
        }

        private double CalculateTwoOpreands(double op1, double op2, string operatoR)
        {
            switch (operatoR)
            {
                case "+": return op1 + op2;
                case "-": return op1 - op2;
                case "/":
                    if (op2 == 0)
                        throw new Exception("Нельзя делить на ноль!");
                    return op1 / op2;
                case "*": return op1 * op2;
                case "^": 
                    if(op1 < 0 || op2 < 0)
                        return Math.Pow(op1, op2) * -1;
                    return Math.Pow(op1,op2);
                default: return 0;
            }
        }
    }
}
