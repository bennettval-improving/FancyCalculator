using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCore
{
    public class Calculator
    {
        public EvaluateResult Evaluate(string input)
        {
            decimal firstNumber;
            decimal secondNumber;

            var inputs = input.Split(' ');

            if (!decimal.TryParse(inputs[0], out firstNumber))
            {
                return new EvaluateResult { ErrorMessage = $"The first number, {inputs[0]}, was not a valid number." };
            }
            if (!decimal.TryParse(inputs[2], out secondNumber))
            {
                return new EvaluateResult { ErrorMessage = $"The second number, {inputs[2]}, was not a valid number." };
            }

            return new EvaluateResult { Result = GetResult(firstNumber, secondNumber, inputs[1]) };
        }

        private decimal GetResult(decimal firstNumber, decimal secondNumber, string opperation)
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
                    return 0;
            }
        }
    }
}
