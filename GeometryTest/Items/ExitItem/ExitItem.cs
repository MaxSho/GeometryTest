﻿using GeometryTest.Data;
using GeometryTest.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTest.Items.ExitItem
{
    internal class ExitItem : IMenuItem
    {
        public string Title { get; }

        public ExitItem(string title)
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
