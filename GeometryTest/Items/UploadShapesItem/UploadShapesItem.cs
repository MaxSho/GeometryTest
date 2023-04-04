using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryTest.Interface;

namespace GeometryTest.Items.UploadShapesItem
{
    internal class UploadShapesItem : IMenuItem
    {
        public string Title { get; }

        IMenuItem[] menuItems =
            {
                //new MenuItem("Triangle"),
                //new MenuItem("Rectangle"),
                //new MenuItem("Square"),
                //new MenuItem("Circle"),
                //new MenuItem("Cancel")
            };

        public UploadShapesItem(string title)
        {
            this.Title = title;

        }
        public void ShowIn()
        {
            Console.Clear();
            foreach (var item in menuItems)
            {
                Console.WriteLine(item.Title);
            }
        }
        public void ShowMe(int num)
        {
            Console.WriteLine($"{num}. {Title}");
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
