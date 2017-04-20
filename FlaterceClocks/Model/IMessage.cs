using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaterceClocks.Model
{
    public interface IMessage
    {
        string Parameter { get; set; }

        void Call();
    }
}
