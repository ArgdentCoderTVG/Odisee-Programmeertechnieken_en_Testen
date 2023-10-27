using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetaalTerminal.PaymentMethods
{
    internal class PaymentMethodMealvouchers : PaymentMethodBase
    {
        //[»] Constant variable members
        const string PAYMENT_METHOD_NAME = "Mealvouchers";
        const short LAST_THREE_DIGITS_MODULUS = 1000; // No Magic numbers

        //[»] Private backing variable members

        //[»] Property members

        //[»] Constructor members

        public PaymentMethodMealvouchers() : base(PAYMENT_METHOD_NAME) { }

        //[»] Primary Method members

        public override void ExecuteTransactionLogic(double amount)
        {
            // Ask for kaartnummer
            int kaartnummer = AnsiConsole.Ask<int>("Geef kaartnummer?");

            // Calculate budget (last three digits)
            int budget = kaartnummer % LAST_THREE_DIGITS_MODULUS;

            // Check if budget is greater or equal than amount
            if (budget < amount) throw new Exception($"Budget €{budget} less than amount €{amount}");

            // Evaluate true if budget is lower than amount
            IsPaymentSucceeded = budget >= amount ? true : false;
        }

        //[»] Secondary Method members
    }
}
