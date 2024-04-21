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

        public static IDictionary<int[], int> MOCK_TEST_DATA()
        {
            IDictionary<int[], int> testDictionary = new Dictionary<int[], int>();
            const int DEFAULT_INT = 4500;

            testDictionary.Add(new int[] { 173, 137 }, DEFAULT_INT);
            testDictionary.Add(new int[] { 154, 502 }, DEFAULT_INT);
            testDictionary.Add(new int[] { 298, 608 }, DEFAULT_INT);
            testDictionary.Add(new int[] { 259, 511 }, DEFAULT_INT);
            testDictionary.Add(new int[] { 274, 540 }, DEFAULT_INT);
            testDictionary.Add(new int[] { 399, 421 }, DEFAULT_INT);

            return testDictionary;
        }
    }
}
