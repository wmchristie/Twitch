using System;
using System.Collections.Generic;
using System.Text;

namespace Twitch.Core
{

    public class TwitchWindow
    {
        private readonly IntPtr _handle;

        public TwitchWindow(IntPtr handle)
        {
            _handle = handle;
        }

        public WindowList ChildWindows
        {
            get { return new WindowList(GetChildWindowHandles()); }
        }

        public virtual string Title
        {
            get { return GetText(_handle); }
        }

        private static string GetText(IntPtr hWnd)
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

            WindowsApi.EnumChildWindows(_handle, (hwnd, lParam) => {

                handles.Add(hwnd);

                return true;

            }, empty);

            return handles;
        }
    }
}