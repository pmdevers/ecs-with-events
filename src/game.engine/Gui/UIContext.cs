using System;
using System.Collections.Generic;
using System.Text;

using Game.Engine.Graphics;
using Game.Engine.Platform.UI;

namespace Game.Engine.Gui
{
    public abstract class UIContext : UIElement
    {
        public Window Window { get; }
        
        public static UIContext Create(Window window)
        {
            return new OpenGLUIContext(window);
        }

        protected UIContext() : base(null)
        {

        }

        public void Draw()
        {
            base.Draw(this);
        }
    }
}
