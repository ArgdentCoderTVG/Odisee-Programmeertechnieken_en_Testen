using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetaalTerminal
{
    internal interface IPaymentMethod
    {
        string Name { get; }
        string PaymentFailedMessage { get; }
        string PaymentSucceededMessage { get; }
        bool IsPaymentSucceeded { get; }
        void StartTransaction(double amount);
    }
}
