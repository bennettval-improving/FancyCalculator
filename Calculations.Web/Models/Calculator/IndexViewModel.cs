using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculations.Web.Models.Calculator
{
    public class IndexViewModel
    {
        public string CurrentUsername { get; set; }
        public string Equation { get; set; }
        public string ErrorMessage { get; set; }
        public decimal? Result { get; set; }
        public List<CalculatorCore.HistoryItem> History { get; set; }
    }
}
