using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationOasis.Infrastructure.Utility
{
    public class JasonHelper<T>
    {
        private static readonly JsonSerializerSettings Options = new JsonSerializerSettings()
        { NullValueHandling = NullValueHandling.Ignore };
        public static void WriteJsonToFile(List<T> obj, string fileName)
        {
            try
            {
                using var streamWriter = File.CreateText(fileName);
                using var jsonWriter = new JsonTextWriter(streamWriter);
                JsonSerializer.CreateDefault(Options).Serialize(jsonWriter, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<T> ReadJsonFromFile(string fileName)
        {
            try
            {
                if (!File.Exists(fileName)) { File.CreateText(fileName); }
                using var streamReader = File.OpenText(fileName);
                using var jsonreader = new JsonTextReader(streamReader);
                var result = JsonSerializer.CreateDefault(Options).Deserialize<List<T>>(jsonreader);
                return result ?? new List<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
