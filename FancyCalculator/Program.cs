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
                //var inputs = inputEquation.Split(' ');
                //if (inputs.Length == 3)
                //{
                //    decimal firstNumber;
                //    if (!decimal.TryParse(inputs[0], out firstNumber))
                //    {
                //        Console.WriteLine($"The first number, {inputs[0]}, was not a valid number.");
                //        continue;
                //    }

                //    decimal secondNumber;
                //    if (!decimal.TryParse(inputs[2], out secondNumber))
                //    {
                //        Console.WriteLine($"The second number, {inputs[2]}, was not a valid number.");
                //        return;
                //    }

                //    var potentialResult = Calculate(firstNumber, secondNumber, inputs[1]);
                //    if (potentialResult.HasValue)
                //    {
                //        _result = potentialResult.Value;
                //        Console.WriteLine($"Result: {potentialResult.Value}");
                //    }
                //    else return;
                //}
                //else if (inputs.Length == 2 && _result.HasValue)
                //{

                //}
                //else Console.WriteLine("The opperation must be in form '<number> <opperation> <number>'. Please try again.");

                EvaluateResult evalutationResult = calculator.Evaluate(inputEquation);
                if (string.IsNullOrEmpty(evalutationResult.ErrorMessage)) Console.WriteLine($"Result: {evalutationResult.Result}");
                else Console.WriteLine(evalutationResult.ErrorMessage);

                Console.WriteLine("Enter the opperation you would like to perform. Enter 'exit' to stop the application.");
                inputEquation = Console.ReadLine();
            }
        }

        //static decimal? Calculate(decimal firstNumber, decimal secondNumber, string opperation)
        //{
        //    switch (opperation)
        //    {
        //        case "+":
        //            return firstNumber + secondNumber;
        //        case "-":
        //            return firstNumber - secondNumber;
        //        case "*":
        //            return firstNumber * secondNumber;
        //        case "/":
        //            return firstNumber / secondNumber;
        //        default:
        //            Console.WriteLine($"The opperation, {opperation}, is invalid. You must use one of the following: + - * /");
        //            return null;
        //    }
        //}
    }
}
