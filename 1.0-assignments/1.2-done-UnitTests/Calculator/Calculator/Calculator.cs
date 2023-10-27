using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator
    {
        public double Sum(double number1, double number2)
        {
            return number1 + number2;
        }

        public double Multiply(double number1, double number2)
        {
            return number1 * number2;
        }

        public double Subtract(double number1, double number2)
        {
            return number1 - number2;
        }

        public double Divide(double number1, double number2)
        {
            if (number2 == 0)
            {
                throw new DivideByZeroException();
            }

            return number1 / number2;
        }

        public bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        public bool IsPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }

            for (int i = number / 2; i > 1; i--)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public string ConvertToBinary(int number)
        {
            string binaryNumber = "";

            if (number < 0)
            {
                throw new ArgumentException();
            }

            while (number > 0)
            {
                if (number % 2 == 1)
                {
                    binaryNumber = "1" + binaryNumber;
                    number -= 1;
                }
                else
                {
                    binaryNumber = "0" + binaryNumber;
                }
                number = number / 2;
            }

            return binaryNumber;
        }

        public int ConvertToDecimal(string binaryNumber)
        {

            int number = 0;
            int i = 1;
            foreach (char c in binaryNumber)
            {
                if (c != '1' && c != '0')
                {
                    throw new ArgumentException();
                }

                if (c == '1')
                {
                    number += (int)Math.Pow(2, binaryNumber.Length - i);
                }
                i++;

            }

            return number;
        }
    }
}
