using System;
using System.Collections.Generic;
using System.Text;

namespace generate_data
{
    public static class LampSwitchGenerator
    {
        private static readonly TimeSpan wakeUpTime = new TimeSpan(8, 0, 0);
        private static readonly TimeSpan getOutTime = new TimeSpan(8, 30, 0);
        private static readonly TimeSpan comeBackTime = new TimeSpan(18, 45, 0);
        private static readonly TimeSpan startSleepTime = new TimeSpan(23, 55, 0);

        private static Random _rand = new Random();

        public static TimeSpan GenRandMinutes()
        {
            return new TimeSpan(0,_rand.Next(-10 * 60, 30 * 60), 0);
        }

        public static bool IsHumanInHome(DateTime time)
        {
            var timespanNow = time.TimeOfDay;

            if ((timespanNow > (wakeUpTime + GenRandMinutes()) && timespanNow < (getOutTime + GenRandMinutes())) || (timespanNow > (comeBackTime + GenRandMinutes()) && timespanNow < (startSleepTime + GenRandMinutes())))
            {
                return true;
            }

            return false;
        }

        public static bool IsHumanSwitchOn(DateTime time) {
            if (IsHumanInHome(time) && ) {

            }
        }
    }
}
