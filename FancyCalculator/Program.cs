using System;

namespace FancyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A Fancy Console Calculator");

            Console.WriteLine("Enter what you would like to see added or subtracted");
            var inputEquation = Console.ReadLine();
            var inputs = inputEquation.Split(' ');

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
                    Console.WriteLine($"Opperation, {opperation} not supported");
                    return null;
            }
        }
    }
}
