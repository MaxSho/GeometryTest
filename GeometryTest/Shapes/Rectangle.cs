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
        public double width { get; }
        public double height { get; }
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

            this.width = width;
            this.height = height;
        }

        public override string? ToString()
        {
            return $"Rectangle - width: {width}, height: {height} - Perimeter - {GetPerimeter()}";
        }

        public override double GetPerimeter()
        {
            return 2 * (width + height);
        }
    }
}
