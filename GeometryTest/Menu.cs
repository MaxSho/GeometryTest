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
        ConsoleKeyInfo cki;
        public event EventHandler<ConsoleKeyInfo> handler1;
        public event EventHandler<ConsoleKeyInfo> handler2;
        public event EventHandler<ConsoleKeyInfo> handler3;
        public event EventHandler<ConsoleKeyInfo> handler4;
        public event EventHandler<ConsoleKeyInfo> handler5;
        public event EventHandler<ConsoleKeyInfo> handler6;
        public event EventHandler<ConsoleKeyInfo> handler7;
        List<EventHandler<ConsoleKeyInfo>> eventHandlers;
        readonly IMenuItem[] menuItems;
        public Menu() 
        {
            menuItems = new IMenuItem[]
            {
                new AddNewShapeItem("Add a new shape"),
                new ViewAllShapesItem("View all shapes"),
                new DeleteShapesItem("Delete shapes"),
                new PerformTheTransformationItem("Perform the transformation"),
                new SaveShapesItem("Save shapes"),
                new UploadShapesItem("Upload shapes"),
                new ExitItem("Exit")
            };

            handler1 += menuItems[0].Menu_handler;
            handler2 += menuItems[1].Menu_handler;
            handler3 += menuItems[2].Menu_handler;
            handler4 += menuItems[3].Menu_handler;
            handler5 += menuItems[4].Menu_handler;
            handler6 += menuItems[5].Menu_handler;
            handler7 += menuItems[6].Menu_handler;

            eventHandlers = new()
            {
                handler1,
                handler2,
                handler3,
                handler4,
                handler5,
                handler6,
                handler7
            };

        }
        public void Startup()
        {
            while (true)
            {
                Show();
                Console.Write("Press any key, or 'X' to quit, or ");

                // Start a console read operation. Do not display the input.
                cki = Console.ReadKey(true);
                // Announce the name of the key that was pressed .
                Console.WriteLine($"  Key pressed: {cki.Key}\n");

                if (cki.Key == ConsoleKey.D1 || cki.Key == ConsoleKey.NumPad1)
                {
                    eventHandlers[0].Invoke(this, cki);
                }
                else if (cki.Key == ConsoleKey.D2 || cki.Key == ConsoleKey.NumPad2)
                {
                    eventHandlers[1].Invoke(this, cki);
                }
                else if (cki.Key == ConsoleKey.D3 || cki.Key == ConsoleKey.NumPad3)
                {
                    eventHandlers[2].Invoke(this, cki);
                }
                else if (cki.Key == ConsoleKey.D4 || cki.Key == ConsoleKey.NumPad4)
                {
                    eventHandlers[3].Invoke(this, cki);
                }
                else if (cki.Key == ConsoleKey.D5 || cki.Key == ConsoleKey.NumPad5)
                {
                    eventHandlers[4].Invoke(this, cki);
                }
                else if (cki.Key == ConsoleKey.D6 || cki.Key == ConsoleKey.NumPad6)
                {
                    eventHandlers[5].Invoke(this, cki);
                }
                else if (cki.Key == ConsoleKey.D7 || cki.Key == ConsoleKey.NumPad7)
                {
                    eventHandlers[6].Invoke(this, cki);
                    break;
                }
                var t = AppData.shapes;
            }
        }
        public void Show()
        {
            Console.Clear();
            for (int i = 0; i < menuItems.Length; i++)
            {
                menuItems[i].ShowMe(i + 1);
            }
        }
    }
   
}
