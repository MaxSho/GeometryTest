using GeometryTest.Data;
using GeometryTest.Interface;
using GeometryTest.Items;
using GeometryTest.Items.AddNewShapeItem;
using GeometryTest.Items.DeleteShapesItem;
using GeometryTest.Items.ExitItem;
using GeometryTest.Items.PerformTheTransformationItem;
using GeometryTest.Items.SaveShapesItem;
using GeometryTest.Items.UploadShapesItem;
using GeometryTest.Items.ViewAllShapesItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTest
{
    internal class Menu
    {
        private ConsoleKeyInfo _cki;

        private Dictionary<ConsoleKey, IMenuItem> _menuItems = new();
        private List<EventHandler<ConsoleKeyInfo>> _eventHandlers =
            new List<EventHandler<ConsoleKeyInfo>>();
        public Menu() 
        {
            var _listmenuItems = new IMenuItem[]
            {
                new AddNewShapeItem("Add a new shape"),
                new ViewAllShapesItem("View all shapes"),
                new DeleteShapesItem("Delete shapes"),
                new PerformTheTransformationItem("Perform the transformation"),
                new SaveShapesItem("Save shapes"),
                new UploadShapesItem("Upload shapes"),
                new ExitItem("Exit")
            };

            for (int i = 0; i < _listmenuItems.Length; i++)
            {
                _menuItems.Add(AppData.s_numberingOrder[i], _listmenuItems[i]);
                _eventHandlers.Add(_listmenuItems[i].Menu_handler);
            }

        }
        public void Startup()
        {
            while (true)
            {
                
                Show();
                _cki = Console.ReadKey(true);

                var indCKI = AppData.s_numberingOrder.IndexOf(_cki.Key);

                Console.WriteLine($"  Key pressed: {_cki.Key}\n");

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
        public void Show()
        {
            Console.Clear();

            foreach (var item in _menuItems)
            {
                item.Value.ShowMe(item.Key);
            }

        }
    }
   
}
