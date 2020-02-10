using System;
using System.Collections.Generic;
using System.Text;

using Game.Engine.Graphics;

namespace Game.Engine.Gui
{
    public class Form : UIElement
    {
        public UIContext Context { get; }
        public string Title { get; set; }

        public List<UIElement> Elements { get; }

        public Form(UIContext context, string title) : base(null)
        {
            Elements = new List<UIElement>();
            Context = context;
        }
    }
}
