using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryTest.Data;
using GeometryTest.Interface;

namespace GeometryTest.Items.AddNewShapeItem.SubItem
{
    internal class SquareSubItem: ISubItem
    {
        public string title { get; }
        public SquareSubItem(string title)
        {
            this.title = title;
        }
        public void Menu_handler(object? sender, ConsoleKeyInfo e)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\tAdding Square");
                Console.Write("Enter width of the Square: ");
                var widthStr = Console.ReadLine();
                if (uint.TryParse(widthStr, out var width))
                {
                    if (width < 0)
                        continue;
                    AppData.shapes.Add(new GeometryTest.Shapes.Square(width));
                    Console.WriteLine("Square added");
                    break;
                }
            }
        }
        public void ShowMe(int num)
        {
            Console.WriteLine($"{num}. {title}");
        }
    }
}
