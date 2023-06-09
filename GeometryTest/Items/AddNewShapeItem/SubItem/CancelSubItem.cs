﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryTest.Data;
using GeometryTest.Interface;

namespace GeometryTest.Items.AddNewShapeItem.SubItem
{
    internal class CancelSubItem : ISubItem
    {
        public string Title { get; }
        public CancelSubItem(string title)
        {
            this.Title = title;
        }
        public void Menu_handler(object? sender, ConsoleKeyInfo e)
        {

        }
        public void ShowMe(ConsoleKey consoleKey)
        {
            Console.WriteLine($"{consoleKey.GetString()}. {Title}");
        }
    }
}
