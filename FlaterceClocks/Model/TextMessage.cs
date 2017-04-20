using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaterceClocks.Model
{
    public class TextMessage : IMessage
    {
        public string Parameter { get; set; } = String.Empty;

        public void Call()
        {
            System.Windows.MessageBox.Show(Parameter);
        }

        public override string ToString()
        {
            return Parameter;
        }
    }
}
