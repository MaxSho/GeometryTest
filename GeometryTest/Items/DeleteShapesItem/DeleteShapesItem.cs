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

        private ConsoleKeyInfo cki;
        public bool IsCancel = false;
        public string Title { get; }

        private Dictionary<ConsoleKey, ISubItem> _menuSubItems = new();
        private List<EventHandler<ConsoleKeyInfo>> _eventHandlers = 
            new List<EventHandler<ConsoleKeyInfo>>();

        public DeleteShapesItem(string title)
        {
            this.Title = title;

            List<ISubItem> subItems = new List<ISubItem>()
            {
                new DeleteShapeSubItem<Triangle>("Triangle"),
                new DeleteShapeSubItem<Rectangle>("Rectange"),
                new DeleteShapeSubItem<Square>("Square"),
                new DeleteShapeSubItem<Circle>("Circle"),
            };
            for (int i = 0; i < subItems.Count; i++)
            {
                _menuSubItems.Add(AppData.s_numberingOrder[i], subItems[i]);
                _eventHandlers.Add(subItems[i].Menu_handler);
            }
        }
        public void ShowIn()
        {
            Console.Clear();
            foreach (var item in _menuSubItems)
            {
                item.Value.ShowMe(item.Key);
            }
            Console.WriteLine($"{AppData.ConvertConsoleKeyToString(AppData.s_numberingOrder[_menuSubItems.Count])}. Cancel");
        }
        public void ShowMe(int num)
        {
            Console.WriteLine($"{num}. {Title}");
        }
        public void Menu_handler(object? sender, ConsoleKeyInfo e)
        {
            while (true)
            {
                ShowIn();

                cki = Console.ReadKey(true);
                var indCKI = AppData.s_numberingOrder.IndexOf(cki.Key);

                if(indCKI != -1 && indCKI < _eventHandlers.Count)
                {
                    _eventHandlers[indCKI].Invoke(this, cki);
                }
                else if(indCKI == _eventHandlers.Count)
                {
                    break;
                }

            }
        }
    }
}
