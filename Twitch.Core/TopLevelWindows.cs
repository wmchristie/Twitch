using System;
using System.Collections.Generic;

namespace Twitch.Core
{
    public class TopLevelWindows : WindowList
    {
        protected override IEnumerable<IntPtr> WindowHandles
        {
            get
            {
                var foregroundWindow = WindowsApi.GetDesktopWindow();

                var prev = default(IntPtr);

                for (var h = foregroundWindow; h != IntPtr.Zero && h != prev; h = WindowsApi.GetWindow(h, GetWindow_Cmd.GW_HWNDLAST))
                {
                    prev = h;
                    yield return h;
                }
            }
        }

    }
}