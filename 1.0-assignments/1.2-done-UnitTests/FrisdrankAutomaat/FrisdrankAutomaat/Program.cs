using Spectre.Console;
using Spectre.Console.Rendering;

namespace FrisdrankAutomaat
{

    internal class Program
    {
        static VendingMachine vendingMachine = new VendingMachine();
        private static IAction _action = new MainMenu();
        static void Main(string[] args)
        {
            // Setup

            List<Drink> drinks = GenerateDrinksList();
            vendingMachine.FillRandomly(drinks);

            while (true)
            {
                App();
            }
            

        }

        private static void App()
        {
            AnsiConsole.Clear();
            PrintInventory(vendingMachine.Inventory);
            if (_action.Message != null)
            {
                PrintMessage(_action.Message);
            }
            PrintBudget(vendingMachine.Budget);
            _action.DoAction(vendingMachine);
            _action = _action.NextAction;
        }

        private static void PrintMessage(string message)
        {
            var panel = new Panel(message);
            panel.BorderColor(Color.Red);
            AnsiConsole.Write(panel);
        }   
        
        private static void PrintBudget(double amount)
        {
            var panel = new Panel($"€ {amount}");
            panel.Header = new PanelHeader("Budget");

            panel.Width = 20;
            panel.Border = BoxBorder.Heavy;
             
            AnsiConsole.Write(panel);
        }
        

        private static void PrintInventory(Dictionary<(int, int), Drink> inventory)
        {

            int maxRows = inventory.Keys.Max(x => x.Item1);
            int maxColumns = inventory.Keys.Max(x => x.Item2);

            var table = new Table();
            table.AddColumn(" ");
            for (int i = 0; i <= maxColumns; i++)
            {


                table.AddColumn(new TableColumn(i.ToString()).Centered());
            }


            for (int i = 0; i <= maxRows; i++)
            {
                List<IRenderable> items = new List<IRenderable>();

                items.Add(new Text(i.ToString()));
                for (int j = 0; j <= maxColumns; j++)
                {
                    if (inventory[(i, j)] == null)
                    {
                        items.Add(new Text(" - "));
                    }
                    else
                    {

                        items.Add(new Text(inventory[(i, j)].Name));

                    }
                }
                table.AddRow(items);
            }
            AnsiConsole.Write(table);
        }




        private static List<Drink> GenerateDrinksList()
        {
            Drink coke = new Drink("cola", 1.5);
            Drink fanta = new Drink("fanta", 1.5);
            Drink water = new Drink("water", 1);
            Drink aquarius = new Drink("aquarius", 1.8);
            Drink icetea = new Drink("ice tea", 1.7);

            List<Drink> drinks = new List<Drink>();
            AddDrink(drinks, coke, 10);
            AddDrink(drinks, fanta, 10);
            AddDrink(drinks, water, 10);
            AddDrink(drinks, aquarius, 10);
            AddDrink(drinks, icetea, 10);
            return drinks;
        }

        private static void AddDrink(List<Drink> drinks, Drink drink, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                drinks.Add(drink);
            }
          
        }
    }
}