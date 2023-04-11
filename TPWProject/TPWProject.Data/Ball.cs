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
        private Direction _verticalDirection;
        private Direction _horizontalDirection;

        public override double Top { get => _top; set { _top = value; OnPropertyChanged(); } }
        public override double Left { get => _left; set { _left = value; OnPropertyChanged(); } }
        public double Diameter { get; }
        public override double Mass { get; }
        public double Speed { get; }


        public Ball(double top, double left, double diameter, double mass)
        {
            Random random = new Random();
            Top = top;
            Left = left;
            Diameter = diameter;
            Mass = mass;
            Speed = random.NextDouble()+0.3;
            Debug.WriteLine(Speed);
            _verticalDirection = random.NextDouble() > 0.5 ? Direction.UP : Direction.DOWN;
            _horizontalDirection = random.NextDouble() > 0.5 ? Direction.LEFT : Direction.RIGHT;
        }

        public override void Move(double height, double width)
        {
            if (Top - Speed <= 0)
            {
                _verticalDirection = Direction.DOWN;
            }
            else if (Top + Speed + Diameter >= height)
            {
                _verticalDirection = Direction.UP;
            }

            if (Left - Speed <= 0)
            {
                _horizontalDirection = Direction.RIGHT;
            }
            else if (Left + Speed + Diameter >= width)
            {
                _horizontalDirection = Direction.LEFT;
            }

            if (_verticalDirection == Direction.DOWN)
            {
                Top += Speed;
            }
            else
            {
                Top -= Speed;
            }

            if (_horizontalDirection == Direction.RIGHT)
            {
                Left += Speed;
            }
            else
            {
                Left -= Speed;
            }
        }
    }
}
