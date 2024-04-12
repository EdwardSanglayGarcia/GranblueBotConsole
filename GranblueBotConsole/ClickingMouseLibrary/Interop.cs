using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClickingMouseLibrary
{
    public static class Interop
    {
        [Flags]
        public enum MouseEventFlags : uint
        {
            Movement = 1u,
            LeftDown = 2u,
            LeftUp = 4u,
            RightDown = 8u,
            RightUp = 0x10u,
            MiddleDown = 0x20u,
            MiddleUp = 0x40u,
            XDown = 0x80u,
            XUp = 0x100u,
            Wheel = 0x800u,
            WheelTilt = 0x1000u,
            Absolute = 0x8000u
        }

        [DllImport("user32.dll")]
        public static extern void mouse_event(uint flags, int x, int y, int data, int extraInfo);

    }
}
