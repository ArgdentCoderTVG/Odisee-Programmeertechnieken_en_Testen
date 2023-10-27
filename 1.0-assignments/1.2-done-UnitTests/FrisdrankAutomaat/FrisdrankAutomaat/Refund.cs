using Spectre.Console;

namespace FrisdrankAutomaat;

public class Refund: IAction
{


    public string Message { get; private set; }
    public IAction NextAction { get; private set; }
    
    public void DoAction(VendingMachine v)
    {
        bool result = AnsiConsole.Confirm("Ben je zeker dat je een refund wil?");
        if (result)
        {
            Double amount = v.Refund();
            Message = $"{amount} euro terug gegegeven";
        }

        NextAction = new MainMenu(Message);
        
    }
}