using System;

namespace Lab2
{
    internal class Time
    {
        private int seconds;

        public Time(int seconds)
        {
            this.seconds = seconds;
        }

        public int Seconds
        {
            get
            {
                return this.seconds;
            }
        }

        public override string ToString()
        {
            int totalSeconds = this.seconds % 86400;
            if (totalSeconds < 0)
            {
                totalSeconds += 86400;
            }
            int hours = totalSeconds / 3600;
            int minutes = (totalSeconds % 3600) / 60;
            int secs = totalSeconds % 60;
            string result = hours.ToString("00")
                + ":" + minutes.ToString("00")
                + ":" + secs.ToString("00");
            return result;
        }
    }
}
