using System.Collections.Generic;
using System.Linq;

namespace Twitch.Core
{
    public class DesktopWindow : TwitchWindow
    {
        public DesktopWindow() : base(WindowsApi.GetDesktopWindow()) {}

        public override IEnumerable<TwitchWindow> Children
        {
            get
            {
                return base.Children.Where(c => c.Title.Trim().Length > 0);
            }
        }

//        public IEnumerable<TwitchWindow> Children
//        {
//            get
//            {
//                var prev = default(IntPtr);
//                var h = Handle;
//
//                while (h != IntPtr.Zero && h != prev)
//                {
//                    prev = h;
//                    h = WindowsApi.GetWindow(h, GetWindow_Cmd.GW_HWNDNEXT);
//                    yield return new TwitchWindow(h);
//                }
//                
//            }
//        }

    }
}