using System;

namespace StringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введи выражение:");
            Calculator calculator = new Calculator();
            calculator.Solution(Console.ReadLine());

            Console.ReadLine();
        }
    }
}
