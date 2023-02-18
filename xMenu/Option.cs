using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xMenu
{
    public class Option : TextLine
    {
        public Func<int> OnSelect { get; set; } = null;

        public Option(string text) : base(text)
        {
            Text = text;
        }

        public Option(string text, string aligment, string color, Func<int> onSelect) : base(text, aligment, color)
        {
            Text = Text;
            Aligment = Aligment;
            Color = Color;
            OnSelect = onSelect;
        }

        public string Build()
        {
            return $"{AlignText()}{Color}{Text}";
        }

        public void Select()
        {
            if (OnSelect != null)
            {
                OnSelect();
            }
        }
    }
}
