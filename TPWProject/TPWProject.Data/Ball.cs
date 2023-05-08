using System;
using System.Diagnostics;
using TPWProject.Data.Abstract;

namespace TPWProject.Data
{
    public class Ball : IBall
    {
        private Direction _verticalDirection;
        private Direction _horizontalDirection;

        public double Top { get; set; }
        public double Left { get; set; }
        public double Diameter { get; }
        public double Mass { get; }
        public double Speed { get; }

        public event BallPositionChangedEventHandler BallPositionChanged;


        public Ball(double top, double left, double diameter, double mass)
        {
            Random random = new Random();
            Top = top;
            Left = left;
            Diameter = diameter;
            Mass = mass;
            Speed = random.NextDouble() + 0.5;
            _verticalDirection = random.NextDouble() > 0.5 ? Direction.UP : Direction.DOWN;
            _horizontalDirection = random.NextDouble() > 0.5 ? Direction.LEFT : Direction.RIGHT;
        }

        public void Move(double height, double width)
        {
            double prevTop = Top;
            double prevLeft = Left;

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

            BallPositionChanged?.Invoke(this, new BallPositionChangedEventArgs(Top, Left, prevTop, prevLeft));
        }
    }
}
