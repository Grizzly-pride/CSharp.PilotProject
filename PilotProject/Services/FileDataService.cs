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
        RegistrationUser,
        Sessions
    }

    internal sealed class FileDataService : ISerializeService<DataFile, object>
    {
        public Dictionary<DataFile, String> Files = new()
        {
            [DataFile.RegistrationUser] = @"D:\IT Academy Project\PilotProject\DataJson\RegistrationUserData.json",
            [DataFile.Sessions] = @"D:\IT Academy Project\PilotProject\DataJson\SessionsData.json",
        };

       
        public async Task ObjectToJsonAsync(DataFile fileName, object obj)
        {
            using FileStream fs = new(Files[fileName], FileMode.Append);
            JsonSerializerOptions options = new()
            {
                WriteIndented = true,
                AllowTrailingCommas = true
            };          
            await JsonSerializer.SerializeAsync(fs, obj, options);
        }


        public async Task<object> JsonToObjectAsync(DataFile fileName)
        {
            using FileStream fs = new(Files[fileName], FileMode.OpenOrCreate);
            return await JsonSerializer.DeserializeAsync<object>(fs);
        }
        







        /*
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
        */
    }
}