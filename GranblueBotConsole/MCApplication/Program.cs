using System.Drawing;
using System;
using System.Configuration;
using System.Windows.Forms;
Console.WriteLine();
IDictionary<int[], int> dataCoordinates = new Dictionary<int[], int>();

dataCoordinates.Add(new int[] { 1, 1 }, 1);

dataCoordinates.ToList().ForEach(x => Console.WriteLine(x.Key[0].ToString()));

Point mouseObject = Cursor.Position;
//while (!Console.KeyAvailable)
//{
//    var data = Console.ReadKey(true).Key;
//    Console.WriteLine(data);
//    mouseObject = Cursor.Position;

//    Console.WriteLine($"({mouseObject.X},{mouseObject.Y})");

//    if (data == ConsoleKey.Escape)
//    {
//        break;
//    }
//}
