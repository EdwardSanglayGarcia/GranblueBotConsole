using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

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

        private static IDictionary<int[], int> MOCK_TEST_DATA()
        {
            IDictionary<int[], int> testDictionary = new Dictionary<int[], int>();
            testDictionary.Add(new int[] { 185, 139 }, 3000);
            testDictionary.Add(new int[] { 185, 591 }, 4000);
            testDictionary.Add(new int[] { 288, 603 }, 7000);
            testDictionary.Add(new int[] { 336, 587 }, 7000);
            testDictionary.Add(new int[] { 307, 418 }, 3000);
            return testDictionary;
        }

        public static void DoTest()
        {
            DefaultData.MOCK_TEST_DATA().ToList().ForEach(x => MouseCommand.PerformAction(MouseCommand.Action.LeftButtonDown, x.Key[0], x.Key[1], x.Value));
            SendKeys.SendWait("{F5}");
            Thread.Sleep(5000);
        }
    }
}
 