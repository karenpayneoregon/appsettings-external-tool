using System.Runtime.CompilerServices;
using ConsoleHelperLibrary.Classes;
using Spectre.Console;

// ReSharper disable once CheckNamespace
namespace ConsoleApp1;

internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Appsettings create for sql-server";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }

    private static void Render(Rule rule)
    {
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
    }

    private static void ExitPrompt()
    {
        Console.WriteLine();
        Render(new Rule($"[yellow]Press a key to exit the demo[/]").RuleStyle(Style.Parse("silver")).Centered());
        Console.ReadLine();
    }

    private static Table efTable => new Table()
        .RoundedBorder()
        .AddColumn("[b]Id[/]")
        .AddColumn("[b]First[/]")
        .AddColumn("[b]Last[/]")
        .Alignment(Justify.Center)
        .BorderColor(Color.LightSlateGrey)
        .Title("[LightGreen]Customers from EF Core[/]");

    private static Table DbTable => new Table()
        .RoundedBorder()
        .AddColumn("[b]Id[/]")
        .AddColumn("[b]First[/]")
        .AddColumn("[b]Last[/]")
        .Alignment(Justify.Center)
        .BorderColor(Color.LightSlateGrey)
        .Title("[LightGreen]From provider[/]");
}