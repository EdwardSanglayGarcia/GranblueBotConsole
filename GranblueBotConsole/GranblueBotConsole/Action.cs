using System;

namespace GranblueBotConsole
{
    public static partial class Clicker
    {
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
    }
}
