using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryTest.Data;
using GeometryTest.Interface;
using Newtonsoft.Json;

namespace GeometryTest.Items.SaveShapesItem
{
    internal class SaveShapesItem : IMenuItem
    {
        public string Title { get; }

        public SaveShapesItem(string title)
        {
            this.Title = title;

        }
        public void ShowIn()
        {
            Console.Clear();
        }
        public void ShowMe(int num)
        {
            Console.WriteLine($"{num}. {Title}");
        }
        public void Menu_handler(object? sender, ConsoleKeyInfo e)
        {
            ShowIn();

            Console.Write("Enter name of file to save (example: Myshapes): ");

            string? fileName = Console.ReadLine();

            Console.WriteLine("Enter path of directory to save (example: C:\\temp): ");

            string? fileDir = Console.ReadLine();

            

            if (fileDir != null && fileName != null)
            {
                string filePath = Path.Combine(fileDir, fileName + ".json");
                if (!Directory.Exists(fileDir))
                {
                    Directory.CreateDirectory(fileDir);
                }
                try
                {
                    
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(file, AppData.GetDictionaryTypeShape()/*AppData.s_shapes*/);
                    }

                    Console.WriteLine("Saving completed successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could not save shapes to file. Error saving JSON to " + filePath + ": " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Could not save shapes to file.");
            }


            Console.ReadKey();
        }
    }
}
