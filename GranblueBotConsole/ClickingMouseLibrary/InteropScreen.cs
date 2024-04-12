using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClickingMouseLibrary
{
    public class InteropScreen
    {
        internal enum DeviceCaps
        {
            HORZSIZE = 8,
            VERTSIZE = 10
        }

        [DllImport("gdi32.dll")]
        public static extern int GetDeviceCaps(IntPtr windowHandle, int caps);

        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr windowHandle);

        [DllImport("User32.dll")]
        public static extern int ReleaseDC(IntPtr windowHandle, IntPtr deviceContextHandle);
    }
}
