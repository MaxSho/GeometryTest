using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTest.Interface
{
    internal interface IMenuItem
    {
        public string title { get; }
        public void ShowIn();
        public void ShowMe(int num);
        public void Menu_handler(object? sender, ConsoleKeyInfo e);
    }
}
