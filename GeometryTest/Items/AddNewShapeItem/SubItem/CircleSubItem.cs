using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryTest.Data;
using GeometryTest.Interface;

namespace GeometryTest.Items.AddNewShapeItem.SubItem
{
    internal class CircleSubItem: ISubItem
    {
        public string title { get; }
        public CircleSubItem(string title)
        {
            this.title = title;
        }
        public void Menu_handler(object? sender, ConsoleKeyInfo e)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\tAdding Circle");
                Console.Write("Enter radius of the Circle: ");
                var radiusStr = Console.ReadLine();
                if (double.TryParse(radiusStr, out var radius))
                {
                    if (radius < 0)
                        continue;

                    AppData.shapes.Add(new GeometryTest.Shapes.Circle(radius));
                    Console.WriteLine("Circle added");
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
