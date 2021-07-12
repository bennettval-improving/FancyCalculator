using System;

namespace FancyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A Fancy Console Calculator");
            string inputEquation = string.Empty;

            Console.WriteLine("Enter what you would like to see added or subtracted");
            inputEquation = Console.ReadLine();

            while (!inputEquation.Equals("exit"))
            {
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
                else return;

                Console.WriteLine("Enter what you would like to see added or subtracted");
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
