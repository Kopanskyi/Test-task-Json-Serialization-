using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Test_task
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter the path:");
            //string path = Console.ReadLine();
            Folder folder = new Folder(@"D:\New folder");
            //folder.ShowInformation();

            JsonSerializer jsonSerializer = new JsonSerializer();
            jsonSerializer.Converters.Add(new IsoDateTimeConverter());
            jsonSerializer.NullValueHandling = NullValueHandling.Ignore;
            jsonSerializer.Formatting = Formatting.Indented;

            using (StreamWriter sw = new StreamWriter(@"D:\folder.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                jsonSerializer.Serialize(writer, folder);
            }

            Console.WriteLine("Done");
        }
    }
}
