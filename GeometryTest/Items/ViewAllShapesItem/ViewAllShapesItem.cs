using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryTest.Data;
using GeometryTest.Interface;
using GeometryTest.Items.ViewAllShapesItem.SubItem;

namespace GeometryTest.Items.ViewAllShapesItem
{
    internal class ViewAllShapesItem : IMenuItem
    {
        public string Title { get; }
        private Dictionary<ConsoleKey, ISubItem> _menuSubItems = new();

        public ViewAllShapesItem(string title)
        {
            this.Title = title;
            InsertMenuItems();
        }
        public void ShowIn()
        {
            InsertMenuItems();

            Console.Clear();
            if (_menuSubItems.Count > 0)
            {
                Console.WriteLine("\tShapes:");
                foreach (var item in _menuSubItems)
                {
                    item.Value.ShowMe(item.Key);
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
            Console.WriteLine($"{num}. {Title}");
        }
        public void Menu_handler(object? sender, ConsoleKeyInfo e)
        {
            ShowIn();

        }
        public void InsertMenuItems()
        {
            _menuSubItems = new Dictionary<ConsoleKey, ISubItem>();

            for (int i = 0; i < AppData.s_shapes.Count; i++)
            {
                _menuSubItems.Add(AppData.s_numberingOrder[i],
                        new ViewShapeSubItem(
                            AppData.s_shapes[i]?.ToString() ?? "not specified",
                            AppData.s_numberingOrder[i]
                            )
                    );
            }
        }
    }
}
