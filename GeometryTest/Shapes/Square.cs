using GeometryTest.Shapes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTest.Shapes
{
    internal class Square: Shape
    {
        public double Width { get; }
        public Square(double width)
        {
            if(Width < 0)
            {
                width = 0;
            }
            
            this.Width = width;
        }

        public override string? ToString()
        {
            return $"Square - Width: {Width} - Perimeter - {GetPerimeter()}";
        }

        public override double GetPerimeter()
        {
            return 4 * Width;
        }
        public static explicit operator Circle (Square square)
        {
            return new Circle(square.Width / 2.0);
        }
    }
}
