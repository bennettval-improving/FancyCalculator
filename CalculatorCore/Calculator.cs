using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCore
{
    public class Calculator
    {
        private readonly string[] _VALID_OPPERATORS = new string[] { "+", "-", "*", "/" };

        public EvaluateResult Evaluate(string input)
        {
            decimal firstNumber;
            decimal secondNumber;

            var inputs = input.Split(' ');
            var opp = inputs[1];

            if (Array.IndexOf(_VALID_OPPERATORS, opp) == -1) return new EvaluateResult { ErrorMessage = $"The opperation, {opp}, is invalid.You must use one of the following: + - * /" };
            if (inputs.Length != 3) return new EvaluateResult { ErrorMessage = "The opperation must be in form '<number> <opperation> <number>'." };

            if (!decimal.TryParse(inputs[0], out firstNumber))
            {
                return new EvaluateResult { ErrorMessage = $"The first number, {inputs[0]}, was not a valid number." };
            }
            if (!decimal.TryParse(inputs[2], out secondNumber))
            {
                return new EvaluateResult { ErrorMessage = $"The second number, {inputs[2]}, was not a valid number." };
            }

            return new EvaluateResult { Result = DoMath(firstNumber, secondNumber, inputs[1]) };
        }

        private decimal DoMath(decimal firstNumber, decimal secondNumber, string opperation)
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
                    return -1; // ???
            }
        }
    }
}
