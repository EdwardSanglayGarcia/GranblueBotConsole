using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;

namespace GranblueBotConsole
{
    public static partial class Clicker
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

        static Clicker()
        {
            RecalculateScreen();
            SystemEvents.DisplaySettingsChanged += delegate
            {
                RecalculateScreen();
            };
        }

        private static void RecalculateScreen()
        {
            ScreenWidth = UserScreenSize.Width();
            ScreenHeight = UserScreenSize.Height();
        }

        public static void Testing(Action mouseOption, int x, int y)
        {
            double num = 65535.0 * (double)(x + 1) / (double)ScreenWidth;
            double num2 = 65535.0 * (double)(y + 1) / (double)ScreenHeight;
            mouse_event((uint)mouseOption, (int)num, (int)num2, 0, 0);
        }

        public static void DoTest()
        {

        }
    }
    public static class UserScreenSize
    {
        public static int Width()
        {
            IntPtr dC = Clicker.GetDC(IntPtr.Zero);
            int deviceCaps = Clicker.GetDeviceCaps(dC, 8);
            Clicker.ReleaseDC(IntPtr.Zero, dC);
            return deviceCaps;
        }

        public static int Height()
        {
            IntPtr dC = Clicker.GetDC(IntPtr.Zero);
            int deviceCaps = Clicker.GetDeviceCaps(dC, 10);
            Clicker.ReleaseDC(IntPtr.Zero, dC);
            return deviceCaps;
        }
    }
}
