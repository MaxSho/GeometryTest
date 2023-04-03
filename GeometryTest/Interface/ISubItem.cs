using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTest.Interface
{
    internal interface ISubItem
    {
        public string title { get; }
        public void ShowMe(int num);
        public void Menu_handler(object? sender, ConsoleKeyInfo e);
    }
}
