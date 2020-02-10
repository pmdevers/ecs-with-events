using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine.Gui.Fonts.Internal
{
    internal struct Rectangle
    {
        public int X, Y, Width, Height;

        public int Right => X + Width;
        public int Bottom => X + Height;

        public Rectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public bool Contains(Rectangle rect)
        {
            return rect.X >= X && rect.Y >= Y &&
                   rect.Right <= Right && rect.Bottom <= Bottom;
        }

        public override string ToString() => $"{X}, {Y}, {Width}, {Height}";
    }

    internal struct ResizableArray<T>
    {
        public T[] Data;
        public int Count;

        public T this[int index] => Data[index];

        public ResizableArray(int capacity)
        {
            Data = new T[capacity];
            Count = 0;
        }

        public void Clear() => Count = 0;

        public void Add(T value)
        {
            if (Count == Data.Length)
            {
                Array.Resize(ref Data, (int)(Data.Length * 1.5));
            }
            Data[Count++] = value;
        }

        public void RemoveAt(int index)
        {
            Count--;
            if (index < Count)
            {
                Array.Copy(Data, index + 1, Data, index, Count - index);
            }
        }
    }

    internal struct BinPacker
    {
        private ResizableArray<Rectangle> freeList;

        public BinPacker(int width, int height)
        {
            freeList = new ResizableArray<Rectangle>(16);
            freeList.Add(new Rectangle(0, 0, width, height));
        }

        public void Clear(int width, int height)
        {
            freeList.Clear();
            freeList.Add(new Rectangle(0, 0, width, height));
        }

        public Rectangle Insert(int width, int height)
        {
            var bestNode = new Rectangle();
            var bestShortFit = int.MaxValue;
            var bestLongFit = int.MaxValue;

            var count = freeList.Count;
            for (int i = 0; i < count; i++)
            {
                var rect = freeList[i];
                if (rect.Width < width || rect.Height < height)
                    continue;

                var leftoverX = Math.Abs(rect.Width - width);
                var leftoverY = Math.Abs(rect.Height - height);
                var shortFit = Math.Min(leftoverX, leftoverY);
                var longFit = Math.Max(leftoverX, leftoverY);

                if (shortFit < bestShortFit || (shortFit == bestShortFit && longFit < bestLongFit))
                {
                    bestNode = new Rectangle(rect.X, rect.Y, width, height);
                    bestShortFit = shortFit;
                    bestLongFit = longFit;
                }
            }

            if (bestNode.Height == 0)
            {
                return bestNode;
            }

            for (int i = 0; i < count; i++)
            {
                if (SplitFreeNode(freeList[i], bestNode))
                {
                    freeList.RemoveAt(i);
                    i--;
                    count--;
                }
            }

            for (int i = 0; i < freeList.Count; i++)
            {
                for (int j = i + 1; j < freeList.Count; j++)
                {
                    var idata = freeList[i];
                    var jdata = freeList[j];
                    if (jdata.Contains(idata))
                    {
                        freeList.RemoveAt(i);
                        i--;
                        break;
                    }

                    if (idata.Contains(jdata))
                    {
                        freeList.RemoveAt(j);
                        j--;
                    }
                }
            }

            return bestNode;
        }

        private bool SplitFreeNode(Rectangle freeNode, Rectangle usedNode)
        {
            var insideX = usedNode.X < freeNode.Right && usedNode.Right > freeNode.X;
            var insideY = usedNode.Y < freeNode.Bottom && usedNode.Bottom > freeNode.Y;
            if (!insideX || !insideY)
            {
                return false;
            }

            if (insideX)
            {
                if (usedNode.Y > freeNode.Y && usedNode.Y < freeNode.Bottom)
                {
                    var newNode = freeNode;
                    newNode.Height = usedNode.Y - newNode.Y;
                    freeList.Add(newNode);
                }

                if (usedNode.Bottom < freeNode.Bottom)
                {
                    var newNode = freeNode;
                    newNode.Y = usedNode.Bottom;
                    newNode.Height = freeNode.Bottom - usedNode.Bottom;
                    freeList.Add(newNode);
                }
            }

            if (insideY)
            {
                if (usedNode.X > freeNode.X && usedNode.X < freeNode.Right)
                {
                    var newNode = freeNode;
                    newNode.Width = usedNode.X - newNode.X;
                    freeList.Add(newNode);
                }

                if (usedNode.Right < freeNode.Right)
                {
                    var newNode = freeNode;
                    newNode.X = usedNode.Right;
                    newNode.Width = freeNode.Right - usedNode.Right;
                    freeList.Add(newNode);
                }
            }
            return true;
        }
    }
}