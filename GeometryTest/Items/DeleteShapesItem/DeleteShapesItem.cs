using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryTest.Data;
using GeometryTest.Interface;
using GeometryTest.Items.DeleteShapesItem.SubItem;
using GeometryTest.Shapes;

namespace GeometryTest.Items.DeleteShapesItem
{
    internal class DeleteShapesItem : IMenuItem
    {
        public bool IsCancel = false;
        public string Title { get; }

        private ConsoleKeyInfo _cki;
        private readonly Dictionary<ConsoleKey, ISubItem> _menuSubItems = new();
        private readonly List<EventHandler<ConsoleKeyInfo>> _eventHandlers = new();

        public DeleteShapesItem(string title)
        {
            this.Title = title;

            List<ISubItem> subItems = new()
            {
                new DeleteShapeSubItem<Triangle>("Triangle"),
                new DeleteShapeSubItem<Rectangle>("Rectange"),
                new DeleteShapeSubItem<Square>("Square"),
                new DeleteShapeSubItem<Circle>("Circle"),
                new DeleteCancelSubItem("Cancel")

            };
            for (int i = 0; i < subItems.Count && i < AppData.s_numberingOrder.Count; i++)
            {
                _menuSubItems.Add(AppData.s_numberingOrder[i], subItems[i]);
                _eventHandlers.Add(subItems[i].Menu_handler);
            }
        }
        public void ShowIn()
        {
            Console.Clear();
            Console.WriteLine("\tDelete New Shape:");
            foreach (var item in _menuSubItems)
            {
                item.Value.ShowMe(item.Key);
            }
        }
        public void Menu_handler(object? sender, ConsoleKeyInfo e)
        {
            while (true)
            {
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
        public void ShowMe(ConsoleKey consoleKey)
        {
            Console.WriteLine($"{consoleKey.GetString()}. {Title}");
        }
    }
}
