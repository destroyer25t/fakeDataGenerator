using System;
using System.Collections.Generic;
using System.Text;

namespace generate_data
{
    public class HumanNeedLightGenerator
    {
        private static readonly TimeSpan wakeUpTime = new TimeSpan(8, 0, 0);
        private static readonly TimeSpan getOutTime = new TimeSpan(8, 30, 0);
        private static readonly TimeSpan comeBackTime = new TimeSpan(18, 45, 0);
        private static readonly TimeSpan startSleepTime = new TimeSpan(23, 55, 0);

        private TimeSpan minutesChange;
        private static Random _rand = new Random();
        public HumanNeedLightGenerator() {
            minutesChange = new TimeSpan(0, _rand.Next(-10, 30), 0);
        }
        
        public bool HumanNeedLight(TimeSpan time)
        {            
            if ((time > (wakeUpTime + minutesChange) && time < (getOutTime + minutesChange)) || (time > (comeBackTime + minutesChange) && time < (startSleepTime + minutesChange)))
            {
                return true;
            }

            return false;
        }        
    }
}
