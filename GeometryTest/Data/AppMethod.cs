using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTest.Data
{
    internal static class AppMethod
    {
        public static string GetString(this ConsoleKey consoleKey)
        {
            if (consoleKey >= ConsoleKey.D0 && consoleKey <= ConsoleKey.D9)
                return consoleKey.ToString()[1..];
            else
                return consoleKey.ToString();
        }
    }
}
