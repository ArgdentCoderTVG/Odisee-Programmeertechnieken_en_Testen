using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BetaalTerminal.PaymentMethods
{
    internal class PaymentMethodPaypal : PaymentMethodBase
    {
        //[»] Constant variable members
        const string PAYMENT_METHOD_NAME = "Paypal";
        const string PASSWORD = "ROMEO";
        const string USERNAME = "TANGO";

        //[»] Private backing variable members

        //[»] Properties members

        //[»] Constructor members
        public PaymentMethodPaypal() : base(PAYMENT_METHOD_NAME) { }

        //[»] Primary Method members

        public override void ExecuteTransactionLogic(double amount)
        {
            // Ask for username and password
            string username = AnsiConsole.Ask<string>("Geef username:");
            string password = AnsiConsole.Ask<string>("Geef password:");

            // Check if username and password are correct => Early exit principle
            if (username != USERNAME) throw new Exception("username not correct");
            if (password != PASSWORD) throw new Exception("passwoord not correct");

            // Evaluate true if budget is lower than amount
            IsPaymentSucceeded = true;
        }

        //[»] Secondary Method members
    }
}
