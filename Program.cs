using System;

namespace StringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (exit == false)
            {
                Console.WriteLine("Введи выражение:");
                Calculator calculator = new Calculator();
                double rezult = calculator.Solution(Console.ReadLine());

                Console.WriteLine($"Результат: {rezult}");
                Console.WriteLine($"Что бы выйти введите в");
                if (Console.ReadLine() == "в")
                    exit = true;
                else
                    Console.Clear();
            }            
        }
    }
}
