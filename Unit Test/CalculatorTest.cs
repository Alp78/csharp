using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Test
{
    // TestClass for Calculator class

    [TestClass]
    public class CalculatorTest
    {
        // TextMethod for Divide() method

        [TestMethod]
        // Roy Osherove's naming strategy for unit tests:
        // [UnitOfWork_StateUnderTest_ExpectedBehavior]

        public void Divide_PositiveNumbers_PositiveQuotient()
        {
            // Arrange
            // initialize variables
            int expected = 5;
            int numerator = 20;
            int denominator = 4;

            // Act
            // added Library.Calculator reference to Calculator.Test project
            // right-click on method and Go To Definition(F12)... for direct access
            int actual = Calculator.Library.Calculator.Divide(numerator, denominator);

            // Assert
            // Build the Solution -> Test -> Windows -> Test Explorer
            // right-clcik on Test_Divide -> Run Selected Test
            Assert.AreEqual(expected, actual);
        }

        // testing with negative numerator and denominator
        [TestMethod]
        public void Divide_NegativeNumbers_PositiveQuotient()
        {
            // Arrange
            int expected = 5;
            int numerator = -20;
            int denominator = -4;

            // Act
            int actual = Calculator.Library.Calculator.Divide(numerator, denominator);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        // testing with positive numerator and negative denominator
        [TestMethod]
        public void Divide_PositiveNumeratorNegativeDenominator_NegativeQuotient()
        {
            // Arrange
            int expected = -5;
            int numerator = 20;
            int denominator = -4;

            // Act
            int actual = Calculator.Library.Calculator.Divide(numerator, denominator);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}