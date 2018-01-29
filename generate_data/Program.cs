using Newtonsoft.Json;
using System;
using System.IO;

namespace generate_data
{
    class Program
    {
        static void Main(string[] args)
        {
            Generate();
        }

        static void ParseDarknessTime() {
            var dates = AstroGovUkParser.GetDarknessTimeFromFile(true);
            dates.AddRange(AstroGovUkParser.GetDarknessTimeFromFile(false));

            var datesJson = JsonConvert.SerializeObject(dates);

            using (StreamWriter file = File.CreateText(@"DataFiles\hours_json.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, dates);
            }
        }

        static void Generate() {
            var generator = new FakeDataGenerator();
        }

    }
}
