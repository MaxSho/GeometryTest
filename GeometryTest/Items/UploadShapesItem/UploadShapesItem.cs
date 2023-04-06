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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA1822:Member does not access instance data and can be marked as static", Justification = "Method needs access to instance data.")]
        public void ShowIn()
        {
            Console.Clear();
            Console.WriteLine("\tUpload Shapes:");
        }
        public void Menu_handler(object? sender, ConsoleKeyInfo e)
        {
            ShowIn();

            Console.Write("Enter name of file to load (example: Myshapes): ");

            string? fileName = Console.ReadLine();

            Console.Write("Enter path of directory to load (example: C:\\temp): ");

            string? fileDir = Console.ReadLine();



            if (fileDir != null && fileName != null && Directory.Exists(fileDir))
            {
                string filePath = Path.Combine(fileDir, fileName + ".json");
                try
                {
                    string json;
                    using (StreamReader file = new(filePath))
                    {
                        json = file.ReadToEnd();
                    }


                        List<Shape>? deserializedShapes = JsonConvert.DeserializeObject<List<Shape>>(json, new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.Auto
                        });

                    AppData.s_shapes.Clear();
                    if(deserializedShapes != null)
                    {
                        AppData.s_shapes.AddRange(deserializedShapes.Take(AppData.s_numberingOrder.Count - 1).ToList());
                        if (deserializedShapes.Count > AppData.s_numberingOrder.Count - 1)
                        {
                            Console.WriteLine($"First {AppData.s_numberingOrder.Count - 1} shapes have  been uploaded");
                        }
                        else
                        {
                            Console.WriteLine("All shapes have  been uploaded");
                        }

                    }
                    else
                    {
                        throw new Exception("DeserializedShapes is null");

                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could not upload shapes from file. Error uploading JSON to " + filePath + ": " + ex.Message);
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
