using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MCGBFClassLibrary
{
    public static class MouseCommand
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(uint flags, int x, int y, int data, int extraInfo);

        private static int ScreenWidth;

        private static int ScreenHeight;

        [Flags]
        public enum Action : uint
        {
            MoveOnly = 32769u,
            LeftButtonDown = 32771u,
            LeftButtonUp = 32773u,
            MiddleButtonDown = 32801u,
            MiddleButtonUp = 32833u,
            RightButtonDown = 32777u,
            RightButtonUp = 32785u
        }

        [DllImport("gdi32.dll")]
        public static extern int GetDeviceCaps(IntPtr windowHandle, int caps);

        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr windowHandle);

        [DllImport("User32.dll")]
        public static extern int ReleaseDC(IntPtr windowHandle, IntPtr deviceContextHandle);

        static MouseCommand()
        {
            RecalculateScreen();
        }

        private static void RecalculateScreen()
        {
            ScreenWidth = UserScreenSize.Width();
            ScreenHeight = UserScreenSize.Height();
        }

        public static void Testing(Action mouseOption, int x, int y, int time)
        {
            double num = 65535.0 * (double)(x + 1) / (double)ScreenWidth;
            double num2 = 65535.0 * (double)(y + 1) / (double)ScreenHeight;
            uint action1, action2;
            if (mouseOption == Action.LeftButtonDown)
            {
                action1 = (uint)Action.LeftButtonDown;
                action2 = (uint)Action.LeftButtonUp;
                mouse_event(action1, (int)num, (int)num2, 0, 0);
                Thread.Sleep(200);
                mouse_event(action2, (int)num, (int)num2, 0, 0);
            }
            Thread.Sleep(time);
        }

        public static void DoTest()
        {

        }
    }
}
