using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace FrisdrankAutomaat
{
    
    public enum CoinsMenuOption
    {
        [Description("2 euro")]
        TWO_EURO,
        [Description("1 euro")]
        ONE_EURO,
        [Description("50 cent")]
        FIFTY_CENT,
        [Description("20 cent")]
        TWENTY_CENT,
        [Description("10 cent")]
        TEN_CENT,
        [Description("5 cent")]
        FIVE_CENT,
        [Description("Keer terug")]
        CANCEL
    }

    internal class InsertCoins : IAction
    {
        public string Message { get; private set; }
        public IAction NextAction { get; private set; }

        public InsertCoins(string message = null)
        {
            Message = message;
        }

        public void DoAction(VendingMachine v)
        {
            CoinsMenuOption choice = AnsiConsole.Prompt(new SelectionPrompt<CoinsMenuOption>()
                .Title("Kies een munt")
                .AddChoices(Enum.GetValues<CoinsMenuOption>())
                .UseConverter(x => x.GetName()));

            switch (choice)
            {
                case CoinsMenuOption.TWO_EURO:
                    InsertCoin(v, Coins.TWO_EURO);
                    break;
                case CoinsMenuOption.ONE_EURO:
                    InsertCoin(v,Coins.ONE_EURO);
                    break;
                case CoinsMenuOption.FIFTY_CENT:
                    InsertCoin(v,Coins.FIFTY_CENTS);
                    break;
                case CoinsMenuOption.TWENTY_CENT:
                    InsertCoin(v, Coins.TWENTY_CENTS);
                    break;
                case CoinsMenuOption.TEN_CENT:
                    InsertCoin(v,Coins.TEN_CENTS);
                    break;
                case CoinsMenuOption.FIVE_CENT:
                    InsertCoin(v, Coins.FIVE_CENTS);
                    break;
                case CoinsMenuOption.CANCEL:
                    NextAction = new MainMenu();
                    break;
            }
        }

        private void InsertCoin(VendingMachine v, Coins coin)
        {
            v.InsertCoins(coin);
            NextAction = new InsertCoins();
        }
    }
}
