using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flipper
{
    public class ComboItem
    {
        public string Text { get; set; }
        public string Data { get; set; }

        public ComboItem(string text, string data)
        {
            Text = text;
            Data = data;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
