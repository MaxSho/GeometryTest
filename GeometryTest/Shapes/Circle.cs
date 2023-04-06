using GeometryTest.Shapes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GeometryTest.Shapes
{
    
    internal class Circle: Shape
    {
        public double Radius { get; }
        public Circle(double radius)
        {
            
            if(radius < 0)
            {
                radius = 0;
            }

            this.Radius = radius;
        }
        public override string? ToString()
        {
            return $"Circle - Radius: {Radius} - Perimeter - {GetPerimeter()}";
        }

        public override double GetPerimeter()
        {
            return Radius * 2 * Math.PI;
        }
        public static explicit operator Square(Circle circle)
        {
            return new Square(circle.Radius * 2.0);
        }

    }
}
