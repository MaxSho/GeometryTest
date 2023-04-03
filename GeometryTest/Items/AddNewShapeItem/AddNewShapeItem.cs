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

        public string title { get; }
        ISubItem[] menuItems;
        ConsoleKeyInfo cki;
        event EventHandler<ConsoleKeyInfo> handler1;
        event EventHandler<ConsoleKeyInfo> handler2;
        event EventHandler<ConsoleKeyInfo> handler3;
        event EventHandler<ConsoleKeyInfo> handler4;
        event EventHandler<ConsoleKeyInfo> handler5;
        List<EventHandler<ConsoleKeyInfo>> eventHandlers;

        public AddNewShapeItem(string title)
        {
            this.title = title;

            menuItems = new ISubItem[]
            {
                new TriangleSubItem("Triangle"),
                new RectangleSubItem("Rectangle"),
                new SquareSubItem("Square"),
                new CircleSubItem("Circle"),
                new CancelSubItem("Cancel")
            };
            handler1 += menuItems[0].Menu_handler;
            handler2 += menuItems[1].Menu_handler;
            handler3 += menuItems[2].Menu_handler;
            handler4 += menuItems[3].Menu_handler;
            handler5 += menuItems[4].Menu_handler;
            

            eventHandlers = new()
            {
                handler1,
                handler2,
                handler3,
                handler4,
                handler5
            };


        }

        public void Menu_handler(object? sender, ConsoleKeyInfo e)
        {
            
            while (true)
            {
                ShowIn();
                cki = Console.ReadKey(true);

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
                    break;
                }
            }
        }

        public void ShowIn()
        {
            Console.Clear();
            for (int i = 0; i < menuItems.Length; i++)
            {
                menuItems[i].ShowMe(i + 1);
            }
        }
        public void ShowMe(int num)
        {
            Console.WriteLine($"{num}. {title}");
        }

    }
}
