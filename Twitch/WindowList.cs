using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TaskSwitcher
{
    public class WindowList : IEnumerable<TwitchWindow>
    {
        protected virtual IEnumerable<IntPtr> WindowHandles { get; private set; }

        public WindowList(IEnumerable<IntPtr> windowHandles)
        {
            WindowHandles = windowHandles;
        }

        protected WindowList() : this(new List<IntPtr>()) {}

        public virtual IEnumerator<TwitchWindow> GetEnumerator()
        {
            return WindowHandles.Select(handle => new TwitchWindow(handle)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}