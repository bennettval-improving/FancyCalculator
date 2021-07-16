using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculations.Web.Models.Calculator;
using CalculatorCore;
using Microsoft.AspNetCore.Mvc;

namespace Calculations.Web.Controllers
{
    public class CalculatorController : Controller
    {
        private const string _CALCULATION_HISTORY_KEY = "CalcutionHistory";
        private const string _CURRENT_USERNAME_KEY = "CurrentUsername";

        public IActionResult Index()
        {
            var currentUsername = HttpContext.Session.Get<string>(_CURRENT_USERNAME_KEY);
            var viewModel = new IndexViewModel { CurrentUsername = currentUsername };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(string equation)
        {
            var history = HttpContext.Session.Get<List<HistoryItem>>(_CALCULATION_HISTORY_KEY);
            var calculator = new Calculator(history ?? new List<HistoryItem>());
            var result = calculator.Evaluate(equation);
            if (result != null && string.IsNullOrWhiteSpace(result.ErrorMessage))
            {
                HttpContext.Session.Set(_CALCULATION_HISTORY_KEY, calculator.History);
            }

            var viewModel = result == null ? new IndexViewModel()
                : new IndexViewModel
                {
                    Equation = equation,
                    ErrorMessage = result.ErrorMessage,
                    Result = result.Result,
                    History = calculator.History
                };

            return View("Index", viewModel);
        }

        [HttpGet]
        [Route("calculator/filter/{filter?}")]
        public IActionResult FilterHistory(string filter)
        {
            var history = HttpContext.Session.Get<List<HistoryItem>>(_CALCULATION_HISTORY_KEY);
            var calculator = new Calculator(history);
            var filteredHistory = calculator.GetFilteredHistory(GetOpperation(filter));
            return Json(filteredHistory);
        }

        private string GetOpperation(string filter)
        {
            switch (filter)
            {
                case "addition":
                    return "+";
                case "subtraction":
                    return "-";
                case "multiplication":
                    return "*";
                case "division":
                    return "/";
                default:
                    return string.Empty;
            }
        }
    }
}
