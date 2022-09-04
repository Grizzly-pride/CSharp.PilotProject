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

    internal sealed class SerializerFileService : ISerializeService<DataFile>
    {
        public static Dictionary<DataFile, string> Files = new()
        {
            [DataFile.RegistrationUser] = @"D:\IT Academy Project\PilotProject\DataJson\RegistrationUserData.json",
            [DataFile.Sessions] = @"D:\IT Academy Project\PilotProject\DataJson\SessionsData.json",
        };


        public async Task ObjectToJsonAsync<T>(DataFile fileName, T obj)
        {
            using (FileStream fs = new(Files[fileName], FileMode.Append))
            {
                JsonSerializerOptions options = new()
                {
                    WriteIndented = true,
                    AllowTrailingCommas = true                    
                };
                await JsonSerializer.SerializeAsync<T>(fs, obj, options);
            }
        }

        public async Task<T> JsonToObjectAsync<T>(DataFile fileName)
        {
            using (FileStream fs = new(Files[fileName], FileMode.OpenOrCreate))
            {
                return await JsonSerializer.DeserializeAsync<T>(fs);
            }
        }
    }
}