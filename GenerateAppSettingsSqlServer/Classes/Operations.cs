using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenerateAppSettingsSqlServer.Models;

namespace GenerateAppSettingsSqlServer.Classes
{
    internal class Operations
    {
        public static void Execute(Options options)
        {
            if (options.Folder == "\\")
            {
                AnsiConsole.MarkupLine("[cyan]Looks like you are running from the solution folder which will not work.[/]");
                Console.ReadLine();
                return;
            }

            List<string> tableNames = 
                options.UseLocalDb == "yes" ? 
                    DataOperations.LocalDbDatabaseNames() : 
                    DataOperations.ExpressDatabaseNames();
            

            while (true)
            {

                Console.Clear();

                AnsiConsole.MarkupLine($"[cyan]   Path:[/] {options.Folder}");
                AnsiConsole.MarkupLine($"[cyan]Encrypt:[/] {options.UseEncryption.ToUpper()}");
                AnsiConsole.MarkupLine($"[cyan]LocalDb:[/] {options.UseLocalDb.ToUpper()}\n");

                var menuItem = AnsiConsole.Prompt(MenuOperations.SelectionPrompt(tableNames));
                if (menuItem.Id != -1)
                {
                    FileOperations.WriteFile(options, menuItem.Text);
                }
                else
                {
                    return;
                }
            }
        }
    }
}
