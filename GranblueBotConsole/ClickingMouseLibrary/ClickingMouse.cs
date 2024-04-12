using System;
using System.Threading;
using System.Runtime.InteropServices;
using Microsoft.Win32;


namespace ClickingMouseLibrary
{
    public static class ClickingMouse
    {

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

        private const Interop.MouseEventFlags AbsoluteMovement = Interop.MouseEventFlags.Movement | Interop.MouseEventFlags.Absolute;

        private static int ScreenWidth;

        private static int ScreenHeight;
        private static void RecalculateScreen()
        {
            ScreenWidth = ScreenSize.Width();
            ScreenHeight = ScreenSize.Height();
        }

        public static void Act(Action mouseOption, int x, int y)
        {
            double num = 65535.0 * (double)(x + 1) / (double)ScreenWidth;
            double num2 = 65535.0 * (double)(y + 1) / (double)ScreenHeight;
            Interop.mouse_event((uint)mouseOption, (int)num, (int)num2, 0, 0);
        }

        //public static void Click(MouseButtons mouseButton, int x, int y, int holdClickTime = 10)
        //{
        //    Action mouseOption;
        //    Action mouseOption2;
        //    switch (mouseButton)
        //    {
        //        case MouseButtons.Left:
        //            mouseOption = Action.LeftButtonDown;
        //            mouseOption2 = Action.LeftButtonUp;
        //            break;
        //        case MouseButtons.Middle:
        //            mouseOption = Action.MiddleButtonDown;
        //            mouseOption2 = Action.MiddleButtonUp;
        //            break;
        //        case MouseButtons.Right:
        //            mouseOption = Action.RightButtonDown;
        //            mouseOption2 = Action.RightButtonUp;
        //            break;
        //        default:
        //            throw new NotSupportedException("The selected mouse button is not yet supported: " + mouseButton);
        //    }

        //    Act(mouseOption, x, y);
        //    Thread.Sleep(holdClickTime);
        //    Act(mouseOption2, x, y);
        //}

    }
}
