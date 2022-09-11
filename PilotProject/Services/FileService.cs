using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace PilotProject.Services
{
    internal static class FileService
    {
        public static async Task ObjectToJsonAsync<T>(string fileName, T obj)
        {
            using (FileStream fs = new(fileName, FileMode.Append))
            {
                JsonSerializerOptions options = new()
                {                   
                    WriteIndented = true,
                    AllowTrailingCommas = true,
                };
                options.Converters.Add(new JsonStringEnumConverter());

                await JsonSerializer.SerializeAsync<T>(fs, obj, options);
            }
        }

        public static async Task<T> JsonToObjectAsync<T>(string fileName)
        {
            using (FileStream fs = new(fileName, FileMode.OpenOrCreate))
            {
                return await JsonSerializer.DeserializeAsync<T>(fs);
            }
        }

        public static async Task StringToTxtFileAsync(string fileName, string text)
        {
            using (FileStream fstream = new FileStream(fileName, FileMode.Create))
            {
                byte[] buffer = Encoding.Default.GetBytes(text);
                await fstream.WriteAsync(buffer, 0, buffer.Length);
            }
        }
    }
}