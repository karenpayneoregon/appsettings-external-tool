using ConsoleApp1.Classes;
using ConsoleApp1.Data;
using Spectre.Console;

namespace ConsoleApp1
{
    internal partial class Program
    {
        static async Task Main(string[] args)
        {

            var table = efTable;

            await using var context = new PizzaContext();
            var customers = context.Customers.ToList();

            foreach (var customer in customers)
            {
                table.AddRow(customer.Id.ToString(), customer.FirstName, customer.LastName);
            }

            AnsiConsole.Write(table);

            Console.WriteLine();
            table = DbTable;

            customers = await DataOperations.CustomersList();

            foreach (var customer in customers)
            {
                table.AddRow(customer.Id.ToString(), customer.FirstName, customer.LastName);
            }

            AnsiConsole.Write(table);

            ExitPrompt();
            
        }
    }
}