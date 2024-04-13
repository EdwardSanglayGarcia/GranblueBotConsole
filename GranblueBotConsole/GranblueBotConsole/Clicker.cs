using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;

namespace GranblueBotConsole
{
    public static class Clicker
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(uint flags, int x, int y, int data, int extraInfo);
        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;
        public const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        public const int MOUSEEVENTF_RIGHTUP = 0x10; //test

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

        private static int ScreenWidth;

        private static int ScreenHeight;
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
