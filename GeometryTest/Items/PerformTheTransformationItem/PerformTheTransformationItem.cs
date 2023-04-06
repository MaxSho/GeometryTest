using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryTest.Data;
using GeometryTest.Interface;
using GeometryTest.Shapes;

namespace GeometryTest.Items.PerformTheTransformationItem
{
    internal class PerformTheTransformationItem : IMenuItem
    {
        public string Title { get; }
        public PerformTheTransformationItem(string title)
        {
            this.Title = title;

        }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA1822:Member does not access instance data and can be marked as static", Justification = "Method needs access to instance data.")]
        public void ShowIn()
        {
            Console.Clear();
            Console.WriteLine("Transformation completed");
        }
        public void Menu_handler(object? sender, ConsoleKeyInfo e)
        {
            for (int i = 0; i < AppData.s_shapes.Count; i++)
            {
                if (AppData.s_shapes[i] is Circle circle)
                {
                    AppData.s_shapes[i] = (Square)circle;
                }
                else if(AppData.s_shapes[i] is Square square)
                {
                    AppData.s_shapes[i] = (Circle)square; 
                }
                else if(AppData.s_shapes[i] is Rectangle rectangle)
                {
                    AppData.s_shapes[i] = (Triangle)rectangle;
                }
                else if (AppData.s_shapes[i] is Triangle triangle)
                {
                    AppData.s_shapes[i] = (Rectangle)triangle;
                }
            }
            ShowIn();
            Console.ReadKey(true);
        }
        public void ShowMe(ConsoleKey consoleKey)
        {
            Console.WriteLine($"{consoleKey.GetString()}. {Title}");
        }
    }
}
