using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryTest.Interface;

namespace GeometryTest.Items.AddNewShapeItem.SubItem
{
    internal class CancelSubItem : ISubItem
    {
        public string title { get; }
        public CancelSubItem(string title)
        {
            this.title = title;
        }
        public void Menu_handler(object? sender, ConsoleKeyInfo e)
        {

        }

        public void ShowMe(int num)
        {
            Console.WriteLine($"{num}. {title}");
        }
    }
}
