using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetaalTerminal
{
    internal abstract class PaymentMethodBase: IPaymentMethod
    {
        //[»] Constant variable members
        const string PAYMENT_METHOD_FAIL_MESSAGE = "betaling niet succesvol";
        const string PAYMENT_METHOD_SUCCESS_MESSAGE = "betaling wel succesvol";

        //[»] Private backing variable members

        //[»] Properties members
        public string Name { get; protected set; }
        public string PaymentFailedMessage { get; protected set; }
        public string PaymentSucceededMessage { get; protected set; }
        public bool IsPaymentSucceeded { get; protected set; }

        //[»] Constructor members
        public PaymentMethodBase(string PAYMENT_METHOD_NAME)
        {
            // Initialise public property values
            Name = PAYMENT_METHOD_NAME;
            PaymentFailedMessage = PAYMENT_METHOD_FAIL_MESSAGE;
            PaymentSucceededMessage = PAYMENT_METHOD_SUCCESS_MESSAGE;
        }

        //[»] Primary Method members
        public void StartTransaction(double amount)
        {
            // Reset the IsPaymentSucceeded flag
            if (IsPaymentSucceeded) IsPaymentSucceeded = false;

            try
            {
                ExecuteTransactionLogic(amount);
            }
            catch (Exception exception)
            {
                AnsiConsole.WriteException(exception);
            }
        }

        public abstract void ExecuteTransactionLogic(double amount);

        //[»] Secondary Method members
    }
}
