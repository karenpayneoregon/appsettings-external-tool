using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GenerateAppSettingsSqlServer.Models;

namespace GenerateAppSettingsSqlServer.Classes
{
    internal class FileOperations
    {
        public static void WriteFile(Options options, string databaseName)
        {
            var baseExpressConnection1 = 
                $"Data Source=.\\SQLEXPRESS;Initial Catalog={databaseName};" + 
                $"integrated security=True;Encrypt=True";

            var baseExpressConnection2 =
                $"Data Source=.\\SQLEXPRESS;Initial Catalog={databaseName};" +
                $"integrated security=True;";


            var baseLocalDbConnection1 =
                $"Server=(localdb)\\MSSQLLocalDB;Initial Catalog={databaseName};" +
                $"integrated security=True;Encrypt=True";

            var baseLocalDbConnection2 =
                $"Server=(localdb)\\MSSQLLocalDB;Initial Catalog={databaseName};" +
                $"integrated security=True;Encrypt=False";

            var useEncryption = options.UseEncryption.ToLower() == "yes";

            

            Configuration configuration = new Configuration()
            {
                ActiveEnvironment = "Development", 
                Development = useEncryption ? baseLocalDbConnection1 : baseLocalDbConnection2, 
                Production = useEncryption ? baseLocalDbConnection1 : baseLocalDbConnection2, 
                Stage = useEncryption ? baseLocalDbConnection1 : baseLocalDbConnection2
            };
            RootSettings rootSettings = new RootSettings() { ConnectionsConfiguration = configuration };

            string jsonString = JsonSerializer.Serialize(rootSettings, new JsonSerializerOptions()
            {
                WriteIndented = true
            });

            var fileName = Path.Combine(options.Folder, "appsettings.json");
            if (File.Exists(fileName))
            {
                fileName = "appsettings_" + UniqueFileName(false);
                File.WriteAllText(fileName, jsonString);
            }
            else
            {
                File.WriteAllText(fileName, jsonString);
            }
            
        }

        public static string UniqueFileName(bool useGuid, string extension = ".json") => useGuid ?
            $"{DateTime.Now:yyyy-dd-M--HH-mm-ss-ms}{Guid.NewGuid()}{extension}" :
            $"{DateTime.Now:yyyy-dd-M--HH-mm-ss-ms}{extension}";
    }
}
