using GeometryTest.Shapes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTest.Shapes
{
    internal class Circle: Shape
    {
        public double radius { get; }
        public Circle(double radius)
        {
            
            if(radius < 0)
            {
                radius = 0;
            }

            this.radius = radius;
        }
        public override string? ToString()
        {
            return $"Circle - radius: {radius} - Perimeter - {GetPerimeter()}";
        }

        public override double GetPerimeter()
        {
            return radius * 2 * Math.PI;
        }
    }
}
