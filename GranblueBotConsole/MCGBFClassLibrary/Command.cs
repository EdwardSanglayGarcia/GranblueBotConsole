using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Windows.Forms;

namespace MCGBFClassLibrary
{
    public static class Command
    {
        private static IDictionary<int[], int> dataCoordinates = new Dictionary<int[], int>();
        private const int DEFAULT_WAITING_TIME = 4000;
        public static void Operate()
        {

            Point mouseObject;
            while (!Console.KeyAvailable)
            {
                var data = Console.ReadKey(true).Key;
                mouseObject = Cursor.Position;

                if (data == ConsoleKey.D1)
                {
                    Console.WriteLine($"Viewed Position: ({mouseObject.X},{mouseObject.Y})");
                }

                if (data == ConsoleKey.D2)
                {
                    dataCoordinates.Add(new int[] { mouseObject.X, mouseObject.Y }, DEFAULT_WAITING_TIME);
                    Console.WriteLine($"Added Position: ({mouseObject.X},{mouseObject.Y})");
                }

                if (data == ConsoleKey.D3)
                {
                    foreach (var executionData in dataCoordinates)
                    {
                        MouseCommand.PerformAction(MouseCommand.Action.LeftButtonDown, executionData.Key[0], executionData.Key[1], 4000);
                    }
                    
                    // dataCoordinates.ToList().ForEach(x => MouseCommand.PerformAction(MouseCommand.Action.LeftButtonDown, x.Key[0], x.Key[1], 1000));
                    continue;
                    
                }

                if (data == ConsoleKey.D4)
                {
                    Thread.Sleep(3000);
                    while (true)
                    {
                        DefaultData.DoTest();
                    }
                    
                    //dataCoordinates.Clear();

                    //while (true)
                    //{
                    //    DefaultData.MOCK_TEST_DATA().ToList().ForEach(x => MouseCommand.PerformAction(MouseCommand.Action.LeftButtonDown, x.Key[0], x.Key[1], x.Value));
                    //}
                }

                if (data == ConsoleKey.D0)
                {
                    Console.WriteLine($"List of Positions");
                    dataCoordinates.ToList().ForEach(x => Console.WriteLine($"{x.Key[0]},{x.Key[1]}"));
                    
                }

                if (data == ConsoleKey.Escape)
                {
                    break;
                }

            }
        }


        #region InDevelopment
        static void RunningProgram()
        {

            Console.WriteLine($"Do you use the PC[1] or custom[2]?");
            int summonNumber, runCounter;
            int[] botXCoordinates = new int[] { 231, 254, 323, 254, 398 };
            int[] botYCoordinates = new int[] { 099, 283, 507, 355, 356 };

            Console.WriteLine($"Input Summon Number:");
            summonNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Input Number Reset");
            runCounter = Convert.ToInt32(Console.ReadLine());

            PerformBot(summonNumber, runCounter, botXCoordinates, botYCoordinates);
        }

        static void RecoverPots(int numberOfPots)
        {

            Thread.Sleep(2000);

            //Raid
            //SimMouse.Click(MouseButtons.Left, 101, 98);
            Thread.Sleep(1500);

            //Potion
            //SimMouse.Click(MouseButtons.Left, 236, 153);
            Thread.Sleep(1500);

            //Quantity
            //SimMouse.Click(MouseButtons.Left, 295, 547);
            Thread.Sleep(1500);

            int potCoordinateSelection = 548 + (numberOfPots * 20);

            //Selection
            //SimMouse.Click(MouseButtons.Left, 320, potCoordinateSelection);
            Thread.Sleep(1500);

            //Use
            //SimMouse.Click(MouseButtons.Left, 329, 577);
            Thread.Sleep(1500);

            //OK
            //SimMouse.Click(MouseButtons.Left, 261, 588);
            Thread.Sleep(1500);
        }

        static void PerformBot(int summonCount, int botResetCount, int[] botXCoordinates, int[] botYCoordinates)
        {
            int numberOfRuns = 1;
            while (true)
            {
                Point mouseObject = Cursor.Position;
                Thread.Sleep(3000);

                //Raid
                //SimMouse.Click(MouseButtons.Left, botXCoordinates[0], botYCoordinates[0]);
                Thread.Sleep(2000);

                //Select
                //SimMouse.Click(MouseButtons.Left, botXCoordinates[1], (summonCount * 70) + botYCoordinates[1]);
                Thread.Sleep(2000);

                //OK
                //SimMouse.Click(MouseButtons.Left, botXCoordinates[2], botYCoordinates[2]);
                Thread.Sleep(2700);

                //Auto
                //SimMouse.Click(MouseButtons.Left, botXCoordinates[3], botYCoordinates[3]);
                //SimMouse.Click(MouseButtons.Left, botXCoordinates[3], botYCoordinates[3]);
                //SimMouse.Click(MouseButtons.Left, botXCoordinates[3], botYCoordinates[3]);

                Thread.Sleep(6500);

                SendKeys.SendWait("{F5}");
                Thread.Sleep(2000);

                //Dulo
                //SimMouse.Click(MouseButtons.Left, botXCoordinates[4], botYCoordinates[4]);
                //SimMouse.Click(MouseButtons.Left, botXCoordinates[4], botYCoordinates[4]);

                if (numberOfRuns == botResetCount)
                {
                    Random random = new Random();
                    Thread.Sleep(1000 * (random.Next(1, 5))); //to prevent bot tracking
                    numberOfRuns = 1;
                    //Thread.Sleep(2000);
                    //RecoverPots(Math.Abs(botResetCount / 2) -1);
                }

                numberOfRuns++;
            }

        }

        static void GetLivePositions()
        {
            Point mouseObject = Cursor.Position;
            int positionX = mouseObject.X;
            int positionY = mouseObject.Y;


            while (true)
            {
                mouseObject = Cursor.Position;
                if (positionX != mouseObject.X && positionY != mouseObject.Y)
                {
                    positionX = mouseObject.X;
                    positionY = mouseObject.Y;
                    Console.WriteLine($"{mouseObject.X},{mouseObject.Y}");
                }
            }

        }
        #endregion

    }
}
