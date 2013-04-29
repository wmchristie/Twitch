using System;
using System.Collections.Generic;
using System.Text;

namespace Twitch.Core
{

    public class TwitchWindow
    {

        public TwitchWindow(IntPtr handle)
        {
            Handle = handle;
        }

        public IntPtr Handle { get; private set; }

        public virtual IEnumerable<TwitchWindow> Children
        {
            get { return new WindowList(GetChildWindowHandles()); }
        }

        public virtual string Title
        {
            get { return GetText(Handle); }
        }

        protected static string GetText(IntPtr hWnd)
        {
            // Allocate correct string length first
            var length = WindowsApi.GetWindowTextLength(hWnd);
            var sb = new StringBuilder(length + 1);
            WindowsApi.GetWindowText(hWnd, sb, sb.Capacity);
            return sb.ToString();
        }


        private IEnumerable<IntPtr> GetChildWindowHandles()
        {
            var empty = default(IntPtr);
            var handles = new List<IntPtr>();

            WindowsApi.EnumChildWindows(Handle, (hwnd, lParam) => {

                handles.Add(hwnd);

                return true;

            }, empty);

            return handles;
        }
    }
}