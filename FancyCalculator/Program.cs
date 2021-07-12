using System;
using System.Collections.Generic;

namespace FancyCalculator
{
    class Program
    {
        private static decimal? _result = null;
        private static string _errorMessage;

        static void Main(string[] args)
        {
            var calculator = new Calculator();
            Console.WriteLine("A Fancy Console Calculator");

            Console.WriteLine("Enter the opperation you would like to perform. Enter 'exit' to stop the application.");
            string inputEquation = Console.ReadLine();

            while (!inputEquation.Trim().ToLower().Equals("exit"))
            {
                EvaluateResult evalutationResult = calculator.Evaluate(inputEquation);
                if (string.IsNullOrEmpty(evalutationResult.ErrorMessage)) Console.WriteLine($"Result: {evalutationResult.Result}");
                else Console.WriteLine(evalutationResult.ErrorMessage);

                Console.WriteLine("Enter the opperation you would like to perform. Enter 'exit' to stop the application.");
                inputEquation = Console.ReadLine();
            }
        }
    }
}
