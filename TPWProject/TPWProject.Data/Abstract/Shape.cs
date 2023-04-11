using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TPWProject.Data.Abstract
{
    public abstract class Shape
    {
        public abstract double Top { get; set; }
        public abstract double Left { get; set; }
        public abstract double Mass { get; }

        public abstract void Move(double height, double width);
    }
}
