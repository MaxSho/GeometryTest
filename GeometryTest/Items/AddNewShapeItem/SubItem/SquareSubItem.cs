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
        public string Title { get; }
        public SquareSubItem(string title)
        {
            this.Title = title;
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
                    AppData.s_shapes.Add(new GeometryTest.Shapes.Square(width));
                    Console.WriteLine("Square added");
                    Console.ReadKey();
                    break;
                }
            }
        }
        public void ShowMe(ConsoleKey consoleKey)
        {
            Console.WriteLine($"{consoleKey.GetString()}. {Title}");
        }
    }
}
