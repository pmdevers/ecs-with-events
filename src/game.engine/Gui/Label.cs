using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine.Gui
{
    public class Label : UIElement
    {
        public string Caption { get; }
        public string Font { get; }
        public int FontSize { get; }

        public Label(UIElement parent, string caption, string font, int fontSize) : base(parent)
        {
            Caption = caption;
            Font = font;
            FontSize = fontSize;
        }

        public override void Draw(UIContext ctx)
        {
            base.Draw(ctx);

            // Set things up so that we can render text in
            // window coordinates
            beginText();

            // Render the text
            drawString(0.0, 0.0, "James Madison University");

            // Set things up for normal rendering
            endText();
        }
    }
}
