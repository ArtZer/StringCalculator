using System;

namespace StringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введи выражение:");
            Calculator calculator = new Calculator();
            double rezult = calculator.Solution(Console.ReadLine());

            Console.WriteLine($"Результат: {rezult}");
            Console.ReadLine();
        }
    }
}
