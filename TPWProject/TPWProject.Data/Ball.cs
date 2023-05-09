using System;
using TPWProject.Data.Abstract;

namespace TPWProject.Data
{
    public class Ball : IBall
    {
        public double Top { get; set; }
        public double Left { get; set; }
        public double Diameter { get; }
        public double Mass { get; }
        public double SpeedX { get; set; }
        public double SpeedY { get; set; }

        public event BallPositionChangedEventHandler BallPositionChanged;


        public Ball(double top, double left, double diameter, double mass)
        {
            Random random = new();
            Top = top;
            Left = left;
            Diameter = diameter;
            Mass = mass;
            SpeedX = random.NextDouble() + 0.5;
            SpeedY = random.NextDouble() + 0.5;
        }

        public void Move()
        {
            Top += SpeedY;
            Left += SpeedX;

            BallPositionChanged?.Invoke(this, new BallPositionChangedEventArgs(Top, Left));
        }
    }
}
