using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGBFClassLibrary
{
    public static class UserScreenSize
    {
        public static int Width()
        {
            IntPtr dC = MouseCommand.GetDC(IntPtr.Zero);
            int deviceCaps = MouseCommand.GetDeviceCaps(dC, 8);
            MouseCommand.ReleaseDC(IntPtr.Zero, dC);
            return deviceCaps;
        }

        public static int Height()
        {
            IntPtr dC = MouseCommand.GetDC(IntPtr.Zero);
            int deviceCaps = MouseCommand.GetDeviceCaps(dC, 10);
            MouseCommand.ReleaseDC(IntPtr.Zero, dC);
            return deviceCaps;
        }
    }
}
