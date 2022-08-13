using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using PilotProject.Interfaces;

namespace PilotProject.Services
{
    enum DataFile
    {
        Account,
        Pizza
    }

    internal sealed class FileDataService : ISerializeService<Object, String>, IFileService<DataFile, String>
    {
        public static Dictionary<DataFile, String> Files = new()
        {
            [DataFile.Account] = @"D:\IT Academy Project\PilotProject\Data\AccountData.json",
            [DataFile.Pizza] = @"D:\IT Academy Project\PilotProject\Data\PizzaData.json"
        };

        #region JsonAndFile
        public void OjectToJsonFile(object obj, DataFile fileName)
        {
            string jsonString = Serialize(obj);
            WriteFile(fileName, jsonString);
        }

        public object JsonFileToObject(DataFile fileName)
        {
            string jsonString = ReadFile(fileName);
            return Deserialize(jsonString);
        }
        #endregion

        #region JsonSerializer
        public object Deserialize(string jsonString)
        {     
            return JsonSerializer.Deserialize(jsonString, typeof(object))!;
        }

        public string Serialize(object obj)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            return JsonSerializer.Serialize(obj, options);
        }
        #endregion

        #region File
        public void WriteFile(DataFile fileName, string jsonString)
        {
            File.AppendAllText(Files[fileName], jsonString);
        }

        public string ReadFile(DataFile fileName)
        {
            return File.ReadAllText(Files[fileName]);
        }
        #endregion
    }
}