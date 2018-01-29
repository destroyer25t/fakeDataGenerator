using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace generate_data
{
    public class FakeDataGenerator
    {
        List<Sensor> sensors;
        List<DateTimeWD> allDarknessData = new List<DateTimeWD>(365);
        public FakeDataGenerator()
        {
            sensors = new List<Sensor>
            {
                new Sensor
                {
                    Id = 0,
                    Name = "sonoffSensor"
                },
                new Sensor{
                    Id=1,
                    Name = "lightningSensor"
                }
            };
            GetDarknessDataFromFile();

            foreach (var day in allDarknessData)
            {
                GenerateDayData(day);
            }
        }

        public void GenerateDayData(DateTimeWD day)
        {
            List<SensorRecord> records = new List<SensorRecord>(24 * 60 / 5);
            for (int i = 0; i < 24 * 60; i += 5)
            {

            }
        }

        public void GetDarknessDataFromFile()
        {
            using (StreamReader sr = new StreamReader(@"DataFiles\hours_json.json"))
            {
                var allFile = sr.ReadToEnd();
                allDarknessData = JsonConvert.DeserializeObject<List<DateTimeWD>>((allFile));
            }
        }
    }
}
