using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaterceClocks.Model
{
    class ShutdownMessage : IMessage
    {
        public string Parameter { get; set; }

        public void Call()
        {
        
        }
    }
}
