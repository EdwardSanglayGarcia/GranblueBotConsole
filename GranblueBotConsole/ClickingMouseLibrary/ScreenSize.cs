using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickingMouseLibrary
{
    public class ScreenSize
    {
        public static int Width()
        {
            IntPtr dC = InteropScreen.GetDC(IntPtr.Zero);
            int deviceCaps = InteropScreen.GetDeviceCaps(dC, 8);
            InteropScreen.ReleaseDC(IntPtr.Zero, dC);
            return deviceCaps;
        }

        public static int Height()
        {
            IntPtr dC = InteropScreen.GetDC(IntPtr.Zero);
            int deviceCaps = InteropScreen.GetDeviceCaps(dC, 10);
            InteropScreen.ReleaseDC(IntPtr.Zero, dC);
            return deviceCaps;
        }
    }
}
