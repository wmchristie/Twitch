using System.Runtime.InteropServices;

namespace Twitch.Core
{
// ReSharper disable InconsistentNaming
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;

        public RECT(RECT Rectangle) : this(Rectangle.Left, Rectangle.Top, Rectangle.Right, Rectangle.Bottom) {}
        public RECT(int Left, int Top, int Right, int Bottom)
        {
            left = Left;
            top = Top;
            right = Right;
            bottom = Bottom;
        }
        
        public int X
        {
            get { return left; } 
            set
            {
                right -= (left - value);
                left = value;
            }
        }

        public int Y
        {
            get { return top; }
            set
            {
                bottom -= (top - value);
                top = value;
            }
        }

        public int Height
        {
        get
        {
            return bottom - top;
        }
        set
        {
            bottom = value + top;
        }
        }
        public int Width
        {
        get
        {
            return right - left;
        }
        set
        {
            right = value + left;
        }
        }
        //
        public int Left
        {
        get
        {
            return left;
        }
        set
        {
            left = value;
        }
        }
        public int Top
        {
        get
        {
            return top;
        }
        set
        {
            top = value;
        }
        }
        public int Right
        {
        get
        {
            return right;
        }
        set
        {
            right = value;
        }
        }
        public int Bottom
        {
        get
        {
            return bottom;
        }
        set
        {
            bottom = value;
        }
        }
        //
        public Point Location
        {
        get
        {
            return new Point(Left, Top);
        }
        set
        {
            right -= (left - value.X);
            bottom -= (top - value.Y);
            left = value.X;
            top = value.Y;
        }
        }
        public Size Size
        {
        get
        {
            return new Size(Width, Height);
        }
        set
        {
            right = value.Width + left;
            bottom = value.Height + top;
        }
        }
        //
        public static implicit operator Rectangle(RECT Rectangle)
        {
        return new Rectangle(Rectangle.Left, Rectangle.Top, Rectangle.Width, Rectangle.Height);
        }
        public static implicit operator RECT(Rectangle Rectangle)
        {
        return new RECT(Rectangle.Left, Rectangle.Top, Rectangle.Right, Rectangle.Bottom);
        }
        //
        public static bool operator ==(RECT Rectangle1, RECT Rectangle2)
        {
        return Rectangle1.Equals(Rectangle2);
        }
        public static bool operator !=(RECT Rectangle1, RECT Rectangle2)
        {
        return !Rectangle1.Equals(Rectangle2);
        }
        //
        public bool Equals(RECT Rectangle)
        {
        return Rectangle.Left == left && Rectangle.Top == top && Rectangle.Right == right && Rectangle.Bottom == bottom;
        }
        public override bool Equals(object Object)
        {
        if (Object is RECT)
        {
            return Equals((RECT)Object);
        }
        else if (Object is Rectangle)
        {
            return Equals(new RECT((Rectangle)Object));
        }

        return false;
        }
        //
        public override int GetHashCode()
        {
        return ToString().GetHashCode();
        }
        public override string ToString()
        {
        return "{Left: " + left + "; " + "Top: " + top + "; Right: " + right + "; Bottom: " + bottom + "}";
        }
    }
// ReSharper restore InconsistentNaming
}