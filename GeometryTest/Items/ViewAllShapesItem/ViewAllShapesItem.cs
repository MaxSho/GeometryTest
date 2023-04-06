using System.Text;
using GeometryTest.Data;
using GeometryTest.Interface;
using GeometryTest.Shapes.Base;

namespace GeometryTest.Items.ViewAllShapesItem
{
    internal class ViewAllShapesItem : IMenuItem
    {
        public string Title { get; }
        private Dictionary<ConsoleKey, Shape> _menuSubItems = new();
        public ViewAllShapesItem(string title)
        {
            this.Title = title;
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
                    Console.WriteLine($"{item.Key.GetString()}. {item.Value}");
                }
            }
            else
            {
                Console.WriteLine("\tThe list of Shapes is empty:");
            }
            
            Console.ReadKey();
        }
        public void Menu_handler(object? sender, ConsoleKeyInfo e)
        {
            ShowIn();
        }
        public void InsertMenuItems()
        {
            _menuSubItems = new Dictionary<ConsoleKey, Shape>();

            for (int i = 0; i < AppData.s_shapes.Count; i++)
            {
                _menuSubItems.Add(AppData.s_numberingOrder[i],
                        AppData.s_shapes[i]
                    );
            }
        }
        public void ShowMe(ConsoleKey consoleKey)
        {
            Console.WriteLine($"{consoleKey.GetString()}. {Title}");
        }

    }
}
