using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryTest.Data;
using GeometryTest.Interface;
using GeometryTest.Shapes.Base;
using Newtonsoft.Json;

namespace GeometryTest.Items.UploadShapesItem
{
    internal class UploadShapesItem : IMenuItem
    {
        public string Title { get; }

        public UploadShapesItem(string title)
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

            Console.Write("Enter name of file to load (example: Myshapes): ");

            string? fileName = Console.ReadLine();

            Console.WriteLine("Enter path of directory to load (example: C:\\temp): ");

            string? fileDir = Console.ReadLine();



            if (fileDir != null && fileName != null && Directory.Exists(fileDir))
            {
                string filePath = Path.Combine(fileDir, fileName + ".json");
                try
                {
                    string json;
                    using (StreamReader file = new StreamReader(filePath))
                    {
                        json = file.ReadToEnd();
                    }


                        List<Shape> deserializedShapes = JsonConvert.DeserializeObject<List<Shape>>(json, new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.Auto
                        });

                    AppData.s_shapes.Clear();
                    AppData.s_shapes.AddRange(deserializedShapes);

                    //JsonSerializerSettings settings = new JsonSerializerSettings();
                    //settings.TypeNameHandling = TypeNameHandling.Auto;
                    //List<Shape> shapes;

                    //using (StreamReader file = new StreamReader(filePath))
                    //{
                    //    string jsonData = file.ReadToEnd();
                    //    shapes = JsonConvert.DeserializeObject<List<Shape>>(jsonData, settings);
                    //}

                    //AppData.s_shapes.Clear();
                    //AppData.s_shapes.AddRange(shapes);

                    Console.WriteLine("All shapes have  been uploaded");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could not upload shapes from file. Error saving JSON to " + filePath + ": " + ex.Message);
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
            Console.WriteLine($"{AppData.ConvertConsoleKeyToString(consoleKey)}. {Title}");
        }
    }
}
