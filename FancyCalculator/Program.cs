using System;

namespace FancyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A Fancy Console Calculator");

            Console.WriteLine("Enter the opperation you would like to perform. Enter 'exit' to stop the application.");
            string inputEquation = Console.ReadLine();

            while (!inputEquation.Trim().ToLower().Equals("exit"))
            {
                var inputs = inputEquation.Split(' ');
                if (inputs.Length == 3)
                {
                    decimal firstNumber;
                    if (!decimal.TryParse(inputs[0], out firstNumber))
                    {
                        Console.WriteLine($"The first number, {inputs[0]}, was not a valid number.");
                        return;
                    }

                    decimal secondNumber;
                    if (!decimal.TryParse(inputs[2], out secondNumber))
                    {
                        Console.WriteLine($"The second number, {inputs[2]}, was not a valid number.");
                        return;
                    }

                    var result = Calculate(firstNumber, secondNumber, inputs[1]);
                    if (result.HasValue) Console.WriteLine($"Result: {result}");
                    else return;
                }
                else Console.WriteLine("The opperation must be in form '<number> <opperation> <number>'. Please try again.");

                Console.WriteLine("Enter the opperation you would like to perform. Enter 'exit' to stop the application.");
                inputEquation = Console.ReadLine();
            }
        }

        static decimal? Calculate(decimal firstNumber, decimal secondNumber, string opperation)
        {
            switch (opperation)
            {
                case "+":
                    return firstNumber + secondNumber;
                case "-":
                    return firstNumber - secondNumber;
                case "*":
                    return firstNumber * secondNumber;
                case "/":
                    return firstNumber / secondNumber;
                default:
                    Console.WriteLine($"The opperation, {opperation}, is invalid. You must use one of the following: + - * /");
                    return null;
            }
        }
    }
}
