using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorCore.Test
{
    [TestClass]
    public class CalculatorCoreTests
    {
        [TestMethod]
        public void Calculator_Evaluate_AddTwoNumbers()
        {
            // arrange
            var input = "1 + 2";
            var expected = "Result: 3";
            var target = new Calculator();

            // act
            var result = target.Evaluate(input);

            // assert
            Assert.AreEqual(expected, result);
        }
    }
}
