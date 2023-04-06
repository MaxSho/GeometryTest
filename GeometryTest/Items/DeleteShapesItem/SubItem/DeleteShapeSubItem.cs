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
        public string Title { get; }
        private ConsoleKeyInfo _cki;
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

                _cki = Console.ReadKey(true);
                

                var keyValDel = _menuShapeItems.ToList().Find(x => x.Key == _cki.Key);

                if(keyValDel.Value != null)
                {
                    AppData.s_shapes.Remove(keyValDel.Value);
                }

                if(_cki.Key == AppData.s_numberingOrder[_menuShapeItems.Count])
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
                    Console.WriteLine($"{AppData.s_numberingOrder[ind].GetString()}. {item}");
                    ind++;
                }
                
            }
            Console.WriteLine($"{AppData.s_numberingOrder[ind].GetString()}. Cancel");
        }
        public void ShowMe(ConsoleKey consoleKey)
        {

            Console.WriteLine($"{consoleKey.GetString()}. {Title}");
        }
    }
}
