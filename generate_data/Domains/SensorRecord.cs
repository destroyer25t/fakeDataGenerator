using System;
using System.Collections.Generic;
using System.Text;

namespace generate_data
{
    public class SensorRecord
    {
        public DateTime recordDateTime { get; set; }
        public Sensor sensor { get; set; }
        public string SensorData { get; set; }
        public Type DataType { get; set; }
    }
}
