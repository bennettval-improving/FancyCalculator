using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyCalculator
{
    public class Calculator
    {
        private string _errorMessage;
        private decimal? _result;
        private decimal? _previousResult;
        public List<HistoryItem> History { get; private set; } = new List<HistoryItem>();

        public EvaluateResult Evaluate(string input)
        {
            decimal firstNumber;
            decimal secondNumber = 0;
            _errorMessage = "";

            var inputs = input.Split(' ');
            bool hasInvalidParameters = !((inputs.Length == 2 && _result.HasValue) || inputs.Length == 3);
            if (hasInvalidParameters)
            {
                _errorMessage = "The opperation must be in form '<number> <opperation> <number>'. Please try again.";
                return GetEvaluateResult();
            }

            if (inputs.Length == 3)
            {
                if (!decimal.TryParse(inputs[0], out firstNumber))
                {
                    _errorMessage = $"The first number, {inputs[0]}, was not a valid number." ;
                    return GetEvaluateResult();
                }

                if (!decimal.TryParse(inputs[2], out secondNumber))
                {
                    _errorMessage = $"The second number, {inputs[2]}, was not a valid number.";
                    return GetEvaluateResult();
                }
                Calculate(firstNumber, secondNumber, inputs[1]);
                AddHistoryItem(input);
                return GetEvaluateResult();
            }
            else
            {
                if (!decimal.TryParse(inputs[1], out secondNumber))
                {
                    _errorMessage = $"The first number, {inputs[1]}, was not a valid number.";
                    return GetEvaluateResult();
                }
                Calculate(_result.Value, secondNumber, inputs[0]);
                AddHistoryItem(input);
                return GetEvaluateResult();
            }
        }

        private void AddHistoryItem(string input)
        {
            if (string.IsNullOrEmpty(_errorMessage))
            {
                if (input.Split(' ').Length == 2) History.Add(new HistoryItem { Input = $"_{_previousResult.Value}_ {input}", Result = _result.Value.ToString() });
                else History.Add(new HistoryItem { Input = input, Result = _result.Value.ToString() });
            }
        }

        private void Calculate(decimal firstNumber, decimal secondNumber, string opperation)
        {
            switch (opperation)
            {
                case "+":
                    _previousResult = _result;
                    _result = firstNumber + secondNumber;
                    break;
                case "-":
                    _previousResult = _result;
                    _result = firstNumber - secondNumber;
                    break;
                case "*":
                    _previousResult = _result;
                    _result = firstNumber * secondNumber;
                    break;
                case "/":
                    _previousResult = _result;
                    _result = firstNumber / secondNumber;
                    break;
                default:
                    _errorMessage = $"The opperation, {opperation}, is invalid. You must use one of the following: + - * /";
                    break;
            }
        }

        private EvaluateResult GetEvaluateResult()
        {
            return new EvaluateResult
            {
                ErrorMessage = _errorMessage,
                Result = _result
            };
        }
    }
}
