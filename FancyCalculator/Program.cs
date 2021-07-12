using System;

namespace FancyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A Fancy Console Calculator");

            Console.WriteLine("Enter what you would like to see added");
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

            var result = firstNumber + secondNumber;
            Console.WriteLine($"Result: {result}");
        }
    }
}
