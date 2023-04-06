using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryTest.Data;
using GeometryTest.Interface;
using Newtonsoft.Json;
using GeometryTest.Shapes.Base;

namespace GeometryTest.Items.SaveShapesItem
{
    internal class SaveShapesItem : IMenuItem
    {
        public string Title { get; }

        public SaveShapesItem(string title)
        {
            this.Title = title;
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA1822:Member does not access instance data and can be marked as static", Justification = "Method needs access to instance data.")]
        public void ShowIn()
        {
            Console.Clear();
            Console.WriteLine("\tSave Shapes:");
        }
        public void Menu_handler(object? sender, ConsoleKeyInfo e)
        {
            ShowIn();

            Console.Write("Enter name of file to save (example: Myshapes): ");

            string? fileName = Console.ReadLine();

            Console.Write("Enter path of directory to save (example: C:\\temp): ");

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
                    string json = JsonConvert.SerializeObject(AppData.s_shapes, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto
                    });

                    using(System.IO.StreamWriter file = new(filePath))
                    {
                        file.WriteLine(json);
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
                Console.WriteLine("The path is specified with errors.");
            }


            Console.ReadKey();
        }
        public void ShowMe(ConsoleKey consoleKey)
        {
            Console.WriteLine($"{consoleKey.GetString()}. {Title}");
        }
    }
}
