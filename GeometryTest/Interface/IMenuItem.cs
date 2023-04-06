using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTest.Interface
{
    internal interface IMenuItem
    {
        public string Title { get; }
        public void ShowMe(ConsoleKey consoleKey);
        public void Menu_handler(object? sender, ConsoleKeyInfo e);
    }
}
