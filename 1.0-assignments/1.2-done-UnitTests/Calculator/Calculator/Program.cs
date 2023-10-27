using Spectre.Console;
using System.Runtime.CompilerServices;

namespace Calculator
{
    internal class Program
    {

        static Calculator calculator = new Calculator();
        static void Main(string[] args)
        {
            while (true)
            {
                App();
            }

        }
        static void App()
        {
            string choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
               .Title("Choose the preferred calculator operation")
               .AddChoices("Sum", "Multiply", "Subtract", "Divide", "IsEven", "IsPrime", "ConvertToBinary", "ConvertToDecimal"));

            switch (choice)
            {
                case "Sum":
                    Sum();
                    break;
                case "Multiply":
                    Multiply();
                    break;
                case "Subtract":
                    Subtract();
                    break;
                case "Divide":
                    Divide();
                    break;
                case "IsEven":
                    IsEven();
                    break;
                case "IsPrime":
                    IsPrime();
                    break;
                case "ConvertToBinary":
                    ConvertToBinary();
                    break;
                case "ConvertToDecimal":
                    ConvertToDecimal();
                    break;

            }

            bool cont = AnsiConsole.Confirm("Do you want to continue?");
            if (cont == false)
            {

                Environment.Exit(0);
            }
            else
            {
                AnsiConsole.Clear();
            }
        }

        static void Sum()
        {
            double number1 = AnsiConsole.Ask<double>("Pick a first number?");
            double number2 = AnsiConsole.Ask<double>("Pick a second number?");

            AnsiConsole.WriteLine($"The result is {calculator.Sum(number1, number2)}");

        }

        static void Multiply()
        {
            double number1 = AnsiConsole.Ask<double>("Pick a first number?");
            double number2 = AnsiConsole.Ask<double>("Pick a second number?");

            AnsiConsole.WriteLine($"The result is {calculator.Multiply(number1, number2)}");

        }

        static void Subtract()
        {
            double number1 = AnsiConsole.Ask<double>("Pick a first number?");
            double number2 = AnsiConsole.Ask<double>("Pick a second number?");

            AnsiConsole.WriteLine($"The result is {calculator.Subtract(number1, number2)}");

        }

        static void Divide()
        {
            double number1 = AnsiConsole.Ask<double>("Pick a first number?");
            double number2 = AnsiConsole.Ask<double>("Pick a second number?");

            try
            {
                AnsiConsole.WriteLine($"The result is {calculator.Divide(number1, number2)}");
            }
            catch (DivideByZeroException e)
            {
                AnsiConsole.WriteLine("Illegal operation");
            }

        }

        static void IsEven()
        {
            int number = AnsiConsole.Ask<int>("Pick a number?");


            if (calculator.IsEven(number))
            {
                AnsiConsole.WriteLine($"{number} is even");
            }
            else
            {
                AnsiConsole.WriteLine($"{number} is odd");
            }

        }

        static void IsPrime()
        {
            int number = AnsiConsole.Ask<int>("Pick a number?");


            if (calculator.IsPrime(number))
            {
                AnsiConsole.WriteLine($"{number} is prime");
            }
            else
            {
                AnsiConsole.WriteLine($"{number} is not prime");
            }
        }

        static void ConvertToBinary()
        {
            int number = AnsiConsole.Ask<int>("Pick a positive number?");
            try
            {
                AnsiConsole.WriteLine($"{number} is {calculator.ConvertToBinary(number)} in binary");
            }
            catch (ArgumentException e)
            {
                AnsiConsole.WriteLine("Wrong input");
            }
        }

        static void ConvertToDecimal()
        {
            string number = AnsiConsole.Ask<string>("Pick a binary number?");

            try
            {
                AnsiConsole.WriteLine($"{number} is {calculator.ConvertToDecimal(number)} in decimal");
            }
            catch (ArgumentException e)
            {
                AnsiConsole.WriteLine("Wrong input");
            }

        }
    }
}