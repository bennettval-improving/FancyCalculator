using System;
using System.Collections.Generic;
using System.Linq;

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
                if (inputEquation.Trim().ToLower().Contains("history"))
                {
                    PrintHistory(calculator, inputEquation);
                }
                else
                {
                    EvaluateResult evalutationResult = calculator.Evaluate(inputEquation);
                    if (string.IsNullOrEmpty(evalutationResult.ErrorMessage)) Console.WriteLine($"Result: {evalutationResult.Result.Value}");
                    else Console.WriteLine(evalutationResult.ErrorMessage);
                }

                Console.WriteLine("Enter the opperation you would like to perform. Enter 'exit' to stop the application.");
                inputEquation = Console.ReadLine();
            }
        }

        static void PrintHistory(Calculator calculator, string input)
        {
            if (calculator.History.Count > 0)
            {
                var inputs = input.Split(" ");
                var filteredHistory = calculator.History;
                if (inputs.Length > 1)
                {
                    filteredHistory = filteredHistory.Where(x => x.Input.Contains(inputs[1])).ToList();
                }

                int leftMax = filteredHistory.OrderByDescending(x => x.Input.Length).ToList().FirstOrDefault().Input.Length + 5;
                int rightMax = filteredHistory.OrderByDescending(x => x.Result.Length).ToList().FirstOrDefault().Result.Length + 5;
                filteredHistory.ForEach(x => Console.WriteLine("{0,-" + leftMax + "} {1,-" + rightMax + "}", x.Input, $"= {x.Result}"));
            }
            else Console.WriteLine("No opperations have been performed.");
        }
    }
}
