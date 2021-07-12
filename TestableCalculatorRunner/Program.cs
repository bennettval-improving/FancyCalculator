using System;
using CalculatorCore;

namespace TestableCalculatorRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            Console.WriteLine("Enter the opperation you would like to perform.");

            var input = Console.ReadLine();
            var result = calculator.Evaluate(input);

            if (string.IsNullOrEmpty(result.ErrorMessage)) Console.WriteLine(result);
            else
            {
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.ErrorMessage);
                Console.Beep();
            }
        }
    }
}
