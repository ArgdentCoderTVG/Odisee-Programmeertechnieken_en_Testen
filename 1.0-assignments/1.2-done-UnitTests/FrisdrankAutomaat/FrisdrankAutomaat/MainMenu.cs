using Spectre.Console;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrisdrankAutomaat
{

    public enum MainMenuOption
    {
        [Description("Munten inwerpen")]
        INSERT_COINS,
        [Description("Drank kiezen")]
        PURCHASE_DRINK,
        [Description("Geld teruggeven")]
        REFUND
    }
    internal class MainMenu : IAction
    {
        public string Message {get; private set; }
        
        public IAction NextAction { get; private set; }

        public MainMenu(string message = null)
        {
            Message = message;
        }


        public void DoAction(VendingMachine v)
           {
            MainMenuOption choice = AnsiConsole.Prompt(new SelectionPrompt<MainMenuOption>()
                .Title("Maak een keuze")
               .AddChoices(Enum.GetValues<MainMenuOption>())
               .UseConverter(x => x.GetName())
               );

            switch (choice)
            {
                case MainMenuOption.INSERT_COINS:
                    NextAction = new InsertCoins();
                    break;
                case MainMenuOption.PURCHASE_DRINK:
                    NextAction = new PurchaseDrink();
                    break;
                case MainMenuOption.REFUND:
                    NextAction = new Refund();
                    break;
            }
        }

      
    }
}
