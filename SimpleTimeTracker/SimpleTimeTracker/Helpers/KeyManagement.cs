using System;
using System.Runtime.InteropServices;

namespace SimpleTimeTracker.Helpers
{
    public class KeyManagement
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    }
}