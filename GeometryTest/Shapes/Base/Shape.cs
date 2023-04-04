using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTest.Shapes.Base
{
    internal class Shape
    {
        public override string? ToString()
        {
            return base.ToString();
        }
        public virtual double GetPerimeter()
        {
            return 0;
        }
        public virtual void AddToGlobal()
        {
            
        }
        
    }
}
