﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;


namespace GranblueBotConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Point mouseObject = Cursor.Position;

            while (!Console.KeyAvailable)
            {

                var data = Console.ReadKey(true).Key;
                Console.WriteLine(data);
                mouseObject = Cursor.Position;
                
                Console.WriteLine($"({mouseObject.X},{mouseObject.Y})");

                if (data == ConsoleKey.Escape)
                {
                    break;
                }
            }

            }

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
    }
}