using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TPWProject.Data.Abstract;

namespace TPWProject.Data
{
    public class Ball : Shape
    {
        private double _top;
        private double _left;

        public override double Top { get => _top; set { _top = value; OnPropertyChanged(); } }
        public override double Left { get => _left; set { _left = value; OnPropertyChanged(); } }
        public double Diameter { get; }
        public override double Mass { get; }
        public int Speed { get; }


        public Ball(double top, double left, double diameter, double mass)
        {
            Top = top;
            Left = left;
            Diameter = diameter;
            Mass = mass;
            Speed = 2;
        }

        public override void Move(double height, double width)
        {
            Random random = new Random();
            //TODO change to smooth movement
            Top += (random.NextDouble() - 0.5) * Speed;
            Left += (random.NextDouble() - 0.5) * Speed;
        }
    }
}
