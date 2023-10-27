using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetaalTerminal.PaymentMethods
{
    internal class PaymentMethodBancontact : PaymentMethodBase
    {
        //[»] Constant variable members
        const string PAYMENT_METHOD_NAME = "bancontact";

        //[»] Private backing variable members

        //[»] Constructor members
        public PaymentMethodBancontact() : base(PAYMENT_METHOD_NAME) { }

        //[»] Property members

        //[»] Primary Method members

        public override void ExecuteTransactionLogic(double amount)
        {
            // Ask for kaartnummer and pin
            string kaartnummer = AnsiConsole.Ask<string>("Geef kaartnummer?");
            string pin = AnsiConsole.Ask<string>("Geef pin?");

            // Check if pin < kaartnummer and if kaartnummer contains pin
            bool pinIsShortestString = string.Compare(pin, kaartnummer) < 0;
            bool pinIsInKaartnummer = kaartnummer.Contains(pin);

            // Evaluate true if both checks succeeded
            IsPaymentSucceeded = pinIsShortestString && pinIsInKaartnummer;
        }

        //[»] Secondary Method members
    }
}
