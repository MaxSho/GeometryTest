using GeometryTest.Shapes;
using GeometryTest.Shapes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTest.Data
{
    internal static class AppData
    {
        public static List<Shape> s_shapes = new List<Shape>();
        public static List<ConsoleKey> s_numberingOrder = new List<ConsoleKey>()
        {
            ConsoleKey.D1,
            ConsoleKey.D2,
            ConsoleKey.D3,
            ConsoleKey.D4,
            ConsoleKey.D5,
            ConsoleKey.D6,
            ConsoleKey.D7,
            ConsoleKey.D8,
            ConsoleKey.D9,
            ConsoleKey.A,
            ConsoleKey.B,
            ConsoleKey.C,
            ConsoleKey.D,
            ConsoleKey.E,
            ConsoleKey.F,
            ConsoleKey.G,
            ConsoleKey.H,
            ConsoleKey.I,
            ConsoleKey.J,
            ConsoleKey.K,
            ConsoleKey.L,
            ConsoleKey.M,
            ConsoleKey.N,
            ConsoleKey.O,
            ConsoleKey.P,
            ConsoleKey.Q,
            ConsoleKey.R,
            ConsoleKey.S,
            ConsoleKey.T,
            ConsoleKey.U,
            ConsoleKey.V,
            ConsoleKey.W,
            ConsoleKey.X,
            ConsoleKey.Y,
            ConsoleKey.Z
        };
        public static string ConvertConsoleKeyToString(ConsoleKey consoleKey)
        {
            if (consoleKey >= ConsoleKey.D0 && consoleKey <= ConsoleKey.D9)
                return consoleKey.ToString().Substring(1);
            else
                return consoleKey.ToString();
        }
        
        public static List<Tuple<string, Shape>> GetDictionaryTypeShape()
        {
            var d = new List<Tuple<string, Shape>>();
            foreach (var item in s_shapes)
            {
                d.Add(new Tuple<string, Shape>(item.GetType().Name, item));
            }
            return d;
        }
        
    }
}
