using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorCore.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Calculator_Evaluate_AddTwoNumbers()
        {
            // arrange
            var input = "1 + 2";
            var expected = 3;
            var target = new Calculator();

            // act
            var result = target.Evaluate(input);

            // assert 
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Result);
        }
    }
}
