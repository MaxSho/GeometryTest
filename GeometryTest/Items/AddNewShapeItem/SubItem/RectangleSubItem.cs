using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryTest.Data;
using GeometryTest.Interface;

namespace GeometryTest.Items.AddNewShapeItem.SubItem
{
    internal class RectangleSubItem: ISubItem
    {
        public string title { get; }
        public RectangleSubItem(string title)
        {
            this.title = title;
        }
        public void Menu_handler(object? sender, ConsoleKeyInfo e)
        {
            while (true)
            {
                bool isExit = false;
                Console.Clear();
                Console.WriteLine("\tAdding Rectangle");
                Console.Write("Enter width of Rectangle: ");
                var widthStr = Console.ReadLine();
                if (uint.TryParse(widthStr, out var width))
                {
                    if (width < 0)
                        continue;
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Adding Rectangle");
                        Console.WriteLine($"Enter width of Rectangle: {width}");
                        Console.Write($"Enter height of Rectangle: ");
                        var heightStr = Console.ReadLine();
                        if (uint.TryParse(heightStr, out var height))
                        {
                            if (height < 0)
                                continue;
                            AppData.shapes.Add(new GeometryTest.Shapes.Rectangle(width, height));
                            Console.WriteLine("Rectangle added");
                            isExit = true;
                            break;
                        }
                    }
                    
                }
                if (isExit)
                {
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
