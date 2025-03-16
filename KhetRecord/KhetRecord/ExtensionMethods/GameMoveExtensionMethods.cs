using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KhetRecord.ExtensionMethods
{
    public interface IGameMove;

    public static class GameMoveExtensionMethods
    {
        public static string ToJson<T>(this T record) where T : IGameMove
        {
            return JsonSerializer.Serialize(record);
        }

        public static T? FromJson<T>(this string json) where T : IGameMove
        {
            return JsonSerializer.Deserialize<T>(json);
        }

        public static void Log<T>(this T record) where T : IGameMove
        {
            var baseFilePath = "..\\..\\..\\MoveLogs\\";
            // Create or overwrite the file and write the content to it
            using (StreamWriter writer = new StreamWriter(baseFilePath + "json.log", true))
            {
                writer.WriteLine(record.ToJson());  // Writes content to the file
            }

            using (StreamWriter writer = new StreamWriter(baseFilePath + "record.log", true))
            {
                writer.WriteLine(record);  // Writes content to the file
            }
        }
    }


}
