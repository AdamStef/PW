using System;
using System.Diagnostics;
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
            Random random = new Random();
            Top = top;
            Left = left;
            Diameter = diameter;
            Mass = mass;
            SpeedX = random.NextDouble() + 0.5;
            SpeedY = random.NextDouble() + 0.5;
        }

        public void Move(double height, double width)
        {
            double prevTop = Top;
            double prevLeft = Left;

            Top += SpeedY;
            Left += SpeedX;

            BallPositionChanged?.Invoke(this, new BallPositionChangedEventArgs(Top, Left, prevTop, prevLeft));
        }
    }
}
