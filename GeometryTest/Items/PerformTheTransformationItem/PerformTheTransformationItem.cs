using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryTest.Interface;

namespace GeometryTest.Items.PerformTheTransformationItem
{
    internal class PerformTheTransformationItem : IMenuItem
    {
        public string title { get; }

        IMenuItem[] menuItems =
            {
                //new MenuItem("Triangle"),
                //new MenuItem("Rectangle"),
                //new MenuItem("Square"),
                //new MenuItem("Circle"),
                //new MenuItem("Cancel")
            };

        public PerformTheTransformationItem(string title)
        {
            this.title = title;

        }
        public void ShowIn()
        {
            Console.Clear();
            foreach (var item in menuItems)
            {
                Console.WriteLine(item.title);
            }
        }
        public void ShowMe(int num)
        {
            Console.WriteLine($"{num}. {title}");
        }
        public void Menu_handler(object? sender, ConsoleKeyInfo e)
        {
            if (e.Key == ConsoleKey.D1 || e.Key == ConsoleKey.NumPad1)
            {
                //ShowIn();
            }
        }
    }
}
