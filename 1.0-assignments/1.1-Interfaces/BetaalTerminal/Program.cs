using BetaalTerminal.PaymentMethods;
using Spectre.Console;
using System.Collections.Immutable;

namespace BetaalTerminal
{
    internal class Program
    {
        // List of payment methods
        static readonly ImmutableList<IPaymentMethod> PAYMENT_METHODS = ImmutableList.Create<IPaymentMethod>(
            new PaymentMethodPaypal(), new PaymentMethodMealvouchers(), new PaymentMethodBancontact());

        static void Main(string[] args)
        {
            // Ask for amount
            double amount = AnsiConsole.Ask<double>("Welk bedrag wil je [green]betalen[/]?");

            // Ask for payment method using Checkbox 
            IPaymentMethod paymentMethod = AnsiConsole.Prompt(new SelectionPrompt<IPaymentMethod>()
            .Title("Welke betaalmethode wil je gebruiken?")
            .AddChoices(PAYMENT_METHODS)
            .UseConverter<IPaymentMethod>(x => x.Name));


            // Start the chosen transaction
            paymentMethod.StartTransaction(amount);
            
            // Display the chosen transaction result
            AnsiConsole.WriteLine(paymentMethod.IsPaymentSucceeded ? paymentMethod.PaymentSucceededMessage : paymentMethod.PaymentFailedMessage);
        }
    }
}