using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PilotProject.Services
{
    
    internal static class DataService
    {
        public static void WriteToJesonFile<T>(T obj, DataFile fileName)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(obj, options);
            File.AppendAllText(DataBase.Files[fileName], jsonString);
            
        }

        public static T WriteToObject<T>(DataFile fileName)
        {
            //добавить эксепшен на проверку наличия файла
            string jsonString = File.ReadAllText(DataBase.Files[fileName]);
            return JsonSerializer.Deserialize<T>(jsonString)!;
        }
    }
}
