using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaterceClocks.Model
{
    class SoundMessage : IMessage
    {
        public string Parameter { get; set; }

        public void Call()
        {
            System.Windows.MessageBox.Show(Parameter);
        }

        public override string ToString()
        {
            return Path.GetFileName(Parameter);
        }
    }
}
