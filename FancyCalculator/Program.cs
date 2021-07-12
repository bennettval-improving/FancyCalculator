using System;

namespace FancyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A Fancy Console Calculator");

            Console.WriteLine("Enter a number");
            var inputOne = Console.ReadLine();
            decimal firstNumber;
            if (!decimal.TryParse(inputOne, out firstNumber))
            {
                Console.WriteLine($"The first number, {inputOne}, was not a valid number.");
                return;
            }

            Console.WriteLine("Enter a second number and I will add it to the first");
            decimal secondNumber;
            var inputTwo = Console.ReadLine();
            if (!decimal.TryParse(inputTwo, out secondNumber))
            {
                Console.WriteLine($"The first number, {inputTwo}, was not a valid number.");
                return;
            }

            var result = firstNumber + secondNumber;
            Console.WriteLine($"Result: {result}");
        }
    }
}
