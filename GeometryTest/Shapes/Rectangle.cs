using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryTest.Shapes.Base;

namespace GeometryTest.Shapes
{
    internal class Rectangle: Shape
    {
        public double Width { get; }
        public double Height { get; }
        public Rectangle(double width, double height) 
        {
            

            if(width < 0)
            {
                width = 0;
            }
            if (height < 0)
            {
                height = 0;
            }

            this.Width = width;
            this.Height = height;
        }

        public override string? ToString()
        {
            return $"Rectangle - Width: {Width}, Height: {Height} - Perimeter - {GetPerimeter()}";
        }

        public override double GetPerimeter()
        {
            return 2 * (Width + Height);
        }
        public static explicit operator Triangle(Rectangle rectangle)
        {
            return new Triangle(rectangle.Width, rectangle.Height,
                Math.Sqrt(rectangle.Width * rectangle.Width +
                            rectangle.Height * rectangle.Height));
        }
    }
}
