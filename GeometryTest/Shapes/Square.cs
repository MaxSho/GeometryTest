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
        public uint width { get; }
        public Square(uint width)
        {
            if(width < 0)
            {
                width = 0;
            }
            
            this.width = width;
        }

        public override string? ToString()
        {
            return $"Square - width: {width} - Perimeter - {GetPerimeter()}";
        }

        public override double GetPerimeter()
        {
            return 4 * width;
        }
    }
}
