using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace generate_data
{
    public class FakeDataGenerator
    {
        Sensor lampSwitchSensor = new Sensor
        {
            Id = 0,
            Name = "sonoffSensor"
        };

        Sensor sensor2 = new Sensor
        {
            Id = 1,
            Name = "lightningSensor"
        };
        
        List<DateTimeWD> allDarknessData = new List<DateTimeWD>(365);
        public FakeDataGenerator()
        {
            GetDarknessDataFromFile();

            foreach (var day in allDarknessData)
            {
                var dataDay = GenerateDayData(day);
            }
        }

        public List<SensorRecord> GenerateDayData(DateTimeWD day)
        {
            List<SensorRecord> records = new List<SensorRecord>();

            for (int i = 0; i < 24 * 60; i += 5)
            {
                var currentTime = new TimeSpan(0, i, 0);
                var ourTime = new TimeSpan(8, 5, 0);
                bool isLight = currentTime < new TimeSpan(day.Sunset.Hour, day.Sunset.Minute, 0) && currentTime > new TimeSpan(day.Sunrise.Hour, day.Sunrise.Minute, 0);

                if (!isLight) Console.WriteLine(currentTime + " is Dark now");

                HumanNeedLightGenerator gen = new HumanNeedLightGenerator();
                if (gen.HumanNeedLight(currentTime) && !isLight)
                {
                    records.Add(new SensorRecord
                    {
                        sensor = lampSwitchSensor,
                        recordDateTime = new DateTime(day.DateTime.Year, day.DateTime.Month, day.DateTime.Day, currentTime.Hours, currentTime.Minutes, currentTime.Seconds),
                        SensorData = "1"
                    });
                }
                else
                {
                    records.Add(new SensorRecord
                    {
                        sensor = lampSwitchSensor,
                        recordDateTime = new DateTime(day.DateTime.Year, day.DateTime.Month, day.DateTime.Day, currentTime.Hours, currentTime.Minutes, currentTime.Seconds),
                        SensorData = "0"
                    });
                }
            }
            return records;
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
