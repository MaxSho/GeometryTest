using GeometryTest.Shapes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTest.Shapes
{
    internal class Triangle: Shape
    {
        public double A { get; }
        public double B { get; }
        public double C { get; }
        public Triangle(double a, double b, double c)
        {
            if(a < 0)
            {
                a = 0;
            }
            if (b < 0)
            {
                b = 0;
            }
            if (c < 0)
            {
                c = 0;
            }

            this.A = a;
            this.B = b;
            this.C = c;
        }
        public override string? ToString()
        {
            return $"Triangle - a: {A}, b: {B}, c: {C} - Perimeter: {GetPerimeter()}";
        }

        public override double GetPerimeter()
        {
            return A + B + C;
        }
        public static bool IsExist(double a, double b, double c)
        {
            return a < b + c && b < c + a && c < a + b;
        }
        public static explicit operator Rectangle(Triangle triangle)
        {
            return new Rectangle(triangle.A, triangle.B);
        }
    }
}
