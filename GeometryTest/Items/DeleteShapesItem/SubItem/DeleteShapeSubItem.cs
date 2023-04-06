using GeometryTest.Data;
using GeometryTest.Interface;
using GeometryTest.Shapes;
using GeometryTest.Shapes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTest.Items.DeleteShapesItem.SubItem
{
    internal class DeleteShapeSubItem<TypeShape> : ISubItem
    {
        private ConsoleKeyInfo cki;
        public string Title { get; }
        private Dictionary<ConsoleKey, Shape> _menuShapeItems = new();
        public DeleteShapeSubItem(string title)
        {
            this.Title = title;
        }

        public void Menu_handler(object? sender, ConsoleKeyInfo e)
        {
            while (true)
            {
                ShowIn();

                cki = Console.ReadKey(true);
                
                var indCKI = AppData.s_numberingOrder.IndexOf(cki.Key);

                if(indCKI !=-1 && indCKI < _menuShapeItems.Count)
                {
                    AppData.s_shapes.RemoveAt(indCKI);
                }
                else if(indCKI == _menuShapeItems.Count)
                {
                    break;
                }

                
            }
        }
        public void ShowIn()
        {
            Console.Clear();

            _menuShapeItems = new();
            int ind = 0;
            foreach (var item in AppData.s_shapes)
            {
                if (item is TypeShape)
                {
                    _menuShapeItems.Add(AppData.s_numberingOrder[ind], item);
                    Console.WriteLine($"{AppData.s_numberingOrder[ind]}. {item}");
                    ind++;
                }
                
            }
            Console.WriteLine($"{AppData.s_numberingOrder[ind]}. Cancel");
        }
        public void ShowMe(ConsoleKey consoleKey)
        {

            Console.WriteLine($"{consoleKey.GetString()}. {Title}");
        }
    }
}
