using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace FlaterceClocks.Model
{
    public class Alarm
    {
        private DispatcherTimer timer;

        public Alarm()
        {
        
        }

        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsRepeatable { get; set; }
        public TimeSpan ScheduleTime { get; set; }
        public IMessage Message { get; set; }
        public List<DayOfWeek> Days { get; set; }

        private void TimerHandler(object sender, EventArgs e)
        {
            var t = DateTime.Now;
            if (IsEnabled &&
                Days.Contains(t.DayOfWeek) &&
                t.Hour == ScheduleTime.Hours &&
                t.Minute == ScheduleTime.Minutes &&
                t.Second == ScheduleTime.Seconds)
            {
                Message.Call();
            }
        }

        public void Create()
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(TimerHandler);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        public void Destroy()
        {
            if (timer != null)
            {
                timer.Stop();
            }
        }
    }
}
