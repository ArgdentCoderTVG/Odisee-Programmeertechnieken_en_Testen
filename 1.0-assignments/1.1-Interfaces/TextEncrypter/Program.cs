using Spectre.Console;
using System.Collections.Immutable;
using TextEncrypter.EncryptionMethods;

namespace TextEncrypter
{
    internal class Program
    {
        // List of payment methods (Immutable)
        static readonly ImmutableList<IEncryptionMethod> ENCRYPTION_METHODS = ImmutableList.Create<IEncryptionMethod>(
            new ReverseAlphabetEncryptionMethod(),
            new ReverseOrderEncryptionMethod(),
            new ShiftOrderOneUpEncryptionMethod()/*,
            new EncryptionMethodMixer(),
            new EnigmaRotorEncryptionMethod()*/);

        static void Main(string[] args)
        {
            // Define a UI loop
            bool tryEncryptionAgain = true;
            do { tryEncryptionAgain = ExecuteEncryptionMethodUI(); }

            while (tryEncryptionAgain);

            //TODO: Define decoding UI paths
            //TODO: Define checkbox mixed encryption de-/encode UI loop
        }

        private static bool ExecuteEncryptionMethodUI()
        {
            // Clear the console
            Console.Clear();

            // Ask for amount
            string input = AnsiConsole.Ask<string>("Geef een te encoderen string:");

            // Ask for payment method using Checkbox 
            IEncryptionMethod encryptionMethod = AnsiConsole.Prompt(new SelectionPrompt<IEncryptionMethod>()
            .Title("Welke encryptie methode wil je gebruiken?")
            .AddChoices(ENCRYPTION_METHODS)
            .UseConverter<IEncryptionMethod>(x => x.Name));

            // Write the output to the screen
            AnsiConsole.WriteLine($"Encryptie methode resultaat: {encryptionMethod.EncodeString(input)}");

            // Loop back if necessary
            return AnsiConsole.Prompt(
            new ConfirmationPrompt("Wil je verdergaan?"));
        }
    }
}