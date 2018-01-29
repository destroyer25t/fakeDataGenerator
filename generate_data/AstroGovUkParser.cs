using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace generate_data
{
    /// <summary>
    /// Get data of darkness time in London from txt file
    /// </summary>
    public static class AstroGovUkParser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstHalf">true if it first half of year, false if second</param>
        /// <returns></returns>
        public static List<DateTimeWD> GetDarknessTimeFromFile(bool firstHalf = true)
        {
            List<DateTimeWD> dates = new List<DateTimeWD>();
            using (StreamReader reader = new StreamReader(firstHalf ? $@"DataFiles\hours of darkness formatted_1.txt" : $@"DataFiles\hours of darkness formatted_2.txt"))
            {
                string dayString = "";
                dayString = reader.ReadLine();
                int day = 1;
                while (dayString != null)
                {
                    var mass = dayString.Split('*');
                    switch (mass[0])
                    {
                        case "29":
                            {
                                dates.AddRange(GetMonthDaysFromString(mass, 29, firstHalf));
                                break;
                            }
                        case "30":
                            {
                                dates.AddRange(GetMonthDaysFromString(mass, 30, firstHalf));
                                break;
                            }
                        case "31":
                            {
                                dates.AddRange(GetMonthDaysFromString(mass, 31, firstHalf));
                                break;
                            }
                        default:
                            {
                                dates.AddRange(GetMonthDaysFromString(mass, day++, firstHalf));
                                break;
                            }
                    }
                    dayString = reader.ReadLine();
                }
            }

            dates.Sort((a, b) => a.DateTime.CompareTo(b.DateTime));
            return dates;
        }

        /// <summary>
        /// Parse array from string and return range of darkness time of day of 6 months
        /// </summary>
        /// <param name="mass">array of days from string</param>
        /// <param name="day">what a day from string we parse</param>
        /// <param name="firstHalf">if true - first 6 months, if false - second 6 months</param>
        /// <returns></returns>
        public static List<DateTimeWD> GetMonthDaysFromString(string[] mass, int day, bool firstHalf)
        {

            List<DateTimeWD> temp = new List<DateTimeWD>();

            for (int i = 1; i < mass.Length; i++)
            {

                try
                {
                    var darknessTimes = mass[i].Split(';');
                    var endTime = new TimeShort(darknessTimes[0].Split(':')[0], darknessTimes[0].Split(':')[1]);
                    var beginTime = new TimeShort(darknessTimes[1].Split(':')[0], darknessTimes[1].Split(':')[1]);

                    var newDay = new DateTimeWD
                    {
                        DateTime = new System.DateTime(2017, firstHalf ? i : i + 6, day),
                        BeginOfDarkness = beginTime,
                        EndOfDarkness = endTime
                    };

                    temp.Add(newDay);
                }
                catch { }
            }
            return temp;
        }
    }
}
