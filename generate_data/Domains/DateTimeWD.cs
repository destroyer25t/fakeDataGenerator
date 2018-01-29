using System;
using System.Collections.Generic;
using System.Text;

namespace generate_data
{
    public class DateTimeWD
    {
        public DateTime DateTime { get; set; }
        public TimeShort EndOfDarkness { get; set; }
        public TimeShort BeginOfDarkness { get; set; }
        public TimeShort Sunrise => new TimeShort((EndOfDarkness.Hour + 2).ToString(), (EndOfDarkness.Minute).ToString());
        public TimeShort Sunset => new TimeShort((BeginOfDarkness.Hour + 2).ToString(), (BeginOfDarkness.Minute).ToString());
    }
}
