using Spectre.Console;

namespace FrisdrankAutomaat;

internal class PurchaseDrink: IAction
{

    public string Message { get; private set; } 
    public IAction NextAction { get; private set; }
    
    public void DoAction(VendingMachine v)
    {
        int row = AnsiConsole.Ask<int>("Kies een rij:");
        int column = AnsiConsole.Ask<int>("Kies een kolom:");

        try
        {
            Drink drink = v.Buy(row, column);
            Message = $"Je kocht een {drink.Name}";
            NextAction = new MainMenu(Message);

        }
        catch (IndexOutOfRangeException e)
        {
            Message = $"({row}, {column}) is een ongeldige combinatie";
        }
        catch (NoInventoryException e)
        {
            Message = $"Op positie ({row}, {column}) is er geen voorraad meer";

        }
        catch (NotEnoughMoneyException e)
        {
            Drink d = v.Inventory[(row, column)];
            Message = $"{d.Name} kost {d.Price} euro. Je komt {Math.Round(d.Price-e.Budget, 2)} euro tekort";
        }
        finally
        {
            NextAction = new MainMenu(Message);
        }
    }

}