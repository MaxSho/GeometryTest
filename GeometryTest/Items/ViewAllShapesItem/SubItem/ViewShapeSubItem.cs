using GeometryTest.Data;
using GeometryTest.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTest.Items.ViewAllShapesItem.SubItem
{
    internal class ViewShapeSubItem : ISubItem
    {
        public string Title { get; }
        public ConsoleKey @ConsoleKey { get; }
        public string StrConsoleKey
        {
            get 
            {
                if (@ConsoleKey >= ConsoleKey.D0 && @ConsoleKey <= ConsoleKey.D9)
                    return @ConsoleKey.ToString().Substring(1);
                return @ConsoleKey.ToString();
            }
        }

        public ViewShapeSubItem(string title, ConsoleKey consoleKey)
        {
            this.Title = title;
            this.@ConsoleKey = consoleKey;
        }
        public void Menu_handler(object? sender, ConsoleKeyInfo e)
        {
            throw new NotImplementedException();
        }

        public void ShowMe()
        {
            Console.WriteLine($"{StrConsoleKey}. {Title}");
        }

        public void ShowMe(int num)
        {
            throw new NotImplementedException();
        }

        public void ShowMe(ConsoleKey consoleKey)
        {
            Console.WriteLine($"{AppData.ConvertConsoleKeyToString(consoleKey)}. {Title}");
        }
    }
}
