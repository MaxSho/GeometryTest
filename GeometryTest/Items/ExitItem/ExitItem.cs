﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryTest.Interface;

namespace GeometryTest.Items.ExitItem
{
    internal class ExitItem : IMenuItem
    {
        public string title { get; }
        public ExitItem(string title)
        {
            this.title = title;
        }
        public void Menu_handler(object? sender, ConsoleKeyInfo e)
        {
            throw new NotImplementedException();
        }

        public void ShowIn()
        {
            throw new NotImplementedException();
        }

        public void ShowMe(int num)
        {
            throw new NotImplementedException();
        }
    }
}