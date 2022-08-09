using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using PilotProject.Interfaces;

namespace PilotProject
{
    internal sealed class JsonService: ISerializeService
    {
        public string Serialize(object obj) => JsonSerializer.Serialize(obj);
  

        public object Deserialize(string json)
        {
            try
            {
                return JsonSerializer.Deserialize(json, typeof(object));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
