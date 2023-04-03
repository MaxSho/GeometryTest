using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryTest.Data;
using GeometryTest.Interface;

namespace GeometryTest.Items.ViewAllShapesItem
{
    internal class ViewAllShapesItem : IMenuItem
    {
        public string title { get; }

        public ViewAllShapesItem(string title)
        {
            this.title = title;

        }
        public void ShowIn()
        {
            Console.Clear();
            if(AppData.shapes.Count > 0 )
            {
                Console.WriteLine("\tShapes:");
                foreach (var item in AppData.shapes)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("\tThe list of Shapes is empty:");
            }
            
            Console.ReadKey();
        }
        public void ShowMe(int num)
        {
            Console.WriteLine($"{num}. {title}");
        }
        public void Menu_handler(object? sender, ConsoleKeyInfo e)
        {
            ShowIn();

            //if (e.Key == ConsoleKey.D1 || e.Key == ConsoleKey.NumPad1)
            //{
            //    // ShowIn();
            //}
        }
    }
}
