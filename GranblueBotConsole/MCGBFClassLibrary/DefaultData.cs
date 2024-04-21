using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGBFClassLibrary
{
    public static class DefaultData
    {
        public static void DisplayInstructions()
        {
            Console.WriteLine($"[ESC] - End Program");
            Console.WriteLine($"[1] - View Position");
            Console.WriteLine($"[2] - Record Position");
            Console.WriteLine($"[3] - Execute Positions");
            Console.WriteLine($"[0] - View List of Added Position/s\n");

        }
    }
}
