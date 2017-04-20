using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaterceClocks.Model
{
    public static class AlarmRepository
    {
        public static ObservableCollection<Alarm> Content { get; set; } = new ObservableCollection<Alarm>();
    }
}
