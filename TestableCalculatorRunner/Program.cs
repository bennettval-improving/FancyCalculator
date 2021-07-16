using System;
using CalculatorCore;

namespace TestableCalculatorRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();

            Console.WriteLine("Enter the opperation you would like to perform. Enter 'exit' to stop the application.");
            var input = Console.ReadLine();

            while (!input.Trim().ToLower().Equals("exit"))
            {
                if (input.Trim().ToLower().Equals("history"))
                {
                    foreach (var item in calculator.History)
                    {
                        Console.WriteLine($"{item.Equation} = {item.Result}");
                    }
                }
                else
                {
                    var result = calculator.Evaluate(input);

                    if (string.IsNullOrEmpty(result.ErrorMessage)) Console.WriteLine(result.Result);
                    else
                    {
                        Console.Beep();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(result.ErrorMessage);
                        Console.Beep();
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }

                Console.WriteLine("Enter the opperation you would like to perform. Enter 'exit' to stop the application.");
                input = Console.ReadLine();
            }
        }
    }
}
