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
        public void ShowIn()
        {
            Console.Clear();
            Console.WriteLine("Transformation completed");
        }
        public void ShowMe(int num)
        {
            Console.WriteLine($"{num}. {Title}");
        }
        public void Menu_handler(object? sender, ConsoleKeyInfo e)
        {
            for (int i = 0; i < AppData.s_shapes.Count; i++)
            {
                if (AppData.s_shapes[i] is Circle)
                {
                    AppData.s_shapes[i] = (Square)AppData.s_shapes[i];
                }
                else if(AppData.s_shapes[i] is Square)
                {
                    AppData.s_shapes[i] = (Circle)AppData.s_shapes[i];
                }
                else if(AppData.s_shapes[i] is Rectangle)
                {
                    AppData.s_shapes[i] = (Triangle)AppData.s_shapes[i];
                }
                else if (AppData.s_shapes[i] is Triangle)
                {
                    AppData.s_shapes[i] = (Rectangle)AppData.s_shapes[i];
                }
            }
            ShowIn();
            Console.ReadKey(true);
        }
    }
}
