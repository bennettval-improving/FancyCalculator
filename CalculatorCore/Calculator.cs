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
        private decimal? _previousResult;
        private List<HistoryItem> _history;
        public List<HistoryItem> History => _history;

        public Calculator() : this(new List<HistoryItem>()) { }

        public Calculator(List<HistoryItem> history)
        {
            _history = history;
            _previousResult = history.Count > 0 ? history.OrderByDescending(x => x.InsertedUtc).FirstOrDefault().Result : null;
        }

        public EvaluateResult Evaluate(string input)
        {
            decimal firstNumber;
            decimal secondNumber;
            decimal result;

            var inputs = input.Split(' ');

            bool hasInvalidParameters = !((inputs.Length == 2 && _previousResult.HasValue) || inputs.Length == 3);
            if (hasInvalidParameters) return new EvaluateResult { ErrorMessage = "The opperation must be in form '<number> <opperation> <number>'." };

            if (inputs.Length == 3)
            {
                var opp = inputs[1];
                if (Array.IndexOf(_VALID_OPPERATORS, opp) == -1) return new EvaluateResult { ErrorMessage = $"The opperation, {opp}, is invalid.You must use one of the following: + - * /" };

                if (!decimal.TryParse(inputs[0], out firstNumber))
                {
                    return new EvaluateResult { ErrorMessage = $"The first number, {inputs[0]}, was not a valid number." };
                }
                if (!decimal.TryParse(inputs[2], out secondNumber))
                {
                    return new EvaluateResult { ErrorMessage = $"The second number, {inputs[2]}, was not a valid number." };
                }
                result = DoMath(firstNumber, secondNumber, inputs[1]).Value;
                _history.Add(new HistoryItem { Equation = input, Result = result, InsertedUtc = DateTime.UtcNow });
                return new EvaluateResult { Result = result };
            }
            else
            {
                var opp = inputs[0];
                if (Array.IndexOf(_VALID_OPPERATORS, opp) == -1) return new EvaluateResult { ErrorMessage = $"The opperation, {opp}, is invalid.You must use one of the following: + - * /" };

                if (!decimal.TryParse(inputs[1], out secondNumber))
                {
                    return new EvaluateResult { ErrorMessage = $"The second number, {inputs[1]}, was not a valid number." };
                }
                result = DoMath(_previousResult.Value, secondNumber, inputs[0]).Value;
                _history.Add(new HistoryItem { Equation = input, Result = result, InsertedUtc = DateTime.UtcNow });
                return new EvaluateResult { Result = result };
            }
        }

        public List<HistoryItem> GetFilteredHistory(string opperation)
        {
            return _history.Where(x => x.Equation.Contains(opperation)).ToList();
        }

        private decimal? DoMath(decimal firstNumber, decimal secondNumber, string opperation)
        {
            decimal? result = null;
            switch (opperation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    result = firstNumber / secondNumber;
                    break;
            }
            _previousResult = result;
            return result;
        }
    }
}
