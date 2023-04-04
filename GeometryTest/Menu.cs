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
        public event EventHandler<ConsoleKeyInfo> Handler1;
        public event EventHandler<ConsoleKeyInfo> Handler2;
        public event EventHandler<ConsoleKeyInfo> Handler3;
        public event EventHandler<ConsoleKeyInfo> Handler4;
        public event EventHandler<ConsoleKeyInfo> Handler5;
        public event EventHandler<ConsoleKeyInfo> Handler6;
        public event EventHandler<ConsoleKeyInfo> Handler7;
        private List<EventHandler<ConsoleKeyInfo>> _eventHandlers;
        private readonly IMenuItem[] _menuItems;
        public Menu() 
        {
            _menuItems = new IMenuItem[]
            {
                new AddNewShapeItem("Add a new shape"),
                new ViewAllShapesItem("View all shapes"),
                new DeleteShapesItem("Delete shapes"),
                new PerformTheTransformationItem("Perform the transformation"),
                new SaveShapesItem("Save shapes"),
                new UploadShapesItem("Upload shapes"),
                new ExitItem("Exit")
            };

            Handler1 += _menuItems[0].Menu_handler;
            Handler2 += _menuItems[1].Menu_handler;
            Handler3 += _menuItems[2].Menu_handler;
            Handler4 += _menuItems[3].Menu_handler;
            Handler5 += _menuItems[4].Menu_handler;
            Handler6 += _menuItems[5].Menu_handler;
            Handler7 += _menuItems[6].Menu_handler;

            _eventHandlers = new()
            {
                Handler1,
                Handler2,
                Handler3,
                Handler4,
                Handler5,
                Handler6,
                Handler7
            };

        }
        public void Startup()
        {
            while (true)
            {
                
                Show();
                Console.Write("Press any key, or 'X' to quit, or ");

                // Start a console read operation. Do not display the input.
                _cki = Console.ReadKey(true);
                // Announce the name of the key that was pressed .
                Console.WriteLine($"  Key pressed: {_cki.Key}\n");

                if (_cki.Key == ConsoleKey.D1 || _cki.Key == ConsoleKey.NumPad1)
                {
                    _eventHandlers[0].Invoke(this, _cki);
                }
                else if (_cki.Key == ConsoleKey.D2 || _cki.Key == ConsoleKey.NumPad2)
                {
                    _eventHandlers[1].Invoke(this, _cki);
                }
                else if (_cki.Key == ConsoleKey.D3 || _cki.Key == ConsoleKey.NumPad3)
                {
                    _eventHandlers[2].Invoke(this, _cki);
                }
                else if (_cki.Key == ConsoleKey.D4 || _cki.Key == ConsoleKey.NumPad4)
                {
                    _eventHandlers[3].Invoke(this, _cki);
                }
                else if (_cki.Key == ConsoleKey.D5 || _cki.Key == ConsoleKey.NumPad5)
                {
                    _eventHandlers[4].Invoke(this, _cki);
                }
                else if (_cki.Key == ConsoleKey.D6 || _cki.Key == ConsoleKey.NumPad6)
                {
                    _eventHandlers[5].Invoke(this, _cki);
                }
                else if (_cki.Key == ConsoleKey.D7 || _cki.Key == ConsoleKey.NumPad7)
                {
                    _eventHandlers[6].Invoke(this, _cki);
                    break;
                }
                var t = AppData.s_shapes;
            }
        }
        public void Show()
        {
            Console.Clear();
            for (int i = 0; i < _menuItems.Length; i++)
            {
                _menuItems[i].ShowMe(i + 1);
            }
        }
    }
   
}
