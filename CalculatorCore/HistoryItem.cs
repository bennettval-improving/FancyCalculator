using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCore
{
    public class HistoryItem
    {
        public string Equation { get; set; }
        public decimal Result { get; set; }
        public DateTime InsertedUtc { get; set; }
    }
}
