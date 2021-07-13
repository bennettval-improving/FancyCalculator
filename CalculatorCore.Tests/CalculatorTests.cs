using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorCore.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        private Calculator _target;

        [TestInitialize]
        public void SetUp()
        {
            _target = new Calculator();
        }

        [TestMethod]
        public void Calculator_Evaluate_ShouldReturnResult_AddTwoNumbers()
        {
            // arrange
            var input = "1 + 2";
            var expected = 3;

            // act
            var result = _target.Evaluate(input);

            // assert 
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Result);
        }

        [TestMethod]
        public void Calculator_Evaluate_CannotParseFirstNumber()
        {
            // arrange
            var input = "one + 2";
            var expected = $"The first number, one, was not a valid number.";

            // act
            var result = _target.Evaluate(input);

            // assert 
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.ErrorMessage);
        }

        [TestMethod]
        public void Calculator_Evaluate_CannotParseSecondNumber()
        {
            // arrange
            var input = "1 + two";
            var expected = $"The second number, two, was not a valid number.";

            // act
            var result = _target.Evaluate(input);

            // assert 
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.ErrorMessage);
        }

        [TestMethod]
        public void Calculator_Evaluate_ShouldReturnResult_SubtractTwoNumbers()
        {
            // arrange
            var input = "3 - 2";
            var expected = 1;

            // act
            var result = _target.Evaluate(input);

            // assert 
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Result);
        }

        [TestMethod]
        public void Calculator_Evaluate_ShouldReturnResult_MultiplyTwoNumbers()
        {
            // arrange
            var input = "3 * 2";
            var expected = 6;

            // act
            var result = _target.Evaluate(input);

            // assert 
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Result);
        }

        [TestMethod]
        public void Calculator_Evaluate_ShouldReturnResult_DivideTwoNumbers()
        {
            // arrange
            var input = "10 / 5";
            var expected = 2;

            // act
            var result = _target.Evaluate(input);

            // assert 
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Result);
        }

        [TestMethod]
        public void Calculator_Evaluate_ShouldReturnErrorWhenInvalidOpperator()
        {
            // arrange
            var input = "10 plus 5";
            var expected = "The opperation, plus, is invalid.You must use one of the following: + - * /";

            // act
            var result = _target.Evaluate(input);

            // assert 
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.ErrorMessage);
        }

        [TestMethod]
        public void Calculator_Evaluate_ShouldReturnErrorWhenInputDoesNotHaveRightNumberOfPieces()
        {
            // arrange
            var input = "10 +";
            var expected = "The opperation must be in form '<number> <opperation> <number>'.";

            // act
            var result = _target.Evaluate(input);

            // assert 
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.ErrorMessage);
        }
    }
}
