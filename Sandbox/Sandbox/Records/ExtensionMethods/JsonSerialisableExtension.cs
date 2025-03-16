using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Records.ExtensionMethods
{
    public interface IJsonSerialisable;

    public static class JsonSerialisableExtensions
    {
        public static string ToJson<T>(this T record) where T : IJsonSerialisable
        {
            return JsonSerializer.Serialize(record);
        }

        public static T? FromJson<T>(this string json) where T : IJsonSerialisable
        {
            return JsonSerializer.Deserialize<T>(json);
        }

        public static void Log<T>(this T record) where T : IJsonSerialisable
        {
            var baseFilePath = "..\\..\\..\\Logs\\";
            // Create or overwrite the file and write the content to it
            using (StreamWriter writer = new StreamWriter(baseFilePath + "JsonLog.txt", true))
            {
                writer.WriteLine(record.ToJson());  // Writes content to the file
            }

            using (StreamWriter writer = new StreamWriter(baseFilePath + "MoveLog.txt", true))
            {
                writer.WriteLine(record);  // Writes content to the file
            }
        }
    }
}
