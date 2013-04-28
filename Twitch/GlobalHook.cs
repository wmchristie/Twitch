//using System;
//using System.Diagnostics;
//using System.Runtime.InteropServices;
//using System.Windows.Forms;
//
//namespace TaskSwitcher
//{
//    public delegate IntPtr HookHandlerProc(int nCode, IntPtr wParam, IntPtr lParam);
//    public delegate IntPtr EnumWindowsCallback(IntPtr hWnd, IntPtr lParam);
//
//    public class GlobalHook : IDisposable
//    {
//        private const int WH_SHELL = 10;
//        private const int WH_KEYBOARD_LL = 13;
//        private const int WM_KEYDOWN = 0x0100;
//        private const int WM_ACTIVATE = 0x0006;
//        private const int WM_SYSKEYDOWN = 0X0104;
//
//        private HookHandlerProc _keyboardProc = KeyboardHookCallback;
//        private HookHandlerProc _windowProc = WindowHookCallback;
//        private static IntPtr _keyboardHookId = IntPtr.Zero;
//        private static IntPtr _windowHookId = IntPtr.Zero;
//
//        public GlobalHook (Action<Keys> notify)
//        {
//            Notify = notify;
//            _keyboardHookId = SetHook(_keyboardProc, WH_KEYBOARD_LL);
//            _windowHookId = SetHook(_windowProc, WH_SHELL);
//
//        }
//
//        public GlobalHook() : this(k => { }) {}
//
//        private static Action<Keys> Notify { get; set; }
//
//        public void Dispose ()
//        {
//            UnhookWindowsHookEx(_keyboardHookId);
//            UnhookWindowsHookEx(_windowHookId);
//        }
//
//        private IntPtr SetHook(HookHandlerProc proc, int hook)
//        {
//            using (var curProcess = Process.GetCurrentProcess())
//            using (var curModule = curProcess.MainModule)
//            {
//                return SetWindowsHookEx(hook, proc, GetModuleHandle(curModule.ModuleName), 0);
//            }
//        }
//
//
//        private delegate IntPtr WindowProc(int nCode, IntPtr wParam, IntPtr lParam);
//
//        private static IntPtr WindowHookCallback(int nCode, IntPtr wParam, IntPtr lParam) {
//
//            const int HSHELL_WINDOWACTIVATED = 4;
//            const int HSHELL_WINDOWCREATED = 1;
//            const int HSHELL_WINDOWDESTROYED = 2;
//
//            Console.WriteLine("Window Callback: {0}, {1}", wParam, lParam);
//
//            return CallNextHookEx(_windowHookId, nCode, wParam, lParam);
//        }
//
//        private static IntPtr KeyboardHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
//        {
//            Console.WriteLine("");
//            Console.WriteLine("{0}, {1}, {2}", nCode, wParam, Marshal.ReadInt32(lParam));
//            Console.WriteLine("");
//
//            if (wParam == (IntPtr)WM_ACTIVATE) {
//                Console.WriteLine("Activate!");
//            }
//
//            if (wParam == (IntPtr)WM_SYSKEYDOWN) {
//                Console.WriteLine("Sys Key Down!");
//            }
//
//            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
//            {
//                Notify((Keys)Marshal.ReadInt32(lParam));
//            }
//
//            return CallNextHookEx(_keyboardHookId, nCode, wParam, lParam);
//        }
//
//        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
//        private static extern IntPtr SetWindowsHookEx(int idHook, HookHandlerProc lpfn, IntPtr hMod, uint dwThreadId);
//
//        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
//        [return: MarshalAs(UnmanagedType.Bool)]
//        private static extern bool UnhookWindowsHookEx(IntPtr hhk);
//
//        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
//        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
//
//        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
//        private static extern IntPtr GetModuleHandle(string lpModuleName);
//
//        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
//        [return: MarshalAs(UnmanagedType.Bool)]
//        private static extern bool EnumWindows(EnumWindowsCallback callback, IntPtr extraData);
//
//    }
//}