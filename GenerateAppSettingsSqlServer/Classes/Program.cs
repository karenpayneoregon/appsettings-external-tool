using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace GenerateAppSettingsSqlServer;

internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Appsettings create for sql-server";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}