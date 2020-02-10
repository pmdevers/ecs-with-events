using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Game.Engine.Gui
{
    public abstract class UIElement
    {
        private readonly  List<UIElement> _children = new List<UIElement>();

        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public bool Visible { get; set; }
        public bool Enabled { get; set; }
        public bool HasFocus { get; set; }
        public bool HasMouseFocus { get; set; }
        public string Tooltip { get; set; }
        public float FontSize { get; set; }

        public Form Form
        {
            get
            {
                var element = this;
                while (true)
                {
                    if(element == null)
                        throw new Exception("Could not find parent form.");

                    if (element is Form f)
                    {
                        return f;
                    }

                    element = element.Parent;
                }
            }
        }

        public UIElement Parent { get; }
        public UIElement[] Childeren => _children.ToArray();

        public UIElement(UIElement parent)
        {
            Parent = parent;
            parent?.AddChild(this);
        }

        public void AddChild(UIElement element)
        {
            _children.Add(element);
        }

        public void Remove(UIElement element)
        {
            _children.Remove(element);
        }

        public void Remove(int index)
        {
            _children.RemoveAt(index);
        }

        public int IndexOf(UIElement element)
        {
            return _children.IndexOf(element);
        }

        public UIElement FindUIElement(Vector2 p)
        {
            foreach (UIElement element in Childeren)
            {
                if (element.Visible && element.Contains(p))
                {
                    return element.FindUIElement(p - Position);
                }
            }

            return Contains(p) ? this : null;
        }

        public bool Contains(Vector2 b)
        {
            var a = Position;
            var c = Size;
            return (a.y * b.x - a.x * b.y) * (a.y * c.x - a.x * c.y) < 0;
        }

        public virtual void Draw(UIContext ctx)
        {
            if (!_children.Any())
                return;

            foreach (var child in _children)
            {
                child.Draw(ctx);
            }
        }
    }
}
