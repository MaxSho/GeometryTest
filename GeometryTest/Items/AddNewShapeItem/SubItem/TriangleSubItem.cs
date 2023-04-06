using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryTest.Data;
using GeometryTest.Interface;

namespace GeometryTest.Items.AddNewShapeItem.SubItem
{
    internal class TriangleSubItem: ISubItem
    {
        public string Title { get; }
        public TriangleSubItem(string title)
        { 
            this.Title = title;
        }
        public void Menu_handler(object? sender, ConsoleKeyInfo e)
        {
            while (true)
            {
                bool isExit = false;
                Console.Clear();
                Console.WriteLine("\tAdding Triangle");
                Console.Write("Enter side a of the Triangle: ");
                var aStr = Console.ReadLine();
                if (uint.TryParse(aStr, out var a))
                {
                    if (a < 0)
                        continue;
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("\tAdding Triangle");
                        Console.WriteLine($"Enter side a of the Triangle: {a}");

                        Console.Write($"Enter side b of the Triangle: ");
                        var bStr = Console.ReadLine();
                        if (uint.TryParse(bStr, out var b))
                        {
                            if (b < 0)
                                continue;
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("\tAdding Triangle");
                                Console.WriteLine($"Enter side a of the Triangle: {a}");
                                Console.WriteLine($"Enter side b of the Triangle: {b}");


                                Console.Write($"Enter side c of the Triangle: ");
                                var cStr = Console.ReadLine();
                                if (uint.TryParse(cStr, out var c))
                                {
                                    if (c < 0 || !GeometryTest.Shapes.Triangle.IsExist(a, b, c))
                                        continue;

                                    AppData.s_shapes.Add(new GeometryTest.Shapes.Triangle(a, b, c));
                                    Console.WriteLine("Triangle added");
                                    Console.ReadKey();
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
                if (isExit)
                {
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
