using System;
using System.Collections.Generic;
using System.Text;

namespace generate_data
{
    public class TimeShort
    {
        public TimeShort(string hour, string minute) {
            Hour = int.Parse(hour);
            Minute = int.Parse(minute);
        }

        public int Hour { get; set; }
        public int Minute { get; set; }
    }
}
