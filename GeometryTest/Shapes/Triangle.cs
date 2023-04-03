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
        public uint a { get; }
        public uint b { get; }
        public uint c { get; }
        public Triangle(uint a, uint b, uint c)
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

            this.a = a;
            this.b = b;
            this.c = c;
        }
        public override string? ToString()
        {
            return $"Triangle - a: {a}, b: {b}, c: {c} - Perimeter: {GetPerimeter()}";
        }

        public override double GetPerimeter()
        {
            return a + b + c;
        }
    }
}
