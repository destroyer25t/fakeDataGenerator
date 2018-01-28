using Newtonsoft.Json;
using System;
using System.IO;

namespace generate_data
{
    class Program
    {
        static void Main(string[] args)
        {
            var dates = AstroGovUkParser.GetDarknessTimeFromFile(true);
            dates.AddRange(AstroGovUkParser.GetDarknessTimeFromFile(false));

            var datesJson = JsonConvert.SerializeObject(dates);

            using (StreamWriter file = File.CreateText(@"hours_json.txt"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, dates);
            }

        }

    }
}
