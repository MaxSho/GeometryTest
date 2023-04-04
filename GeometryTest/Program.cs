using GeometryTest;
using GeometryTest.Data;
using GeometryTest.Shapes;
using GeometryTest.Shapes.Base;


//var t = new Triangle(3, 4, 5);
//Shape s = t;
//var n = (Circle)s;
////AppData.s_shapes.Add();
//var isff = s is Triangle;
//var isff2 = s is Rectangle;


ConsoleKeyInfo keyInfo = Console.ReadKey(true);
Console.WriteLine(keyInfo.KeyChar);

string keyName = keyInfo.Key.ToString();
Console.WriteLine(keyName);
Menu menu = new();
menu.Startup();


