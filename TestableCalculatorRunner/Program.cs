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

            Console.WriteLine(result);
        }
    }
}
