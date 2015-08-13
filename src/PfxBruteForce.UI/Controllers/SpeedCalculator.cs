using System;

namespace PfxBruteForce.UI.Controllers
{
    public class SpeedCalculator
    {
        private DateTime startDate;
        private int count;
        private DateTime countStartDate;
        private TimeSpan granularity;

        public void Init()
        {
            count = 0;
            startDate =
            countStartDate = DateTime.UtcNow;
            granularity = TimeSpan.FromSeconds(0.5);
        }

        public void Push(int count)
        {
            this.count += count;
        }

        public int Speed
        {
            get
            {
                var now = DateTime.UtcNow;
                var elapsed = now - countStartDate;
                var result = (int)(count / elapsed.TotalSeconds);
                if (elapsed > granularity)
                {
                    countStartDate = now;
                    count = 0;
                }
                return result;
            }
        }

        public TimeSpan Elapsed
        {
            get
            {
                return DateTime.UtcNow - startDate;
            }
        }
    }
}