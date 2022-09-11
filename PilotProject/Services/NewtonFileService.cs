using Newtonsoft.Json;


namespace PilotProject.Services
{
    internal static class NewtonFileService
    {
        public static void SerilizationToFile<T>(string fileName, T obj)
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(obj, Formatting.Indented));
        }

        public static T? DeserializeFromFile<T>(string fileName)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(fileName));        
        }
    }
}