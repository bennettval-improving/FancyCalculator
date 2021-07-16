using System;
using System.Collections.Generic;
using System.Linq;
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
        public void Calculator_Ctor_ShouldInitializeHistoryWhenNotProvided()
        {
            // arrange
            var expectedCount = 0;

            // act
            var result = new Calculator();

            // assert
            Assert.AreEqual(expectedCount, result.History.Count);
        }

        [TestMethod]
        public void Calculator_Ctor_ShouldSetHistoryWhenGiven()
        {
            // arrange
            var expectedHistory = new List<HistoryItem> { new HistoryItem(), new HistoryItem() };

            // act
            var result = new Calculator(expectedHistory);

            // assert 
            Assert.AreEqual(expectedHistory.Count, result.History.Count);
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

        [TestMethod]
        public void Calculator_Evaluate_ShouldReturnResult_MultiCalculations()
        {
            // arrange
            var firstInput = "1 + 2";
            var secondInput = "* 5";
            var expected = 15;

            // act
            _target.Evaluate(firstInput);
            var result = _target.Evaluate(secondInput);

            // assert 
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Result);
        }

        [TestMethod]
        public void Calculator_Evaluate_ShouldAddHistoryItemWhenSuccessfulCalculation()
        {
            // arrange
            var input = "5 * 3";
            var expectedResult = 15;

            // act
            _target.Evaluate(input);
            var result = _target.History;

            // assert
            Assert.AreEqual(1, result.Count);
            var item = result.First();
            Assert.AreEqual(input, item.Equation);
            Assert.AreEqual(expectedResult, item.Result);
        }

        [TestMethod]
        public void Calculator_Evaluate_ShouldNotAddHistoryWhenThereIsAnError()
        {
            // arrange
            var initialHistory = new List<HistoryItem>
            {
                new HistoryItem
                {
                    Equation = "1 + 1",
                    Result = 2,
                    InsertedUtc = DateTime.UtcNow.AddMinutes(-10)
                }
            };
            var input = "3 plus 4";
            var target = new Calculator(initialHistory);

            // act
            target.Evaluate(input);
            var result = target.History;

            // assert
            Assert.AreEqual(initialHistory.Count, result.Count);
        }
    }
}
