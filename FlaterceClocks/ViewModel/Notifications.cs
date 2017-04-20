using FlaterceClocks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaterceClocks.ViewModel
{
    public class OpenEditWindowMessage
    {
        public OpenEditWindowMessage(Alarm alarm)
        {
            Alarm = alarm;
        }

        public Alarm Alarm { get; set; }
    }

    public class AlarmEditingMessage
    {
        public AlarmEditingMessage(Alarm alarm)
        {
            Alarm = alarm;
        }

        public Alarm Alarm { get; set; }
    }

    public class CloseEditWindowMessage
    {

    }
}
