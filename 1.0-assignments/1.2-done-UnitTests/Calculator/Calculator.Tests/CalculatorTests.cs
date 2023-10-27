using FluentAssertions;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        /*
            Sum Method:
            1. Tests summation of two natural numbers.
            2. Tests summation of two negative numbers.
            3. Tests summation of one negative- and one natural number.
            4. Tests summation of two zeros.

            Multiply Method:
            1. Tests multiplication of two natural numbers.
            2. Tests multiplication of two negative numbers.
            3. Tests multiplication of one negative- and one natural number.
            4. Tests multiplication of two zeros.

            Subtract Method:
            1. Tests subtraction of two natural numbers.
            2. Tests subtraction of two negative numbers.
            3. Tests subtraction of one negative- and one natural number.
            4. Tests subtraction of two zeros.

            Divide Method:
            1. Tests division of two natural numbers.
            2. Tests division of two negative numbers.
            3. Tests division of one natural- and one negative number.
            4.1 Tests division by zero exception.
            4.2 Tests division of zero by a natural number.

            IsEven Method:
            1. Tests if an even natural number is recognized as even.
            2. Tests if an uneven natural number is recognized as not even.
            3. Tests if zero is recognized as even.

            IsPrime Method:
            1. Tests if a prime natural number is recognized as a prime number.
            2. Tests if a non-prime natural number is recognized as a non-prime number.
            3. Tests if a negative number is recognized as non-prime number.
            4. Tests if zero is recognized as non-prime number.

            ConvertToBinary Method:
            1. Tests binary conversion of a natural number to a binary string.
            2. Tests if binary conversion of a negative number throws the correct type of exception.

            ConvertToDecimal Method:
            1. Tests decimal conversion of a binary string to a decimal number.
            2. Tests if decimal conversion of an unexpected string throws the correct type of exception.
        */


        //[»] Methode Sum() |-----------|*|-----------|

        // Two natural numbers
        [Fact]
        public void GivenTwoNaturalNumbers_WhenCallSum_ThenSummationResultCorrect()
        {
            // Arrange
            Calculator sut = new Calculator();
            double firstNaturalNumber = 2;
            double secondNaturalNumber = 5;
            double expectedResult = 7;

            // Act
            double actualResult = sut.Sum(firstNaturalNumber, secondNaturalNumber);

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        // Two negative numbers
        [Fact]
        public void GivenTwoNegativeNumbers_WhenCallSum_ThenSummationResultCorrect()
        {
            // Arrange
            Calculator sut = new Calculator();
            double firstNegativeNumber = -30;
            double secondNegativeNumber = -70;
            double expectedResult = -100;

            // Act
            double actualResult = sut.Sum(firstNegativeNumber, secondNegativeNumber);

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        // One negative- and one natural number
        [Fact]
        public void GivenOneNegativeAndOneNaturalNumber_WhenCallSum_ThenSummationResultCorrect()
        {
            // Arrange
            Calculator sut = new Calculator();
            double firstNegativeNumber = -30;
            double secondNaturalNumber = 3;
            double expectedResult = -27;

            // Act
            double actualResult = sut.Sum(firstNegativeNumber, secondNaturalNumber);

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        // Two zero numbers
        [Fact]
        public void GivenTwoZeroNumbers_WhenCallSum_ThenSummationResultCorrect()
        {
            // Arrange
            Calculator sut = new Calculator();
            double firstZeroNumber = 0;
            double secondZeroNumber = 0;
            double expectedResult = 0;

            // Act
            double actualResult = sut.Sum(firstZeroNumber, secondZeroNumber);

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        //[»] Methode Multiply() |-----------|*|-----------|

        // Two natural numbers
        [Fact]
        public void GivenTwoNaturalNumbers_WhenCallMultiply_ThenMultiplicationResultCorrect()
        {
            // Arrange
            Calculator sut = new Calculator();
            double firstNaturalNumber = 3;
            double secondNaturalNumber = 3;
            double expectedResult = 9;

            // Act
            double actualResult = sut.Multiply(firstNaturalNumber, secondNaturalNumber);

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        // Two negative numbers
        [Fact]
        public void GivenTwoNegativeNumbers_WhenCallMultiply_ThenMultiplicationResultCorrect()
        {
            // Arrange
            Calculator sut = new Calculator();
            double firstNegativeNumber = -3;
            double secondNegativeNumber = -5;
            double expectedResult = 15;

            // Act
            double actualResult = sut.Multiply(firstNegativeNumber, secondNegativeNumber);

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        // One negative- and one natural number
        [Fact]
        public void GivenOneNegativeAndOneNaturalNumber_WhenCallMultiply_ThenMultiplicationResultCorrect()
        {
            // Arrange
            Calculator sut = new Calculator();
            double firstNegativeNumber = -6;
            double secondNaturalNumber = 3;
            double expectedResult = -18;

            // Act
            double actualResult = sut.Multiply(firstNegativeNumber, secondNaturalNumber);

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        // Two zero numbers
        [Fact]
        public void GivenTwoZeroNumbers_WhenCallMultiply_ThenMultiplicationResultCorrect()
        {
            // Arrange
            Calculator sut = new Calculator();
            double firstZeroNumber = 0;
            double secondZeroNumber = 0;
            double expectedResult = 0;

            // Act
            double actualResult = sut.Multiply(firstZeroNumber, secondZeroNumber);

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        //[»] Methode Subtract() |-----------|*|-----------|

        // Two natural numbers
        [Fact]
        public void GivenTwoNaturalNumbers_WhenCallSubtract_ThenSubtractionResultCorrect()
        {
            // Arrange
            Calculator sut = new Calculator();
            double firstNaturalNumber = 7;
            double secondNaturalNumber = 6;
            double expectedResult = 1;

            // Act
            double actualResult = sut.Subtract(firstNaturalNumber, secondNaturalNumber);

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        // Two negative numbers
        [Fact]
        public void GivenTwoNegativeNumbers_WhenCallSubtract_ThenSubtractionResultCorrect()
        {
            // Arrange
            Calculator sut = new Calculator();
            double firstNegativeNumber = -17;
            double secondNegativeNumber = -2;
            double expectedResult = -15;

            // Act
            double actualResult = sut.Subtract(firstNegativeNumber, secondNegativeNumber);

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        // One negative- and one natural number
        [Fact]
        public void GivenOneNegativeAndOneNaturalNumber_WhenCallSubtract_ThenSubtractionResultCorrect()
        {
            // Arrange
            Calculator sut = new Calculator();
            double firstNegativeNumber = -17;
            double secondNaturalNumber = 5;
            double expectedResult = -22;

            // Act
            double actualResult = sut.Subtract(firstNegativeNumber, secondNaturalNumber);

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        // Two zero numbers
        [Fact]
        public void GivenTwoZeroNumbers_WhenCallSubtract_ThenSubtractionResultCorrect()
        {
            // Arrange
            Calculator sut = new Calculator();
            double firstZeroNumber = 0;
            double secondZeroNumber = 0;
            double expectedResult = 0;

            // Act
            double actualResult = sut.Subtract(firstZeroNumber, secondZeroNumber);

            // Assert
            actualResult.Should().Be(expectedResult);
        }


        //[»] Methode Divide() |-----------|*|-----------|

        // Two natural numbers
        [Fact]
        public void GivenTwoNaturalNumbers_WhenCallDivide_ThenDivisionResultCorrect()
        {
            // Arrange
            Calculator sut = new Calculator();
            double firstNaturalNumber = 10;
            double secondNaturalNumber = 2;
            double expectedResult = 5;

            // Act
            double actualResult = sut.Divide(firstNaturalNumber, secondNaturalNumber);

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        // Two negative numbers
        [Fact]
        public void GivenTwoNegativeNumbers_WhenCallDivide_ThenDivisionResultCorrect()
        {
            // Arrange
            Calculator sut = new Calculator();
            double firstNegativeNumber = -6;
            double secondNegativeNumber = -2;
            double expectedResult = 3;

            // Act
            double actualResult = sut.Divide(firstNegativeNumber, secondNegativeNumber);

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        // One negative-, and one natural number
        [Fact]
        public void GivenOneNaturalAndOneNegativeNumber_WhenCallDivide_ThenDivisionResultCorrect()
        {
            // Arrange
            Calculator sut = new Calculator();
            double firstNaturalNumber = 5;
            double secondNegativeNumber = -1;
            double expectedResult = -5;

            // Act
            double actualResult = sut.Divide(firstNaturalNumber, secondNegativeNumber);

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        // Divide natural number by zero
        [Fact]
        public void GivenNaturalNumberDivideByZero_WhenCallDivide_ThenDivisionThrowsDivideByZeroException()
        {
            // Arrange
            Calculator sut = new Calculator();
            double firstNaturalNumber = 9;
            double secondZeroNumber = 0;
            Type expectedResult = typeof(DivideByZeroException);

            // Act
            Type actualResult;
            try
            {
                actualResult = sut.Divide(firstNaturalNumber, secondZeroNumber).GetType();
            }
            catch (DivideByZeroException)
            {
                actualResult = typeof(DivideByZeroException);
            }
            catch (Exception)
            {
                actualResult = typeof(Exception);
            }

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        // Divide zero number by natural number
        [Fact]
        public void GivenZeroDivideByNaturalNumber_WhenCallDivide_ThenResultIsZero()
        {
            // Arrange
            Calculator sut = new Calculator();
            double firstZeroNumber = 0;
            double secondNaturalNumber = 9;
            double expectedResult = 0;

            // Act
            double actualResult = sut.Divide(firstZeroNumber, secondNaturalNumber);

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        //[»] Methode IsEven() |-----------|*|-----------|

        // Even natural number
        [Fact]
        public void GivenOneEvenNaturalNumber_WhenCallIsEven_ThenEvaluationToTrue()
        {
            // Arrange
            Calculator sut = new Calculator();
            int evenNaturalNumber = 12;
            bool expectedResult = true;

            // Act
            bool actualResult = sut.IsEven(evenNaturalNumber);

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        [Fact]
        // Uneven natural number
        public void GivenOneUnevenNaturalNumber_WhenCallIsEven_ThenEvaluationToFalse()
        {
            // Arrange
            Calculator sut = new Calculator();
            int unevenNaturalNumber = 13;
            bool expectedResult = false;

            // Act
            bool actualResult = sut.IsEven(unevenNaturalNumber);

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        // Even zero number
        [Fact]
        public void GivenOneEvenZeroNumber_WhenCallIsEven_ThenEvaluationToTrue()
        {
            // Arrange
            Calculator sut = new Calculator();
            int ZeroNumber = 0;
            bool expectedResult = true;

            // Act
            bool actualResult = sut.IsEven(ZeroNumber);

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        //[»] Methode IsPrime() |-----------|*|-----------|
        
        // Prime natural number
        [Fact]
        public void GivenPrimeNaturalNumber_WhenCallIsPrime_ThenEvaluationToTrue()
        {
            // Arrange
            Calculator sut = new Calculator();
            int primeNaturalNumber = 7;
            bool expectedResult = true;

            // Act
            bool actualResult = sut.IsPrime(primeNaturalNumber);

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        // Non-prime natural number
        [Fact]
        public void GivenNonprimeNaturalNumber_WhenCallIsPrime_ThenEvaluationToFalse()
        {
            // Arrange
            Calculator sut = new Calculator();
            int nonprimeNaturalNumber = 8;
            bool expectedResult = false;

            // Act
            bool actualResult = sut.IsPrime(nonprimeNaturalNumber);

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        // Negative number
        [Fact]
        public void GivenNegativeNumber_WhenCallIsPrime_ThenEvaluationToFalse()
        {
            // Arrange
            Calculator sut = new Calculator();
            int negativeNumber = -7;
            bool expectedResult = false;

            // Act
            bool actualResult = sut.IsPrime(negativeNumber);

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        // Zero number
        [Fact]
        public void GivenZeroNumber_WhenCallIsPrime_ThenEvaluationToTrue()
        {
            // Arrange
            Calculator sut = new Calculator();
            int zeroNumber = 0;
            bool expectedResult = false;

            // Act
            bool actualResult = sut.IsPrime(zeroNumber);

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        //[»] Methode ConvertToBinary() |-----------|*|-----------|

        // natural number
        [Fact]
        public void GivenOneNaturalNumber_WhenCallConvertToBinary_ThenResultCorrect()
        {
            // Arrange
            Calculator sut = new Calculator();
            int naturalNumber = 8;
            string expectedResult = "00001000";

            // Act
            string actualResult = sut.ConvertToBinary(naturalNumber);

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        // negative number
        [Fact]
        public void GivenOneNegativeNumber_WhenCallConvertToBinary_ThenThrowException()
        {
            // Arrange
            Calculator sut = new Calculator();
            int negativeNumber = -8;
            Type expectedResult = typeof(ArgumentException);

            // Act
            Type actualResult;
            try
            {
                actualResult = sut.ConvertToBinary(negativeNumber).GetType();
            }
            catch (ArgumentException)
            {
                actualResult = typeof(ArgumentException);
            }

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        //[»] Methode ConvertToDecimal() |-----------|*|-----------|

        // natural number
        [Fact]
        public void GivenOneStringifiedNaturalNumber_WhenCallConvertToDecimal_ThenResultCorrect()
        {
            // Arrange
            Calculator sut = new Calculator();
            string stringifiedBinaryNumber = "00001000";
            int expectedResult = 8;

            // Act
            int actualResult = sut.ConvertToDecimal(stringifiedBinaryNumber);

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        // unexpected string
        [Fact]
        public void GivenOneStringifiedNegativeNumber_WhenCallConvertToDecimal_ThenThrowException()
        {
            // Arrange
            Calculator sut = new Calculator();
            string stringifiedUnexpectedInput = "hito hito no mi model nika";
            Type expectedResult = typeof(ArgumentException);

            // Act
            Type actualResult;
            try
            {
                actualResult = sut.ConvertToDecimal(stringifiedUnexpectedInput).GetType();
            }
            catch (ArgumentException)
            {
                actualResult = typeof(ArgumentException);
            }

            // Assert
            actualResult.Should().Be(expectedResult);
        }
    }
}
