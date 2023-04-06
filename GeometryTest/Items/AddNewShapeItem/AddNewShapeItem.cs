using GeometryTest.Data;
using GeometryTest.Interface;
using GeometryTest.Items.AddNewShapeItem.SubItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTest.Items.AddNewShapeItem
{
    internal class AddNewShapeItem : IMenuItem
    {
        public string Title { get; }

        private ConsoleKeyInfo _cki;
        private readonly Dictionary<ConsoleKey, ISubItem> _menuSubItems = new();
        private readonly List<EventHandler<ConsoleKeyInfo>> _eventHandlers = new();
        public AddNewShapeItem(string title)
        {
            this.Title = title;

            var _listmenuSubItems = new ISubItem[]
            {
                new TriangleSubItem("Triangle"),
                new RectangleSubItem("Rectangle"),
                new SquareSubItem("Square"),
                new CircleSubItem("Circle"),
                new CancelSubItem("Cancel")
            };
            for (int i = 0; i < _listmenuSubItems.Length && i < AppData.s_numberingOrder.Count; i++)
            {
                _menuSubItems.Add(AppData.s_numberingOrder[i], _listmenuSubItems[i]);
                _eventHandlers.Add(_listmenuSubItems[i].Menu_handler);
            }
        }

        public void Menu_handler(object? sender, ConsoleKeyInfo e)
        {
            
            while (true)
            {
                if (AppData.s_shapes.Count >= AppData.s_numberingOrder.Count - 1)
                {
                    Console.Clear();
                    Console.WriteLine($"The list of figures is completely filled, the maximum number of elements: {AppData.s_numberingOrder.Count - 1}");
                    Console.ReadKey(true);
                    break;
                }

                ShowIn();
                _cki = Console.ReadKey(true);

                var indCKI = _menuSubItems.ToList().FindIndex(x => x.Key == _cki.Key);

                if (indCKI != -1 && indCKI < _eventHandlers.Count)
                {
                    _eventHandlers[indCKI].Invoke(this, _cki);
                }

                if (indCKI == _eventHandlers.Count - 1)
                {
                    break;
                }
            }
        }

        public void ShowIn()
        {
            Console.Clear();
            Console.WriteLine("\tAdd New Shape:");
            foreach (var item in _menuSubItems)
            {
                item.Value.ShowMe(item.Key);
            }
        }
        public void ShowMe(ConsoleKey consoleKey)
        {
            Console.WriteLine($"{consoleKey.GetString()}. {Title}");
        }
    }
}
